using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWheelsSql.Pages.Alugar;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Models;

public class SelecaoDeProdutos : PageModel
{
    private readonly MyWheelsSql.Data.MyWhelssDbContext _context;
    
    [BindProperty(SupportsGet = true)]
    public string Cpf { get; set; }
    
    
    public List<SelectListItem> Bicicletas { get; set; } = new();
    [BindProperty]
    public List<int> BicicletasSelecionadas { get; set; } = new(); 

    
    public SelecaoDeProdutos(MyWheelsSql.Data.MyWhelssDbContext context)
    {
        _context = context;
    }
    
    
    public async Task OnGetAsync()
    {
        var bicicleta = await _context.Produtos.OfType<Bicicleta>().Where(b => b.Disponivel).Select(b => new SelectListItem{Value = b.ProdutoId.ToString(), 
            Text = $"Nome - {b.Nome}  /  Tipo - {b.Tipo}  /  Tamanho - {b.Tamanho}  /  Preço - {b.Preco}"}).ToListAsync();
        Bicicletas = bicicleta;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        return RedirectToPage("Create",new {Cpf = Cpf,bicicletas = string.Join(",", BicicletasSelecionadas)});

    }
}
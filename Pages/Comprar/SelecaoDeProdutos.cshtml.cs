using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Comprar;

public class SelecaoDeProdutos : PageModel
{
    private readonly MyWheelsSql.Data.MyWhelssDbContext _context;
    
    [BindProperty(SupportsGet = true)]
    public string Cpf { get; set; }
    

    public List<SelectListItem> Pecas { get; set; } = new();
    public List<SelectListItem> Bicicletas { get; set; } = new();
    
    [BindProperty]
    public List<int> PecasSelecionadas { get; set; } = new(); 
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
        var peca = await _context.Produtos.OfType<Peca>().Where(p => p.Disponivel).Select(p => new SelectListItem{Value = p.ProdutoId.ToString(),
            Text = $"Nome - {p.Nome}  /  Categoria - {p.Categoria}  /  Marca - {p.Marca}  /  Preço - {p.Preco}"}).ToListAsync();
        Bicicletas = bicicleta;
        Pecas = peca;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        return RedirectToPage("Create",new {Cpf = Cpf, pecas = string.Join(",", PecasSelecionadas), bicicletas = string.Join(",", BicicletasSelecionadas)});

    }
}
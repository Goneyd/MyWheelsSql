using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWheelsSql.Pages.Comprar;

public class VereficarCadastro : PageModel
{
    private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

    public VereficarCadastro(MyWheelsSql.Data.MyWhelssDbContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public string Cpf { get; set; }
    
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Cpf) || Cpf.Length != 11)
        {
            ModelState.AddModelError(nameof(Cpf), "CPF inválido. Por favor, informe um CPF com 11 caracteres.");
            return Page();
        }

        try
        {
            var ClienteEncontrado = _context.Clientes.FirstOrDefault(x => x.Cpf == Cpf);
            if (ClienteEncontrado != null)
            {
                return RedirectToPage("SelecaoDeProdutos", new { Cpf = Cpf });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nenhum cliente encontrado com o CPF informado.");
                return Page();
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, "Erro ao acessar os dados. Tente novamente mais tarde.");
            return Page();

        }
       
       
    }
}
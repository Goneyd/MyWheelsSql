using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public CreateModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

     
            var clienteExistente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Cpf == Cliente.Cpf);

            if (clienteExistente != null)
            {
      
                ModelState.AddModelError("Cliente.Cpf", "O CPF informado já está cadastrado no sistema.");

                return Page();
            }

      
            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

          
            return RedirectToPage("./Index");
        }
    }
}
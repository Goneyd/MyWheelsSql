using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Comprar
{
    public class CreateModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;
        
        [BindProperty(SupportsGet = true)]
        public string Cpf { get; set; }
        public Cliente Cliente { get; set; } = default!;
        [BindProperty]
        public Compra Compra { get; set; } = default!;

        public CreateModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Cpf))
            {
                var ClienteEncontrado = await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == Cpf);
                Cliente = ClienteEncontrado;
            }

            return Page();
        }
        
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Compras.Add(Compra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

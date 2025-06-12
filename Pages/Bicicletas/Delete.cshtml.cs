using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Bicicletas
{
    public class DeleteModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public DeleteModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bicicleta Bicicleta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Produtos
                .OfType<Bicicleta>()  // Filtro para carregar só Bicicletas
                .Include(b => b.Compra)
                .Include(b => b.Aluguel)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            
            if (bicicleta == null)
            {
                return NotFound();
            }

            Bicicleta = bicicleta;
            return Page();
            
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Produtos
                .OfType<Bicicleta>()
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (bicicleta != null)
            {
                Bicicleta = bicicleta;
                _context.Produtos.Remove(Bicicleta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

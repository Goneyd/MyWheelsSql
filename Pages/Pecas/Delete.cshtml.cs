using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Pecas
{
    public class DeleteModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public DeleteModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Peca Peca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Produtos.OfType<Peca>()
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            if (peca is not null)
            {
                Peca = peca;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Produtos.
                OfType<Peca>().
                FirstOrDefaultAsync();
            if (peca != null)
            {
                Peca = peca;
                _context.Produtos.Remove(Peca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

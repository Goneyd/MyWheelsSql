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
    public class DetailsModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public DetailsModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public Peca Peca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Produtos.OfType<Peca>().
                FirstOrDefaultAsync(m => m.ProdutoId == id);

            if (peca is not null)
            {
                Peca = peca;

                return Page();
            }

            return NotFound();
        }
    }
}

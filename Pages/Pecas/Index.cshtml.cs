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
    public class IndexModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public IndexModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public IList<Peca> Peca { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Peca = await _context.Produtos.OfType<Peca>()
                .Include(p => p.Aluguel)
                .Include(p => p.Compra)
                .ToListAsync();
        }
    }
}

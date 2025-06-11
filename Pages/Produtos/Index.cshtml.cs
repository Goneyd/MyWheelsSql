using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public IndexModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produto
                .Include(p => p.Aluguel)
                .Include(p => p.Compra).ToListAsync();
        }
    }
}

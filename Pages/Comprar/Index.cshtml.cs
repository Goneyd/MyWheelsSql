using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Comprar
{
    public class IndexModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;
        
        public IndexModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public IList<Compra> Compra { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Compra = await (from c in _context.Compras join Cl in _context.Clientes on c.ClienteId equals Cl.ClienteId 
                select new Compra { CompraId = c.CompraId, ClienteId = c.ClienteId,Data = c.Data,ValorTotal = c.ValorTotal, Cliente = new Cliente{Nome = Cl.Nome,Cpf = Cl.Cpf,Email = Cl.Email},}).ToListAsync();

        }
    }
}

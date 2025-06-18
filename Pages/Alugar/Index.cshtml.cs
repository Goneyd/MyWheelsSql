using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Alugar
{
    public class IndexModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;
        
        public IndexModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public IList<Aluguel> Aluguel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Aluguel = await (from a in _context.Aluguels join Cl in _context.Clientes on a.ClienteId equals Cl.ClienteId 
                select new Aluguel { AluguelId = a.AluguelId, ClienteId = a.ClienteId,DataInicio = a.DataInicio,DataFim = a.DataFim,ValorTotal = a.ValorTotal, Cliente = new Cliente{Nome = Cl.Nome,Cpf = Cl.Cpf,Email = Cl.Email},}).ToListAsync();

        }
    }
}

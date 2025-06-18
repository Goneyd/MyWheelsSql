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
  
     public class DeleteModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public DeleteModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aluguel Aluguel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aluguel = await (from a in _context.Aluguels
                join cl in _context.Clientes on a.ClienteId equals cl.ClienteId
                join p in _context.Produtos on a.AluguelId equals p.AluguelId into produtos
                where a.AluguelId == id
                select new Aluguel
                {
                    AluguelId = a.AluguelId,
                    ClienteId = a.ClienteId,
                    DataInicio = a.DataInicio,
                    DataFim = a.DataFim,
                    ValorTotal = a.ValorTotal,
                    Cliente = new Cliente
                    {
                        Nome = cl.Nome,
                        Cpf = cl.Cpf,
                        Email = cl.Email
                    },
                    Items = produtos.ToList() 
                }).FirstOrDefaultAsync();

            if (aluguel is not null)
            {
                Aluguel = aluguel;

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

          
            var aluguel = await _context.Aluguels.Include(c => c.Items).FirstOrDefaultAsync(c => c.AluguelId == id);
            if (aluguel != null)
            {
       
                foreach (var produto in aluguel.Items)
                {
                    produto.AluguelId = null;
                    produto.Disponivel = true; 
                }


                _context.Aluguels.Remove(aluguel);

       
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

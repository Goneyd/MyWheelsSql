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
    public class DeleteModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public DeleteModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compra Compra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var compra = await (from c in _context.Compras
                join cl in _context.Clientes on c.ClienteId equals cl.ClienteId
                join p in _context.Produtos on c.CompraId equals p.CompraId into produtos
                where c.CompraId == id
                select new Compra
                {
                    CompraId = c.CompraId,
                    ClienteId = c.ClienteId,
                    Data = c.Data,
                    ValorTotal = c.ValorTotal,
                    Cliente = new Cliente
                    {
                        Nome = cl.Nome,
                        Cpf = cl.Cpf,
                        Email = cl.Email
                    },
                    Produtos = produtos.ToList() 
                }).FirstOrDefaultAsync();

            if (compra is not null)
            {
                Compra = compra;

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

          
            var compra = await _context.Compras.Include(c => c.Produtos).FirstOrDefaultAsync(c => c.CompraId == id);
            if (compra != null)
            {
       
                foreach (var produto in compra.Produtos)
                {
                    produto.CompraId = null;
                    produto.Disponivel = true; 
                }


                _context.Compras.Remove(compra);

       
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
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
        public string bicicletas { get; set; } 
        [BindProperty(SupportsGet = true)]
        public string pecas { get; set; }


        public IList<Bicicleta> Bicicletas { get; set; } = default!;
        public IList<Peca> Pecas { get; set; } = default!;
        
        public decimal ValorTotal { get; set; }
        
        
        
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
                
                List<int> bicicletaList = new List<int>(bicicletas.Split(',').Select(x => int.Parse(x)));
                var BicicletasEncontradas =  await _context.Produtos.OfType<Bicicleta>().Where(b => bicicletaList.Contains(b.ProdutoId)).ToListAsync();
                Bicicletas = BicicletasEncontradas;
                
                List<int> PecaList = new List<int>(pecas.Split(',').Select(x => int.Parse(x)));
                var PecasEncontradas =  await _context.Produtos.OfType<Peca>().Where(p => PecaList.Contains(p.ProdutoId)).ToListAsync();
                Pecas = PecasEncontradas;
                
                ValorTotal = Bicicletas.Sum(b => b.Preco) + Pecas.Sum(p => p.Preco);
                
                
            }
            Compra = new Compra
            {
                Data = DateTime.Now.Date,
                ClienteId = Cliente.ClienteId,
                ValorTotal = ValorTotal,
            };


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
            
            if (!string.IsNullOrEmpty(bicicletas))
            {
                List<int> bicicletaIds = bicicletas.Split(',').Select(int.Parse).ToList();
                var bicicletasParaAtualizar = await _context.Produtos.OfType<Bicicleta>()
                    .Where(b => bicicletaIds.Contains(b.ProdutoId))
                    .ToListAsync();

                foreach (var bicicleta in bicicletasParaAtualizar)
                {
                    bicicleta.CompraId = Compra.CompraId; 
                    bicicleta.Disponivel = false;
                }
            }
            
            if (!string.IsNullOrEmpty(pecas))
            {
                List<int> pecaIds = pecas.Split(',').Select(int.Parse).ToList();
                var pecasParaAtualizar = await _context.Produtos.OfType<Peca>()
                    .Where(p => pecaIds.Contains(p.ProdutoId))
                    .ToListAsync();

                foreach (var peca in pecasParaAtualizar)
                {
                    peca.CompraId = Compra.CompraId; 
                    peca.Disponivel = false; 
                }
            }


            await _context.SaveChangesAsync();
            return RedirectToPage("/Pages/Index");
        }
    }
}

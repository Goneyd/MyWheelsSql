
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Models;
namespace MyWheelsSql.Pages.Alugar
{

    
    public class CreateModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;
        
        [BindProperty(SupportsGet = true)]
        public string bicicletas { get; set; } 
        public IList<Bicicleta> Bicicletas { get; set; } = default!;

        public decimal ValorTotal { get; set; }
        
        
        
        [BindProperty(SupportsGet = true)]
        public string Cpf { get; set; }
        public Cliente Cliente { get; set; } = default!;
        
        
        [BindProperty]
        public Aluguel Aluguel { get; set; } = default!;

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
                
                ValorTotal = Bicicletas.Sum(b => b.Preco);
                
                
            }
            Aluguel = new Aluguel
            {
                DataInicio = DateTime.Now.Date,
                DataFim = DateTime.Now.Date,
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

            _context.Aluguels.Add(Aluguel);
            await _context.SaveChangesAsync();
            
            if (!string.IsNullOrEmpty(bicicletas))
            {
                List<int> bicicletaIds = bicicletas.Split(',').Select(int.Parse).ToList();
                var bicicletasParaAtualizar = await _context.Produtos.OfType<Bicicleta>()
                    .Where(b => bicicletaIds.Contains(b.ProdutoId))
                    .ToListAsync();

                foreach (var bicicleta in bicicletasParaAtualizar)
                {
                    bicicleta.AluguelId = Aluguel.AluguelId; 
                    bicicleta.Disponivel = false;
                }
            }
            
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}



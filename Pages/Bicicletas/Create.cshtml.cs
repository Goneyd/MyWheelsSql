using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Bicicletas
{
    public class CreateModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public CreateModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AluguelId"] = new SelectList(_context.Aluguels, "AluguelId", "AluguelId");
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId");
            return Page();
        }

        [BindProperty]
        public Bicicleta Bicicleta { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    var key = entry.Key;
                    var errors = entry.Value.Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Erro em {key}: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _context.Produtos.Add(Bicicleta); 
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
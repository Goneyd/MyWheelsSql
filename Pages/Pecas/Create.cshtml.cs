using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWheelsSql.Data;
using MyWheelsSql.Models;

namespace MyWheelsSql.Pages.Pecas
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
        public Peca Peca { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produtos.Add(Peca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

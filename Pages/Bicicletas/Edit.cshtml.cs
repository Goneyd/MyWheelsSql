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

namespace MyWheelsSql.Pages.Bicicletas
{
    public class EditModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public EditModel(MyWheelsSql.Data.MyWhelssDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bicicleta Bicicleta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Produtos
                .OfType<Bicicleta>()
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            if (bicicleta == null)
            {
                return NotFound();
            } 
            Bicicleta = bicicleta;
           ViewData["AluguelId"] = new SelectList(_context.Aluguels, "AluguelId", "AluguelId");
           ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
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

            _context.Attach(Bicicleta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Bicicleta.ProdutoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos
                .OfType<Bicicleta>()
                .Any(e => e.ProdutoId == id);
        }
    }
}

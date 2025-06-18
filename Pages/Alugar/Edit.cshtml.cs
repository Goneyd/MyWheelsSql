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

namespace MyWheelsSql.Pages.Alugar
{
    public class EditModel : PageModel
    {
        private readonly MyWheelsSql.Data.MyWhelssDbContext _context;

        public EditModel(MyWheelsSql.Data.MyWhelssDbContext context)
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

            var aluguel =  await _context.Aluguels.FirstOrDefaultAsync(m => m.AluguelId == id);
            if (aluguel == null)
            {
                return NotFound();
            }
            Aluguel = aluguel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aluguel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(Aluguel.AluguelId))
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

        private bool AluguelExists(int id)
        {
            return _context.Aluguels.Any(e => e.AluguelId == id);
        }
    }
}

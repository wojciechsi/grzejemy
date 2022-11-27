using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using grzejemy.Data;
using grzejemy.Models;

namespace grzejemy.Pages.FuelTypes
{
    public class EditModel : PageModel
    {
        private readonly grzejemy.Data.ApplicationDbContext _context;

        public EditModel(grzejemy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FuelType FuelType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FuelTypes == null)
            {
                return NotFound();
            }

            var fueltype =  await _context.FuelTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (fueltype == null)
            {
                return NotFound();
            }
            FuelType = fueltype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FuelType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelTypeExists(FuelType.Id))
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

        private bool FuelTypeExists(int id)
        {
          return (_context.FuelTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

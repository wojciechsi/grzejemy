using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using grzejemy.Data;
using grzejemy.Models;

namespace grzejemy.Pages.FuelTypes
{
    public class DeleteModel : PageModel
    {
        private readonly grzejemy.Data.ApplicationDbContext _context;

        public DeleteModel(grzejemy.Data.ApplicationDbContext context)
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

            var fueltype = await _context.FuelTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (fueltype == null)
            {
                return NotFound();
            }
            else 
            {
                FuelType = fueltype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FuelTypes == null)
            {
                return NotFound();
            }
            var fueltype = await _context.FuelTypes.FindAsync(id);

            if (fueltype != null)
            {
                FuelType = fueltype;
                _context.FuelTypes.Remove(FuelType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

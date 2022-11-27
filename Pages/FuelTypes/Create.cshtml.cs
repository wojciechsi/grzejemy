using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using grzejemy.Data;
using grzejemy.Models;

namespace grzejemy.Pages.FuelTypes
{
    public class CreateModel : PageModel
    {
        private readonly grzejemy.Data.ApplicationDbContext _context;

        public CreateModel(grzejemy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FuelType FuelType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FuelTypes == null || FuelType == null)
            {
                return Page();
            }

            _context.FuelTypes.Add(FuelType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly grzejemy.Data.ApplicationDbContext _context;

        public IndexModel(grzejemy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FuelType> FuelType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FuelTypes != null)
            {
                FuelType = await _context.FuelTypes.ToListAsync();
            }
        }
    }
}

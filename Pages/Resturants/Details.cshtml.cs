using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RegionofTexasASP.Models;

namespace Final_Project.Pages.Resurants
{
    public class DetailsModel : PageModel
    {
        private readonly RegionofTexasASP.Models.RegionofTexasDbContext _context;

        public DetailsModel(RegionofTexasASP.Models.RegionofTexasDbContext context)
        {
            _context = context;
        }

        public Resturant Resturant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturant.FirstOrDefaultAsync(m => m.ResturantID == id);

            if (Resturant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

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
    public class DeleteModel : PageModel
    {
        private readonly RegionofTexasASP.Models.RegionofTexasDbContext _context;

        public DeleteModel(RegionofTexasASP.Models.RegionofTexasDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resturant Resturant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturants.FirstOrDefaultAsync(m => m.ResturantID == id);

            if (Resturant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturants.FindAsync(id);

            if (Resturant != null)
            {
                _context.Resturants.Remove(Resturant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

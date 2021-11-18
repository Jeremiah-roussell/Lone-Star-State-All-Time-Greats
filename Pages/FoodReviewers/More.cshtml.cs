using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RegionofTexasASP.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project.Pages.FoodReviewers
{
    public class MoreModel : PageModel
    {
        private readonly RegionofTexasASP.Models.RegionofTexasDbContext _context;

        public MoreModel(RegionofTexasASP.Models.RegionofTexasDbContext context, ILogger<MoreModel>logger)
        {
           
            _context = context;
        }
        [BindProperty]
        public int Resturanttodelete{get; set;}
        public FoodReviewer FoodReviewer { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodReviewer = await _context.FoodReviewer.Include(m => m.ReviewResturants).ThenInclude(m=>m.resturant).FirstOrDefaultAsync(m => m.FoodReviewerID == id);

            if (FoodReviewer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostDeleteReview(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }        
    }
}
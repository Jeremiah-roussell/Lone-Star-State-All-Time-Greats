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

namespace Final_Project.Pages.Resurants
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly RegionofTexasASP.Models.RegionofTexasDbContext _context;
         

        public DetailsModel(RegionofTexasASP.Models.RegionofTexasDbContext context, ILogger<DetailsModel>logger)
        {
           
            _context = context;
            _logger=logger;
        }

        public Resturant Resturant { get; set; }
        [BindProperty]
        public int DeleteReview{get; set;}
        [BindProperty]
        [Display(Name ="Reviewer")]
        public List<FoodReviewer> AllReviewers{get; set;}
        public SelectList ReviewDropdown{get; set;}
        [BindProperty]
        public int  AddReviewer{get; set;}
         public async Task<IActionResult> OnPostDeletedReviewAsync(int? id)
        {
            _logger.LogWarning($"OnPost: ReviewId {id}, Delete Review {DeleteReview}");
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturant.Include(s => s.ReviewResturants).ThenInclude(sc => sc.FoodReviewer).FirstOrDefaultAsync(m => m.ResturantID == id);
            AllReviewers=await _context.FoodReviewer.ToListAsync();
            ReviewDropdown= new SelectList(AllReviewers, "FoodReviewerID","Description");
            
            if (Resturant == null)
            {
                return NotFound();
            }

            ReviewResturant DropReviewer = _context.ReviewResturant.Find(DeleteReview, id.Value);

            if (DropReviewer != null)
            {
                _context.Remove(DropReviewer);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Food Reviwer did not give review");
            }

            return RedirectToPage(new {id = id});
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturant.Include(m=>m.ReviewResturants).ThenInclude(mc=>mc.FoodReviewer).FirstOrDefaultAsync(m => m.ResturantID == id);
            AllReviewers = await _context.FoodReviewer.ToListAsync();
            ReviewDropdown = new SelectList(AllReviewers, "FoodReviewerID", "Name");

            if (Resturant == null)
            {
                return NotFound();
            }
            return Page();
        }


     public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: ResturantId {id}, ADD Food Reviewer {AddReviewer}");
            if (AddReviewer == 0)
            {
                ModelState.AddModelError("AddReviewer", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            Resturant = await _context.Resturant.Include(s => s.ReviewResturants).ThenInclude(sc => sc.FoodReviewer).FirstOrDefaultAsync(m => m.ResturantID == id);            
            AllReviewers = await _context.FoodReviewer.ToListAsync();
            ReviewDropdown = new SelectList(AllReviewers, "FoodReviewerID", "Name");

            if (Resturant == null)
            {
                return NotFound();
            }

            if (!_context.ReviewResturant.Any(sc => sc.FoodReviewerID == AddReviewer && sc.ResturantID == id.Value))
            {
                ReviewResturant courseToAdd = new ReviewResturant { ResturantID = id.Value, FoodReviewerID = AddReviewer};
                _context.Add(courseToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Student already enrolled in the course");
            }

            // Best practice is that OnPost should redirect. This clears the form data.
            // FIXME: Can we just populate the routeValues from what is already there?
            return RedirectToPage(new {id = id});
        }
    }
}

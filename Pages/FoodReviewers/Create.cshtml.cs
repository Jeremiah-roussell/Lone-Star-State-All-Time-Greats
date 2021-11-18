using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegionofTexasASP.Models;
namespace Final_Project.Pages.FoodReviewers
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
         private readonly RegionofTexasDbContext _context;
         [BindProperty]
        public FoodReviewer FoodReviewer{get; set;}


        public CreateModel(RegionofTexasDbContext context,ILogger<CreateModel> logger)
        {
            _context=context;
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            _context.FoodReviewer.Add(FoodReviewer);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
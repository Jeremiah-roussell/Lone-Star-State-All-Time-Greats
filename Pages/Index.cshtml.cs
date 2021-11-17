using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RegionofTexasASP.Models;

namespace Final_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RegionofTexasDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<FoodReviewer> FoodReviewers{get; set; }

        public IndexModel(RegionofTexasDbContext context, ILogger<IndexModel> logger)
        {
            _context=context;
            _logger = logger;
        }

        public void OnGet()
        {
          FoodReviewers= _context.FoodReviewer.ToList();
            

        }
    }
}

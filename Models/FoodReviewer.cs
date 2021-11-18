using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RegionofTexasASP.Models
{
    public class FoodReviewer
    {
        public int FoodReviewerID {get; set;}	// Primary Key

        [BindProperty]
        public string Name {get; set;}
        public List<ReviewResturant> ReviewResturants {get; set;}
    }
    public class ReviewResturant{
        public int FoodReviewerID{get; set;}
        public int ResturantID{get; set;}
        public FoodReviewer FoodReviewer{get; set;}
        public Resturant resturant{get; set;}
    }
}

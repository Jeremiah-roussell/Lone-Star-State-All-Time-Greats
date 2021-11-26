using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace RegionofTexasASP.Models
{
    public class Resturant{
        public int ResturantID{get; set;}
         [BindProperty]
        [Required]
        public string Name{get; set;}
        [StringLength(20, MinimumLength=3)]
         [BindProperty]
        [Required]

        public string Genre{get; set;}
         [BindProperty]
        [Required]
        [Range(1,10)]
        public double Rating{get; set;}

       public List <ReviewResturant> ReviewResturants{get; set;}

    }
}
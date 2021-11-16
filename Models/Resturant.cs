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
        public string Name{get; set;}
        public string Genre{get; set;}
        public double Rating{get; set;}

       public List <ReviewResturant> ReviewResturants{get; set;}

    }
}
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
    public class IndexModel : PageModel
    {
        private readonly RegionofTexasASP.Models.RegionofTexasDbContext _context;

        public IndexModel(RegionofTexasASP.Models.RegionofTexasDbContext context)
        {
            _context = context;
        }

        public IList<Resturant> Resturant { get;set; }
        [BindProperty(SupportsGet =true)]
        public int pagenum {get; set;}=1;
        public int pagesize{get;set;}=5;
        [BindProperty(SupportsGet =true)]
        public string sort{get; set;}
        [BindProperty(SupportsGet =true)]
        public string searchString{get; set;}

        public async Task  OnGetAsync() 
        {
            var query=_context.Resturant.Select(p=>p);
            switch(sort){
                case "Name_a":
                query=query.OrderBy(p=>p.Name);
                break;
                case "Name_d":
                query=query.OrderByDescending(p=>p.Name);
                break;

                case "Genre_a":
                query=query.OrderBy(p=>p.Genre);
                break;
                case "Genre_d":
                query=query.OrderByDescending(p=>p.Genre);
                break;

                case "Rating_a":
                query=query.OrderBy(p=>p.Rating);
                break;
                case "Rating_d":
                query=query.OrderByDescending(p=>p.Rating);
                break;
                
            }
            if(searchString!=null){
                Resturant = await query.Include(a=>a.ReviewResturants).ThenInclude(sc=>sc.FoodReviewer).Skip((pagenum-1)*pagesize).Take(pagesize).Where(p=>p.Name.Contains(searchString)).ToListAsync();

            }
            else{
                Resturant = await query.Include(a=>a.ReviewResturants).ThenInclude(sc=>sc.FoodReviewer).Skip((pagenum-1)*pagesize).Take(pagesize).ToListAsync();
                
            }
            
            
        }
       
        
    }
}

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

        public async Task OnGetAsync()
        {
            Resturant = await _context.Resturants.ToListAsync();
        }
    }
}

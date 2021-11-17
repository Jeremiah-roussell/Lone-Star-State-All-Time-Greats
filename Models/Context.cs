using Microsoft.EntityFrameworkCore;
namespace RegionofTexasASP.Models
{
	public class RegionofTexasDbContext : DbContext
	{
		public RegionofTexasDbContext (DbContextOptions<RegionofTexasDbContext> options)
			: base(options)
		{
		}
		 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewResturant>().HasKey(s => new {s.ResturantID, s.FoodReviewerID});
        }
		public DbSet<FoodReviewer> FoodReviewer {get; set;}
        public DbSet<Resturant> Resturant {get; set;}
		public DbSet <ReviewResturant> ReviewResturant{get; set;}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
namespace RegionofTexasASP.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RegionofTexasDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<RegionofTexasDbContext>>()))
            {
        
                if (context.Resturant.Any())
                {
                    return; // DB has been seeded
                }
                List <Resturant> Resturants= new List<Resturant>{
                    new Resturant{Name="Blacks BBQ", Genre="BBQ", Rating=6.5},
                    new Resturant{Name="Willy Burger", Genre="American", Rating=7.5},
                    new Resturant{Name="The Pickett House", Genre="Southern", Rating=10},
                    new Resturant{Name="Gourdough", Genre="Deserts/Snacks", Rating=5},
                    new Resturant{Name="Fred's Texas Cafe", Genre="American", Rating=8},

                    new Resturant{Name="Biscuits+Groovy", Genre="Southern", Rating=7},
                    new Resturant{Name="Hypnotic Donuts", Genre="Deserts/Snacks", Rating=5.7},
                   new Resturant{Name="Blacks BBQ", Genre="BBQ", Rating=10},
                    new Resturant{Name="Hubcap Grill", Genre="Misc.", Rating=7.5},
                    new Resturant{Name="Mac and Ernie's Roadside Eatery", Genre="American", Rating=4.5},

                    new Resturant{Name="Killen's Steakhouse", Genre="Southern", Rating=8},
                    new Resturant{Name="The Waffle Bus", Genre="Southern", Rating=1.5},
                    new Resturant{Name="The Gristmill", Genre="American", Rating=9.5},
                    new Resturant{Name="Hubcap Grill", Genre="Misc.", Rating=9.5},
                    new Resturant{Name="Franklin Barbecue", Genre="BBQ", Rating=3.5},

                    new Resturant{Name="Kemuri Tatsu-Ya", Genre="Asian", Rating=3.5},
                    new Resturant{Name="Tamale House East", Genre="Tex-Mex", Rating=7.6},
                    new Resturant{Name="Cattleeack BBQ", Genre="BBQ", Rating=8.5},
                    new Resturant{Name="Hypnotic Donuts", Genre="Deserts/Snacks", Rating=10},
                    new Resturant{Name="Tei-An", Genre="Asian", Rating=8},

                    new Resturant{Name="Fred's Texas Cafe", Genre="American", Rating=2},
                    new Resturant{Name="Swiss Pastry Shop", Genre="Deserts/Snacks", Rating=2.5},
                    new Resturant{Name="Killen's Steakhouse", Genre="Southern", Rating=4},
                    new Resturant{Name="Pho Dien", Genre="Asian", Rating=1.5},
                    new Resturant{Name="Killen's Steakhouse", Genre="Southern", Rating=6},
                };
                context.AddRange(Resturants);


                List <FoodReviewer> FoodReviewers=new List<FoodReviewer>{
                new FoodReviewer{Name="Austin Burch"},
                new FoodReviewer{Name="Elara Mcnally"},
                new FoodReviewer{Name=" Mikail Le"},
                new FoodReviewer{Name="Horace Ramierez"},
                new FoodReviewer{Name="Clement Peacock"},
                };
                context.AddRange(FoodReviewers);

                List<ReviewResturant> Additons=new List<ReviewResturant>{
                    new ReviewResturant {ResturantID=1, FoodReviewerID=1},
                    new ReviewResturant {ResturantID=2, FoodReviewerID=2},
                    new ReviewResturant {ResturantID=3, FoodReviewerID=3},
                    new ReviewResturant {ResturantID=4, FoodReviewerID=4},
                    new ReviewResturant {ResturantID=5, FoodReviewerID=5},

                    new ReviewResturant {ResturantID=6, FoodReviewerID=1},
                    new ReviewResturant {ResturantID=7, FoodReviewerID=2},
                    new ReviewResturant {ResturantID=8, FoodReviewerID=3},
                    new ReviewResturant {ResturantID=9, FoodReviewerID=4},
                    new ReviewResturant {ResturantID=10, FoodReviewerID=5},

                    new ReviewResturant {ResturantID=11, FoodReviewerID=1},
                    new ReviewResturant {ResturantID=12, FoodReviewerID=2},
                    new ReviewResturant {ResturantID=13, FoodReviewerID=3},
                    new ReviewResturant {ResturantID=14, FoodReviewerID=4},
                    new ReviewResturant {ResturantID=15, FoodReviewerID=5},

                    new ReviewResturant {ResturantID=16, FoodReviewerID=1},
                    new ReviewResturant {ResturantID=17, FoodReviewerID=2},
                    new ReviewResturant {ResturantID=18, FoodReviewerID=3},
                    new ReviewResturant {ResturantID=19, FoodReviewerID=4},
                    new ReviewResturant {ResturantID=20, FoodReviewerID=5},

                    new ReviewResturant {ResturantID=21, FoodReviewerID=1},
                    new ReviewResturant {ResturantID=22, FoodReviewerID=2},
                    new ReviewResturant {ResturantID=23, FoodReviewerID=3},
                    new ReviewResturant {ResturantID=24, FoodReviewerID=4},
                    new ReviewResturant {ResturantID=25, FoodReviewerID=5},

                };
                context.AddRange(Additons);
                
                
                context.SaveChanges();
            }
        }
    }
}
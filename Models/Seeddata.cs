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
        
                if (context.FoodReviewers.Any())
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
                    new ReviewResturant {ResturantID=1, FoodReviewerID=2},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=3},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=4},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=5},

                    new ReviewResturant {ResturantID=1, FoodReviewerID=6},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=7},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=8},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=9},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=10},

                    new ReviewResturant {ResturantID=1, FoodReviewerID=11},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=12},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=13},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=14},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=15},

                    new ReviewResturant {ResturantID=1, FoodReviewerID=16},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=17},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=18},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=19},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=22},

                    new ReviewResturant {ResturantID=1, FoodReviewerID=21},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=20},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=23},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=24},
                    new ReviewResturant {ResturantID=1, FoodReviewerID=25},

                };
                context.AddRange(Additons);
                
                
                context.SaveChanges();
            }
        }
    }
}
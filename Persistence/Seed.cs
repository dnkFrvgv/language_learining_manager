using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Languages.Any()) return;
            
            var languages = new List<Language>
            {
                new Language 
                {
                  Title = "English",
                  StartDate = new DateOnly(2021, 09, 13),
                  LastStudiedDate = DateTime.Now,
                },
                new Language 
                {
                  Title = "Spanish",
                  StartDate = new DateOnly(2023, 01, 13),
                  LastStudiedDate = DateTime.Now,
                }
            };

            await context.Languages.AddRangeAsync(languages);
            await context.SaveChangesAsync();
        }
    }
}
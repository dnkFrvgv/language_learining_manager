using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence
{
    public class Seed
    {
      private static async Task SeedLanguages(DataContext context){
        if (context.Languages.Any()) return;

        var languages = new List<Language>
        {
            new Language 
            {
              Title = "English",
            },
            new Language 
            {
              Title = "Spanish",
            },
            new Language
            {
              Title = "German",
            }
        };

        await context.Languages.AddRangeAsync(languages);
        await context.SaveChangesAsync();
      }
      private static async Task SeedSkills(DataContext context){
        if (context.Skills.Any()) return;
       
        var coreSkills = new List<Skill>
        {
          new Skill
          {
            Title = "Listening"
          },
          new Skill
          {
            Title = "Reading"
          },
          new Skill
          {
            Title = "Speaking"
          },
          new Skill
          {
            Title = "Writing"
          },
          new Skill
          {
            Title = "Grammar"
          },
        };

        await context.Skills.AddRangeAsync(coreSkills);            
        await context.SaveChangesAsync();


      }
      public static async Task SeedData(DataContext context)
        {

          await SeedLanguages(context);
          await SeedSkills(context);

        }
    }
}
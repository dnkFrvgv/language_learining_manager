using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Language : BaseEntity
    {
        
      // public Guid Id { get; set; }
      // public User User { get; set; }
      public string Title { get; set; }
      public DateOnly StartDate  { get; set; }
      public DateTime LastUpdatedDate { get; set; }
    }
}
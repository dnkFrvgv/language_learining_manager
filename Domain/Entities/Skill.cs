using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class Skill : BaseEntity
  {
    public string Title { get; set; }
    public ICollection<Log> Logs { get; set; }
  }
}
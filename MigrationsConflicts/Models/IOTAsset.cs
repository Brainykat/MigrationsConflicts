using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationsConflicts.Models
{
  public class IOTAsset
  {
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public DateTime DateCreated { get; set; }

    //public string Field_B { get; set; }
    //public string Description { get; set; }
    //public string Field_A { get; set; }    
  }
}

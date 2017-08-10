using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Models
{
  public class Application
  {
    [Key]
    public int ApplicationId { get; set; }
    public string Name { get; set; }
    public bool IsAcceptable { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Models
{
  public class ClientApplication
  {
    public string Name { get; set; }
    public IEnumerable<ClientQuestion> Questions { get; set; }
  }
}

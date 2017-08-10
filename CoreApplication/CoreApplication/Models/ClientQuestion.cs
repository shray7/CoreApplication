using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Models
{
  public class ClientQuestion
  {
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public string UserAnswer { get; set; }
  }
}

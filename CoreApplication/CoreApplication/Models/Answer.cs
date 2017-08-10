using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Models
{
  public class Answers
  {
    [Key]
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public string Answer { get; set; }
    public bool AnsweredCorrectly { get; set; }
    public string Name { get; set; }

  }
}

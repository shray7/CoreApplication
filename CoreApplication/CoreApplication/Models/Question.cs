using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Models
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}

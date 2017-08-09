using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        //[Column("Question")]
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}

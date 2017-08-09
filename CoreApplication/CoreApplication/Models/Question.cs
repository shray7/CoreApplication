using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class QuestionInfo
    {
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int RightAnswer { get; set; }
        public string Subject { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    internal class Questions
    {
        public string questionstmt {  get; set; }
        public int correctAnswerIndex { get; set; }
        public string[] options { get; set; } = new string[4];
        public bool isDone { get; set; }
    }
}

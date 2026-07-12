using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    internal class Quiz
    {
        public List<Questions> Questions { get; set; }
        public int score { get; set; }
        public int correctAnswers { get; set;}
        public int wrongAnswers { get; set;}
        public int currentQuestion { get; set;}

        public Quiz () {
            Questions = new List<Questions>();
            currentQuestion = 0;
        }

    }
}

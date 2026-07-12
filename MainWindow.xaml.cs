using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Quiz quiz = new Quiz();
        public MainWindow()
        {
            InitializeComponent();
            LoadQuestions();
            DisplayQuestion();       
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CrossBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoadQuestions()
        {
            quiz.Questions.Add(new Questions
            {
                questionstmt = "Who invented the telephone?",
                correctAnswerIndex = 1,
                options = new string[]
                  {
                     "Thomas Edison",
                     "Alexander Graham Bell",
                     "Nikola Tesla",
                     "Albert Einstein"
                  }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Which is the largest planet in our solar system?",
                correctAnswerIndex = 2,
                options = new string[]
                {
                    "Earth",
                    "Mars",
                    "Jupiter",
                    "Saturn"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Which programming language is used with .NET?",
                correctAnswerIndex = 0,
                options = new string[]
                {
                    "C#",
                    "Java",
                    "Python",
                    "PHP"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "What does CPU stand for?",
                correctAnswerIndex = 3,
                options = new string[]
                {
                    "Central Process Unit",
                    "Computer Processing Unit",
                    "Control Processing Unit",
                    "Central Processing Unit"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Which country is known as the Land of the Rising Sun?",
                correctAnswerIndex = 2,
                options = new string[]
                {
                    "China",
                    "South Korea",
                    "Japan",
                    "Thailand"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Who painted the Mona Lisa?",
                correctAnswerIndex = 1,
                options = new string[]
                {
                    "Pablo Picasso",
                    "Leonardo da Vinci",
                    "Vincent van Gogh",
                    "Michelangelo"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "How many continents are there on Earth?",
                correctAnswerIndex = 0,
                options = new string[]
                {
                    "7",
                    "6",
                    "5",
                    "8"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Which gas do plants absorb from the atmosphere?",
                correctAnswerIndex = 2,
                options = new string[]
                {
                    "Oxygen",
                    "Nitrogen",
                    "Carbon Dioxide",
                    "Hydrogen"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Which company created the PlayStation?",
                correctAnswerIndex = 1,
                options = new string[]
                {
                    "Microsoft",
                    "Sony",
                    "Nintendo",
                     "Sega"
                }
            });

            quiz.Questions.Add(new Questions
            {
                questionstmt = "Which is the fastest land animal?",
                correctAnswerIndex = 3,
                options = new string[]
                {
                    "Lion",
                    "Tiger",
                    "Horse",
                    "Cheetah"
                }
            });
        }

        private void DisplayQuestion()
        {
            QuestionBox.Text = $"{quiz.currentQuestion + 1}. {quiz.Questions[quiz.currentQuestion].questionstmt}";

            R1.Content = quiz.Questions[quiz.currentQuestion].options[0];
            R2.Content = quiz.Questions[quiz.currentQuestion].options[1];
            R3.Content = quiz.Questions[quiz.currentQuestion].options[2];
            R4.Content = quiz.Questions[quiz.currentQuestion].options[3];      
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selected = -1;

                if (R1.IsChecked == true)
                {
                    selected = 0;
                }
                else if (R2.IsChecked == true)
                {
                    selected = 1;
                }
                else if (R3.IsChecked == true)
                {
                    selected = 2;
                }
                else if (R4.IsChecked == true)
                {
                    selected = 3;
                }


                if (selected == quiz.Questions[quiz.currentQuestion].correctAnswerIndex)
                {
                    if (!quiz.Questions[quiz.currentQuestion].isDone)
                    {
                        quiz.score++;
                        quiz.Questions[quiz.currentQuestion].isDone = true;
                    }

                    Dispatcher.Invoke(() =>
                    {
                        ScoreCount.Text = quiz.score.ToString();
                    });
                }
                else
                {
                    if (!quiz.Questions[quiz.currentQuestion].isDone)
                    {
                        quiz.Questions[quiz.currentQuestion].isDone = true;
                    }
                }

                if (quiz.currentQuestion < quiz.Questions.Count - 1)
                {
                    quiz.currentQuestion++;
                }

                if (quiz.currentQuestion < quiz.Questions.Count)
                {
                    R1.IsChecked = false;
                    R2.IsChecked = false;
                    R3.IsChecked = false;
                    R4.IsChecked = false;
                    DisplayQuestion();
                    if (quiz.currentQuestion == quiz.Questions.Count - 1)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            NextBtn.Content = "Submit";
                        });
                    }
                    bool showResult = true;
                    foreach (var q in quiz.Questions)
                    {
                        if (!q.isDone)
                        {
                            showResult = false;
                            break;
                        }
                    }

                    if (showResult)
                    {
                        double percentage = ((double)quiz.score / (double)quiz.Questions.Count) * 100;
                        MessageBox.Show($"You got {percentage}% marks", "Quiz Submitted",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        NextBtn.IsEnabled = false;
                        NextBtn.Background = new SolidColorBrush(Colors.Gray);
                    }
                }            
            } catch (Exception ex)
            {
                
            }
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PROJECT_PROEL2;

public partial class SimpleQuizForm : ContentPage
{
    public ObservableCollection<QuizQuestion> Questions { get; } = new();

    public SimpleQuizForm()
    {
        InitializeComponent();

        Questions.Add(new QuizQuestion
        {
            Id = "q1",
            QuestionText = "What is the capital of France?",
            Options = new List<string> { "Berlin", "Madrid", "Paris", "Rome" },
            CorrectAnswer = "Paris"
        });

        Questions.Add(new QuizQuestion
        {
            Id = "q2",
            QuestionText = "Which planet is known as the Red Planet?",
            Options = new List<string> { "Earth", "Mars", "Venus", "Saturn" },
            CorrectAnswer = "Mars"
        });

        Questions.Add(new QuizQuestion
        {
            Id = "q3",
            QuestionText = "What is the largest ocean on Earth?",
            Options = new List<string> { "Atlantic", "Pacific", "Indian", "Arctic" },
            CorrectAnswer = "Pacific"
        });
        Questions.Add(new QuizQuestion
        {
            Id = "q4",
            QuestionText = "Who is the Presiden in Philippines?",
            Options = new List<string> { "Bongbong Marcos", "Rodrigo Duterte", "Zessuah Ray Nellas", "Anchor Jave Arnejo" },
            CorrectAnswer = "Bongbong Marcos"

        });

        BindingContext = this;
    }

    private void OnPreviousClicked(object sender, EventArgs e)
    {
        if (quizCarousel.Position > 0)
        {
            quizCarousel.ScrollTo(quizCarousel.Position - 1, animate: true);
        }
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        if (quizCarousel.Position < Questions.Count - 1)
        {
            quizCarousel.ScrollTo(quizCarousel.Position + 1, animate: true);
        }
    }

    private async void OnSubmitQuiz(object sender, EventArgs e)
    {
        var score = Questions.Count(q => q.SelectedAnswer != null && q.SelectedAnswer == q.CorrectAnswer);
        await DisplayAlert("Result", $"You scored {score} / {Questions.Count}", "OK");
    }

    private void OnOptionChecked(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value) return;

        if (sender is RadioButton rb)
        {
            var question = FindParentQuizQuestion(rb);
            if (question != null)
            {
                question.SelectedAnswer = rb.Value?.ToString();
            }
        }
    }

    private QuizQuestion FindParentQuizQuestion(BindableObject element)
    {
        while (element != null)
        {
            if (element.BindingContext is QuizQuestion question)
                return question;

            element = (element as Element)?.Parent;
        }
        return null;
    }

    public class QuizQuestion : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }

        private string selectedAnswer;
        public string SelectedAnswer
        {
            get => selectedAnswer;
            set
            {
                if (selectedAnswer != value)
                {
                    selectedAnswer = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string p = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
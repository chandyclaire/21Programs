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

        // Sample questions
        Questions.Add(new QuizQuestion
        {
            Id = "q1",
            QuestionText = "What is '2' + '2' ",
            Options = new List<string> { "4", "22", "2", "0" },
            CorrectAnswer = "22"
        });

        Questions.Add(new QuizQuestion
        {
            Id = "q2",
            QuestionText = "Who is the Main Character of Lord of the Mysteries",
            Options = new List<string> { "navI htieK nolyaB", "Zessuah Ray Nellas", "Alger Eggers", "Klein Moretti" },
            CorrectAnswer = "Klein Moretti"
        });

        Questions.Add(new QuizQuestion
        {
            Id = "q3",
            QuestionText = "Who developed C#?",
            Options = new List<string> { "Google", "Microsoft", "Apple", "Oracle" },
            CorrectAnswer = "Microsoft"
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

        if (sender is RadioButton rb && rb.BindingContext is string option)
        {
            if (rb.Parent?.BindingContext is QuizQuestion question)
            {
                question.SelectedAnswer = option;
            }
        }
    }
}

public class QuizQuestion : INotifyPropertyChanged
{
    public string Id { get; set; }             // unique id per question
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

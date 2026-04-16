using System.Collections.Generic;

namespace comprehensure.DASHBOARD.StoryPage;

public partial class QuizPage1 : ContentPage
{
    private int _currentQuestionIndex = 0;
    private int _score = 0;
    private string _selectedAnswer = "";

    private List<QuizQuestion> _questions = new List<QuizQuestion>
    {
        new QuizQuestion("Why was the library mostly forgotten by the people in town?", "b", "It was destroyed by a storm.", "People preferred modern bookstores and online sources.", "It was too far from the town center.", "It only contained children’s books."),
        new QuizQuestion("How does the author describe the inside of the library?", "c", "Bright, colorful, and crowded.", "Dark, empty, and newly built.", "Dusty, quiet, and filled with old books.", "Modern, clean, and well-organized."),
        new QuizQuestion("What made Leo interested in visiting the library?", "c", "His friends told him to go.", "He needed a quiet place to study.", "He heard rumors about hidden stories and knowledge.", "He wanted to avoid schoolwork."),
        new QuizQuestion("What does Leo discover behind the bookshelf?", "b", "A secret treasure chest.", "A hidden passage with old journals.", "A locked door to another building.", "A room full of modern computers."),
        new QuizQuestion("Why was Leo unable to understand the journal at first?", "c", "It was written in a foreign language.", "The pages were missing.", "It was written in shorthand.", "The writing was invisible."),
        new QuizQuestion("What strategy did Leo use to understand the journals?", "c", "He asked his teachers to translate.", "He ignored the difficult parts.", "He studied patterns and symbols over time.", "He guessed the meaning of each word."),
        new QuizQuestion("What kind of information did the journals contain?", "c", "Recipes and daily routines.", "Stories about fictional characters.", "Accounts of explorers’ journeys and decisions.", "Lists of books in the library."),
        new QuizQuestion("What important realization did Leo have about history?", "c", "It is only about famous people.", "It focuses only on large events.", "It includes small details and human decisions.", "It is mostly made up of myths."),
        new QuizQuestion("What was the result of Leo sharing his discoveries?", "b", "The library was closed permanently.", "People became interested and visited the library again.", "The journals were taken away and hidden.", "The town ignored his findings."),
        new QuizQuestion("What is the main message of the story?", "c", "Old buildings should be replaced.", "Knowledge is only valuable if it is popular.", "Important truths can be found through curiosity and effort.", "History is not useful in modern times.")
    };

    public QuizPage1()
    {
        InitializeComponent();
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        var q = _questions[_currentQuestionIndex];
        QuestionNumberLabel.Text = $"Question {_currentQuestionIndex + 1} of 10";
        QuizProgress.Progress = (_currentQuestionIndex + 1) / 10.0;
        QuestionText.Text = q.Title;

        BtnA.Text = q.OptionA;
        BtnB.Text = q.OptionB;
        BtnC.Text = q.OptionC;
        BtnD.Text = q.OptionD;

        ResetCircles();
        NextButton.IsEnabled = false;
        _selectedAnswer = "";
    }

    private void OnOptionClicked(object sender, EventArgs e)
    {
        var tappedArgs = e as TappedEventArgs;
        string choice = tappedArgs?.Parameter?.ToString();

        if (string.IsNullOrEmpty(choice)) return;

        ResetCircles();
        _selectedAnswer = choice;

        switch (choice)
        {
            case "a": CircleA.BackgroundColor = Color.FromArgb("#80c2ed"); break;
            case "b": CircleB.BackgroundColor = Color.FromArgb("#80c2ed"); break;
            case "c": CircleC.BackgroundColor = Color.FromArgb("#80c2ed"); break;
            case "d": CircleD.BackgroundColor = Color.FromArgb("#80c2ed"); break;
        }

        NextButton.IsEnabled = true;
    }

    private void ResetCircles()
    {
        CircleA.BackgroundColor = Colors.Transparent;
        CircleB.BackgroundColor = Colors.Transparent;
        CircleC.BackgroundColor = Colors.Transparent;
        CircleD.BackgroundColor = Colors.Transparent;
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        if (_selectedAnswer == _questions[_currentQuestionIndex].CorrectAnswer)
            _score++;

        if (_currentQuestionIndex < _questions.Count - 1)
        {
            _currentQuestionIndex++;
            LoadQuestion();
        }
        else
        {
            await DisplayAlert("Quiz Finished", $"You scored {_score} out of 10!", "OK");
            await Navigation.PopAsync();
        }
    }
}

public class QuizQuestion
{
    public string Title { get; set; }
    public string CorrectAnswer { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }

    public QuizQuestion(string title, string correct, string a, string b, string c, string d)
    {
        Title = title; CorrectAnswer = correct;
        OptionA = a; OptionB = b; OptionC = c; OptionD = d;
    }
}
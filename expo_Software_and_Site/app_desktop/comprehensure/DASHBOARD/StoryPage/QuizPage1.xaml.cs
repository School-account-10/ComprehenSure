namespace comprehensure.DASHBOARD.StoryPage;

public partial class QuizPage1 : ContentPage
{
    private readonly QuizPage1ViewModel _viewModel;
    private string _selectedAnswer = "";

    public QuizPage1(QuizPage1ViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadQuestions();
    }

    private void OnOptionClicked(object sender, TappedEventArgs e)
    {
        _selectedAnswer = e.Parameter?.ToString().ToUpper() ?? "";
        ResetCircles();

        switch (_selectedAnswer)
        {
            case "A": CircleA.BackgroundColor = Color.FromArgb("#80c2ed"); break;
            case "B": CircleB.BackgroundColor = Color.FromArgb("#80c2ed"); break;
            case "C": CircleC.BackgroundColor = Color.FromArgb("#80c2ed"); break;
            case "D": CircleD.BackgroundColor = Color.FromArgb("#80c2ed"); break;
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
        bool correct = _viewModel.CheckAnswer(_selectedAnswer);

        _selectedAnswer = "";
        NextButton.IsEnabled = false;
        ResetCircles();

        bool hasNext = _viewModel.NextQuestion();

        if (!hasNext)
        {
           
            await _viewModel.SaveQuizResults();
            await DisplayAlert("Quiz Complete",
                $"You scored {_viewModel.Score} out of {_viewModel.TotalQuestions}!", "OK");
            await Navigation.PopAsync();
        }
    }
}

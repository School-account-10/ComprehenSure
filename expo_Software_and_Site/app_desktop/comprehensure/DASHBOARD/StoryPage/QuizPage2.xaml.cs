namespace comprehensure.DASHBOARD.StoryPage;

public partial class QuizPage2 : ContentPage
{
    public QuizPage2(DASHBOARD.StoryPage.QuizPage2ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {

        await DisplayAlert("Quiz Complete", "You have finished the quiz for Module 2!", "OK");
        await Navigation.PopToRootAsync();
    }

    private async void OnBackToStoryClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
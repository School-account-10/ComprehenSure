namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage3 : ContentPage // 1
{
    public StoryPage3(DASHBOARD.StoryPage.QuizPage3ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {

        
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage6 : ContentPage // 1
{
    public StoryPage6(DASHBOARD.StoryPage.QuizPage6ViewModel viewModel)
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
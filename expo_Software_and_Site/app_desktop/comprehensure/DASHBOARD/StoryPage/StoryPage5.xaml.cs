namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage5 : ContentPage // 1
{
    public StoryPage5(DASHBOARD.StoryPage.QuizPage5ViewModel viewModel)
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
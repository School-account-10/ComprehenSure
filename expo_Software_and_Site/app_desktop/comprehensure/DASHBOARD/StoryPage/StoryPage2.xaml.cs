namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage2 : ContentPage // 1
{
    public StoryPage2(DASHBOARD.StoryPage.QuizPage2ViewModel viewModel)
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
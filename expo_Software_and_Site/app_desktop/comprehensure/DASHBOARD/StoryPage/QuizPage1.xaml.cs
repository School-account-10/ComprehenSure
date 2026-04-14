namespace comprehensure.DASHBOARD.StoryPage;
public partial class QuizPage1 : ContentPage
{
    public QuizPage1(DASHBOARD.StoryPage.QuizPage1ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }


    private async void OnBackToStoryClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
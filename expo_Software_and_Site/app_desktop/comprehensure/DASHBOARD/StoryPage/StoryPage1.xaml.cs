namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage1 : ContentPage
{
    public StoryPage1(DASHBOARD.StoryPage.StoryPage1ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }


    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {
      
        await Navigation.PushAsync(new QuizPage1());
    }


    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        
        await Navigation.PopAsync();
    }
}
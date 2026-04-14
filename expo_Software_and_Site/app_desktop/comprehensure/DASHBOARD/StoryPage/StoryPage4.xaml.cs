namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage4 : ContentPage // 1
{
    public StoryPage4(DASHBOARD.StoryPage.StoryPage4ViewModel viewModel)
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
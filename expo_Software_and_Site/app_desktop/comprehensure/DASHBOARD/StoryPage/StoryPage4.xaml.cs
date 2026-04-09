namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage4 : ContentPage // 1
{
    public StoryPage4() // 2
    {
        InitializeComponent();
    }

    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new QuizPage4()); // 3
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
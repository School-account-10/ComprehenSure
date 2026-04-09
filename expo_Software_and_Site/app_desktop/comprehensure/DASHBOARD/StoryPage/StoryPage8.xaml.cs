namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage8 : ContentPage // 1
{
    public StoryPage8() // 2
    {
        InitializeComponent();
    }

    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new QuizPage8()); // 3
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
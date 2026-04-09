namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage1 : ContentPage
{
    public StoryPage1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Navigates the user to the quiz page for Module 1.
    /// Ensure QuizPage1.xaml.cs is in the same namespace.
    /// </summary>
    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {
        // Navigate forward to QuizPage1
        await Navigation.PushAsync(new QuizPage1());
    }

    /// <summary>
    /// Returns the user to the previous screen (the Modules Dashboard).
    /// </summary>
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Remove the current page from the navigation stack
        await Navigation.PopAsync();
    }
}
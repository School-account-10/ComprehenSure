namespace comprehensure.DASHBOARD.MiniGames;

public partial class SynonymHuntPage : ContentPage
{
    public SynonymHuntPage()
    {
        InitializeComponent();
    }

    // This fixes the XHR006 "No method OnCorrectAnswer found" error
    private async void OnCorrectAnswer(object sender, EventArgs e)
    {
        await DisplayAlert("Correct!", "You remembered the story well!", "Next");
        await Navigation.PopAsync();
    }

    // This fixes the error for the second button
    private async void OnWrongAnswer(object sender, EventArgs e)
    {
        await DisplayAlert("Try Again", "Ancient refers to something from a very long time ago.", "OK");
    }
}
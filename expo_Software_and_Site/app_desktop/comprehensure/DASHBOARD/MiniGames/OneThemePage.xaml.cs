namespace comprehensure.DASHBOARD.MiniGames;

public partial class OneThemePage : ContentPage
{
    public OneThemePage()
    {
        InitializeComponent();
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        // Navigates back to the Dashboard
        await Shell.Current.GoToAsync("..");
    }
}
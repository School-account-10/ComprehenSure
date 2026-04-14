namespace comprehensure.DASHBOARD;

public partial class MainDashboard : ContentPage
{
    public MainDashboard(DataBaseControl.Models.MainDashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    // This handles the PLAY NOW button on the dashboard
    private async void OnSynonymHuntClicked(object sender, EventArgs e)
    {
        // This performs the actual redirection
        await Navigation.PushAsync(new MiniGames.SynonymHuntPage());
    }

    private async void OnOneWordClicked(object sender, EventArgs e)
    {
        // Ensure OneThemePage exists in your MiniGames folder
        await Navigation.PushAsync(new MiniGames.OneThemePage());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing(); 
        if (BindingContext is DataBaseControl.Models.MainDashboardViewModel vm)
        {
            await vm.OnAppearing();
        }
    }
}
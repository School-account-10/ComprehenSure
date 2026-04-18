using comprehensure.DataBaseControl.Models;

namespace comprehensure.DASHBOARD;

public partial class MainDashboard : ContentPage
{
    private readonly MainDashboardViewModel _viewModel;

    public MainDashboard(MainDashboardViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnAppearing();
        _viewModel.StartAutoRefresh();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.StopAutoRefresh();
    }

    private async void OnSynonymHuntClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiniGames.SynonymHuntPage());
    }

    private async void OnOneWordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiniGames.OneThemePage());
    }
}
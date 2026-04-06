

using comprehensure.DataBaseControl.Models;

namespace comprehensure.DASHBOARD;

public partial class MainDashboard : ContentPage
{
    public MainDashboard(DataBaseControl.Models.MainDashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        
    }


    private async void ProgressButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgressDashboard());
    }

    private async void ModulesButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ModulesDaskboard());
    }

   

    private async void AboutUsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AllAboutUS_Dashboard());
    }

   
}

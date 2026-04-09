namespace comprehensure.DASHBOARD;

using comprehensure.DataBaseControl.Models;

public partial class ProfileDashboard : ContentPage
{
    public ProfileDashboard(DataBaseControl.Models.ProfileDashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
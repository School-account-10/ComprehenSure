using comprehensure.DataBaseControl.Models;
using Microsoft.Maui.Controls;
using System;

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

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfileDashboard());
    }

    private async void AboutUsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AllAboutUS_Dashboard());
    }
}
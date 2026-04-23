using System;
using Microsoft.Maui.Controls;


namespace comprehensure.DASHBOARD;

public partial class ModulesDashboard : ContentPage
{
    public ModulesDashboard(DataBaseControl.Models.ModulesDashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        await Shell.Current.GoToAsync("///MainDashboard");
    }


}
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

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        
        if (BindingContext is MainDashboardViewModel vm)
        {
            await vm.OnAppearing();
        }
    }

   
}
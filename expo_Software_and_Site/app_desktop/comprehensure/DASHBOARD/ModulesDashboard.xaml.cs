using System;
using Microsoft.Maui.Controls;


namespace comprehensure.DASHBOARD;

public partial class ModulesDashboard : ContentPage
{
    public ModulesDashboard()
    {
        InitializeComponent();
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    
}
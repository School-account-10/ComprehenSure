using System;
using Microsoft.Maui.Controls;
using comprehensure.DASHBOARD.StoryPage;

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

    private async void OnStartClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new StoryPage1());
    }
}
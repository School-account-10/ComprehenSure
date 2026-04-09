using Microsoft.Maui.Controls;
using System;
using comprehensure.DASHBOARD.StoryPage;

namespace comprehensure.DASHBOARD;

public partial class ModulesDaskboard : ContentPage
{
	public ModulesDaskboard()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    public ModulesDaskboard()
    {
        InitializeComponent();
    }

    
    private async void OnStartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StoryPage1());
    }
}
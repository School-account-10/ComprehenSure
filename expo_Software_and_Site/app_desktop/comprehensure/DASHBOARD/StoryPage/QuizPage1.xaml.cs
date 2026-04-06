using Microsoft.Maui.Controls;
using System;

namespace comprehensure.DASHBOARD.StoryPage; 

public partial class QuizPage1 : ContentPage
{
    public QuizPage1()
    {
        InitializeComponent();
    }


    private async void OnBackToStoryClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
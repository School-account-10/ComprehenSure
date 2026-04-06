using Microsoft.Maui.Controls;
using System;

namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage2 : ContentPage
{
    public StoryPage2()
    {
        InitializeComponent();
    }

    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {
        // Navigates specifically to QuizPage2
        await Navigation.PushAsync(new QuizPage2());
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Returns to the Modules Dashboard
        await Navigation.PopAsync();
    }
}
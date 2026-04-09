using Microsoft.Maui.Controls;
using System;
namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage2 : ContentPage // 1
{
    public StoryPage2() // 2
    {
        InitializeComponent();
    }

    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new QuizPage2()); // 3
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
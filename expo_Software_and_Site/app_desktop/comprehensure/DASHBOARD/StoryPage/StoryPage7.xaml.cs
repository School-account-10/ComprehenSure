using Microsoft.Maui.Controls;
using System;
namespace comprehensure.DASHBOARD.StoryPage;

public partial class StoryPage7 : ContentPage // 1
{
    public StoryPage7() // 2
    {
        InitializeComponent();
    }

    private async void OnGoToQuizClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new QuizPage7()); // 3
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
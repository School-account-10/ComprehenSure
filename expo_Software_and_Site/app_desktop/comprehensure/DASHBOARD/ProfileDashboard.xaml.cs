using Microsoft.Maui.Controls;
using System;

namespace comprehensure.DASHBOARD;

public partial class ProfileDashboard : ContentPage
{
    public ProfileDashboard()
    {
        InitializeComponent();
    }

    private async void OnChangePfpClicked(object sender, EventArgs e)
    {
        // Placeholder for image picker logic
        await DisplayAlert("Profile Picture", "This is where the user will select a new photo from their gallery.", "OK");
    }

    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        // Placeholder for navigation to a Change Password page
        await DisplayAlert("Security", "Navigate to the Change Password screen.", "OK");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Ask for confirmation before logging out
        bool answer = await DisplayAlert("Log Out", "Are you sure you want to log out of your account?", "Yes", "No");
        
        if (answer)
        {
            // Logic to clear user data and return to the login screen
            // await Navigation.PushAsync(new LoginPage()); 
            await DisplayAlert("Success", "You have been logged out.", "OK");
        }
    }
}
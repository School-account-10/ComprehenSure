namespace comprehensure;

public partial class SignUpPage : ContentPage
{
    // private SwitchOffline _checker;
    public SignUpPage(DataBaseControl.Models.SignUpViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }



    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        // await DisplayAlert("Sign Up", "Sign up button clicked!", "OK");
        // SwitchOffline.Checker();


    }

    private async void OnLoginNavigationClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

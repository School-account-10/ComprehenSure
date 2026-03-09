using comprehensure.DataBaseControl.Models;

namespace comprehensure
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_login_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(LoginPage));
            




        }

        private async void Button_sign_up_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
    }
}

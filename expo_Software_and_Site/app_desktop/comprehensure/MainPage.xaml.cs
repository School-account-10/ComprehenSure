namespace comprehensure
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_login_Clicked(object sender, EventArgs e)
        {
            await DisplayAlertAsync("LOGIN", "You have been alerted", "OK");

        }

        private async void Button_sign_in_Clicked(object sender, EventArgs e)
        {
            await DisplayAlertAsync("SIGNIN", "You have been alerted", "OK");
        }
    }
}

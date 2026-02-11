namespace comprehensure
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Button_Clicked(object sender, EventArgs e)
        {

        }


        public async void BackButtonEvent(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}

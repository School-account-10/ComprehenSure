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
            
            await Navigation.PushAsync(new LoginPage());


        }

        private async void Button_sign_up_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}

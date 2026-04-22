namespace comprehensure
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(DataBaseControl.Models.LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public class UserAccount // in simple terms this more of the name of the terms in the accounts.json
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        /* public async Task<List<UserAccount>> GetAccountsAsync()
         {
             try
             {
                 var stream = await FileSystem.OpenAppPackageFileAsync(
                     "LocalDB/ACCOUNTS/Accounts.json"
                 );
                 var reader = new StreamReader(stream);
                 var contents = await reader.ReadToEndAsync();

                 var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                 return JsonSerializer.Deserialize<List<UserAccount>>(contents, options)
                     ?? new List<UserAccount>();
             }
             catch (Exception e)
             {
                 await DisplayAlert(
                     "no DB",
                     "dora the explorer why cant i find the db????????????",
                     "why cant it find the db? "
                 ); // why tf //update why still not seeing db// update: works now

                 return new List<UserAccount>();
             }
             // for the devs in simple termmms just return the value of email and password
             // note for future me:  DO NOT DO THIS THIS YOU CAN EXPLOIT THIS BY reading memory or sum OR JUST READING THE ACCOUNTS.JSON
         }

         private async void Login_Button_Clicked(object sender, EventArgs e)
         {
             var accounts = await GetAccountsAsync();

             //String ConvEmail = Email.Replace(" ", String.Empty);

             string cleanEmail = Email.Text.Trim();

             var user = accounts.FirstOrDefault(a =>
                 a.Email == cleanEmail && a.Password == Password.Text
             );

             if (user != null)
             {
                 await DisplayAlert("Success", "Welcome back!", "OK");
                 await Navigation.PushAsync(new DASHBOARD.MainDashboard());
             }
             else
             {
                 await DisplayAlert("Error", "Invalid wrong something!", "OK");
             }
         }
        */


        public async void BackButtonEvent(Object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.SetNavBarIsVisible(this, false);
            Shell.SetNavBarHasShadow(this, false);
            Shell.SetBackButtonBehavior(this, new BackButtonBehavior
            {
                IsVisible = false,
                IsEnabled = false
            });
        }
    }
}

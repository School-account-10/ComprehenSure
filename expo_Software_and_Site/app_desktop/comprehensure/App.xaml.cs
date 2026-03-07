using Microsoft.Extensions.DependencyInjection;

namespace comprehensure
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Connectivity.Current.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        protected override async void OnStart()
        {
            base.OnStart();

            await Task.Delay(500);

            CheckInitialConnection();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        private async void CheckInitialConnection()
        {
            var offlineSwitcher = new comprehensure.DataBaseControl.SwitchOffline.SwitchModes(
                false
            );

            bool isOnline = await offlineSwitcher.CHECK();

            Console.WriteLine($"Startup connection status: {isOnline}");
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
            {
                Shell.Current.DisplayAlert("Connection Lost", "You are now offline.", "OK");
            }
        }
    }
}

//
//
// using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AuthenticationServices;
//using MetalPerformanceShadersGraph;

// using Xamarin.KotlinX.Coroutines.Selects;
using Microsoft.Maui.Networking;

namespace comprehensure.DataBaseControl
{
    internal class SwitchOffline
    {
        public class SwitchModes(Boolean Switcher)
        {
            public async Task<bool> CHECK()
            {
                var current = Connectivity.Current.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    Switcher = true;

                    await Shell.Current.DisplayAlert("INTERNET DETEC", "YOUR ONLINE!", "OK");
                }
                else if (current == NetworkAccess.ConstrainedInternet)
                {
                    Console.WriteLine("CAPTIVE PORTAL / LIMITED ACCESS");
                    await Shell.Current.DisplayAlert("INTERNET DETEC", "CAPTIVE PORTAL", "OK");
                    Switcher = false;
                }
                else
                {
                    await Shell.Current.DisplayAlert("INTERNET DETEC", "OFFLINE", "OK");
                    Console.WriteLine("OFFLINE OR UNKNOWN");
                    Switcher = false;
                }

                return Switcher;
            }
        }
    }
}

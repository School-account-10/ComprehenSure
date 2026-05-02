using comprehensure.DataBaseControl.Models;

namespace comprehensure.DASHBOARD
{
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
            BindingContext = new AboutUsViewModel();
        }
    }
}
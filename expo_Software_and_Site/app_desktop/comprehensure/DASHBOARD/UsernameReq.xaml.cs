namespace comprehensure.DASHBOARD;

public partial class UsernameReq : ContentPage
{
	public UsernameReq(DataBaseControl.Models.UsernameReqViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; //DASHBOARD.StoryPage.StoryPage.StoryPage1ViewModel
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetNavBarHasShadow(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false,
            IsEnabled = false
        });
    }
}
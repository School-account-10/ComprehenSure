namespace comprehensure.DASHBOARD;

public partial class UsernameReq : ContentPage
{
	public UsernameReq(DataBaseControl.Models.UsernameReqViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; //DASHBOARD.StoryPage.StoryPage.StoryPage1ViewModel
    }
}


namespace comprehensure.DASHBOARD;

public partial class UsernameReq : ContentPage
{
	public UsernameReq(DataBaseControl.Models.UsernameReqViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
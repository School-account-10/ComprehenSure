namespace comprehensure.DASHBOARD;

public partial class ModulesDaskboard : ContentPage
{
	public ModulesDaskboard()
	{
		InitializeComponent();
	}

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
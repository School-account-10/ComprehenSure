using CommunityToolkit.Mvvm.Messaging.Messages;


namespace comprehensure.DASHBOARD;

public partial class MainDashboard : ContentPage 
{
	public MainDashboard()
	{
		InitializeComponent();
        this.BindingContext = this;
    }
	public int score;
	public int modulefinished;
	public int added;


	public readonly int module_count = 8;
    public float ResultModule;
    public int Percentage()
	{
		// fake user data 

		
		modulefinished = 1;
		score = 30;



		ResultModule = (modulefinished / module_count) * 100;





		return (int)ResultModule;
	}




	private async void ProgressButton_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ProgressDashboard());
    }
	private async void ModulesButton_Clicked(object sender, EventArgs e)
	{
		
        await Navigation.PushAsync(new ModulesDaskboard());
    }

	private async void ProfileButton_Clicked(object sender, EventArgs e)
	{
		
        await Navigation.PushAsync(new ProfileDashboard());
    }
	private async void AboutUsButton_Clicked(object sender, EventArgs e)
	{
		
        await Navigation.PushAsync(new AllAboutUS_Dashboard());
    }

}
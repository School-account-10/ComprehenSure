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
	public readonly int score_count_max = 80;
	public float ResultModule;
    public float ResultScore;
    public (float, float) Percentage()
    {
		// fake user data 

		
		modulefinished = 1;
		score = 10;


        ResultModule = ((float)modulefinished / module_count) * 100;
        ResultScore = ((float)score / score_count_max) * 100;





        return (ResultModule, ResultScore);
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
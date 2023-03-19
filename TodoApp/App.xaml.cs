namespace TodoApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        window.Title = AppInfo.Name + " " + AppInfo.VersionString;
        return window;
    }

    protected override void OnStart()
    {
        base.OnStart();
        Shell.Current.GoToAsync("//TodoPage");
    }
}

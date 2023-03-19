using TodoApp.Views;
namespace TodoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TodoPage), typeof(TodoPage));
		Routing.RegisterRoute(nameof(TodoAddPage), typeof(TodoAddPage));
				LabelVersion.Text = "Ver " + AppInfo.Current.VersionString;
	}
}

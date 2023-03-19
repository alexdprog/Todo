using CommunityToolkit.Maui.Views;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    public partial class TodoArhivePage : ContentPage
    {
    	public new TodoArhiveViewModel ViewModel => (TodoArhiveViewModel)BindingContext;

        public TodoArhivePage(TodoArhiveViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            ViewModel.OnNavigatedTo();
        }
        
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (ViewModel.ToggledCommand.CanExecute(sender))
            {
                ViewModel.ToggledCommand.Execute(this);
            }
        }
    }
}

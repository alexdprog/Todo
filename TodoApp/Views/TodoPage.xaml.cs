using CommunityToolkit.Maui.Views;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    public partial class TodoPage : ContentPage
    {
    	public TodoViewModel ViewModel => (TodoViewModel)BindingContext;

        public TodoPage(TodoViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Task.Run(() => ViewModel.OnNavigatedTo());
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

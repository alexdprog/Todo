using TodoApp.ViewModels;

namespace TodoApp.Views
{
    public partial class MainPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}

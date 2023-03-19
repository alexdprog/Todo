using TodoApp.ViewModels;

namespace TodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoAddPage
    {
        public TodoAddPage(TodoAddViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}

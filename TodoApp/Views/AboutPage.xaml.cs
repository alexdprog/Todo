using CommunityToolkit.Maui.Views;
using TodoApp.ViewModels;

namespace TodoApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage(AboutViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}


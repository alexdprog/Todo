using System.Windows.Input;

namespace TodoApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }

        public string ProjectName { get; set; }

        public MainPageViewModel()
            : base()
        {
            ProjectName = "TodoApp";
            NavigateCommand = new Command<string>(Navigate);
        }

        async void Navigate(string pageName)
        {
           await Shell.Current.GoToAsync("//" + pageName);
        }
    }
}

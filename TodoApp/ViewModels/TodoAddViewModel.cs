
using System.Windows.Input;

using TodoApp.DataAccess;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class TodoAddViewModel : BaseViewModel, IQueryAttributable
    {
        private TodoAppBaseContext _todoappBaseContext;
        private Todo _todoValue;
        private string _applyName;
        private bool AddMode;

        public Todo TodoValue  {get => _todoValue; set => SetProperty(ref _todoValue, value); }

        public string ApplyName { get => _applyName; set => SetProperty (ref _applyName, value); }

        public ICommand OnAcceptCommand { private set; get; }
        public ICommand OnCancelCommand { private set; get; }
         
        public TodoAddViewModel(TodoAppBaseContext todoappBaseContext)
        {
            _todoappBaseContext = todoappBaseContext;
            OnAcceptCommand = new Command(OnAccept);
            OnCancelCommand = new Command(OnCancel);
        }

        void OnAccept()
        {
            if (AddMode)
            {   
                TodoValue.Time = DateTime.Now;
                _todoappBaseContext.Todo.Add(TodoValue);
            }
            _todoappBaseContext.SaveChanges();
            Shell.Current.Navigation.PopAsync();
        }

        void OnCancel()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Todo", out var queryValue))
            {
                TodoValue = queryValue as Todo;
                ApplyName = "Apply";
                AddMode = false;
            }
            else
            {
                TodoValue = new Todo();
                AddMode = true;
                ApplyName = "Add";
            }
        }
    }
}

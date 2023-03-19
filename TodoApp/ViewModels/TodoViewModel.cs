using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

using TodoApp.DataAccess;
using TodoApp.Models;
using TodoApp.Views;

namespace TodoApp.ViewModels
{
    public partial class TodoViewModel : BaseViewModel
    {
       
        private TodoAppBaseContext _todoappBaseContext;
                private ObservableCollection<Todo> _todoList;
        public ObservableCollection<Todo> TodoList  
        {
            get => _todoList;
            set => SetProperty(ref _todoList, value);
        }
        
        public ICommand AddCommand { private set; get; }

        public ICommand EditCommand { private set; get; }

        public ICommand DeleteCommand { private set; get; }
     
        private bool CanToggled{ get; set; }
         
        public TodoViewModel(TodoAppBaseContext todoappBaseContext)
        {
            _todoappBaseContext = todoappBaseContext;
                        TodoList = new ObservableCollection<Todo>(_todoappBaseContext.Todo.ToList());
                        AddCommand = new Command(AddExecute);
            EditCommand = new Command<Todo>(EditExecute);
            DeleteCommand = new Command<Todo>(DeleteExecute);
        }

        async void AddExecute()
        {
            await Shell.Current.GoToAsync(nameof(TodoAddPage));
        }

        async void EditExecute(Todo todo)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Todo", todo }
            };
            await Shell.Current.GoToAsync(nameof(TodoAddPage), navigationParameter);
        }

        public void OnAdded(object item)
        {
            if (item is Todo todo)
            {
                _todoappBaseContext.Todo.Add(todo);
                _todoappBaseContext.SaveChanges();
                TodoList.Add(todo);
            }
        }
        
        public override async Task Reload()
        {
            CanToggled = false;            TodoList = new ObservableCollection<Todo>(_todoappBaseContext.Todo.Where(t => !t.Done));
                        CanToggled = true;        }
        
        private void DeleteExecute(Todo todo)
        {
                        TodoList.Remove(todo);
                        _todoappBaseContext.Todo.Remove(todo);
            _todoappBaseContext.SaveChanges();
        }

        [RelayCommand(CanExecute = nameof(CanToggled))]
         private  void OnToggled(object sender)
        {
            if (sender is Todo todo)
            {
                _todoappBaseContext.SaveChanges();
                if (todo.Done)
                {
                    IDispatcherTimer timer = App.Current.Dispatcher.CreateTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(50);
                    timer.IsRepeating = false;
                    timer.Tick += (s, e) =>
                    {
                                                TodoList.Remove(todo);
                                            };
                    timer.Start();
                }
            }
        }
            }
}

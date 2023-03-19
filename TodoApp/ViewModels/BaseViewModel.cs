using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoApp.ViewModels
{
    [INotifyPropertyChanged]
    public abstract partial class BaseViewModel
    {
        private bool _busy = false;
        public bool Busy
        {
            get => _busy;
            set
            {
                SetProperty(ref _busy, value);
                OnPropertyChanged("Ready");
            }
        }
        public bool Ready => !Busy;

        /// <summary>
        /// Calls when Navigatet to page
        /// </summary>
        public virtual async void  OnNavigatedTo()
        {
            await LoadPage(
              async () =>
              {
                  await Reload();
              }
            );
        }

        /// <summary>
        /// Load data for page
        /// </summary>
        /// <param name="loadPage">Reload function</param>
        /// <returns></returns>
        protected async Task LoadPage(Func<Task> loadPage)
        {
            Busy = true;
 
            await loadPage();
           
            Busy = false;
        }

        /// <summary>
        /// Reload data function
        /// </summary>
        /// <returns></returns>
        public virtual async Task Reload()
        {
            await Task.CompletedTask;
        }
    }
}

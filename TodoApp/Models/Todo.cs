
namespace TodoApp.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;

    [INotifyPropertyChanged]
    public partial class Todo
    {
        private string _name;
        private string _notes;
        private DateTime _time;
        private bool _done;
            public int TodoId { get; set; }        public int Id { get; set; }        public string Name         {
            get => _name; 
            set => SetProperty(ref _name, value); 
        }         public string Notes         {
            get => _notes; 
            set => SetProperty(ref _notes, value); 
        }         public DateTime Time         {
            get => _time; 
            set => SetProperty(ref _time, value); 
        }         public bool Done         {
            get => _done; 
            set => SetProperty(ref _done, value); 
        }             private bool _expanded = false;
    [NotMapped]
    public bool Expanded { get => _expanded; set => SetProperty(ref _expanded, value); }
    [NotMapped]
    public ICommand OnExpand { get; set; }
    public Todo()
    {
        OnExpand = new Command(onExpand);
    }

    void onExpand()
    {
        Expanded= !Expanded;
            
    }
        }

}

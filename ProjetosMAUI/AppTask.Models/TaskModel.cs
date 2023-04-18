using System.ComponentModel;

namespace AppTask.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime PrevisionDate { get; set;}


        private bool _isCompleted;
        public bool IsCompleted {
            get { return _isCompleted; }
            set {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<SubTaskModel> SubTasks { get; set; } = new List<SubTaskModel>();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
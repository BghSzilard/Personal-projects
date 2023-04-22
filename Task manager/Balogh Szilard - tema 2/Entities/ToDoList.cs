using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Balogh_Szilard___tema_2.Entities
{
    public class ToDoList : INotifyPropertyChanged
    {
        private string _title;
        private string _image;
        private string _path;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }

        public ObservableCollection<Task> Tasks { get; }

        public ObservableCollection<ToDoList> SubToDoLists { get; }

        public ToDoList()
        {
            Tasks = new ObservableCollection<Task>();
            SubToDoLists = new ObservableCollection<ToDoList>();
            Path = "";
        }

        public void AddTask(Task task)
        {
            task.Path = Path;
            task.Path = task.Path + "/" + Title;
            Tasks.Add(task);
        }

        public void AddSubToDoList(ToDoList subToDoList)
        {
            subToDoList.Path = Path;
            subToDoList.Path += "/" + Title;
            SubToDoLists.Add(subToDoList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Title;
        }
    }
}

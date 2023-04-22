using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class AddToDoListViewModel:ViewModelBase
    {
        private ToDoListServices _toDoListServices => ToDoListServices.Instance;
        private string _toDoListName;
        private string _toDoListImage;
        public ICommand AddCommand { get; }
        public string ToDoListName
        {
            get { return _toDoListName; }
            set
            {
                if (_toDoListName != value)
                {
                    _toDoListName = value;
                    OnPropertyChanged(nameof(ToDoListName));
                }
            }
        }
        public string ToDoListImage
        {
            get { return _toDoListImage; }
            set
            {
                if (_toDoListImage != value)
                {
                    _toDoListImage = value;
                    OnPropertyChanged(nameof(ToDoListImage));
                }
            }
        }
        public AddToDoListViewModel()
        {
            AddCommand = new RelayCommand(AddNewToDoList);
        }
        private void AddNewToDoList()
        {
            ToDoList newToDoList = new ToDoList();
            newToDoList.Title = _toDoListName;
            newToDoList.Image = _toDoListImage;
            _toDoListServices.AddToDoList(newToDoList);
        }
    }
}

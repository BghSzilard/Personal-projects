using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class AddSubToDoListViewModel:ViewModelBase
    {
        public ICommand AddCommand { get; }
        private ToDoListServices _toDoListServices => ToDoListServices.Instance;
        private string _subToDoListName;
        private string _subToDoListImage;
        private ToDoList _selectedToDoList;
        public AddSubToDoListViewModel()
        {
            AddCommand = new RelayCommand(AddSubToDoList);
        }
        public IEnumerable ToDoLists => _toDoListServices.GetAllToDoLists();
        public string SubToDoListName
        {
            get { return _subToDoListName; }
            set
            {
                if (_subToDoListName != value)
                {
                    _subToDoListName = value;
                    OnPropertyChanged(nameof(SubToDoListName));
                }
            }
        }
        public string SubToDoListImage
        {
            get { return _subToDoListImage; }
            set
            {
                if (_subToDoListImage != value)
                {
                    _subToDoListImage = value;
                    OnPropertyChanged(nameof(SubToDoListImage));
                }
            }
        }
        public ToDoList SelectedToDoList
        {
            get { return _selectedToDoList;}
            set
            {
                if (_selectedToDoList != value)
                {
                    _selectedToDoList = value;
                    OnPropertyChanged(nameof(SelectedToDoList));
                }
            }
        }
        public void AddSubToDoList()
        {
            ToDoList newSubToDoList = new ToDoList();
            newSubToDoList.Title = _subToDoListName;
            newSubToDoList.Image = _subToDoListName;
            _selectedToDoList.AddSubToDoList(newSubToDoList);
        }
    }
}

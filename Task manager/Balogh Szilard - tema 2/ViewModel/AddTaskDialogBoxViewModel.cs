using System.Windows.Input;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using Balogh_Szilard___tema_2.Model;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class AddTaskDialogBoxViewModel : ViewModelBase
    {
        private ToDoListServices _toDoListServices => ToDoListServices.Instance;
        private string _taskName;
        private Priority _priority;
        private string _type;
        private string _description;
        private DateTime _deadline = DateTime.Now;
        private string _selectedCategory;
        private ToDoList _selectedToDoList;
        public ToDoList SelectedToDoList
        {
            get => _selectedToDoList;
            set
            {
                if (_selectedToDoList != value)
                {
                    _selectedToDoList = value;
                    OnPropertyChanged(nameof(SelectedToDoList));
                }
            }
        }
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }
        public string TaskName
        {
            get { return _taskName; }
            set
            {
                if (_taskName != value)
                {
                    _taskName = value;
                    OnPropertyChanged(nameof(TaskName));
                }
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description= value; 
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public IEnumerable ToDoLists => _toDoListServices.GetAllToDoLists();
        public IEnumerable<Priority> PriorityOptions
        {
            get { return (Priority[])Enum.GetValues(typeof(Priority)); }
        }
        public IEnumerable<string> CategoryOptions
        {
            get { return CategoryModel.Instance.Categories; }
        }

        public Priority Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                if (_deadline != value)
                {
                    _deadline = value;
                    OnPropertyChanged(nameof(Deadline));
                }
            }
        }

        public ICommand AddCommand { get; }

        public AddTaskDialogBoxViewModel()
        {
            AddCommand = new RelayCommand(addTask);
        }
        private void addTask()
        {
            Task newTask = new Task { Deadline = Deadline, Description = Description, Title = TaskName, 
                Category = SelectedCategory, Priority = Priority};
            SelectedToDoList.AddTask(newTask);
        }
    }
}
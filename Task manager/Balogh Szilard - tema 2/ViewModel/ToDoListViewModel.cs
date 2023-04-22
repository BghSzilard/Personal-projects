using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class ToDoListViewModel : ViewModelBase
    {
        public static ObservableCollection<Task> DisplayedTasks
        {
            get => TasksToDisplay.Tasks;
            set => TasksToDisplay.Tasks = value;
        }
        private ToDoListServices _toDoListServices => ToDoListServices.Instance;
        public ICommand MoveToDoListUpCommand { get; }
        public ObservableCollection<ToDoList> ToDoLists
        {
            get { return _toDoListServices.ToDoLists; }
        }
        public ToDoList SelectedList
        {
            get { return SelectedToDoList.Current; }
            set
            {
                SelectedToDoList.Current = value;
                OnPropertyChanged(nameof(SelectedToDoList));
            }
        }
        public ToDoListViewModel()
        {
            var toDoList1 = new ToDoList() { Title = "Groceries", Image="/Images/Search.png" };
            toDoList1.Tasks.Add(new Task() { Title = "Buy milk" });
            toDoList1.Tasks.Add(new Task() { Title = "Buy bread" });

            var toDoList2 = new ToDoList() { Title = "Workout Plan" };
            toDoList2.Tasks.Add(new Task() { Title = "Run 5K" });
            toDoList2.Tasks.Add(new Task() { Title = "Do 30 pushups" });

            var toDoList3 = new ToDoList() { Title = "Home Projects" };
            toDoList3.SubToDoLists.Add(new ToDoList() { Title = "Bedroom" });
            toDoList3.SubToDoLists[0].Tasks.Add(new Task() { Title = "Paint walls" });

            _toDoListServices.AddToDoList(toDoList1);
            _toDoListServices.AddToDoList(toDoList2);
            _toDoListServices.AddToDoList(toDoList3);
        }
        public void AddToDoList(ToDoList toDoList)
        {
            _toDoListServices.AddToDoList(toDoList);
        }

        public void RemoveToDoList()
        {
            _toDoListServices.RemoveToDoList(SelectedToDoList.Current);
        }
    }
}

using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class FindTaskViewModel : ViewModelBase
    {
        private ObservableCollection<string> _items = new ObservableCollection<string>()
        {
            "Name", "Deadline",
        };
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }
        private Visibility _nameSearchTermVisibility = Visibility.Visible;

        public Visibility NameSearchTermVisibility
        {
            get { return _nameSearchTermVisibility; }
            set
            {
                if (_nameSearchTermVisibility != value)
                {
                    _nameSearchTermVisibility = value;
                    OnPropertyChanged(nameof(NameSearchTermVisibility));
                }
            }
        }
        private Visibility _deadlineVisibility = Visibility.Collapsed;

        public Visibility DeadlineVisibility
        {
            get { return _deadlineVisibility; }
            set
            {
                if (_deadlineVisibility != value)
                {
                    _deadlineVisibility = value;
                    OnPropertyChanged(nameof(DeadlineVisibility));
                }
            }
        }

        private string _selectedItem = "Name";
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                    // Handle the selected item changed event here
                    if (SelectedItem == "Deadline")
                    {
                        NameSearchTermVisibility = Visibility.Collapsed;
                        DeadlineVisibility = Visibility.Visible;

                    }
                    else
                    {
                        DeadlineVisibility = Visibility.Collapsed;
                        NameSearchTermVisibility = Visibility.Visible;
                    }

                }
            }
        }
        private string searchType;
        private string searchTerm;
        private DateTime searchDeadline = DateTime.Now;
        private ObservableCollection<Task> searchResults;

        public ICommand SearchCommand => new RelayCommand(() =>
        {
            if (SelectedItem == "Name")
            {
                StartSearch();
            }
            else
            {
                StartSearchByDeadline();
            }
        });
        public ICommand DeadlineSearchCommand { get; }
        public FindTaskViewModel()
        {
            
        }
        public ObservableCollection<Task> SearchResults
        {
            get { return searchResults; }
            set
            {
                searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }

        public string SearchType
        {
            get { return searchType; }
            set
            {
                searchType = value;
                OnPropertyChanged(nameof(SearchType));
            }
        }
        public DateTime SearchDeadline
        {
            get { return searchDeadline; }
            set
            {
                searchDeadline = value;
                OnPropertyChanged(nameof(SearchDeadline));
            }
        }
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
            }
        }

        public void Search(ToDoList toDoList)
        {
            foreach (Task task in toDoList.Tasks)
            {
                if (task.Title.Contains(SearchTerm))
                {
                    SearchResults.Add(task);
                }
            }

            foreach (ToDoList subList in toDoList.SubToDoLists)
            {
                Search(subList); // recursively search sublists
            }
        }
        public void StartSearch()
        {
            ToDoListServices toDoListServices = ToDoListServices.Instance;
            SearchResults = new ObservableCollection<Task>();

            foreach (ToDoList toDoList in toDoListServices.ToDoLists)
            {
                Search(toDoList);
            }
        }
        public void SearchByDeadline(ToDoList toDoList)
        {

            foreach (Task task in toDoList.Tasks)
            {
                if (task.Deadline != null && task.Deadline <= SearchDeadline)
                {
                    SearchResults.Add(task);
                }
            }

            foreach (ToDoList subList in toDoList.SubToDoLists)
            {
                SearchByDeadline(subList); // recursively search sublists
            }
        }

        // call the SearchByDeadline method with all the top-level ToDoLists
        public void StartSearchByDeadline()
        {
            ToDoListServices toDoListServices = ToDoListServices.Instance;
            SearchResults = new ObservableCollection<Task>();

            foreach (ToDoList toDoList in toDoListServices.ToDoLists)
            {
                SearchByDeadline(toDoList);
            }
        }
    }
}

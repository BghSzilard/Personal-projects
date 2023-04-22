using System.Windows.Input;
using System.Windows;
using Balogh_Szilard___tema_2.View;
using Balogh_Szilard___tema_2.Services;
using Microsoft.VisualBasic;
using System.IO;
using Balogh_Szilard___tema_2.Entities;
using System.Linq;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class MenuBarViewModel : ViewModelBase
    {
        public ICommand AboutCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand FindTaskCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand NewDatabaseCommand { get; }
        public ICommand NewToDoListRootCommand { get; }
        public ICommand NewSubToDoListCommand { get; }
        public ICommand MoveDownSelectedListCommand { get; }
        public ICommand MoveUpSelectedListCommand { get; }
        public ICommand RemoveToDoListCommand { get; }
        public ICommand EditToDoListCommand { get; }
        public ICommand OpenCategoryCommand { get; }
        public ICommand FilterCommand { get; }
        ToDoListServices toDoListServices = ToDoListServices.Instance;
        public ICommand ExitCommand => new RelayCommand(() => Application.Current.Shutdown());
        public MenuBarViewModel()
        {
            AboutCommand = new RelayCommand(ShowAboutMessage);
            AddTaskCommand = new RelayCommand(AddNewTask);
            FindTaskCommand = new RelayCommand(FindTask);
            SaveCommand = new RelayCommand(SaveDatabase);
            OpenCommand = new RelayCommand(OpenDatabase);
            NewDatabaseCommand = new RelayCommand(CreateNewDatabase);
            NewToDoListRootCommand = new RelayCommand(CreateNewToDoList);
            MoveDownSelectedListCommand = new RelayCommand(MoveSelectedToDoListDown);
            MoveUpSelectedListCommand = new RelayCommand(MoveSelectedToDoListUp);
            RemoveToDoListCommand = new RelayCommand(RemoveToDoList);
            EditToDoListCommand = new RelayCommand(EditToDoList);
            NewSubToDoListCommand = new RelayCommand(AddNewSubToDoList);
            OpenCategoryCommand = new RelayCommand(OpenCategory);
            FilterCommand = new RelayCommand(FilterTasks);
        }
        private void ShowAboutMessage()
        {
            MessageBox.Show("Balogh Szilard - Informatica - grupa 211 - szilard.balogh@student.unitbv.ro");
        }
        private void AddNewTask()
        {

            var addTaskDialogBoxView = new AddTaskDialogBoxView();
            var dialogWindow = new Window { Content = addTaskDialogBoxView, SizeToContent = SizeToContent.WidthAndHeight, WindowStyle = WindowStyle.ToolWindow };
            dialogWindow.ShowDialog();
        }
        private void FindTask()
        {
            var findTaskDialogView = new FindTaskView();
            var dialogWindow = new Window { Content = findTaskDialogView, SizeToContent = SizeToContent.WidthAndHeight, WindowStyle = WindowStyle.ToolWindow };
            dialogWindow.ShowDialog();
        }
        private void SaveDatabase()
        {
            string path = Interaction.InputBox("Enter the name of the database:", "Save Database", "");
            ToDoListServices toDoListServices = ToDoListServices.Instance;
            toDoListServices.SaveToDoListsToFile(path);
        }
        private void OpenDatabase()
        {
            string path = Interaction.InputBox("Enter the name of the database:", "Open Database", "");
            if (File.Exists(path))
            {
                ToDoListServices toDoListServices = ToDoListServices.Instance;
                toDoListServices.LoadToDOLIstsFromFile(path);
            }
            else
            {
                MessageBox.Show("The specified file does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void CreateNewDatabase()
        {
            ToDoListServices toDoListServices = ToDoListServices.Instance;
            toDoListServices.DeleteDatabase();
        }
        private void CreateNewToDoList()
        { 
            var addTaskDialogBoxView = new AddToDoListView();
            var dialogWindow = new Window { Content = addTaskDialogBoxView, SizeToContent = SizeToContent.WidthAndHeight, WindowStyle = WindowStyle.ToolWindow };
            dialogWindow.ShowDialog();
        }
        private void MoveSelectedToDoListDown()
        {
            var toDoLists = ToDoListServices.Instance.ToDoLists;
            var selectedToDoList = SelectedToDoList.Current;
            var selectedIndex = toDoLists.IndexOf(selectedToDoList);

            if (selectedToDoList.Path == "")
            {
                if (selectedIndex < toDoLists.Count - 1)
                {
                    toDoLists[selectedIndex] = toDoLists[selectedIndex + 1];
                    toDoLists[selectedIndex + 1] = selectedToDoList;
                }
            }
            else
            {
                var pathSegments = selectedToDoList.Path.Split('/');
                var parentPath = string.Join("/", pathSegments.Take(pathSegments.Length - 1));
                var parentList = toDoLists.First(list => list.Path == parentPath);

                var subListIndex = parentList.SubToDoLists.IndexOf(selectedToDoList);

                if (subListIndex < parentList.SubToDoLists.Count - 1)
                {
                    parentList.SubToDoLists.Move(subListIndex, subListIndex + 1);
                }
            }
        }
        private void MoveSelectedToDoListUp()
        {
            var toDoLists = ToDoListServices.Instance.ToDoLists;
            var selectedToDoList = SelectedToDoList.Current;
            var selectedIndex = toDoLists.IndexOf(selectedToDoList);
            if (selectedToDoList.Path == "")
            {
                if (selectedIndex > 0)
                {
                    toDoLists[selectedIndex] = toDoLists[selectedIndex - 1];
                    toDoLists[selectedIndex - 1] = selectedToDoList;
                }
            }else
            {
                var pathSegments = selectedToDoList.Path.Split('/');
                var parentPath = string.Join("/", pathSegments.Take(pathSegments.Length - 1));
                var parentList = toDoLists.First(list => list.Path == parentPath);

                var subListIndex = parentList.SubToDoLists.IndexOf(selectedToDoList);

                if (subListIndex > 0)
                {
                    parentList.SubToDoLists.Move(subListIndex, subListIndex - 1);
                }
            }
        }
        public void RemoveToDoList()
        {
            toDoListServices.RemoveToDoList(SelectedToDoList.Current);
        }
        public void EditToDoList()
        {
            string imagePath = Interaction.InputBox("New image path", "Enter the new image path", "");
            SelectedToDoList.Current.Image = imagePath;
        }
        public void AddNewSubToDoList()
        {
            var addTaskDialogBoxView = new AddSubToDoListView();
            var dialogWindow = new Window
            {
                Content = addTaskDialogBoxView,
                SizeToContent = SizeToContent.Manual,
                Width = 400,
                Height = 200,
                WindowStyle = WindowStyle.ToolWindow
            };
            dialogWindow.ShowDialog();

        }
        public void OpenCategory()
        {
            var addTaskDialogBoxView = new CategoryView();
            var dialogWindow = new Window
            {
                Content = addTaskDialogBoxView,
                SizeToContent = SizeToContent.Manual,
                Width = 400,
                Height = 200,
                WindowStyle = WindowStyle.ToolWindow
            };
            dialogWindow.ShowDialog();
        }
        public void FilterTasks()
        {

        }
    }
}
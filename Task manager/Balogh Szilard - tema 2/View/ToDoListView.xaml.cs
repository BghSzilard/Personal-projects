using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using Balogh_Szilard___tema_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Balogh_Szilard___tema_2.View
{
    /// <summary>
    /// Interaction logic for ToDoListView.xaml
    /// </summary>
    public partial class ToDoListView : UserControl
    {
        public ToDoListView()
        {
            InitializeComponent();
        }
        private void SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is ToDoList selectedList)
            {
                SelectedToDoList.Current = selectedList;
                TasksToDisplay.Tasks.Clear();
                for (int i = 0; i < selectedList.Tasks.Count; i++)
                {
                    TasksToDisplay.Tasks.Add(selectedList.Tasks[i]);
                }
            }
        }
    }
}
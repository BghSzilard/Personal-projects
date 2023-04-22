using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balogh_Szilard___tema_2.Model
{
    public class ToDoListModel
    {
        private static readonly ObservableCollection<ToDoList> toDoLists = ToDoListServices.Instance.ToDoLists;
        public static bool IsToDoListNameTaken(string title)
        {
            foreach (ToDoList toDoList in toDoLists)
            {
                if (toDoList.Title == title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

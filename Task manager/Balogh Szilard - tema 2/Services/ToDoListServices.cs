using Balogh_Szilard___tema_2.Entities;
using Balogh_Szilard___tema_2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Balogh_Szilard___tema_2.Services
{
    public class ToDoListServices
    {
        private static readonly ToDoListServices instance = new ToDoListServices();
        public static ToDoListServices Instance
        {
            get { return instance; }
        }

        private readonly ObservableCollection<ToDoList> toDoLists;

        public ObservableCollection<ToDoList> ToDoLists
        {
            get { return toDoLists; }
        }

        private ToDoListServices()
        {
            toDoLists = new ObservableCollection<ToDoList>();
        }

        public void AddToDoList(ToDoList list)
        {
            if (ToDoListModel.IsToDoListNameTaken(list.Title))
            {
                MessageBox.Show("There is already a list with the given name");
            }else
            {
                toDoLists.Add(list);
            }
        }

        public void RemoveToDoList(ToDoList list)
        {
            toDoLists.Remove(list);
        }
        public List<ToDoList> GetAllToDoLists()
        {
            List<ToDoList> allToDoLists = new List<ToDoList>();
            GetAllToDoListsRecursive(ToDoLists, allToDoLists);
            return allToDoLists;
        }
        private void GetAllToDoListsRecursive(IEnumerable<ToDoList> toDoLists, List<ToDoList> allToDoLists)
        {
            foreach (ToDoList toDoList in toDoLists)
            {
                allToDoLists.Add(toDoList);
                GetAllToDoListsRecursive(toDoList.SubToDoLists, allToDoLists);
            }
        }
        public void SaveToDoListsToFile(string filePath)
        {
            string json = JsonConvert.SerializeObject(ToDoLists);
            File.WriteAllText(filePath, json);
        }
        public void LoadToDOLIstsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var lists = JsonConvert.DeserializeObject<ObservableCollection<ToDoList>>(json);
                ToDoLists.Clear();
                foreach (var list in lists)
                {
                    ToDoLists.Add(list);
                }
            }
        }
        public void DeleteDatabase()
        {
            toDoLists.Clear();
        }
    }
}
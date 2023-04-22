using Balogh_Szilard___tema_2.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Balogh_Szilard___tema_2.Services
{
    public static class TasksToDisplay
    {
        public static ObservableCollection<Task> Tasks = new ObservableCollection<Task>();
    }
}
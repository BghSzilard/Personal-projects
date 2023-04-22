using System;

namespace Balogh_Szilard___tema_2.Entities
{
    public enum Priority
    {
        Low,
        Medium,
        High,
    }
    public enum TaskState
    {
        Completed,
        InProgress,
        NotStarted
    }
   
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public Priority Priority { get; set; }
        public string Category { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Path { get; set; }
        public Task() {
            Path = "";
        }
    }
}
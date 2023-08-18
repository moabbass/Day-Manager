using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_Manager.MVVM.Model
{
    public class Task
    {
        public string description { get; set; }
        public TaskType type { get; set; }
        public DateTime dateTime { get; set; }
        public bool done { get; set; }

        public Task(string description, TaskType type, DateTime dateTime)
        {
            this.description = description;
            this.type = type;
            this.dateTime = dateTime;
            this.done = false;
        }
    }
}

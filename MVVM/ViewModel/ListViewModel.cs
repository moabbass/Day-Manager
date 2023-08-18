using Day_Manager.Core;
using Day_Manager.MVVM.Model;
using Day_Manager.MVVM.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Documents;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows;

namespace Day_Manager.MVVM.ViewModel
{
    public class ListViewModel
    {
        //public List<Model.Task> tasks { get; set; }
        public string strWorkPath;
        public string jsonFilePath;
        private RelayCommand addTaskViewCommand{ get; set; }
        public ObservableCollection<Model.Task> taskList { get; } = new ObservableCollection<Model.Task>();

        public ICommand AddTaskViewCommand
        {
            get
            {
                if (addTaskViewCommand == null)
                {
                    addTaskViewCommand = new RelayCommand(param => moveToAddTaskView());
                }
                return addTaskViewCommand;
            }
        }

        

        public ListViewModel()
        {
            addTaskViewCommand = new RelayCommand(param => moveToAddTaskView());            
            

            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            jsonFilePath = System.IO.Path.Combine(strWorkPath, "Tasks.JSON");            
            //Model.Task t = new Model.Task("test", TaskType.Daily, DateTime.Today);
            //App.tasks.Add(t);
            loadTasks();

            ListChangedEventHandler listC = new ListChangedEventHandler();
            App.tasksChanged.ListChanged += loadTasksToObservableCollection;
        }

        public void convertToJson()
        {
            var json = JsonConvert.SerializeObject(App.tasks);
            if (!File.Exists(jsonFilePath))
            {

                System.IO.File.AppendAllText(jsonFilePath, json);
            }

        }

        public void loadTasks()
        {
            taskList.Clear();
            foreach (var task in App.tasks)
            {
                taskList.Add(task);
            }
            Console.WriteLine(taskList.Count);
        }

        public void loadTasksToObservableCollection(object source, EventArgs e)
        {
            loadTasks();
            
        }



        public void readJsonFile()
        {
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                App.tasks = JsonConvert.DeserializeObject<List<Model.Task>>(json);
            }
        }

        public void moveToAddTaskView()
        {
            AddTasksView addTask = new AddTasksView();
            //AddTaskView addTask = new AddTaskView();
            addTask.Show();
        }

        public void test()
        {

        }


    }
}

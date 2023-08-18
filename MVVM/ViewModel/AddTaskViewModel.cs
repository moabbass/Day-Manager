using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_Manager.Core;
using System.Windows.Input;
using Day_Manager.MVVM.Model;
using Day_Manager.MVVM.View;
using Task = Day_Manager.MVVM.Model.Task;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Security.RightsManagement;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Caliburn.Micro;

namespace Day_Manager.MVVM.ViewModel
{
    public class AddTaskViewModel : ICloseWindows
    {
        private string _descriptionTxt;
        public string DescriptionTxt
        {
            get { return _descriptionTxt; }
            set
            {
                if (_descriptionTxt != value)
                {
                    _descriptionTxt = value;
                    onTextChanged(DescriptionTxt);
                }                
            }
        }

        public event PropertyChangedEventHandler TextChanged;

        protected virtual void onTextChanged(string propertyName)
        {
            TextChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public BindableCollection<string> taskType { get; set; }

        private string _selectedType;

        public string selectedType
        {
            get { return _selectedType; }
            set 
            {     
                if (_selectedType != value)
                {

                }
                _selectedType = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged(this, new propertyChangedEventArgs(propertyName));
        //}



        //public ObservableCollection<string> taskType
        //{
        //    get { return taskt; }
        //    set
        //    {
        //        taskt = value;
        //        NotifyPropertyChanged();
        //    }
        //}


        //public event PropertyChangedEventHandler PropertyChanged;



        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //public string selectedType;


        public TaskType tType;
        
        public DateTime dTime;       

        private RelayCommand addTaskCommand { get; set; }
        private RelayCommand closeCommand { get; set; }


        public Action Close {  get; set; }

        public ICommand AddTaskCommand
        {
            get
            {
                if (addTaskCommand == null)
                {
                    addTaskCommand = new RelayCommand(param => addTask());
                }
                return addTaskCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(param => closeView());
                }
                return closeCommand;
            }
        }
        public AddTaskViewModel()
        {
            taskType = new BindableCollection<string>();
            taskType.Add("Daily");
            taskType.Add("Scheduled");


            addTaskCommand = new RelayCommand(param => addTask());
            

            //listC.ListChanged += onListChanged;
        }

        public void addTask()
        {
            setTtype();

            //App.tasks.Add(View.AddTasksView.);
            if (DescriptionTxt != null && DescriptionTxt != "Description") 
            {
                Console.WriteLine(taskType.ToString());
                if (taskType != null ) 
                {
                    if(dTime!= null)
                    {                       
                        App.tasks.Add( new Task(DescriptionTxt, tType,dTime));
                    }
                    else
                    {
                        App.tasks.Add(new Task(DescriptionTxt, tType, DateTime.Now));
                    }
                }                
                Close?.Invoke();
                App.tasksChanged.OnListChanged(null);
            }
            else
            {
                // pop up a message promting user to fill all required fields
            }            
        }

        //public void onListChanged(object source, EventArgs e)
        //{
        //    addTask(); 
        //}


        public void closeView()
        {
            Close?.Invoke();
        }

        public void setTtype()
        {
            //taskType=taskTypeCbx.SelectedItem.ToString();

            if (selectedType == "Daily")
            {
                tType = TaskType.Daily;
            }
            if (selectedType == "Scheduled")
            {
                tType = TaskType.Scheduled;
            }
        }
    }


    interface ICloseWindows
    {
        Action Close { get; set; }
    }
}

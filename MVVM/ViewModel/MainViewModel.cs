using Day_Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_Manager.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand listViewCommand { get; set; }
        public RelayCommand CalenderViewCommand { get; set; }
        public ListViewModel listVM { get; set; }
        public CalenderViewModel CalVM { get; set; }
        private object _currentView;
        ListChangedEventHandler listC = new ListChangedEventHandler();
        //public List<Model.Task> tasks;


        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            //tasks = new List<Model.Task>();
            listVM=new ListViewModel();
            CalVM = new CalenderViewModel();
            CurrentView = listVM;

            listViewCommand = new RelayCommand(o =>
            {
                CurrentView = listVM;
            });

            CalenderViewCommand = new RelayCommand(o =>
            {
                CurrentView = CalVM;
            });



        }
    }
}

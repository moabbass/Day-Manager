using Day_Manager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ListChangedEventHandler = Day_Manager.Core.ListChangedEventHandler;

namespace Day_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<MVVM.Model.Task> tasks;
        public static ListChangedEventHandler tasksChanged = new ListChangedEventHandler();

    }
}

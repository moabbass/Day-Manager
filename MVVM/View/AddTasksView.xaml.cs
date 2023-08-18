using Day_Manager.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Day_Manager.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddTasksView.xaml
    /// </summary>
    public partial class AddTasksView : Window
    {
        public AddTasksView()
        {
            this.DataContext = new AddTaskViewModel();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }

        
    }
}

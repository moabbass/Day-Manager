using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_Manager.Core
{
    public class ListChangedEventHandler
    {
        public event EventHandler ListChanged;
        

        public virtual void OnListChanged(EventArgs e)
        {
            //if(ListChanged != null)
            //{
            //    ListChanged(this, EventArgs.Empty);
            //}
            EventHandler handler= ListChanged;
            handler?.Invoke(this, e);
        }

        public delegate void ListEventHandler(object sender, EventArgs e);
    }
}

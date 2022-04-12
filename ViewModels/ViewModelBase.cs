using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        protected void SetPropertyValue<T>(ref T property, T value)
        {
            var propertyName = new StackTrace().GetFrame(1).GetMethod().Name;

            property = value;
            OnPropertyChanged(propertyName);
        }
        protected void SetPropertyValue<T>(ref T property, T value,Func<bool> myAction)
        {
            var propertyName = new StackTrace().GetFrame(1).GetMethod().Name;

            property = value;
            OnPropertyChanged(propertyName);

            myAction();
        }
    }
}

using ReserveRoom.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReserveRoom.ViewModels
{
   public class NormalClass : ViewModelBase
    {

        private string _message;

        public ICommand ClickMeCommand { get; set; }

        public string Message
        {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public NormalClass()
        {

            Message = "My Name is Maroua";
            ClickMeCommand = new ClickMeCommand(GetMessage);

        }
    
        public void GetMessage()
        {
            Message ="I'm a message without parameter and generic type and return type";
        }
        public DateTime GetDateTime(DateTime dateTime)
        {
             this.Message = dateTime.ToString();
            return DateTime.Now;
        }
    }
}

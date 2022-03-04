using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Commands
{
    public class ClickMeCommand : CommandBase
    {

        public delegate T MyAction<T>(T m);
        public delegate void MyAction();
        public MyAction<DateTime> MyStrAction { get; }
        public MyAction MyAction1 { get; }


         public ClickMeCommand(MyAction<DateTime> myAction)
         {
            MyStrAction = myAction;
         }

        public ClickMeCommand(MyAction myAction)
        {
            MyAction1 = myAction;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public int Counter = 0;
        public override void Execute(object parameter)
        {
            //MyStrAction(DateTime.Now);
            MyAction1();
        }
       


    }
}

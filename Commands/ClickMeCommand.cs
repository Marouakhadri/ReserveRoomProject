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

        public MyAction<DateTime> MyStrAction { get; }

         public ClickMeCommand(MyAction<DateTime> myAction)
         {
            MyStrAction = myAction;
         }


        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public int Counter = 0;
        public override void Execute(object parameter)
        {
            MyStrAction(DateTime.Now);
        }
       


    }
}

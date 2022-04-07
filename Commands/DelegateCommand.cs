using ReserveRoom.Stores;
using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReserveRoom.Commands
{
    public class DelegateCommand : CommandBase
    {
        private Action executeMethod;

        private bool canSubmited;

        public Action ExecuteMethod { get => executeMethod; set => executeMethod = value; }
        public bool CanSubmited { get => canSubmited; set => canSubmited = value; }

        public DelegateCommand(Action submitedMethod)
        {
            this.ExecuteMethod = submitedMethod;
            this.CanSubmited = canSubmited;
        }

        public override void Execute(object parameter)
        {
            ExecuteMethod();
        }
    }
}

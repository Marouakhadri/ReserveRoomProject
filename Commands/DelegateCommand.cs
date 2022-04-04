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
        private Action submitedMethod;
        private bool canSubmited;

        public Action SubmitedMethod { get => submitedMethod; set => submitedMethod = value; }
        public bool CanSubmited { get => canSubmited; set => canSubmited = value; }

        //public DelegateCommand(Action submitedMethod) : this(submitedMethod, true)
        //{
        //}
        public DelegateCommand(Action submitedMethod)
        {
            this.SubmitedMethod = submitedMethod;
            this.CanSubmited = canSubmited;
        }
        public DelegateCommand(Action submitedMethod,bool tr=true)
        {
            this.SubmitedMethod = submitedMethod;
            this.CanSubmited = canSubmited;
        }



        public override void Execute(object parameter)
        {
            SubmitedMethod();
        }
    }
}

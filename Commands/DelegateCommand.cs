using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReserveRoom.Commands
{
    public class DelegateCommand : ICommand
    {
        private Action submitedMethod;
        private bool canSubmited;

        public Action SubmitedMethod { get => submitedMethod; set => submitedMethod = value; }
        public bool CanSubmited { get => canSubmited; set => canSubmited = value; }        

        public DelegateCommand(Action submitedMethod, bool canSubmited)
        {
            this.SubmitedMethod = submitedMethod;
            this.CanSubmited = canSubmited;
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return CanSubmited;
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        public void Execute(object parameter)
        {
            SubmitedMethod();
        }
    }
}

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
        private readonly NavigationStore _navigationStore;

        private readonly Func<ViewModelBase> _creatViewModel;

        private Action submitedMethod;
        private bool canSubmited;

        public Action SubmitedMethod { get => submitedMethod; set => submitedMethod = value; }
        public bool CanSubmited { get => canSubmited; set => canSubmited = value; }

        //public DelegateCommand(Action submitedMethod) : this(submitedMethod, true)
        //{

        //}

        public DelegateCommand (NavigationStore navigationStore, Func<ViewModelBase> CreatViewModel)
        {
            _navigationStore = navigationStore;
            _creatViewModel = CreatViewModel;
        }
        public DelegateCommand(Action submitedMethod)
        {
            this.SubmitedMethod = submitedMethod;
            this.CanSubmited = canSubmited;
        }

 

        public override void Execute(object parameter)
        {
            if (SubmitedMethod != null)
            {
                SubmitedMethod();
            }else
            {
                _navigationStore.CurrentView = _creatViewModel();
            }

           
        }
    }
}

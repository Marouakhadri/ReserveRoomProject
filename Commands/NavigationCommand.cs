using ReserveRoom.Stores;
using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Commands
{
    public class NavigationCommand : CommandBase

    {
         private readonly NavigationStore _navigationStore;

         public NavigationCommand(NavigationStore navigationStore)
         {
            _navigationStore = navigationStore;
         }
         public override void Execute(object parameter)
         {
            _navigationStore.CurrentView = new MakeReservationViewModel(new Models.Hotel(""));
         }
    }
}

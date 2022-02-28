using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
       public ViewModelBase CurrentView { get;}

        public MainViewModel()
        {
            //CurrentView = new MakeReservationViewModel();
            CurrentView = new ReservationListingViewModel();

        }
    }
}

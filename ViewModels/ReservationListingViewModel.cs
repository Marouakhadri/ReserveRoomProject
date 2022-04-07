using ReserveRoom.Commands;
using ReserveRoom.Models;
using ReserveRoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReserveRoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<ViewModelBase> _creatViewModel;

        public void CancelMethod()
        {
            _navigationStore.CurrentView = _creatViewModel();
        }

        public ReservationListingViewModel(NavigationStore navigationStore, Func<MakeReservationViewModel> creatMakeReservationViewModel)
        {
            _navigationStore = navigationStore;
            _creatViewModel = creatMakeReservationViewModel;

            NavigateToMakeReservationCommand = new DelegateCommand(CancelMethod);

            reservationList = new ObservableCollection<ReservationViewModel>();

            reservationList.Add(new ReservationViewModel(new Reservation(new RoomID(1, 4), "Maroua", DateTime.Now, DateTime.Now)));
            reservationList.Add(new ReservationViewModel(new Reservation(new RoomID(1, 3), "Mary", DateTime.Now, DateTime.Now)));
            reservationList.Add(new ReservationViewModel(new Reservation(new RoomID(1, 3), "Mary", DateTime.Now, DateTime.Now)));

        }

        private readonly ObservableCollection<ReservationViewModel> reservationList;
        public IEnumerable<ReservationViewModel> Reservations => reservationList;
        public DelegateCommand NavigateToMakeReservationCommand { get; }

    }
}

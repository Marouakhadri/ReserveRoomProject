using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReserveRoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly Hotel _hotel;
        private readonly MakeReservationViewModel _makeReservationViewModel;

        public MakeReservationCommand( )
        {
            
        }

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            _makeReservationViewModel.PropertyChanged += OnViewModelChange;
        }

        private void OnViewModelChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UserName"
                || e.PropertyName == nameof(_makeReservationViewModel.FloorNumber)
                || e.PropertyName == nameof(MakeReservationViewModel.RoomNumber)
                || e.PropertyName == nameof(MakeReservationViewModel.StartDate)

                )
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {

            return string.IsNullOrEmpty(_makeReservationViewModel.UserName) == false
                && _makeReservationViewModel.FloorNumber > 0
                && _makeReservationViewModel.RoomNumber > 0
                && _makeReservationViewModel.EndDate >= _makeReservationViewModel.StartDate
                && base.CanExecute(parameter);

        }

        public override void Execute(object parameter)
        {
            Reservation reservation = new Reservation(new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.UserName,_makeReservationViewModel.StartDate,_makeReservationViewModel.EndDate);
            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Sucssefuly reserved room", "sucsseful",MessageBoxButton.OK);
            }
            catch(ReservationConflictException)
            {
                MessageBox.Show("This room is already taken","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

    }
}

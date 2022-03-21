using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
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
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.UserName) && base.CanExecute(parameter);
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

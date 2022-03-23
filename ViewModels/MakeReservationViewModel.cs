using ReserveRoom.Commands;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace ReserveRoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {

        private string _userName;
        private int _floorNumber;
        private int _roomNumber;
        private DateTime _startDate;
        private DateTime _endDate;
        private Hotel _hotel;

        public MakeReservationViewModel(Hotel hotel)
        {
            //SubmitCommand = new MakeReservationCommand(this, hotel);
            _hotel = hotel;
            SubmitCommand = new DelegateCommand(SubmitedMethod, CanSubmited);
            this.PropertyChanged += MakeReservationViewModel_PropertyChanged;


          /// CancelCommand = new CancelMakeReservationCommand();



        }

        private void MakeReservationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SubmitCommand.OnCanExecuteChanged();    
        }

        public void SubmitedMethod()
        {
            Reservation reservation = new Reservation(new RoomID(FloorNumber, RoomNumber),
                UserName, StartDate, EndDate);
            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Sucssefuly reserved room", "sucsseful", MessageBoxButton.OK);
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool CanSubmited()
        {
           return this.UserName.IsNotNullOrWhiteSpace()
                && FloorNumber > 0
                && RoomNumber > 0
                && EndDate >= StartDate;
        }


        public DelegateCommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
             
            }
        }

        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        public int RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

    }
}

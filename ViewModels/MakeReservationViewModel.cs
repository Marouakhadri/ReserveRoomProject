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
        private bool _isEnabled;

        public bool IsEnabled {
            get {
                return _isEnabled;
            }
            set {
                _isEnabled = value;
                OnPropertyChanged("IsEnable");
            } 
        }
        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public MakeReservationViewModel(Hotel hotel)
        {
            //SubmitCommand = new MakeReservationCommand(this, hotel);
            _hotel = hotel;
            SubmitCommand = new DelegateCommand(SubmitedMethod,IsEnabled);
            this.PropertyChanged += MakeReservationViewModel_PropertyChanged;


            /// CancelCommand = new CancelMakeReservationCommand();

        }


        public void ckeckValidity()
        {
            if (this.UserName.IsNotNullOrWhiteSpace()
                && FloorNumber > 0
                && RoomNumber > 0
                && EndDate >= StartDate)
            {
                IsEnabled = true;
            }else
            {
                IsEnabled=false;
            }

        }
        private void MakeReservationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //SubmitCommand.OnCanExecuteChanged();
            ckeckValidity();
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
                && EndDate > StartDate;
        }


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
                //IsEnabled = true;

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

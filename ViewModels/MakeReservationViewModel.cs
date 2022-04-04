﻿using ReserveRoom.Commands;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using ReserveRoom.Stores;
using System;
using System.Windows;
using System.Windows.Controls;
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
        private bool _isFormValid=false;
        private string _messageError = " UserName is required";
        private int _colorState;
       
        public DelegateCommand SubmitCommand { get; set; }
        public NavigationCommand CancelCommand { get; set; }

        public MakeReservationViewModel(Hotel hotel, NavigationStore navigationStore, Func<ReservationListingViewModel> creatReservationListingViewModel)
        {
            //SubmitCommand = new MakeReservationCommand(this, hotel);
            _hotel = hotel;
            SubmitCommand = new DelegateCommand(SubmitedMethod);
            this.PropertyChanged += MakeReservationViewModel_PropertyChanged;

            CancelCommand = new  NavigationCommand(navigationStore, creatReservationListingViewModel);
            /// CancelCommand = new CancelMakeReservationCommand();

        }

        private readonly NavigationStore _navigationStore;
        public void ReservationCanceled()
        {

            _navigationStore.CurrentView = new MakeReservationViewModel(_hotel);
        }
        public string MessageError
        {
            get { return _messageError;  }
            set 
            {
                if (_messageError != value)
                {
                    _messageError = value;
                    OnPropertyChanged("MessageError");
                }
              
            }
        }
        public int ColorState
        {
            get { return _colorState; }
            set 
            {
                if (_colorState != value)
                {
                    _colorState = value; 
                    OnPropertyChanged("ColorState"); 
                }
            }
        }

        public bool IsFormValid
        {
            get
            {
                return _isFormValid;
            }
            set
            {
                if (_isFormValid!= value)
                {
                    _isFormValid = value;
                    OnPropertyChanged("IsFormValid");
                }
            }
        } 
        //public void ValidateOnly<TProperty>(ref TProperty propertyName , System.ComponentModel.PropertyChangedEventArgs e)
        //{
            //if (e.PropertyName == propertyName)
            //{
            //    if (UserName.IsNotNullOrWhiteSpace())
            //    {
            //        MessageError = propertyName + " is required";
            //    }
            //    else
            //    {
            //        MessageError = "";
            //    }
            //}
        //}

        public void CkeckValidity()
        {
            if (this.UserName.IsNotNullOrWhiteSpace()
               && this.FloorNumber != 0
               && this.RoomNumber != 0
               && this.EndDate >= this.StartDate)
            {
                IsFormValid = true;
                ColorState = 1;
            }
            else
            {
                IsFormValid = false;
                ColorState = 0;
            }

        }
        private void MakeReservationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //ValidateOnly(ref _userName, e);

            if (!UserName.IsNotNullOrWhiteSpace())
            {
                MessageError =  " UserName is required";
            }
            else
            {
                MessageError = "";
            }

            if (e.PropertyName != nameof(IsFormValid))
            {
                CkeckValidity();
            }
        }

        public void SubmitedMethod()
        {
            if (this.IsFormValid)
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
            else
            {
                MessageBox.Show("Fi9 m3ana");
            }
        }
        //public bool CanSubmited()
        //{
        //   return this.UserName.IsNotNullOrWhiteSpace()
        //        && FloorNumber > 0
        //        && RoomNumber > 0
        //        && EndDate > StartDate;
        //}


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

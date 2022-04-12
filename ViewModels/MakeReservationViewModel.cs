using ReserveRoom.Commands;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using ReserveRoom.Stores;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReserveRoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {

        private string _userName;
        private int? _floorNumber;
        private int? _roomNumber;
        private DateTime _startDate= DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddDays(1);
        private Hotel _hotel;
        private bool _isFormValid=false;
        private string _messageError = " UserName is required";
        private int _colorState=1;
       
        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public MakeReservationViewModel(Hotel hotel, NavigationStore navigationStore, Func<ReservationListingViewModel> creatReservationListingViewModel)
        {
            _hotel = hotel;
            SubmitCommand = new DelegateCommand(SubmitedMethod);
            this.PropertyChanged += MakeReservationViewModel_PropertyChanged;
            CancelCommand = new DelegateCommand(CancelMethod);
            _navigationStore = navigationStore;
            _creatViewModel = creatReservationListingViewModel;
        }


        private readonly NavigationStore _navigationStore;

        private readonly Func<ViewModelBase> _creatViewModel;

        public void CancelMethod()
        {
            _navigationStore.CurrentView = _creatViewModel();
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

        public void CkeckValidity()
        {
            if (!this.UserName.IsNotNullOrWhiteSpace())
            {
                MessageError = " UserName is required";
                ColorState = 1;
            }
            else
            {
                MessageError = "UserName is valid";
                ColorState = 0;
            }
            if (this.UserName.IsNotNullOrWhiteSpace()
               && this.FloorNumber != null
               && this.RoomNumber != null
               && this.EndDate >= this.StartDate)
            {
                IsFormValid = true;
               
            }
            else
            {
                IsFormValid = false;
            }

        }
        private void MakeReservationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if (e.PropertyName != nameof(ColorState))
            //{
            //    if (!UserName.IsNotNullOrWhiteSpace())
            //    {
                    
            //        MessageError = " UserName is required";
                  
            //    }
            //    else
            //    {
                   
            //        MessageError = "UserName is valid";
                    
            //    }
            //}
           

            if (e.PropertyName != nameof(IsFormValid))
            {
                CkeckValidity();
            }
        }

        public void SubmitedMethod()
        {
            if (this.IsFormValid)
            {
                Reservation reservation = new Reservation(new RoomID(FloorNumber.Value, RoomNumber.Value),
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

        public int? FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
         {
                
                _floorNumber = value;
                //OnPropertyChanged(nameof(FloorNumber));
                SetPropertyValue(ref _floorNumber, value);

            }
        }

        private bool NumberValidationTextBox()
        {
            Regex regex = new Regex("[^0-9]+");

            if (regex.IsMatch(FloorNumber.Value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int? RoomNumber
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

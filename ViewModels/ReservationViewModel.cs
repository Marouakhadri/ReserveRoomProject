using ReserveRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        public ReservationViewModel(Reservation reservation)
        {
            this.reservation = reservation;
        }

        public Reservation reservation { get;}

        public string RoomID => reservation.RoomID?.ToString();
        public string UserName => reservation.UserName;
        public DateTime StartTime => reservation.StartTime;
        public DateTime EndTime => reservation.EndTime;

       
    }
}

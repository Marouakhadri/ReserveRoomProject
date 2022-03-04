using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>

        public Hotel(string name)
        {
            Name=name;
            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get the reservations All Resident
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The reservations for the user.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }
        /// <summary>
        /// Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        /// <exception cref="ReservationConflitException"
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}

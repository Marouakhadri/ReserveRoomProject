using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Models
{
    public class Reservation
    {

        public Reservation(RoomID roomID, string userName, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            UserName = userName;
            StartTime = startTime;
            EndTime = endTime;

        }
        public RoomID RoomID { get; }
        public string UserName { get; set; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public TimeSpan Length => EndTime - StartTime;
        public TimeSpan LengthT => EndTime.Subtract(StartTime);

      
        internal bool Conflicts(Reservation reservation)
        {
            if (!reservation.RoomID.Equals(RoomID))
            {
                return true;
            }

            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}

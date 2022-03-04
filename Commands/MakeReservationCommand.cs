using ReserveRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private Hotel _hotel;

        public MakeReservationCommand()
        {
        }

        public MakeReservationCommand(Hotel hotel)
        {
            _hotel = hotel;
        }

        public override void Execute(object parameter)
        {
            // commit A

        }

    }
}

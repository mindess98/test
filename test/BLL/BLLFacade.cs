using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;
using DAL;

namespace BLL
{
    public class BLLFacade
    {
        private DALFacade _dalFacade;

        public BLLFacade()
        {
            _dalFacade = new DALFacade();
        }

        public IService<Guest> GetGuestService { get { return new GuestService(_dalFacade); }  }

        public IService<Reservation> GetReservationService { get { return new ReservationService(_dalFacade); } }

        public IService<RoomType> GetRoomTypeService { get { return new RoomTypeService(_dalFacade); } }

        public IService<Room> GetRoomService { get { return new RoomService(_dalFacade); } }
    }
}

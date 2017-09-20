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
        
        public IService<Guest> GetGuestService { get { return new GuestService(new DALFacade()); }  }

        public IService<Reservation> GetReservationService { get { return new ReservationService(new DALFacade()); } }

        public IService<RoomType> GetRoomTypeService { get { return new RoomTypeService(new DALFacade()); } }

        public IService<Room> GetRoomService { get { return new RoomService(new DALFacade()); } }
    }
}

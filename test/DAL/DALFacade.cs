using DAL.Repositories;
using DAL.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using test.Entities;

namespace DAL
{
    public class DALFacade
    {
        public IUnitofWork<Room> GetRoomUoW { get { return new RoomUoW(); } }
        public IUnitofWork<RoomType> GetRoomTypeUoW { get { return new RoomTypeUoW(); } }
        public IUnitofWork<Guest> GetGuestUoW { get { return new GuestUoW(); } }
        public IUnitofWork<Reservation> GetReservationUoW { get { return new ReservationUoW(); } }

        public IUoW UnitOfWork { get { return new UnitOfWork(); } }
        
    }
}

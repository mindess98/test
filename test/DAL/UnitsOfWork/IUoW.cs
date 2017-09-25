using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Entities;

namespace DAL.UnitsOfWork
{
    public interface IUoW : IDisposable
    {
        IRepository<Room> RoomRepository { get; }
        IRepository<Reservation> ReservationRepository { get; }
        IRepository<RoomType> RoomTypeRepository { get; }
        IRepository<Guest> GuestRepository { get; }

        int Complete();
    }
}

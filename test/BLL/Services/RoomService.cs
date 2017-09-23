using DAL;
using System;
using System.Collections.Generic;
using test.Entities;

namespace BLL.Services
{
    class RoomService : IService<Room>
    {
        private DALFacade _facade;
        public RoomService(DALFacade facade)
        {
            _facade = facade;
        }
        public Room Create(Room t)
        {
            using (var uow = _facade.GetRoomUoW)
            {
                var newRoom= uow.Repository.Create(t);
                uow.Complete();
                return newRoom;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.GetRoomUoW)
            {
                var room = uow.Repository.Delete(Id);
                uow.Complete();
                return room;
            }
        }

        public IEnumerable<Room> GetAll()
        {
            using (var uow = _facade.GetRoomUoW)
            {
                var rooms = uow.Repository.GetAll();
                uow.Complete();
                return rooms;
            }
        }

        public Room GetById(int Id)
        {
            using (var uow = _facade.GetRoomUoW)
            {
                var room = uow.Repository.GetById(Id);
                uow.Complete();
                return room;
            }
        }

        public Room Update(Room t)
        {
            using (var uow = _facade.GetRoomUoW)
            {
                Room ro = uow.Repository.GetById(t.Id);
                ro.Name = t.Name;
                ro.Price = t.Price;
                ro.Reservation = t.Reservation;
                ro.ReservationId = t.ReservationId;
                ro.RoomType = t.RoomType;
                ro.RoomTypeId = t.RoomTypeId;
                return ro;
            }
           
        }
    }
}

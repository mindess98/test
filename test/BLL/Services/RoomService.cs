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
            throw new NotImplementedException();
        }
    }
}

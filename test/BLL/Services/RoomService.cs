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
            using (var uow = _facade.UnitOfWork)
            {
                var newRoom= uow.RoomRepository.Create(t);
                uow.Complete();
                return newRoom;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var room = uow.RoomRepository.Delete(Id);
                uow.Complete();
                return room;
            }
        }

        public ICollection<Room> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rooms = uow.RoomRepository.GetAll();
                uow.Complete();
                return rooms;
            }
        }

        public Room GetById(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var room = uow.RoomRepository.GetById(Id);
                uow.Complete();
                return room;
            }
        }

        public Room Update(Room t)
        {
            using (var uow = _facade.UnitOfWork)
            {
                Room ro = uow.RoomRepository.Update(t);
                uow.Complete();
                return ro;
            }
           
        }
    }
}

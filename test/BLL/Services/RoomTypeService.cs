using DAL;
using System;
using System.Collections.Generic;
using test.Entities;

namespace BLL.Services
{
    class RoomTypeService : IService<RoomType>
    {
        private DALFacade _facade;
        public RoomTypeService(DALFacade facade)
        {
            _facade = facade;
        }
        public RoomType Create(RoomType t)
        {
            using (var uow = _facade.GetRoomTypeUoW)
            {
                var newRoomType = uow.Repository.Create(t);
                uow.Complete();
                return newRoomType;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.GetRoomTypeUoW)
            {
                var roomType = uow.Repository.Delete(Id);
                uow.Complete();
                return roomType;
            }
        }

        public IEnumerable<RoomType> GetAll()
        {
            using (var uow = _facade.GetRoomTypeUoW)
            {
                var roomTypes = uow.Repository.GetAll();
                uow.Complete();
                return roomTypes;
            }
        }

        public RoomType GetById(int Id)
        {
            using (var uow = _facade.GetRoomTypeUoW)
            {
                var roomType = uow.Repository.GetById(Id);
                uow.Complete();
                return roomType;
            }
        }

        public RoomType Update(RoomType t)
        {
            using (var uow = _facade.GetRoomTypeUoW)
            {
                RoomType rt = uow.Repository.Update(t);
                uow.Complete();
                return rt;
            }
        }
    }
}

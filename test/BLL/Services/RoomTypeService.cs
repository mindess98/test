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
            using (var uow = _facade.UnitOfWork)
            {
                var newRoomType = uow.RoomTypeRepository.Create(t);
                uow.Complete();
                return newRoomType;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var roomType = uow.RoomTypeRepository.Delete(Id);
                uow.Complete();
                return roomType;
            }
        }

        public ICollection<RoomType> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var roomTypes = uow.RoomTypeRepository.GetAll();
                return roomTypes;
            }
        }

        public RoomType GetById(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var roomType = uow.RoomTypeRepository.GetById(Id);
                return roomType;
            }
        }

        public RoomType Update(RoomType t)
        {
            using (var uow = _facade.UnitOfWork)
            {
                RoomType rt = uow.RoomTypeRepository.Update(t);
                uow.Complete();
                return rt;
            }
        }
    }
}

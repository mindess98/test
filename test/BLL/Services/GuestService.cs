using DAL;
using System;
using System.Collections.Generic;
using test.Entities;

namespace BLL.Services
{
    class GuestService : IService<Guest>
    {
        private DALFacade _facade;
        public GuestService(DALFacade facade)
        {
            _facade = facade;
        }
        public Guest Create(Guest t)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newGuest = uow.GuestRepository.Create(t);
                uow.Complete();
                return newGuest;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guest = uow.GuestRepository.Delete(Id);
                uow.Complete();
                return guest;
            }
        }

        public ICollection<Guest> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guests = uow.GuestRepository.GetAll();
                uow.Complete();
                return guests;
            }
        }

        public Guest GetById(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guest = uow.GuestRepository.GetById(Id);
                uow.Complete();
                return guest;
            }
        }

        public Guest Update(Guest t)
        {
            using (var uow = _facade.UnitOfWork)
            {
                Guest gu = uow.GuestRepository.Update(t);
                uow.Complete();
                return gu;
            }
        }
    }
}

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
            using (var uow = _facade.GetGuestUoW)
            {
                var newGuest = uow.Repository.Create(t);
                uow.Complete();
                return newGuest;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.GetGuestUoW)
            {
                var guest = uow.Repository.Delete(Id);
                uow.Complete();
                return guest;
            }
        }

        public IEnumerable<Guest> GetAll()
        {
            using (var uow = _facade.GetGuestUoW)
            {
                var guests = uow.Repository.GetAll();
                uow.Complete();
                return guests;
            }
        }

        public Guest GetById(int Id)
        {
            using (var uow = _facade.GetGuestUoW)
            {
                var guest = uow.Repository.GetById(Id);
                uow.Complete();
                return guest;
            }
        }

        public Guest Update(Guest t)
        {
            throw new NotImplementedException();
        }
    }
}

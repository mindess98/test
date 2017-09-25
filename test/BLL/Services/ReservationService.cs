using DAL;
using System;
using System.Collections.Generic;
using test.Entities;

namespace BLL.Services
{
    class ReservationService : IService<Reservation>
    {
        private DALFacade _facade;
        public ReservationService(DALFacade facade)
        {
            _facade = facade;
        }
        public Reservation Create(Reservation t)
        {
            using (var uow = _facade.UnitOfWork)
            {
                Guest g = uow.GuestRepository.GetById(t.Guest.Id);
                if(g == null)
                {
                    g = uow.GuestRepository.Create(t.Guest);
                }
                var newReservation = uow.ReservationRepository.Create(t);
                uow.Complete();
                return newReservation;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var reservation = uow.ReservationRepository.Delete(Id);
                uow.Complete();
                return reservation;
            }
        }

        public ICollection<Reservation> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var reservations = uow.ReservationRepository.GetAll();
                uow.Complete();
                return reservations;
            }
        }

        public Reservation GetById(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var reservation = uow.ReservationRepository.GetById(Id);
                uow.Complete();
                return reservation;
            }
        }

        public Reservation Update(Reservation t)
        {
            using (var uow = _facade.UnitOfWork)
            {
                Reservation re = uow.ReservationRepository.Update(t);
                uow.Complete();
                return re;
            }
        }
    }
}

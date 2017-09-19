﻿using DAL;
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
            using (var uow = _facade.GetReservationUoW)
            {
                var newReservation = uow.Repository.Create(t);
                uow.Complete();
                return newReservation;
            }
        }

        public bool Delete(int Id)
        {
            using (var uow = _facade.GetReservationUoW)
            {
                var reservation = uow.Repository.Delete(Id);
                uow.Complete();
                return reservation;
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            using (var uow = _facade.GetReservationUoW)
            {
                var reservations = uow.Repository.GetAll();
                uow.Complete();
                return reservations;
            }
        }

        public Reservation GetById(int Id)
        {
            using (var uow = _facade.GetReservationUoW)
            {
                var reservation = uow.Repository.GetById(Id);
                uow.Complete();
                return reservation;
            }
        }

        public Reservation Update(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
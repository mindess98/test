using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.Entities;

namespace rest.Controller
{
    public class ReservationsController : ApiController
    {
        private IService<Reservation> _reservationService;

        public ReservationsController()
        {
            _reservationService = new BLLFacade().GetReservationService;
        }

        // GET: api/Reservations
        public ICollection<Reservation> Get()
        {
            return _reservationService.GetAll();
        }

        // GET: api/Reservations/5
        public Reservation Get(int id)
        {
            return _reservationService.GetById(id);
        }

        // POST: api/Reservations
        public void Post([FromBody]Reservation value)
        {
            _reservationService.Create(value);
        }

        // PUT: api/Reservations/5
        public void Put(int id, [FromBody]Reservation value)
        {
            _reservationService.Update(value);
        }

        // DELETE: api/Reservations/5
        public void Delete(int id)
        {
            _reservationService.Delete(id);
        }
    }
}

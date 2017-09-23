using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.Entities;

namespace rest.Controllers
{
    public class ReservationsController : ApiController
    {
        private IService<Reservation> _reservationService;

        ReservationsController()
        {
            _reservationService = new BLLFacade().GetReservationService;
        }

        // GET: api/Reservations
        public IEnumerable<Reservation> Get()
        {
            return _reservationService.GetAll();
        }

        // GET: api/Reservations/5
        public Reservation Get(int id)
        {
            return _reservationService.GetById(id);
        }

        // POST: api/Reservations
        public void Post([FromBody]Reservation re)
        {
            _reservationService.Create(re);
        }

        // PUT: api/Reservations/5
        public void Put(int id, [FromBody]Reservation re)
        {
            _reservationService.Update(re);
        }

        // DELETE: api/Reservations/5
        public void Delete(int id)
        {
            _reservationService.Delete(id);
        }
    }
}

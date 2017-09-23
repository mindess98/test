using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using test.Entities;

namespace rest.Controllers
{
    public class GuestsController : ApiController
    {
        private IService<Guest> _guestService;

        GuestsController()
        {
            _guestService = new BLLFacade().GetGuestService;
        }

        // GET: api/Guests
        public IEnumerable<Guest> Get()
        {
            return _guestService.GetAll();
        }

        // GET: api/Guests/5
        public Guest Get(int id)
        {
            return _guestService.GetById(id);
        }

        // POST: api/Guests
        public void Post([FromBody]Guest gue)
        {
            _guestService.Create(gue);
        }

        // PUT: api/Guests/5
        public void Put(int id, [FromBody]Guest gue)
        {
            _guestService.Update(gue);
        }

        // DELETE: api/Guests/5
        public void Delete(int id)
        {
            _guestService.Delete(id);
        }
    }
}

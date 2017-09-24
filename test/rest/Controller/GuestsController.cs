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
    public class GuestsController : ApiController
    {
        private IService<Guest> _guestService;

        public GuestsController()
        {
            _guestService = new BLLFacade().GetGuestService;
        }

        // GET: api/Guests
        public ICollection<Guest> Get()
        {
            return _guestService.GetAll();
        }

        // GET: api/Guests/5
        public Guest Get(int id)
        {
            return _guestService.GetById(id);
        }

        // POST: api/Guests
        public void Post([FromBody]Guest value)
        {
            _guestService.Create(value);
        }

        // PUT: api/Guests/5
        public void Put(int id, [FromBody]Guest value)
        {
            _guestService.Update(value);
        }

        // DELETE: api/Guests/5
        public void Delete(int id)
        {
            _guestService.Delete(id);
        }
    }
}

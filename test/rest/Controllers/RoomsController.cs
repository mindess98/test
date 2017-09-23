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
    public class RoomsController : ApiController
    {
        private IService<Room> _roomService;

        RoomsController()
        {
            _roomService = new BLLFacade().GetRoomService;
        }
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return _roomService.GetAll();
        }

        // GET: api/Rooms/5
        public Room Get(int id)
        {
            return _roomService.GetById(id);
        }

        // POST: api/Rooms
        public void Post([FromBody]Room ro)
        {
            _roomService.Create(ro);
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]Room ro)
        {
            _roomService.Update(ro);
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
            _roomService.Delete(id);
        }
    }
}

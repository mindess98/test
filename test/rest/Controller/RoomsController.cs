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
    public class RoomsController : ApiController
    {
        private IService<Room> _roomService;

        public RoomsController()
        {
            _roomService = new BLLFacade().GetRoomService;
        }

        // GET: api/Rooms
        public ICollection<Room> Get()
        {
            return _roomService.GetAll();
        }

        // GET: api/Rooms/5
        public Room Get(int id)
        {
            return _roomService.GetById(id);
        }

        // POST: api/Rooms
        public void Post([FromBody]Room value)
        {
            _roomService.Create(value);
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]Room value)
        {
            _roomService.Update(value);
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
            _roomService.Delete(id);
        }
    }
}

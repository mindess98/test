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
    public class RoomTypesController : ApiController
    {
        private IService<RoomType> _roomTypeService;

        public RoomTypesController()
        {
            _roomTypeService = new BLLFacade().GetRoomTypeService;
        }


        // GET: api/RoomTypes
        public ICollection<RoomType> Get()
        {
            return _roomTypeService.GetAll();
        }

        // GET: api/RoomTypes/5
        public RoomType Get(int id)
        {
            return _roomTypeService.GetById(id);
        }

        // POST: api/RoomTypes
        public void Post([FromBody]RoomType value)
        {
            _roomTypeService.Create(value);
        }

        // PUT: api/RoomTypes/5
        public void Put(int id, [FromBody]RoomType value)
        {
            _roomTypeService.Update(value);
        }

        // DELETE: api/RoomTypes/5
        public void Delete(int id)
        {
            _roomTypeService.Delete(id);
        }
    }
}

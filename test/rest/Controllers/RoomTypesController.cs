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
    public class RoomTypesController : ApiController
    {
        private IService<RoomType> _roomTypeService;

        RoomTypesController()
        {
            _roomTypeService = new BLLFacade().GetRoomTypeService;
        }

        // GET: api/RoomTypes
        public IEnumerable<RoomType> Get()
        {
            return _roomTypeService.GetAll();
        }

        // GET: api/RoomTypes/5
        public RoomType Get(int id)
        {
            return _roomTypeService.GetById(id);
        }

        // POST: api/RoomTypes
        public void Post([FromBody]RoomType rt)
        {
            _roomTypeService.Create(rt);
        }

        // PUT: api/RoomTypes/5
        public void Put(int id, [FromBody]RoomType rt)
        {
            _roomTypeService.Update(rt);
        }

        // DELETE: api/RoomTypes/5
        public void Delete(int id)
        {
            _roomTypeService.Delete(id);
        }
    }
}

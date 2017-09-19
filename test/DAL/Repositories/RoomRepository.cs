﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using test.Entities;

namespace DAL.Repositories
{
    class RoomRepository : IRepository<Room>
    {
        private HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public Room Create(Room t)
        {
            _context.Rooms.Add(t);
            return t;
        }

        public bool Delete(int Id)
        {
            Room g = GetById(Id);
            if (g != null)
            {
                _context.Rooms.Remove(g);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int Id)
        {
            Room g = _context.Rooms.FirstOrDefault(x => x.Id == Id);
            if (g != null)
            {
                return new Room { Name = g.Name, Capacity = g.Capacity,  Price = g.Price, Reservation= g.Reservation, Id = g.Id, RoomImage = g.RoomImage, RoomType = g.RoomType };
            }
            else
                return null;
        }

        public Room Update(Room t)
        {

            return t;
        }
    }
}
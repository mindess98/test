using System;
using System.Collections.Generic;

namespace test.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public List<Room> Rooms { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
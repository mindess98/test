using System;
using System.Collections.Generic;

namespace test
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public List<Guest> Guests { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace test.Entities
{
    public class Reservation
    {
        public Reservation()
        {
            Rooms = new List<Room>();
        }

        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public int GuestId { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
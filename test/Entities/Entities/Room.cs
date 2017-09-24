using System.Collections.Generic;

namespace test.Entities
{
    public class Room
    {
        public Room()
        {
            Reservations = new List<Reservation>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }

        public int RoomTypeId { get; set; }
        public virtual RoomType Type { get; set; }
    }
}
using System.Collections.Generic;

namespace test.Entities
{
    public class RoomType
    {
        public RoomType()
        {
            Rooms = new List<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StarValue { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}

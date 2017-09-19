using System.Collections.Generic;

namespace test.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StarValue { get; set; }
        public List<Room> Rooms { get; set; }

    }
}

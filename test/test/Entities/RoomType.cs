using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StarValue { get; set; }
        public List<Room> Rooms { get; set; }
    }
}

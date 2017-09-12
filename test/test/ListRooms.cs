using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class ListRooms : Form
    {
        private HotelContext context = new HotelContext();

        public ListRooms()
        {
            InitializeComponent();

            dataGridView1.DataSource = context.Rooms.ToList();
        }
    }
}

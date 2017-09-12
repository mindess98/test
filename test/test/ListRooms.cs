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

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = context.RoomTypes.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Rooms.Where(ro => ro.RoomTypeId == (int)comboBox1.SelectedValue).ToList();
        }
    }
}

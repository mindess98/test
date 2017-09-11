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
    public partial class Hotel : Form
    {
        public Hotel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HotelContext context = new HotelContext();
            Room r = new Room();
            r.Capacity = 4;
            r.Price = 400;
            context.Rooms.Add(r);
            context.SaveChanges();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeReservation mr = new MakeReservation();
            mr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListGuests lg = new ListGuests();
            lg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListRooms lr = new ListRooms();
            lr.Show();
        }
    }
}

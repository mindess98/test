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

            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button9.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button9.Hide();

            button6.Show();
            button7.Show();
            button8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListRooms lr = new ListRooms();
            lr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddRoom ar = new AddRoom();
            ar.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();

            button1.Show();
            button4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Hide();
            button7.Hide();
            button8.Hide();

            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button9.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ListReservations lr = new ListReservations();
            lr.Show();
        }
    }
}

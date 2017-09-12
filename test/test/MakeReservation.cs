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
    public partial class MakeReservation : Form
    {
        private HotelContext context = new HotelContext();

        public MakeReservation()
        {
            InitializeComponent();


            comboBox1.DataSource = context.Rooms.ToList();
            comboBox1.DisplayMember = "Capacity";
            comboBox1.ValueMember = "Id";
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MakeReservation_Load(object sender, EventArgs e)
        {

        }
    }
}

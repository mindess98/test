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
    public partial class ListGuests : Form
    {
        private HotelContext context = new HotelContext();


        public ListGuests()
        {

            InitializeComponent();
            dataGridView1.DataSource = context.Guests.ToList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Entities;

namespace test
{
    public partial class ListReservations : Form
    {
        IService<Reservation> service = new BLLFacade().GetReservationService;

        public ListReservations()
        {
            InitializeComponent();

            dataGridView1.DataSource = service.GetAll();
        }

        private void ListReservations_Load(object sender, EventArgs e)
        {

        }
    }
}

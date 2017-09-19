﻿using BLL;
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
    public partial class ListGuests : Form
    {
        IService<Guest> _guestService = new BLLFacade().GetGuestService;


        public ListGuests()
        {

            InitializeComponent();
            dataGridView1.DataSource = _guestService.GetAll();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
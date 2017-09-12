using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class AddRoom : Form
    {
        private HotelContext context = new HotelContext();

        private byte[] imageBytes;

        public AddRoom()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = context.RoomTypes.ToList();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                imageBytes = new byte[fs.Length];

                fs.Read(imageBytes, 0, imageBytes.Length);

                fs.Close();

                MemoryStream memStrm = new MemoryStream(imageBytes);

                pictureBox1.Image = Image.FromStream(memStrm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room r = new Room { Capacity = int.Parse(textBox2.Text), RoomTypeId = (int)comboBox1.SelectedValue, Price = decimal.Parse(textBox1.Text), RoomImage = imageBytes };
            context.Rooms.Add(r);
            context.SaveChanges();

            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Image = null;
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

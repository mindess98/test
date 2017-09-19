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
    public partial class ListRooms : Form
    {

        IService<Room> roomService = new BLLFacade().GetRoomService;
        IService<RoomType> roomTypeService = new BLLFacade().GetRoomTypeService;

        public ListRooms()
        {
            InitializeComponent();

            dataGridView1.DataSource = roomService.GetAll();

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = roomTypeService.GetAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = roomService.GetAll();//.Where(x => x.RoomTypeId == 1);
        }
    }
}

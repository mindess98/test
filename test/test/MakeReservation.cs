using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Entities;

namespace test
{
    public partial class MakeReservation : Form
    {
        IService<Room> roomService = new BLLFacade().GetRoomService;
        IService<Guest> guestService = new BLLFacade().GetGuestService;
        IService<Reservation> reservationService = new BLLFacade().GetReservationService;
        IService<RoomType> roomTypeService = new BLLFacade().GetRoomTypeService;

        private BindingList<Room> rooms = new BindingList<Room>();

        private int daysDifference = 1;
        public int DaysDifference
        {
            get { return daysDifference; }
            set
            {
                int preliminary = (dateTimePicker4.Value - dateTimePicker3.Value).Days;

                if (daysDifference != 0)
                {
                    if (preliminary <= 0)
                    {
                        dateTimePicker4.Value = dateTimePicker3.Value + new TimeSpan(1, 0, 0, 0);
                        PriceTotal /= daysDifference;
                        daysDifference = 1;
                        PriceTotal *= daysDifference;
                    }
                    else
                    {
                        PriceTotal /= daysDifference;
                        daysDifference = preliminary;
                        PriceTotal *= daysDifference;
                    }
                }
                else
                {
                    if (preliminary <= 0)
                    {
                        dateTimePicker4.Value = dateTimePicker3.Value + new TimeSpan(1, 0, 0, 0);
                        daysDifference = 1;
                    }
                    else
                    {
                        daysDifference = preliminary;
                        PriceTotal *= daysDifference;
                    }
                }

            }
        }

        private decimal priceTotal;
        public decimal PriceTotal
        {
            get
                { return priceTotal; }
          set
            {
                priceTotal = value;
                textBox3.Text = priceTotal.ToString(); 
            }
        }

        private int capacityTotal;
        public int CapacityTotal
        {
            get { return capacityTotal; }
            set
            {
                capacityTotal = value;
                textBox4.Text = capacityTotal.ToString();
            }
        }

        public MakeReservation()
        {
            InitializeComponent();

            listBox2.DisplayMember = "Capacity";
            listBox2.DataSource = rooms;

            CreateRoomTypeTabs();

            dateTimePicker4.Value = dateTimePicker3.Value + new TimeSpan(1, 0, 0, 0);

            AddRoomsToTabs();

        }

        private void CreateRoomTypeTabs()
        {
            var roomTypes = roomTypeService.GetAll();
            foreach (RoomType rt in roomTypes)
            {
                tabControl2.TabPages.Add(rt.Name, new string('\x2605', rt.StarValue) + " " + rt.Name );
            }
        }

        private void AddRoomsToTabs()
        {
            foreach (TabPage tp in tabControl2.TabPages)
            {
                FlowLayoutPanel flp = new FlowLayoutPanel();
                
                flp.Dock = DockStyle.Fill;

                var rooms = roomService.GetAll().Where(ro => ro.RoomType.Name == tp.Name);
                foreach (Room ro in rooms)
                {
                    AddRoomButtonToFLP(ro, flp);
                }

                tp.Controls.Add(flp);
            }
        }

        private Button AddRoomButtonToFLP(Room ro, FlowLayoutPanel flp)
        {
            Button b = new Button();
            b.Size = new Size(100, 100);
            b.Text = ro.Name + "\n" + "Guests: " + ro.Capacity;

            /*
            b.BackgroundImageLayout = ImageLayout.Stretch;
            MemoryStream ms = new MemoryStream(ro.RoomImage);
            b.BackgroundImage = Image.FromStream(ms);
            */
            b.Tag = ro;
            b.Click += UpdateReservation;

            flp.Controls.Add(b);

            return b;
        }

        private void UpdateReservation(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Room r = (Room)b.Tag;

            rooms.Add(r);
            PriceTotal += r.Price * DaysDifference;
            CapacityTotal += r.Capacity;
            listBox2.SelectedIndex = listBox2.Items.Count - 1;

            b.Tag = null;
            b.Dispose();
        }

        private void MakeReservation_Load(object sender, EventArgs e)
        {

        }
        
        private void FormatListBoxItem2(object sender, ListControlConvertEventArgs e)
        {
            string roomType = ((Room)e.ListItem).Name;
            string roomPrice = ((Room)e.ListItem).Price.ToString();
            ListBox lb = (ListBox)sender;
            

            e.Value = string.Format("{0,-30}{1,10:c}/Night", roomType, roomPrice);
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rooms.Count == 0) return;
            
            Room r = (Room)listBox2.SelectedItem;
            int i = rooms.IndexOf(r);
            PriceTotal -= r.Price * DaysDifference;
            CapacityTotal -= r.Capacity;
            rooms.Remove(r);
            if (i >= rooms.Count) i = rooms.Count - 1;
            if (i < 0) i = 0;
            if(rooms.Count > 0)
                listBox2.SelectedIndex = i;

            foreach(TabPage tp in tabControl2.TabPages)
            {
                if(tp.Name == r.RoomType.Name)
                {
                    foreach(FlowLayoutPanel flp in tp.Controls)
                    {
                        AddRoomButtonToFLP(r, flp);

                        tp.Controls.Add(flp);
                        return;
                    }
                }
            }
        }

        private void PrintReceipt()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += PrintDocument_PrintPage;

            DialogResult result = printDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12);

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Welcome to the Hotel", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);

            foreach(Room room in rooms)
            {
                string roomName = room.Name.PadRight(30);
                string roomTotal = string.Format("{0:c}", room.Price);
                string roomLine = roomName + roomTotal;

                graphic.DrawString(roomLine, font, new SolidBrush(Color.Black), startX, startY + offset);

                offset += (int)fontHeight + 5;
            }

            offset += 20;

            graphic.DrawString("Total to pay".PadRight(30) + string.Format("{0:c}", priceTotal), font, new SolidBrush(Color.Black), startX, startY + offset);



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            DaysDifference = (dateTimePicker4.Value - dateTimePicker3.Value).Days;

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reservation re = new Reservation();
            re.From = dateTimePicker3.Value;
            re.To = dateTimePicker4.Value;
            re.Rooms = rooms.ToList();
            foreach (Room room in re.Rooms)
                room.Reservation = null;

            Guest g = new Guest();
            g.Name = textBox2.Text;
            g.Reservation = re;

            re.Guest = g;

            guestService.Create(g);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DaysDifference = (dateTimePicker4.Value - dateTimePicker3.Value).Days;
            
        }
    }
}

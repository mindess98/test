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
            foreach(RoomType rt in context.RoomTypes)
            {
                tabControl2.TabPages.Add(rt.Name, new string('\x2605', rt.StarValue) + " " + rt.Name );
            }
        }

        private void AddRoomsToTabs()
        {
            foreach(TabPage tp in tabControl2.TabPages)
            {
                FlowLayoutPanel flp = new FlowLayoutPanel();

                flp.Dock = DockStyle.Fill;

                foreach(Room ro in context.Rooms.Where(ro => ro.RoomType.Name == tp.Name))
                {
                    Button b = new Button();
                    b.Size = new Size(100, 100);
                    b.Text = ro.Name + "\n" + "Guests: " + ro.Capacity;
                    b.TextAlign = ContentAlignment.BottomCenter;

                    b.Tag = ro;
                    b.Click += UpdateReservation;

                    flp.Controls.Add(b);
                }

                tp.Controls.Add(flp);
            }
        }

        private void UpdateReservation(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            Room r = (Room)b.Tag;

            rooms.Add(r);
            PriceTotal += r.Price * DaysDifference;
            CapacityTotal += r.Capacity;
            listBox2.SelectedIndex = listBox2.Items.Count - 1;

        }

        private void MakeReservation_Load(object sender, EventArgs e)
        {

        }
        
        private void FormatListBoxItem2(object sender, ListControlConvertEventArgs e)
        {
            string roomType = ((Room)e.ListItem).RoomType.Name;
            string roomPrice = string.Format("{0:c2}", ((Room)e.ListItem).Price);
            ListBox lb = (ListBox)sender;

            string padding = new string(' ', 45 - roomType.Length - roomPrice.Length);

            e.Value = string.Format("{0}{2}{1}/Night", roomType, roomPrice, padding);
            

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

            Guest g = new Guest();
            g.Name = textBox2.Text;
            g.Reservation = re;

            re.Guest = g;

            context.Guests.Add(g);
            context.Reservations.Add(re);
            context.SaveChanges();

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker4.Value < dateTimePicker3.Value)
            {
                dateTimePicker3.Value = dateTimePicker4.Value - new TimeSpan(1, 0, 0, 0);
            }
            DaysDifference = 1;
        }
    }
}

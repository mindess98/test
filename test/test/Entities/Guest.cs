﻿namespace test
{
    public class Guest
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public string Name { get; set; }
    }
}
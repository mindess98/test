﻿namespace test
{
    public class Room
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}
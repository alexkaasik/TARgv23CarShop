﻿namespace TARgv23CarShop.Models.Car
{
    public class CarIndexViewModel
    {
        public Guid? CarId { get; set; }

        public string? CarName { get; set; }

        public float? CarPrice { get; set; }

        public DateTime? CarYear { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

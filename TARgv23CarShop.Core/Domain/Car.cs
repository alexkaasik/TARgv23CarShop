namespace TARgv23CarShop.Core.Domain
{
    public class Car
    {
        public Guid? CarId { get; set; }

        public string? CarName { get; set; }

        public float? CarPrice { get; set; }

        public DateTime? CarYear { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

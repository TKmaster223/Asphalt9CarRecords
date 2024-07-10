namespace Asphalt9CarRecords.Models.DTOs
{
    public class CarDto // Data Transfer Object for Car
    {
        public int Id { get; set; } // Car ID
        public string Name { get; set; } = string.Empty; // Car name
        public int Speed { get; set; } // Car speed
        public int Acceleration { get; set; } // Car acceleration
        public int Handling { get; set; } // Car handling
        public int Nitro { get; set; } // Car nitro
        public string CarClassName { get; set; } = string.Empty; // Car class name
    }
}

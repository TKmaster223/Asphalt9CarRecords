using System.ComponentModel.DataAnnotations;

namespace Asphalt9CarRecords.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; } // Primary key
        public string Name { get; set; } = string.Empty; // Initialize to avoid null
        public int Speed { get; set; } // Car speed
        public int Acceleration { get; set; } // Car acceleration
        public int Handling { get; set; } // Car handling
        public int Nitro { get; set; } // Car nitro
        public int CarClassId { get; set; } // Foreign key to CarClass
        public CarClass CarClass { get; set; } = null!; // Initialize to avoid null
    }
}

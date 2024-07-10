using System.ComponentModel.DataAnnotations;

namespace Asphalt9CarRecords.Models
{
    public class CarClass
    {
        [Key]
        public int Id { get; set; } // Primary key
        public string Name { get; set; } = string.Empty; // Initialize to avoid null

        public CarClass() { }
    }
}

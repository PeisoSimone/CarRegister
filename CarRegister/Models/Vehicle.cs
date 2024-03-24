using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRegister.Models
{
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Make { get; set; } = "Make";

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Model { get; set; } = "Model";

        public int Year { get; set; } = 2020;

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Color { get; set; } = "Color";

        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        public int IsActive { get; set; } = 1;

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public string Driver { get; set; } = "Driver";
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace GasMeter.DataModels
{
    public class Measure
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public double Measurement { get; set; }
    }
}

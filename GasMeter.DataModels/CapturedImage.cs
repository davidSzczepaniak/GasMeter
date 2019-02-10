using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasMeter.DataModels
{
    public class CapturedImage
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateTaken { get; set; }

        public byte[] Data { get; set; }
    }
}

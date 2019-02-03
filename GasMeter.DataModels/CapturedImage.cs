using System;
using System.ComponentModel.DataAnnotations;

namespace GasMeter.DataModels
{
    public class CapturedImage
    {
        [Key]
        public Guid Id { get; set; }

        public byte[] Data { get; set; }
    }
}

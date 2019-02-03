using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GasMeter.DataModels
{
    public class CapturedImage
    {
        [Key]
        public Guid Id { get; set; }

        public byte[] Data { get; set; }
    }
}

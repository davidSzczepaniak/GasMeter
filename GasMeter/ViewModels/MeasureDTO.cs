using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasMeter.ViewModels
{
    public class MeasureDTO
    {
        public DateTime DateCreated { get; set; }

        public double Measurement { get; set; }

        public CapturedImageDTO Image { get; set; }
    }
}

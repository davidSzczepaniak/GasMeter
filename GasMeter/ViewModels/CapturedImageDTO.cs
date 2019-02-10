using System.Drawing;
using System.IO;

namespace GasMeter.ViewModels
{
    public class CapturedImageDTO
    {
        public byte[] Data { get; set; }

        public Image SavedImage { get => Image.FromStream(new MemoryStream(Data)); }
    }
}
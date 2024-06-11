using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace DLLForRMS.DLInterfaces
{
    public interface IUtility
    {
        bool SaveImage(byte[] image, string path, int ID, string table);

        byte[] ImageToByteArray(Image image);
    }
}

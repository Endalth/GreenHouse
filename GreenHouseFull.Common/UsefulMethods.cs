using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouseFull.Common
{
    public static class UsefulMethods
    {
        public static byte[] ImageByteArrayFromFile(string filePath)
        {
            Image img = Image.FromFile(filePath);
            string[] pathSplit = filePath.Split('.');
            string extension = pathSplit[pathSplit.Length - 1];
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                if (extension == "jpg" || extension == "jpeg")
                    img.Save(ms, ImageFormat.Jpeg);
                else
                    img.Save(ms, ImageFormat.Png);

                bytes = ms.ToArray();
            }

            return bytes;
        }

        public static Image ImageFromByteArray(byte[] bytes)
        {
            Image image;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        public static void ImageSelect(out string file)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Images (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";

            DialogResult dialogResult = ofd.ShowDialog();

            if (dialogResult == DialogResult.OK)
                file = ofd.FileName;
            else
                file = "";
        }

        public static string GetSHA256(string value)
        {
            StringBuilder encryptedPass = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                {
                    encryptedPass.Append(b.ToString("x2"));
                }
            }

            return encryptedPass.ToString();
        }
    }
}

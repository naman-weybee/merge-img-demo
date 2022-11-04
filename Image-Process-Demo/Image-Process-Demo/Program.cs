using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Process_Demo
{
    class Program
    {
        private static string basePath = "D:\\.NET\\ImageProcess\\Image-Process-Demo\\Image-Process-Demo\\images\\";
        private static string mergePath = "D:\\.NET\\ImageProcess\\Image-Process-Demo\\Image-Process-Demo\\mergeImages\\";
        static void Main(string[] args)
        {
            Program program = new Program();
            Image img1 = Image.FromFile(basePath + "bgImage.jpg");
            Image img2 = Image.FromFile(basePath + "squareLogo.jpg");
            Image img3 = Image.FromFile(basePath + "rectangleLogo.jpg");
            Image img4 = Image.FromFile(basePath + "packageLogo.jpg");
            program.MergeImages(img1, img2, img3, img4);
        }

        public Bitmap MergeImages(Image image1, Image image2, Image image3, Image image4)
        {
            Bitmap bitmap = new Bitmap(image1.Width, image1.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image1, 0, 0);
                g.DrawImage(image2, 10, 10);
                g.DrawImage(image3, image1.Width - image3.Width - 10, 0);
                g.DrawImage(image4, image1.Width / 2, image1.Height / 2);
            }
            Image img = bitmap;
            img.Save(mergePath + Guid.NewGuid().ToString() + "_" + "x.jpg");
            Console.WriteLine("Merged");
            return bitmap;
        }
    }
}

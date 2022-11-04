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
            Image bgImage = Image.FromFile(basePath + "bgImage.jpg");
            Image squareLogo = Image.FromFile(basePath + "squareLogo.jpg");
            Image rectangleLogo = Image.FromFile(basePath + "rectangleLogo.jpg");
            Image packageLogo = Image.FromFile(basePath + "packageLogo.jpg");
            program.MergeImages(bgImage, squareLogo, rectangleLogo, packageLogo);
        }

        public Bitmap MergeImages(Image bgImage, Image squareLogo, Image rectangleLogo, Image packageLogo)
        {
            Bitmap bitmap = new Bitmap(bgImage.Width, bgImage.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(bgImage, 0, 0);
                g.DrawImage(squareLogo, 10, 10, 100, 100);
                g.DrawImage(rectangleLogo, bgImage.Width - 150, 10, 150, 150);
                g.DrawImage(packageLogo, bgImage.Width / 2, bgImage.Height / 2, 125, 125);
            }
            Image img = bitmap;
            img.Save(mergePath + Guid.NewGuid().ToString() + "_" + "final.jpg");
            Console.WriteLine("Merged");
            return bitmap;
        }
    }
}

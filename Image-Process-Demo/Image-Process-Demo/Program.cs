using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Image_Process_Demo
{
    class Program
    {
        private static string basePath = "D:\\.NET\\ImageProcess\\Image-Process-Demo\\Image-Process-Demo\\images\\";
        private static string mergePath = "D:\\.NET\\ImageProcess\\Image-Process-Demo\\Image-Process-Demo\\mergeImages\\";
        static void Main(string[] args)
        {
            string text = "test@gmail.com";
            Font font = new Font("Cinzel Decorative", 25, FontStyle.Regular, GraphicsUnit.Pixel);

            Image bgImage = Image.FromFile(basePath + "bgImage.jpg");
            Image squareLogo = Image.FromFile(basePath + "squareLogo.jpg");
            Image rectangleLogo = Image.FromFile(basePath + "rectangleLogo.jpg");
            Image packageLogo = Image.FromFile(basePath + "packageLogo.jpg");

            Program program = new Program();
            program.TextToImage(text, font);
            program.MergeImages(bgImage, squareLogo, rectangleLogo, packageLogo);
        }

        public Bitmap TextToImage(string text, Font font)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font).Width;
            int height = (int)graphics.MeasureString(text, font).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, new SolidBrush(Color.FromArgb(255, 0, 0)), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            Image img = bitmap;
            img.Save(basePath + "Text.jpg");
            return bitmap;
        }

        public Bitmap MergeImages(Image bgImage, Image squareLogo, Image rectangleLogo, Image packageLogo)
        {
            Image Text = Image.FromFile(basePath + "Text.jpg");
            Bitmap bitmap = new Bitmap(bgImage.Width, bgImage.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(bgImage, 0, 0);
                g.DrawImage(squareLogo, 10, 10, 100, 100);
                g.DrawImage(rectangleLogo, bgImage.Width - 150, 10, 150, 150);
                g.DrawImage(packageLogo, bgImage.Width / 2, bgImage.Height / 2, 125, 125);
                g.DrawImage(Text, 10, bgImage.Height - Text.Height - 10);
            }
            Image img = bitmap;
            string file = Path.GetFileNameWithoutExtension("Template_" + Path.GetRandomFileName()) + ".jpg";
            img.Save(mergePath + Guid.NewGuid().ToString() + "_" + file);
            Console.WriteLine("Merged");
            return bitmap;
        }
    }
}

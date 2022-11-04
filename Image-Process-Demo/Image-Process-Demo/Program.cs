using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.IO;
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
            string email = "test@gmail.com";
            string mobileNo = "4567986564";
            string tag = "FrandshipDay";
            Font font = new Font("Cinzel Decorative", 25, FontStyle.Regular, GraphicsUnit.Pixel);

            Image bgImage = Image.FromFile(basePath + "bgImage.jpg");
            Image squareLogo = Image.FromFile(basePath + "squareLogo.jpg");
            Image rectangleLogo = Image.FromFile(basePath + "rectangleLogo.jpg");
            Image packageLogo = Image.FromFile(basePath + "packageLogo.jpg");

            int count = 0;
            Program program = new Program();
            for (int i = 0; i < 3; i++)
            {
                if (count == 0)
                {
                    program.TextToImage(email, font, count);
                }
                else if (count == 1)
                {
                    program.TextToImage(mobileNo, font, count);
                }
                else if (count == 2)
                {
                    program.TextToImage(tag, font, count);
                }
                count++;
            }
            program.MergeImages(bgImage, squareLogo, rectangleLogo, packageLogo);
        }

        public Bitmap TextToImage(string Text, Font font, int count)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(Text, font).Width;
            int height = (int)graphics.MeasureString(Text, font).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(Text, font, new SolidBrush(Color.FromArgb(255, 0, 0)), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            Image img = bitmap;
            if (count == 0)
            {
                img.Save(basePath + "email.jpg");
            }
            else if (count == 1)
            {
                img.Save(basePath + "mobileNo.jpg");
            }
            else if (count == 2)
            {
                img.Save(basePath + "tag.jpg");
            }
            return bitmap;
        }

        public Bitmap MergeImages(Image bgImage, Image squareLogo, Image rectangleLogo, Image packageLogo)
        {
            Image emailImage = Image.FromFile(basePath + "email.jpg");
            Image mobileNoImage = Image.FromFile(basePath + "mobileNo.jpg");
            Image tagImage = Image.FromFile(basePath + "tag.jpg");
            Bitmap bitmap = new Bitmap(bgImage.Width, bgImage.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(bgImage, 0, 0);
                g.DrawImage(squareLogo, 10, 10, 100, 100);
                g.DrawImage(rectangleLogo, bgImage.Width - 150, 10, 150, 150);
                g.DrawImage(packageLogo, (bgImage.Width / 2 - 100), (bgImage.Height / 2 - 100), 200, 200);
                g.DrawImage(emailImage, 10, bgImage.Height - emailImage.Height - 10);
                g.DrawImage(mobileNoImage, (bgImage.Width / 2 - 100), bgImage.Height - mobileNoImage.Height - 10);
                g.DrawImage(tagImage, bgImage.Width - tagImage.Width - 10, bgImage.Height - emailImage.Height - 10);
            }

            Image img = bitmap;
            string file = Path.GetFileNameWithoutExtension("Template_" + Path.GetRandomFileName()) + ".jpg";
            img.Save(mergePath + file);
            return bitmap;
        }
    }
}

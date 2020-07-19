using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tesseract;

namespace IhkObserver.CaptchaSolver
{
    public class CaptchaSolver
    {
        private static string OCR(Bitmap b)
        {
            try
            {
                string res = string.Empty;
                string path = GetTessdataPath();

                using (var engine = new TesseractEngine(path, "eng"))
                {
                    string letters = "abcdefghijklmnopqrstuvwxyz";
                    string numbers = "0123456789";
                    engine.SetVariable("tessedit_char_whitelist", $"{numbers}{letters}{letters.ToUpper()}");
                    engine.SetVariable("tessedit_unrej_any_wd", true);
                    engine.SetVariable("tessedit_adapt_to_char_fragments", true);
                    engine.SetVariable("tessedit_redo_xheight", true);
                    engine.SetVariable("chop_enable", true);

                    Bitmap x = b.Clone(new Rectangle(0, 0, b.Width, b.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                    using (var page = engine.Process(x, PageSegMode.SingleLine))
                        res = page.GetText().Replace(" ", "").Trim();
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetTessdataPath()
        {
            DirectoryInfo info = new DirectoryInfo(Environment.CurrentDirectory);
            while (true)
            {
                if (info.Name == "IHK-Observer")
                {
                    break;
                }

                if (info.Parent == null)
                {
                    throw new NotSupportedException("Could not find IHK-Observer Directory!");
                }
                info = info.Parent;
            }
            //return $@"{info.FullName}\IhkObserver.WpfResultViewer\bin\Debug\tessdata";
            return $@"{info.FullName}\Debug\tessdata";
        }

        public static Bitmap DeCaptcha(Image img, out string value)
        {
            Bitmap bmp = new Bitmap(img);
            bmp = bmp.Clone(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Erosion erosion = new Erosion();
            Dilatation dilatation = new Dilatation();
            Invert inverter = new Invert();
            ColorFiltering cor = new ColorFiltering();
            //cor.Blue = new AForge.IntRange(200, 255);
            cor.Red = new AForge.IntRange(50, 255);
            //cor.Green = new AForge.IntRange(200, 255);
            Opening open = new Opening();
            BlobsFiltering bc = new BlobsFiltering() { MinHeight = 10 };
            Closing close = new Closing();
            GaussianSharpen gs = new GaussianSharpen();
            ContrastCorrection cc = new ContrastCorrection();
            FiltersSequence seq = new FiltersSequence(gs, inverter, open, inverter, bc, inverter, open, cc, cor, bc, inverter, dilatation);
            Image image = seq.Apply(bmp);
            value = OCR((Bitmap)image);
            return (Bitmap)image;
        }

        public static Task<(Bitmap, string)> DeCaptchAsync(Image img)
        {
            return (Task<(Bitmap, string)>)Task.Run(() =>
            {
                string value;
                Bitmap bmp = new Bitmap(img);
                bmp = bmp.Clone(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Erosion erosion = new Erosion();
                Dilatation dilatation = new Dilatation();
                Invert inverter = new Invert();
                ColorFiltering cor = new ColorFiltering();
                //cor.Blue = new AForge.IntRange(200, 255);
                cor.Red = new AForge.IntRange(50, 255);
                //cor.Green = new AForge.IntRange(200, 255);
                Opening open = new Opening();
                BlobsFiltering bc = new BlobsFiltering() { MinHeight = 10 };
                Closing close = new Closing();
                GaussianSharpen gs = new GaussianSharpen();
                ContrastCorrection cc = new ContrastCorrection();
                FiltersSequence seq = new FiltersSequence(gs, inverter, open, inverter, bc, inverter, open, cc, cor, bc, inverter, dilatation);
                Image image = seq.Apply(bmp);
                value = OCR((Bitmap)image);
                return ((Bitmap)image, value);
            });
        }
    }
}

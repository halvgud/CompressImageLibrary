using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace PixelRunner
{
    public class PixelRunner
    {
        public static float Valor { get; set; }
        public static float ValorAnterior { get; set; }
        public static Image CompressImage(Image pbImage)
                GetSize(processedBitmap,ValorAnterior);
                var bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);
                var widthInBytes = bitmapData.Width * (Image.GetPixelFormatSize(processedBitmap.PixelFormat) / 8);
                var heightBytes = (Image.GetPixelFormatSize(processedBitmap.PixelFormat) / 8);
                byte* pixel = (byte*)bitmapData.Scan0;
                System.Threading.Tasks.Parallel.For(0, bitmapData.Height, y =>
                {
                    var currentLine = pixel + (y * bitmapData.Stride);
                    for (var x = 0; x < widthInBytes; x = x + heightBytes)
                    {
                        var oldBlue = ((int)(Math.Round(currentLine[x] / (float)2) * 2) - 1) <= 8 ? 0 : (((int)(Math.Round(currentLine[x] / (float)2) * 2) - 1) > 248 ? 255 : ((int)(Math.Round(currentLine[x] / (float)2) * 2) - 1));
                        var oldGreen = ((int)(Math.Round(currentLine[x + 1] / (float)2) * 2) - 1) <= 8 ? 0 : (((int)(Math.Round(currentLine[x + 1] / (float)2) * 2) - 1) > 248 ? 255 : ((int)(Math.Round(currentLine[x + 1] / (float)2) * 2) - 1));
                        var oldRed = ((int)(Math.Round(currentLine[x + 2] / (float)2) * 2) - 1) <= 8 ? 0 : (((int)(Math.Round(currentLine[x + 2] / (float)2) * 2) - 1) > 248 ? 255 : ((int)(Math.Round(currentLine[x + 2] / (float)2) * 2) - 1));
                        currentLine[x] = (byte)oldBlue;
                        currentLine[x + 1] = (byte)oldGreen;
                        currentLine[x + 2] = (byte)oldRed;
                    }
                });
                processedBitmap.UnlockBits(bitmapData);
                GetSize(processedBitmap,Valor);
                return processedBitmap;
            }
        }

        private static void GetSize(Bitmap image,float Valor)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, image);
            Array = ms.ToArray();
            Valor = Array.Length;
        }
    }
}

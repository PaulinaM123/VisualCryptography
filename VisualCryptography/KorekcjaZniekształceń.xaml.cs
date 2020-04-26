using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kryptografia_wizualna
{
    /// <summary>
    /// Interaction logic for ProstyPrzykład.xaml
    /// </summary>
    public partial class KorekcjaZniekształceń : UserControl
    {
        public KorekcjaZniekształceń()
        {
            InitializeComponent();
        }
        string lokalizacja;
        BitmapSource bs;
        string udział1;
        string udział2;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int Rand()
        {
            lock (syncLock)
            {
                return random.Next(1, 7);
            }
        }



        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files ( *png, *jpg, *bmp) | *.png; *.jpg; *.bmp";
            openDialog.InitialDirectory = "C:\\Users\\PM\\Desktop";
            lokalizacja = openDialog.FileName.ToString();

            Nullable<bool> result = openDialog.ShowDialog();

            if (result == true)
            {
                lokalizacja = openDialog.FileName;
            }

            Display_BlackAndWhite();

        }
  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage(new Uri(lokalizacja));
            int width = (int)image.PixelWidth;
            int height = (int)image.PixelHeight;
            WriteableBitmap bitmap = new WriteableBitmap(image);

            int stride = width * ((bitmap.Format.BitsPerPixel + 7) / 8);
            int arraySize = stride * height;
            byte[] pixels = new byte[arraySize];
            byte[] sub_pixels_1 = new byte[arraySize * 4];
            byte[] sub_pixels_2 = new byte[arraySize * 4];
            bs.CopyPixels(pixels, stride, 0);

            int j = 0;
            int licznik = -width * 8;
            int rand;

            for (int x = 0; x < height; x++)
            {
                licznik = licznik + width * 8;

                for (int y = 0; y < width; y++)
                {
                    byte blue = pixels[j];
                    rand =Rand();
                    byte green = pixels[j + 1];
                    byte red = pixels[j + 2];
                    if ((blue & green & red) == 255)
                    {

                        switch (rand)
                        {
                            case 1:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 255;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 255;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 0;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1] = sub_pixels_2[licznik + 2] = 255;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5] = sub_pixels_2[licznik + 6] = 255;                                   
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                            case 2:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 0;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 0;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 255;

                                    sub_pixels_2[licznik ] = sub_pixels_2[licznik + 1 ] = sub_pixels_2[licznik + 2 ] = 0;
                                    sub_pixels_2[licznik + 4 ] = sub_pixels_2[licznik + 5 ] = sub_pixels_2[licznik + 6 ] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 255;
                                    break;
                                }
                            case 3:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 255;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 0;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 0;

                                    sub_pixels_2[licznik ] = sub_pixels_2[licznik + 1 ] = sub_pixels_2[licznik + 2 ] = 255;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5 ] = sub_pixels_2[licznik + 6 ] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                            case 4:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 0;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 255;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 255;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1] = sub_pixels_2[licznik + 2 ] = 0;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5 ] = sub_pixels_2[licznik + 6 ] = 255;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 255;
                                    break;
                                }
                            case 5:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 255;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 0;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 255;

                                    sub_pixels_2[licznik ] = sub_pixels_2[licznik + 1 ] = sub_pixels_2[licznik + 2 ] = 255;
                                    sub_pixels_2[licznik + 4 ] = sub_pixels_2[licznik + 5 ] = sub_pixels_2[licznik + 6 ] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 255;
                                    break;
                                }
                            case 6:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 0;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 255;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 0;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1 ] = sub_pixels_2[licznik + 2 ] = 0;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5 ] = sub_pixels_2[licznik + 6 ] = 255;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (rand)
                        {
                            case 1:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 0;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 255;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 0;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1] = sub_pixels_2[licznik + 2] = 255;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5] = sub_pixels_2[licznik + 6] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 255;
                                    break;
                                }
                            case 2:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 255;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 0;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 255;

                                    sub_pixels_2[licznik ] = sub_pixels_2[licznik + 1 ] = sub_pixels_2[licznik + 2 ] = 0;
                                    sub_pixels_2[licznik + 4 ] = sub_pixels_2[licznik + 5] = sub_pixels_2[licznik + 6 ] = 255;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                            case 3:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 255;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 255;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 0;

                                    sub_pixels_2[licznik ] = sub_pixels_2[licznik + 1 ] = sub_pixels_2[licznik + 2] = 0;
                                    sub_pixels_2[licznik + 4 ] = sub_pixels_2[licznik + 5 ] = sub_pixels_2[licznik + 6] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 255;
                                    break;
                                }
                            case 4:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 0;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 0;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 255;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1] = sub_pixels_2[licznik + 2] = 255;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5] = sub_pixels_2[licznik + 6] = 255;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                            case 5:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 255;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 0;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 0;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1] = sub_pixels_2[licznik + 2] = 255;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5] = sub_pixels_2[licznik + 6] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                            case 6:
                                {
                                    sub_pixels_1[licznik] = sub_pixels_1[licznik + 1] = sub_pixels_1[licznik + 2] = 0;
                                    sub_pixels_1[licznik + 4] = sub_pixels_1[licznik + 5] = sub_pixels_1[licznik + 6] = 255;
                                    sub_pixels_1[licznik + (width * 8)] = sub_pixels_1[licznik + 1 + (width * 8)] = sub_pixels_1[licznik + 2 + (width * 8)] = 0;
                                    sub_pixels_1[licznik + 4 + (width * 8)] = sub_pixels_1[licznik + 5 + (width * 8)] = sub_pixels_1[licznik + 6 + (width * 8)] = 255;

                                    sub_pixels_2[licznik] = sub_pixels_2[licznik + 1] = sub_pixels_2[licznik + 2] = 255;
                                    sub_pixels_2[licznik + 4] = sub_pixels_2[licznik + 5] = sub_pixels_2[licznik + 6] = 0;
                                    sub_pixels_2[licznik + (width * 8)] = sub_pixels_2[licznik + 1 + (width * 8)] = sub_pixels_2[licznik + 2 + (width * 8)] = 255;
                                    sub_pixels_2[licznik + 4 + (width * 8)] = sub_pixels_2[licznik + 5 + (width * 8)] = sub_pixels_2[licznik + 6 + (width * 8)] = 0;
                                    break;
                                }
                        }
                    }
                    j = j + 4;
                    licznik = licznik + 8;
                }
            }
            
       
            BitmapSource sub1 = BitmapSource.Create(width * 2, height*2, 300, 300, PixelFormats.Bgr32, null, sub_pixels_1, stride * 2);
            BitmapSource sub2 = BitmapSource.Create(width * 2, height*2, 300, 300, PixelFormats.Bgr32, null, sub_pixels_2, stride * 2);
            U1.Source = sub1;
            U2.Source = sub2;

        }


        private void Display_BlackAndWhite()
        {
            BitmapImage image = new BitmapImage(new Uri(lokalizacja));
            int width = (int)image.PixelWidth;
            int height = (int)image.PixelHeight;
            WriteableBitmap bitmap = new WriteableBitmap(image);

            int stride = width * ((bitmap.Format.BitsPerPixel + 7) / 8);
            int arraySize = stride * height;
            byte[] pixels = new byte[arraySize];

            bitmap.CopyPixels(pixels, stride, 0);

            int j = 0;
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    byte blue = pixels[j];
                    byte green = pixels[j + 1];
                    byte red = pixels[j + 2];

                    double mid = 255d * (1d / 1.5d);
                    double avg = (blue + red + green) / 3;
                    if (avg > mid)
                    {
                        pixels[j] = 255;
                        pixels[j + 1] = 255;
                        pixels[j + 2] = 255;
                    }
                    else
                    {
                        pixels[j] = 0;
                        pixels[j + 1] = 0;
                        pixels[j + 2] = 0;
                    }
                    j = j + 4;
                }
            }
            bs = BitmapSource.Create(width, height, 300, 300, PixelFormats.Bgr32, null, pixels, stride);
            Obraz.Source = bs;
        }


        private void U1_zapisz_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"U1.png";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)U1.Source));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);
            udział1 = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "U1.png");
        }

        private void U2_zapisz_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"U2.png";
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)U2.Source));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);
            udział2 = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "U2.png");
        }

        private void Złóż_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage u1 = new BitmapImage(new Uri(udział1));
                BitmapImage u2 = new BitmapImage(new Uri(udział2));
                int width = (int)u1.PixelWidth;
                int height = (int)u1.PixelHeight;
                WriteableBitmap bitmap1 = new WriteableBitmap(u1);
                WriteableBitmap bitmap2 = new WriteableBitmap(u2);

                int stride = width * ((bitmap1.Format.BitsPerPixel + 7) / 8);
                int arraySize = stride * height;

                byte[] sub_pixels_1 = new byte[arraySize];
                byte[] sub_pixels_2 = new byte[arraySize];
                bitmap1.CopyPixels(sub_pixels_1, stride, 0);
                bitmap2.CopyPixels(sub_pixels_2, stride, 0);

                int j = 0;

                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        sub_pixels_1[j] = (byte)(sub_pixels_1[j] + sub_pixels_2[j] - 255);
                        sub_pixels_1[j + 1] = (byte)(sub_pixels_1[j + 1] + sub_pixels_2[j + 1] - 255);
                        sub_pixels_1[j + 2] = (byte)(sub_pixels_1[j + 2] + sub_pixels_2[j + 2] - 255);

                        j = j + 4;

                    }
                }

                BitmapSource together = BitmapSource.Create(width, height, 300, 300, PixelFormats.Bgr32, null, sub_pixels_1, stride);

                Obraz1.Source = together;
            }catch(Exception)
            {
                Console.WriteLine("Nie można wykonac operacji.");
            }
        }

        private void U1_wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files ( *png, *jpg, *bmp) | *.png; *.jpg; *.bmp";
            openDialog.InitialDirectory = "C:\\Users\\PM\\Desktop";
            lokalizacja = openDialog.FileName.ToString();

            Nullable<bool> result = openDialog.ShowDialog();

            if (result == true)
            {
                udział1 = openDialog.FileName;
            }
            U1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(udział1);

        }

        private void U2_wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files ( *png, *jpg, *bmp) | *.png; *.jpg; *.bmp";
            openDialog.InitialDirectory = "C:\\Users\\PM\\Desktop";
            lokalizacja = openDialog.FileName.ToString();

            Nullable<bool> result = openDialog.ShowDialog();

            if (result == true)
            {
                udział2 = openDialog.FileName;
            }
            U2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(udział2);
        }

    }
}

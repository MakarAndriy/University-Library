using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfApplication3.Converters
{
    //Review DM: read about YAGNI pattern
    public class ByteArrayToBitmapImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var rawImageData = value as byte[];
            //Review DM: I think it wiil be beter ti use
            /*
            if (rawImageData != null)
            {
            using (MemoryStream strm = new MemoryStream())......
            }
            */
            //Always use curly braces ({ and }) in conditional statements.
            if (rawImageData == null)
				return null;
            //Review DM: U don't need write full direction, U use using System.Windows.Media.Imaging; in begin of file.
            var bitmapImage = new System.Windows.Media.Imaging.BitmapImage();
            //Review DM: U can use var, write full name of variables.
            using (MemoryStream strm = new MemoryStream())
			{
				strm.Write(rawImageData, 0, rawImageData.Length);
				strm.Position = 0;
				System.Drawing.Image img = System.Drawing.Image.FromStream(strm);

				bitmapImage.BeginInit();
				MemoryStream ms = new MemoryStream();
				img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

				ms.Seek(0, SeekOrigin.Begin);
				bitmapImage.StreamSource = ms;
				bitmapImage.EndInit();
				
			}
            //Revivew DM: I would prefer to use empty line space before return statement
            return bitmapImage;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

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
	public class ByteArrayToBitmapImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var rawImageData = value as byte[];
			if (rawImageData == null)
				return null;

			var bitmapImage = new System.Windows.Media.Imaging.BitmapImage();
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
			return bitmapImage;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

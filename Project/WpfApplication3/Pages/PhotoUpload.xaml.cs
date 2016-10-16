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
using WpfApplication3.Repository;

namespace WpfApplication3.Pages
{
    /// <summary>
    /// Interaction logic for PhotoUpload.xaml
    /// </summary>
    public partial class PhotoUpload : Page
    {
        public PhotoUpload()
        {
            InitializeComponent();
        }

        private byte[] _imageBytes = null;

        // Browse for an image on your computer
        private void BrowseButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) { return; }

            ImagePath.Text = dialog.FileName;
			BitmapImage bitmap = new BitmapImage(new Uri(ImagePath.Text));
            MyImage.Source = bitmap;

            using (var fs = new FileStream(ImagePath.Text, FileMode.Open, FileAccess.Read))
            {
                _imageBytes = new byte[fs.Length];
                fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
            }
        }

        // Save the selected image to your database
        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ImagePath.Text))
            {
                var userRepo = new UserRepository();
				userRepo.UpdateUserPhoto(UserID.Text, _imageBytes);
            }
        }
		private byte[] BitmapSourceToByteArray(BitmapSource image)
		{
			using (var stream = new MemoryStream())
			{
				var encoder = new JpegBitmapEncoder(); // or some other encoder
				encoder.Frames.Add(BitmapFrame.Create(image));
				encoder.Save(stream);
				return stream.ToArray();
			}
		}

        // Load an image from the database
        private void LoadButton_OnClick(object sender, RoutedEventArgs e)
        {
			var userRepo = new UserRepository();
			var user = userRepo.LoadUserDetails(UserID.Text);
			MemoryStream strm = new MemoryStream();
			var data  = user.Photo;

			strm.Write(data, 0, data.Length);
			strm.Position = 0;
			System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
			
			BitmapImage bi = new BitmapImage();

			bi.BeginInit();

			MemoryStream ms = new MemoryStream();
			img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

			ms.Seek(0, SeekOrigin.Begin);
			bi.StreamSource = ms;
			bi.EndInit();
			MyImage.Source = bi;
        }
    }
}

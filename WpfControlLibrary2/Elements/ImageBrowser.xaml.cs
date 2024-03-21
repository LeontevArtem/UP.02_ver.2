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

namespace WpfControlLibrary2.Elements
{
    /// <summary>
    /// Логика взаимодействия для ImageBrowser.xaml
    /// </summary>
    public partial class ImageBrowser : UserControl
    {
        public ImageBrowser()
        {
            InitializeComponent();
            Select.MouseDown += delegate { SelectImage(); };
        }
        public string image;
        public byte[] imgData;
        public string path;
        public BitmapImage BitImage;
        public void SelectImage()
        {
            try
            {
                OpenFileDialog openImg = new OpenFileDialog();
                openImg.ShowDialog();
                if (openImg.FileName == null) return;
                path = openImg.FileName;
                var capture = new BitmapImage();
                var streamCapture = File.OpenRead(path);
                capture.BeginInit();
                capture.CacheOption = BitmapCacheOption.OnLoad;
                capture.StreamSource = streamCapture;
                capture.EndInit();
                img.Source = capture;
                BitImage = capture;
                streamCapture.Close();
                streamCapture.Dispose();
                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    imgData = new byte[file.Length];
                    file.Read(imgData, 0, imgData.Length);
                    file.Close();
                    file.Dispose();
                };
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка загрузки картинки", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        public byte[] GetByteImage()
        {
            return imgData;
        }
        public void HideButton()
        {
            Select.Visibility = Visibility.Collapsed;
        }
        public void ShowButton()
        {
            Select.Visibility = Visibility.Visible;
        }
        public string Image;
        public void SetImage(string Image)
        {
            img.Source = Base64StringToBitMap(Image);
            this.Image = Image;
        }
        public string GetStringImage()
        {

            try
            {
                return Convert.ToBase64String(imgData);
            }
            catch
            {
                return this.Image;
            }
        }
        public BitmapImage GetBitmapImage()
        {
            return BitImage;
        }
        public static BitmapImage Base64StringToBitMap(string base64String)
        {
            //Работа с Изображениями, сохраненными в виде массива битов prod. by Sanya Galanov
            try
            {
                byte[] buffer = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(buffer))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            catch { }

#pragma warning disable CS0162 // Обнаружен недостижимый код
            return null;
#pragma warning restore CS0162 // Обнаружен недостижимый код
        }
    }
}

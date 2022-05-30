using Game___Capture.controler;
using Game___Capture.Resources;
using Game___Capture.service;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

namespace Game___Capture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game_Field.Background = new ImageBrush
            {
                ImageSource = ToBitmapImage(Resource1.ico),
                Stretch = Stretch.Uniform,
            };



            //RenderService renderService = new RenderService(
            //    image: Game_Field,
            //    );


            //this.frontPresenter = new Controler(renderService, horseService);
        }

        private readonly Controler frontPresenter;

        private void Butt_Click(object sender, RoutedEventArgs e)
        {
            Game_Field.Strokes.Clear();
        }

        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}

using Game___Capture.model.Cells;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Game___Capture.util
{
    public static class ConvertUtil
    {
        public static BitmapImage ToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            using MemoryStream memory = new();
            bitmap.Save(memory, ImageFormat.Png);
            memory.Position = 0;

            BitmapImage bitmapImage = new();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }

        public static List<Cell> ToList(Cell[][] cells)
        {
            if (cells == null)
            {
                return null;
            }

            List<Cell> cellsList = new();

            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    cellsList.Add(cells[i][j]);
                }
            }

            return cellsList;
        }

        #region Trash

        public static System.Drawing.Point ToDrawingPoint(this System.Windows.Point point)
        {
            return new System.Drawing.Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
        }

        #endregion
    }
}

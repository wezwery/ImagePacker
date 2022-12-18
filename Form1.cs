using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ImagePacker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Tuple<string, string>> selectedImages = new List<Tuple<string, string>>();

        void updateImageList()
        {
            ImageList.Items.Clear();
            ImageList.Items.AddRange(selectedImages.Select(a => a.Item2).ToArray());

            SaveBtn.Enabled = selectedImages.Count > 0;
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = FolderBrowserDialog.SelectedPath;

                var files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);

                selectedImages.AddRange(files.Select(a => new Tuple<string, string>(a, new FileInfo(a).Name)));

                updateImageList();
            }
        }

        private void ImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteBtn.Enabled = ImageList.SelectedIndex > -1;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            selectedImages.RemoveAt(ImageList.SelectedIndex);

            updateImageList();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathToSave = SaveFileDialog.FileName.Replace(".png", "").Trim();

                Tuple<Bitmap, string>[] images = new Tuple<Bitmap, string>[selectedImages.Count];
                for (int i = 0; i < selectedImages.Count; i++)
                {
                    images[i] = new Tuple<Bitmap, string>(new Bitmap(selectedImages[i].Item1), selectedImages[i].Item2);
                }

                var output = CreateImageSheet(SIZE_OFFSET, SIZE_OFFSET, images);

                output.Item2.Save($"{pathToSave}.png", System.Drawing.Imaging.ImageFormat.Png);

                XmlSerializer xml = new XmlSerializer(typeof(ImageData[]));

                using (var f = File.Create($"{pathToSave}Data.xml"))
                {
                    xml.Serialize(f, output.Item1);
                }
            }
        }

        public struct ImageData
        {
            public string name;
            public IntRect rect;

            public ImageData(string name, IntRect rect)
            {
                this.name = name;
                this.rect = rect;
            }
        }
        public struct IntRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;

            public bool Intersects(IntRect rect)
            {
                int r1MinX = Math.Min(Left, Left + Width);
                int r1MaxX = Math.Max(Left, Left + Width);
                int r1MinY = Math.Min(Top, Top + Height);
                int r1MaxY = Math.Max(Top, Top + Height);

                int r2MinX = Math.Min(rect.Left, rect.Left + rect.Width);
                int r2MaxX = Math.Max(rect.Left, rect.Left + rect.Width);
                int r2MinY = Math.Min(rect.Top, rect.Top + rect.Height);
                int r2MaxY = Math.Max(rect.Top, rect.Top + rect.Height);

                int interLeft = Math.Max(r1MinX, r2MinX);
                int interTop = Math.Max(r1MinY, r2MinY);
                int interRight = Math.Min(r1MaxX, r2MaxX);
                int interBottom = Math.Min(r1MaxY, r2MaxY);

                if ((interLeft < interRight) && (interTop < interBottom))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public IntRect(int left, int top, int width, int height)
            {
                Left = left;
                Top = top;
                Width = width;
                Height = height;
            }
        }

        private const int SIZE_OFFSET = 128;
        public int SPACE_BETWEEN_IMAGES_PX = 1;

        public Tuple<ImageData[], Bitmap> CreateImageSheet(int outputWidth, int outputHeight, Tuple<Bitmap, string>[] images)
        {
            Bitmap outputImage = new Bitmap(outputWidth, outputHeight);
            var sortedImages = images.OrderByDescending(a => Math.Pow(a.Item1.Width + a.Item1.Height, 2)).ToArray();
            List<ImageData> datas = new List<ImageData>();
            bool isEmptyForRect(IntRect another)
            {
                foreach (var data in datas)
                {
                    if (data.rect.Intersects(another)) return false;
                }

                return true;
            }

            using (Graphics gr = Graphics.FromImage(outputImage))
            {
                foreach (var img in images)
                {
                    int width = img.Item1.Width;
                    int height = img.Item1.Height;
                    int x = 0;
                    int y = 0;

                    foreach (var data in datas)
                    {
                        var rect = data.rect;

                        if (rect.Left + rect.Width + width < outputWidth && rect.Top + height < outputHeight)
                        {
                            x = rect.Left + rect.Width + SPACE_BETWEEN_IMAGES_PX;
                            y = rect.Top/* + (y == 0 ? 0 : SPACE_BETWEEN_IMAGES_PX)*/;
                            if (isEmptyForRect(new IntRect(x,y,width,height))) break;
                        }
                        if (rect.Left + width < outputWidth && rect.Top + rect.Height + height < outputHeight)
                        {
                            x = rect.Left/* + (x == 0 ? 0 : SPACE_BETWEEN_IMAGES_PX)*/;
                            y = rect.Top + rect.Height + SPACE_BETWEEN_IMAGES_PX;
                            if (isEmptyForRect(new IntRect(x, y, width, height))) break;
                        }

                        x = rect.Left + rect.Width + SPACE_BETWEEN_IMAGES_PX;
                        y = rect.Top + rect.Height + SPACE_BETWEEN_IMAGES_PX;
                    }

                    if (x + width > outputWidth && outputWidth <= outputHeight)
                    {
                        return CreateImageSheet(outputWidth + SIZE_OFFSET, outputHeight, images);
                    }
                    else if (y + height > outputHeight && outputHeight <= outputWidth)
                    {
                        return CreateImageSheet(outputWidth, outputHeight + SIZE_OFFSET, images);
                    }
                    else if (x + width > outputWidth || y + height > outputHeight)
                    {
                        return CreateImageSheet(outputWidth + SIZE_OFFSET, outputHeight, images);
                    }

                    gr.DrawImage(img.Item1, x, y);
                    datas.Add(new ImageData(img.Item2, new IntRect(x, y, width, height)));
                }
            }

            List<string> names = images.Select(a => a.Item2).ToList();
            ImageData[] sortedDatas = new ImageData[names.Count];

            for (int i = 0; i < datas.Count; i++)
            {
                sortedDatas[names.IndexOf(datas[i].name)] = datas[i];
            }

            return new Tuple<ImageData[], Bitmap>(sortedDatas, outputImage);
        }

        private void SpaceBetweenPicturesNumericDropDown_ValueChanged(object sender, EventArgs e)
        {
            SPACE_BETWEEN_IMAGES_PX = (int)SpaceBetweenPicturesNumericDropDown.Value;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            selectedImages.Clear();

            updateImageList();
        }
    }
}

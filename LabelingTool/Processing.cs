using System.Collections.Generic;
using System.IO;
using OpenCvSharp;

namespace LabelingTool
{
    static class Processing
    {
        private static Size _size;
        private static List<Rect>[] _rects;
        private static Point _temp;
        private static Mat _image;
        private static string[] _filePaths;

        public static string SaveDirectory { set; get; }
        public static int FrameNumber { set; get; }
        public static int FileCount => _filePaths.Length;
        public static int RectCount => _rects[FrameNumber].Count;

        public static Mat Initialize(string dir, string ext, int width, int height)
        {
            FrameNumber = 0;
            _size = new Size(width, height);
            _filePaths = Directory.GetFiles(dir, $"*{ext}");
            _rects = new List<Rect>[_filePaths.Length];
            if (_filePaths.Length == 0) return new Mat(height, width, MatType.CV_8U, 0);
            for (int i = 0; i < _filePaths.Length; i++)
            {
                _rects[i] = new List<Rect>();
            }
            _image = new Mat(_filePaths[0]);
            Cv2.Resize(_image, _image, _size);
            return _image;
        }

        public static Mat GoBack()
        {
            _image = new Mat(_filePaths[--FrameNumber]);
            DrawAll(ref _image);
            return _image;
        }

        public static Mat GoNext()
        {
            _image = new Mat(_filePaths[++FrameNumber]);
            DrawAll(ref _image);
            return _image;
        }

        public static Mat SelectStart(int x, int y)
        {
            _temp = new Point(x, y);
            var viewImg = _image.Clone();
            DrawAll(ref viewImg);
            return viewImg;
        }

        public static Mat Drag(int x, int y)
        {
            if (x == _temp.X || y == _temp.Y) return _image;
            var rect = new Rect();
            if (x > _temp.X && y > _temp.Y) rect = new Rect(_temp, new Size(x - _temp.X, y - _temp.Y));
            if (x > _temp.X && y < _temp.Y) rect = new Rect(new Point(_temp.X, y), new Size(x - _temp.X, _temp.Y - y));
            if (x < _temp.X && y > _temp.Y) rect = new Rect(new Point(x, _temp.Y), new Size(_temp.X - x, y - _temp.Y));
            if (x < _temp.X && y < _temp.Y) rect = new Rect(new Point(x, y), new Size(_temp.X - x, _temp.Y - y));
            var viewImg = _image.Clone();
            DrawAll(ref viewImg);
            Cv2.Rectangle(viewImg, rect, new Scalar(255, 0, 0), 2);
            return viewImg;
        }

        public static Mat SelectGoal(int x, int y)
        {
            if (x == _temp.X || y == _temp.Y) return _image;
            var rect = new Rect();
            if (x > _temp.X && y > _temp.Y) rect = new Rect(_temp, new Size(x - _temp.X, y - _temp.Y));
            if (x > _temp.X && y < _temp.Y) rect = new Rect(new Point(_temp.X, y), new Size(x - _temp.X, _temp.Y - y));
            if (x < _temp.X && y > _temp.Y) rect = new Rect(new Point(x, _temp.Y), new Size(_temp.X - x, y - _temp.Y));
            if (x < _temp.X && y < _temp.Y) rect = new Rect(new Point(x, y), new Size(_temp.X - x, _temp.Y - y));
            _rects[FrameNumber].Add(rect);
            var viewImg = _image.Clone();
            DrawAll(ref viewImg);
            Cv2.Rectangle(viewImg, rect, new Scalar(0, 0, 255), 2);
            return viewImg;
        }

        public static void Save()
        {
            var filename = Path.GetFileNameWithoutExtension(_filePaths[FrameNumber]);
            using (var sw = new StreamWriter($"{SaveDirectory}\\{filename}.txt", false))
            {
                foreach (var rect in _rects[FrameNumber])
                {
                    var centerX = (double)(rect.Left + rect.Width / 2) / _size.Width;
                    var centerY = (double)(rect.Top + rect.Height / 2) / _size.Height;
                    var width = (double)rect.Width / _size.Width;
                    var height = (double)rect.Height / _size.Height;
                    sw.WriteLine($"0 {centerX:f6} {centerY:f6} {width:f6} {height:f6}");
                }
            }
        }

        public static Mat Clear()
        {
            _image = new Mat(_filePaths[FrameNumber]);
            Cv2.Resize(_image, _image, _size);
            _rects[FrameNumber].Clear();
            return _image;
        }

        public static Mat RemoveLast()
        {
            _rects[FrameNumber].RemoveAt(_rects[FrameNumber].Count - 1);
            _image = new Mat(_filePaths[FrameNumber]);
            DrawAll(ref _image);
            return _image;
        }

        private static void DrawAll(ref Mat img)
        {
            Cv2.Resize(img, img, _size);
            foreach (var rect in _rects[FrameNumber])
            {
                Cv2.Rectangle(img, rect, new Scalar(0, 0, 255), 2);
            }
        }
    }
}

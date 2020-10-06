using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using YoloSharp;
using System.IO;

namespace CsApp
{
    public partial class View : Form
    {
        private Detector _detector;
        private Mat img;

        public View()
        {
            InitializeComponent();
            OpenButton.Enabled = false;
            RunButton.Enabled = false;
        }


        private void InitButton_Click(object sender, EventArgs e)
        {
            var cfgPath = CfgTx.Text;
            var namesPath = NamesTx.Text;
            var weightsPath = WeightsTx.Text;
            var confThresh = float.Parse(ConfTx.Text);
            var nmsThresh = float.Parse(NmsTx.Text);
            if (!File.Exists(cfgPath) || !File.Exists(namesPath) || !File.Exists(weightsPath)) return;
            _detector = new Detector();
            _detector.InitializeDetector(cfgPath, namesPath, weightsPath, new Size(384, 288), confThresh, nmsThresh);
            OpenButton.Enabled = true;
            RunButton.Enabled = false;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog();
            op.Title = "画像ファイルを開く";
            if (op.ShowDialog() == DialogResult.OK)
            {
                var ext = Path.GetExtension(op.FileName);
                if (ext != ".jpg" && ext != ".png") return;
                img = new Mat(op.FileName);
                Cv2.Resize(img, img, new Size(640, 480));
                pictureBox.Image = img.ToBitmap();
                RunButton.Enabled = true;
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var results = _detector.Run(img);
            pictureBox.Image = results.OutputImg.ToBitmap();
            sw.Stop();
            Time.Text = $"Runtime : {sw.ElapsedMilliseconds} ms";
            RunButton.Enabled = false;
        }
    }
}

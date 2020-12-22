using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp.Extensions;

namespace LabellingTool
{
    public partial class View : Form
    {
        private bool _mouseMove;
        private string _labelPath;
        private string[] _labels;

        public View()
        {
            InitializeComponent();
            BackButton.Enabled = false;
            NextButton.Enabled = false;
            SaveButton.Enabled = false;
            UndoButton.Enabled = false;
            ClearButton.Enabled = false;
            _mouseMove = false;
            _labelPath = $"..\\..\\..\\classes.txt";
            _labels = File.ReadAllLines(_labelPath).ToArray();
            comboBox.Text = _labels[0];
            comboBox.Items.AddRange(_labels.ToArray());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var fbd1 = new FolderBrowserDialog();
            fbd1.Description = "画像フォルダを選択";
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                var fbd2 = new FolderBrowserDialog();
                fbd2.Description = "保存先を選択";
                if (fbd2.ShowDialog() == DialogResult.OK)
                {
                    var img = Processing.Initialize(fbd1.SelectedPath, fbd2.SelectedPath, _labels, int.Parse(WidthTx.Text), int.Parse(HeightTx.Text));
                    pictureBox.Width = img.Width;
                    pictureBox.Height = img.Height;
                    pictureBox.Image = img.ToBitmap();
                    pictureBox.Enabled = true;
                    ProgressCount_label.Text = $"{Processing.FrameNumber + 1} / {Processing.FileCount}";
                    BackButton.Enabled = false;
                    NextButton.Enabled = false;
                    SaveButton.Enabled = false;
                    UndoButton.Enabled = false;
                    ClearButton.Enabled = false;
                    if (Processing.FrameNumber != Processing.FileCount - 1) NextButton.Enabled = true;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var img = Processing.GoBack();
            pictureBox.Image = img.ToBitmap();
            ProgressCount_label.Text = $"{Processing.FrameNumber + 1} / {Processing.FileCount}";
            NextButton.Enabled = true;
            if (Processing.FrameNumber == 0) BackButton.Enabled = false;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var img = Processing.GoNext();
            pictureBox.Image = img.ToBitmap();
            ProgressCount_label.Text = $"{Processing.FrameNumber + 1} / {Processing.FileCount}";
            BackButton.Enabled = true;
            if (Processing.FrameNumber == Processing.FileCount - 1) NextButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Processing.Save();
            SaveButton.Enabled = false;
            if (Processing.FrameNumber != 0) BackButton.Enabled = true;
            if (Processing.FrameNumber != Processing.FileCount - 1) NextButton.Enabled =true;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            var img = Processing.RemoveLast();
            pictureBox.Image = img.ToBitmap();
            SaveButton.Enabled = true;
            if (Processing.RectCount == 0)
            {
                UndoButton.Enabled = false;
                ClearButton.Enabled = false;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            var img = Processing.Clear();
            pictureBox.Image = img.ToBitmap();
            UndoButton.Enabled = false;
            ClearButton.Enabled = false;
            SaveButton.Enabled = false;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseMove = true;
            var img = Processing.SelectStart(e.X, e.Y);
            pictureBox.Image = img.ToBitmap();
            BackButton.Enabled = false;
            NextButton.Enabled = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseMove)
            {
                var img = Processing.Drag(e.X, e.Y);
                pictureBox.Image = img.ToBitmap();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_mouseMove) return;
            _mouseMove = false;
            var index = comboBox.SelectedIndex;
            if (index == -1) index = 0;
            var img = Processing.SelectGoal(e.X, e.Y, index);
            pictureBox.Image = img.ToBitmap();
            UndoButton.Enabled = true;
            ClearButton.Enabled = true;
            SaveButton.Enabled = true;
        }

        private void View_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "a":
                    if (BackButton.Enabled == false) break;
                    var img1 = Processing.GoBack();
                    pictureBox.Image = img1.ToBitmap();
                    ProgressCount_label.Text = $"{Processing.FrameNumber + 1} / {Processing.FileCount}";
                    NextButton.Enabled = true;
                    if (Processing.FrameNumber == 0) BackButton.Enabled = false;
                    break;
                case "d":
                    if (NextButton.Enabled == false) break;
                    var img2 = Processing.GoNext();
                    pictureBox.Image = img2.ToBitmap();
                    ProgressCount_label.Text = $"{Processing.FrameNumber + 1} / {Processing.FileCount}";
                    BackButton.Enabled = true;
                    if (Processing.FrameNumber == Processing.FileCount - 1) NextButton.Enabled = false;
                    break;
                case "s":
                    if (SaveButton.Enabled == false) break;
                    Processing.Save();
                    SaveButton.Enabled = false;
                    if (Processing.FrameNumber != 0) BackButton.Enabled = true;
                    if (Processing.FrameNumber != Processing.FileCount - 1) NextButton.Enabled = true;
                    break;
                case "c":
                    if (ClearButton.Enabled == false) break;
                    var img3 = Processing.Clear();
                    pictureBox.Image = img3.ToBitmap();
                    UndoButton.Enabled = false;
                    ClearButton.Enabled = false;
                    SaveButton.Enabled = false;
                    break;
                case "x":
                    if (UndoButton.Enabled == false) break;
                    var img4 = Processing.RemoveLast();
                    pictureBox.Image = img4.ToBitmap();
                    SaveButton.Enabled = true;
                    if (Processing.RectCount == 0)
                    {
                        UndoButton.Enabled = false;
                        ClearButton.Enabled = false;
                    }
                    break;
            }
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

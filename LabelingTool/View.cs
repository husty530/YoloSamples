using System;
using System.Windows.Forms;
using OpenCvSharp.Extensions;

namespace LabelingTool
{
    public partial class View : Form
    {
        private bool _mouseMove;

        public View()
        {
            InitializeComponent();
            SaveDirButton.Enabled = false;
            BackButton.Enabled = false;
            NextButton.Enabled = false;
            SaveButton.Enabled = false;
            UndoButton.Enabled = false;
            ClearButton.Enabled = false;
            _mouseMove = false;
        }

        private void OpenDirButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "画像フォルダを選択";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var img = Processing.Initialize(fbd.SelectedPath, ExtensionTx.Text, int.Parse(WidthTx.Text), int.Parse(HeightTx.Text));
                pictureBox.Width = img.Width;
                pictureBox.Height = img.Height;
                pictureBox.Image = img.ToBitmap();
                SaveDirButton.Enabled = true;
                BackButton.Enabled = false;
                NextButton.Enabled = false;
                SaveButton.Enabled = false;
                UndoButton.Enabled = false;
                ClearButton.Enabled = false;
            }
        }

        private void SaveDirButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "保存先を選択";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Processing.SaveDirectory = fbd.SelectedPath;
                pictureBox.Enabled = true;
                if (Processing.FrameNumber != Processing.FileCount - 1) NextButton.Enabled = true;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var img = Processing.GoBack();
            pictureBox.Image = img.ToBitmap();
            NextButton.Enabled = true;
            if (Processing.FrameNumber == 0) BackButton.Enabled = false;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var img = Processing.GoNext();
            pictureBox.Image = img.ToBitmap();
            BackButton.Enabled = true;
            if (Processing.FrameNumber == Processing.FileCount - 1) NextButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Processing.Save();
            SaveButton.Enabled = false;
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
            var img = Processing.SelectGoal(e.X, e.Y);
            pictureBox.Image = img.ToBitmap();
            UndoButton.Enabled = true;
            ClearButton.Enabled = true;
            SaveButton.Enabled = true;
        }
    }
}

namespace LabellingTool
{
    partial class View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WidthTx = new System.Windows.Forms.TextBox();
            this.HeightTx = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProgressCount_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(12, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(81, 47);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Open";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UndoButton.Location = new System.Drawing.Point(586, 12);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(81, 47);
            this.UndoButton.TabIndex = 2;
            this.UndoButton.Text = "Undo(X)";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClearButton.Location = new System.Drawing.Point(673, 12);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(81, 47);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear(C)";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(499, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(81, 47);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save(S)";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.Maroon;
            this.BackButton.Location = new System.Drawing.Point(369, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(59, 47);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "◀(A)";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NextButton.ForeColor = System.Drawing.Color.Navy;
            this.NextButton.Location = new System.Drawing.Point(434, 12);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(59, 47);
            this.NextButton.TabIndex = 6;
            this.NextButton.Text = "▶(D)";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 66);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(113, 50);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Size";
            // 
            // WidthTx
            // 
            this.WidthTx.Location = new System.Drawing.Point(174, 36);
            this.WidthTx.Name = "WidthTx";
            this.WidthTx.Size = new System.Drawing.Size(29, 23);
            this.WidthTx.TabIndex = 10;
            this.WidthTx.Text = "640";
            // 
            // HeightTx
            // 
            this.HeightTx.Location = new System.Drawing.Point(209, 36);
            this.HeightTx.Name = "HeightTx";
            this.HeightTx.Size = new System.Drawing.Size(30, 23);
            this.HeightTx.TabIndex = 12;
            this.HeightTx.Text = "480";
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(760, 36);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(112, 23);
            this.comboBox.TabIndex = 14;
            this.comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(760, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Selected Class";
            // 
            // ProgressCount_label
            // 
            this.ProgressCount_label.AutoSize = true;
            this.ProgressCount_label.Location = new System.Drawing.Point(316, 39);
            this.ProgressCount_label.Name = "ProgressCount_label";
            this.ProgressCount_label.Size = new System.Drawing.Size(30, 15);
            this.ProgressCount_label.TabIndex = 16;
            this.ProgressCount_label.Text = "0 / 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Progress";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 711);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProgressCount_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.HeightTx);
            this.Controls.Add(this.WidthTx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.StartButton);
            this.KeyPreview = true;
            this.Name = "View";
            this.Text = "Labeling Tool";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.View_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WidthTx;
        private System.Windows.Forms.TextBox HeightTx;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ProgressCount_label;
        private System.Windows.Forms.Label label4;
    }
}


namespace CsApp
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
            this.OpenButton = new System.Windows.Forms.Button();
            this.InitButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CfgTx = new System.Windows.Forms.TextBox();
            this.NamesTx = new System.Windows.Forms.TextBox();
            this.WeightsTx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ConfTx = new System.Windows.Forms.TextBox();
            this.NmsTx = new System.Windows.Forms.TextBox();
            this.Time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(11, 388);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 34);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // InitButton
            // 
            this.InitButton.Location = new System.Drawing.Point(12, 319);
            this.InitButton.Name = "InitButton";
            this.InitButton.Size = new System.Drawing.Size(75, 34);
            this.InitButton.TabIndex = 1;
            this.InitButton.Text = "Init";
            this.InitButton.UseVisualStyleBackColor = true;
            this.InitButton.Click += new System.EventHandler(this.InitButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(188, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 480);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Initialize Detector";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Open Image File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Config File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Names File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Weights File";
            // 
            // CfgTx
            // 
            this.CfgTx.Location = new System.Drawing.Point(12, 27);
            this.CfgTx.Name = "CfgTx";
            this.CfgTx.Size = new System.Drawing.Size(141, 23);
            this.CfgTx.TabIndex = 8;
            this.CfgTx.Text = "D:\\\\YOLOv4\\\\yolov4.cfg";
            // 
            // NamesTx
            // 
            this.NamesTx.Location = new System.Drawing.Point(12, 81);
            this.NamesTx.Name = "NamesTx";
            this.NamesTx.Size = new System.Drawing.Size(141, 23);
            this.NamesTx.TabIndex = 9;
            this.NamesTx.Text = "D:\\\\YOLOv4\\\\coco.names";
            // 
            // WeightsTx
            // 
            this.WeightsTx.Location = new System.Drawing.Point(12, 139);
            this.WeightsTx.Name = "WeightsTx";
            this.WeightsTx.Size = new System.Drawing.Size(141, 23);
            this.WeightsTx.TabIndex = 10;
            this.WeightsTx.Text = "D:\\\\YOLOv4\\\\yolov4.weights";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Run Detection";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(12, 459);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 38);
            this.RunButton.TabIndex = 12;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Confidence Threshold";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "NMS Threshold";
            // 
            // ConfTx
            // 
            this.ConfTx.Location = new System.Drawing.Point(11, 200);
            this.ConfTx.Name = "ConfTx";
            this.ConfTx.Size = new System.Drawing.Size(142, 23);
            this.ConfTx.TabIndex = 15;
            this.ConfTx.Text = "0.5";
            // 
            // NmsTx
            // 
            this.NmsTx.Location = new System.Drawing.Point(11, 260);
            this.NmsTx.Name = "NmsTx";
            this.NmsTx.Size = new System.Drawing.Size(142, 23);
            this.NmsTx.TabIndex = 16;
            this.NmsTx.Text = "0.3";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(188, 27);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(60, 15);
            this.Time.TabIndex = 17;
            this.Time.Text = "Runtime : ";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(852, 544);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.NmsTx);
            this.Controls.Add(this.ConfTx);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.WeightsTx);
            this.Controls.Add(this.NamesTx);
            this.Controls.Add(this.CfgTx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.InitButton);
            this.Controls.Add(this.OpenButton);
            this.Name = "View";
            this.Text = "Detection Time : ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button InitButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CfgTx;
        private System.Windows.Forms.TextBox NamesTx;
        private System.Windows.Forms.TextBox WeightsTx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ConfTx;
        private System.Windows.Forms.TextBox NmsTx;
        private System.Windows.Forms.Label Time;
    }
}


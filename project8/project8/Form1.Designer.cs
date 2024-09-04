namespace project6
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            lbl1 = new Label();
            lbl2 = new Label();
            pictureBox2 = new PictureBox();
            lbl3 = new Label();
            pictureBox3 = new PictureBox();
            lbl4 = new Label();
            pictureBox4 = new PictureBox();
            lbl5 = new Label();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(12, 9);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(94, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "HinhGocRGB";
            lbl1.Click += label1_Click;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(12, 339);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(73, 20);
            lbl2.TabIndex = 3;
            lbl2.Text = "Kenh Hue";
            lbl2.Click += lbl2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(12, 362);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(256, 256);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(300, 339);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(114, 20);
            lbl3.TabIndex = 5;
            lbl3.Text = "Kenh Saturation";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(311, 362);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(256, 256);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Location = new Point(625, 339);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(59, 20);
            lbl4.TabIndex = 7;
            lbl4.Text = "Kenh V ";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(625, 362);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(256, 256);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Location = new Point(921, 339);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(72, 20);
            lbl5.TabIndex = 9;
            lbl5.Text = "Hinh HSV";
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(921, 362);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(256, 256);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 653);
            Controls.Add(lbl5);
            Controls.Add(pictureBox5);
            Controls.Add(lbl4);
            Controls.Add(pictureBox4);
            Controls.Add(lbl3);
            Controls.Add(pictureBox3);
            Controls.Add(lbl2);
            Controls.Add(pictureBox2);
            Controls.Add(lbl1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = " RGB_sang_CMYK";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbl1;
        private Label lbl2;
        private PictureBox pictureBox2;
        private Label lbl3;
        private PictureBox pictureBox3;
        private Label lbl4;
        private PictureBox pictureBox4;
        private Label lbl5;
        private PictureBox pictureBox5;
    }
}

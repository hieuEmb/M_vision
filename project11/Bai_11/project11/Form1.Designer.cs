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
            label1 = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            pictureBox4 = new PictureBox();
            label3 = new Label();
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
            pictureBox1.Location = new Point(12, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(12, -1);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(94, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "HinhGocRGB";
            lbl1.Click += label1_Click;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(530, -1);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(140, 20);
            lbl2.TabIndex = 3;
            lbl2.Text = "Hinhdalammuot3x3";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(530, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(512, 512);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1048, -1);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 5;
            label1.Text = "Hinhdalammuot5x5";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(1048, 22);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(512, 512);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 537);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 7;
            label2.Text = "Hinhdalammuot7x7";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(12, 552);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(512, 512);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(530, 537);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 9;
            label3.Text = "Hinhdalammuot9x9";
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(530, 552);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(512, 512);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(label3);
            Controls.Add(pictureBox5);
            Controls.Add(label2);
            Controls.Add(pictureBox4);
            Controls.Add(label1);
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
        private Label label1;
        private PictureBox pictureBox3;
        private Label label2;
        private PictureBox pictureBox4;
        private Label label3;
        private PictureBox pictureBox5;
    }
}

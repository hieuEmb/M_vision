namespace project3._1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxHinhGoc = new System.Windows.Forms.PictureBox();
            this.lblHinhGoc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picBoxHinhNhiPhan = new System.Windows.Forms.PictureBox();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.lblThresold = new System.Windows.Forms.Label();
            this.labelNguong = new System.Windows.Forms.Label();
            this.trackBar_bien = new System.Windows.Forms.TrackBar();
            this.lblNguong = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label_nguong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhNhiPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_bien)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxHinhGoc
            // 
            this.picBoxHinhGoc.Location = new System.Drawing.Point(0, 23);
            this.picBoxHinhGoc.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxHinhGoc.Name = "picBoxHinhGoc";
            this.picBoxHinhGoc.Size = new System.Drawing.Size(512, 512);
            this.picBoxHinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhGoc.TabIndex = 0;
            this.picBoxHinhGoc.TabStop = false;
            // 
            // lblHinhGoc
            // 
            this.lblHinhGoc.AutoSize = true;
            this.lblHinhGoc.Location = new System.Drawing.Point(9, 7);
            this.lblHinhGoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHinhGoc.Name = "lblHinhGoc";
            this.lblHinhGoc.Size = new System.Drawing.Size(49, 13);
            this.lblHinhGoc.TabIndex = 2;
            this.lblHinhGoc.Text = "HinhGoc";
            this.lblHinhGoc.Click += new System.EventHandler(this.lblHinhGoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Edge Detection";
            // 
            // picBoxHinhNhiPhan
            // 
            this.picBoxHinhNhiPhan.Location = new System.Drawing.Point(535, 23);
            this.picBoxHinhNhiPhan.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxHinhNhiPhan.Name = "picBoxHinhNhiPhan";
            this.picBoxHinhNhiPhan.Size = new System.Drawing.Size(512, 512);
            this.picBoxHinhNhiPhan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhNhiPhan.TabIndex = 9;
            this.picBoxHinhNhiPhan.TabStop = false;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(926, 405);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(8, 6);
            this.vScrollBar2.TabIndex = 12;
            // 
            // lblThresold
            // 
            this.lblThresold.AutoSize = true;
            this.lblThresold.Location = new System.Drawing.Point(108, 602);
            this.lblThresold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThresold.Name = "lblThresold";
            this.lblThresold.Size = new System.Drawing.Size(45, 13);
            this.lblThresold.TabIndex = 13;
            this.lblThresold.Text = "Nguong";
            // 
            // labelNguong
            // 
            this.labelNguong.AutoSize = true;
            this.labelNguong.Location = new System.Drawing.Point(1227, 23);
            this.labelNguong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNguong.Name = "labelNguong";
            this.labelNguong.Size = new System.Drawing.Size(0, 13);
            this.labelNguong.TabIndex = 14;
            // 
            // trackBar_bien
            // 
            this.trackBar_bien.Location = new System.Drawing.Point(225, 602);
            this.trackBar_bien.Maximum = 255;
            this.trackBar_bien.Name = "trackBar_bien";
            this.trackBar_bien.Size = new System.Drawing.Size(661, 45);
            this.trackBar_bien.TabIndex = 15;
            this.trackBar_bien.Value = 130;
            this.trackBar_bien.Scroll += new System.EventHandler(this.vScrollBarHinhNhiPhan_ValueChanged);
            // 
            // lblNguong
            // 
            this.lblNguong.AutoSize = true;
            this.lblNguong.Location = new System.Drawing.Point(173, 572);
            this.lblNguong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNguong.Name = "lblNguong";
            this.lblNguong.Size = new System.Drawing.Size(0, 13);
            this.lblNguong.TabIndex = 16;
            this.lblNguong.Click += new System.EventHandler(this.vScrollBarHinhNhiPhan_ValueChanged);
            this.lblNguong.Validated += new System.EventHandler(this.vScrollBarHinhNhiPhan_ValueChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(197, 572);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 17;
            // 
            // label_nguong
            // 
            this.label_nguong.AutoSize = true;
            this.label_nguong.Location = new System.Drawing.Point(197, 585);
            this.label_nguong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nguong.Name = "label_nguong";
            this.label_nguong.Size = new System.Drawing.Size(0, 13);
            this.label_nguong.TabIndex = 18;
            this.label_nguong.Click += new System.EventHandler(this.vScrollBarHinhNhiPhan_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 757);
            this.Controls.Add(this.label_nguong);
            this.Controls.Add(this.label);
            this.Controls.Add(this.lblNguong);
            this.Controls.Add(this.trackBar_bien);
            this.Controls.Add(this.labelNguong);
            this.Controls.Add(this.lblThresold);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxHinhNhiPhan);
            this.Controls.Add(this.lblHinhGoc);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Chuyen anh mau sang muc sam";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhNhiPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_bien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.Label lblHinhGoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxHinhNhiPhan;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.Label lblThresold;
        private System.Windows.Forms.Label labelNguong;
        private System.Windows.Forms.TrackBar trackBar_bien;
        private System.Windows.Forms.Label lblNguong;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_nguong;
    }
}


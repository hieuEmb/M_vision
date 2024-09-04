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
            this.labl1 = new System.Windows.Forms.Label();
            this.picBoxHinhXam = new System.Windows.Forms.PictureBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.picBoxHinhXamAverage = new System.Windows.Forms.PictureBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.picBoxHinhXamLuminanc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXamAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXamLuminanc)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxHinhGoc
            // 
            this.picBoxHinhGoc.Location = new System.Drawing.Point(12, 28);
            this.picBoxHinhGoc.Name = "picBoxHinhGoc";
            this.picBoxHinhGoc.Size = new System.Drawing.Size(500, 381);
            this.picBoxHinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhGoc.TabIndex = 0;
            this.picBoxHinhGoc.TabStop = false;
            // 
            // lblHinhGoc
            // 
            this.lblHinhGoc.AutoSize = true;
            this.lblHinhGoc.Location = new System.Drawing.Point(12, 9);
            this.lblHinhGoc.Name = "lblHinhGoc";
            this.lblHinhGoc.Size = new System.Drawing.Size(59, 16);
            this.lblHinhGoc.TabIndex = 2;
            this.lblHinhGoc.Text = "HinhGoc";
            this.lblHinhGoc.Click += new System.EventHandler(this.lblHinhGoc_Click);
            // 
            // labl1
            // 
            this.labl1.AutoSize = true;
            this.labl1.Location = new System.Drawing.Point(821, 9);
            this.labl1.Name = "labl1";
            this.labl1.Size = new System.Drawing.Size(64, 16);
            this.labl1.TabIndex = 4;
            this.labl1.Text = "Lightness";
            // 
            // picBoxHinhXam
            // 
            this.picBoxHinhXam.Location = new System.Drawing.Point(821, 28);
            this.picBoxHinhXam.Name = "picBoxHinhXam";
            this.picBoxHinhXam.Size = new System.Drawing.Size(500, 381);
            this.picBoxHinhXam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhXam.TabIndex = 3;
            this.picBoxHinhXam.TabStop = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(12, 424);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(59, 16);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "Average";
            // 
            // picBoxHinhXamAverage
            // 
            this.picBoxHinhXamAverage.Location = new System.Drawing.Point(12, 443);
            this.picBoxHinhXamAverage.Name = "picBoxHinhXamAverage";
            this.picBoxHinhXamAverage.Size = new System.Drawing.Size(500, 381);
            this.picBoxHinhXamAverage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhXamAverage.TabIndex = 5;
            this.picBoxHinhXamAverage.TabStop = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(824, 424);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(72, 16);
            this.lbl3.TabIndex = 8;
            this.lbl3.Text = "Luminance";
            // 
            // picBoxHinhXamLuminanc
            // 
            this.picBoxHinhXamLuminanc.Location = new System.Drawing.Point(824, 443);
            this.picBoxHinhXamLuminanc.Name = "picBoxHinhXamLuminanc";
            this.picBoxHinhXamLuminanc.Size = new System.Drawing.Size(500, 381);
            this.picBoxHinhXamLuminanc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhXamLuminanc.TabIndex = 7;
            this.picBoxHinhXamLuminanc.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 953);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.picBoxHinhXamLuminanc);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.picBoxHinhXamAverage);
            this.Controls.Add(this.labl1);
            this.Controls.Add(this.picBoxHinhXam);
            this.Controls.Add(this.lblHinhGoc);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Chuyen anh mau sang muc sam";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXamAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXamLuminanc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.Label lblHinhGoc;
        private System.Windows.Forms.Label labl1;
        private System.Windows.Forms.PictureBox picBoxHinhXam;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.PictureBox picBoxHinhXamAverage;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.PictureBox picBoxHinhXamLuminanc;
    }
}


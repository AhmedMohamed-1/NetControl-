namespace Internet
{
    partial class Internet_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Internet_Form));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_WriteTheCode = new System.Windows.Forms.Label();
            this.btn_GO = new System.Windows.Forms.Button();
            this.label_Tittle = new System.Windows.Forms.Label();
            this.label_TimeLeft = new System.Windows.Forms.Label();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox_Change);
            // 
            // label_WriteTheCode
            // 
            this.label_WriteTheCode.AutoSize = true;
            this.label_WriteTheCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WriteTheCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_WriteTheCode.Location = new System.Drawing.Point(394, 111);
            this.label_WriteTheCode.Name = "label_WriteTheCode";
            this.label_WriteTheCode.Size = new System.Drawing.Size(172, 21);
            this.label_WriteTheCode.TabIndex = 1;
            this.label_WriteTheCode.Text = "اكتب الكود الخاص بك هنا";
            // 
            // btn_GO
            // 
            this.btn_GO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_GO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GO.Enabled = false;
            this.btn_GO.FlatAppearance.BorderSize = 0;
            this.btn_GO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(184)))));
            this.btn_GO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(224)))));
            this.btn_GO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GO.ForeColor = System.Drawing.Color.White;
            this.btn_GO.Location = new System.Drawing.Point(12, 105);
            this.btn_GO.Name = "btn_GO";
            this.btn_GO.Size = new System.Drawing.Size(109, 32);
            this.btn_GO.TabIndex = 2;
            this.btn_GO.Text = "افتح";
            this.btn_GO.UseVisualStyleBackColor = false;
            this.btn_GO.Click += new System.EventHandler(this.btn_GO_Click);
            this.btn_GO.MouseEnter += new System.EventHandler(this.btn_GO_Enter);
            this.btn_GO.MouseLeave += new System.EventHandler(this.btn_GO_Leave);
            // 
            // label_Tittle
            // 
            this.label_Tittle.AutoSize = true;
            this.label_Tittle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tittle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_Tittle.Location = new System.Drawing.Point(44, 12);
            this.label_Tittle.Name = "label_Tittle";
            this.label_Tittle.Size = new System.Drawing.Size(64, 21);
            this.label_Tittle.TabIndex = 4;
            this.label_Tittle.Text = "Internet";
            // 
            // label_TimeLeft
            // 
            this.label_TimeLeft.AutoSize = true;
            this.label_TimeLeft.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TimeLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label_TimeLeft.Location = new System.Drawing.Point(257, 40);
            this.label_TimeLeft.Name = "label_TimeLeft";
            this.label_TimeLeft.Size = new System.Drawing.Size(24, 37);
            this.label_TimeLeft.TabIndex = 5;
            this.label_TimeLeft.Text = " ";
            this.label_TimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Minimize.BackgroundImage = global::Internet.Properties.Resources.minimize_ico;
            this.btn_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Location = new System.Drawing.Point(515, 8);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(20, 20);
            this.btn_Minimize.TabIndex = 7;
            this.btn_Minimize.UseVisualStyleBackColor = false;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.btn_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
            this.btn_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.BackgroundImage = global::Internet.Properties.Resources.Exit;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(540, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(20, 20);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BackgroundImage = global::Internet.Properties.Resources.png_web_folder;
            this.pictureBox_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Logo.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(26, 21);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Logo.TabIndex = 3;
            this.pictureBox_Logo.TabStop = false;
            // 
            // Internet_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 149);
            this.Controls.Add(this.btn_Minimize);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label_TimeLeft);
            this.Controls.Add(this.label_Tittle);
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.btn_GO);
            this.Controls.Add(this.label_WriteTheCode);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Internet_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Internet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Internet_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_WriteTheCode;
        private System.Windows.Forms.Button btn_GO;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
        private System.Windows.Forms.Label label_Tittle;
        private System.Windows.Forms.Label label_TimeLeft;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Minimize;
    }
}


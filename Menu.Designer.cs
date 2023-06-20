namespace Tetris
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.buttonCloseAdmin = new System.Windows.Forms.Button();
            this.bJugar = new System.Windows.Forms.Button();
            this.bAutor = new System.Windows.Forms.Button();
            this.bReglas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCloseAdmin
            // 
            this.buttonCloseAdmin.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseAdmin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCloseAdmin.FlatAppearance.BorderSize = 0;
            this.buttonCloseAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonCloseAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.buttonCloseAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCloseAdmin.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseAdmin.Image")));
            this.buttonCloseAdmin.Location = new System.Drawing.Point(689, 12);
            this.buttonCloseAdmin.Name = "buttonCloseAdmin";
            this.buttonCloseAdmin.Size = new System.Drawing.Size(51, 47);
            this.buttonCloseAdmin.TabIndex = 3;
            this.buttonCloseAdmin.UseVisualStyleBackColor = false;
            this.buttonCloseAdmin.Click += new System.EventHandler(this.buttonCloseAdmin_Click);
            // 
            // bJugar
            // 
            this.bJugar.BackColor = System.Drawing.Color.White;
            this.bJugar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bJugar.ForeColor = System.Drawing.Color.Black;
            this.bJugar.Location = new System.Drawing.Point(463, 70);
            this.bJugar.Name = "bJugar";
            this.bJugar.Size = new System.Drawing.Size(131, 69);
            this.bJugar.TabIndex = 4;
            this.bJugar.Text = "JUGAR";
            this.bJugar.UseVisualStyleBackColor = false;
            this.bJugar.Click += new System.EventHandler(this.bJugar_Click);
            // 
            // bAutor
            // 
            this.bAutor.BackColor = System.Drawing.Color.White;
            this.bAutor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAutor.ForeColor = System.Drawing.Color.Black;
            this.bAutor.Location = new System.Drawing.Point(463, 246);
            this.bAutor.Name = "bAutor";
            this.bAutor.Size = new System.Drawing.Size(131, 69);
            this.bAutor.TabIndex = 5;
            this.bAutor.Text = "AUTOR";
            this.bAutor.UseVisualStyleBackColor = false;
            this.bAutor.Click += new System.EventHandler(this.bAutor_Click);
            // 
            // bReglas
            // 
            this.bReglas.BackColor = System.Drawing.Color.White;
            this.bReglas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bReglas.ForeColor = System.Drawing.Color.Black;
            this.bReglas.Location = new System.Drawing.Point(463, 158);
            this.bReglas.Name = "bReglas";
            this.bReglas.Size = new System.Drawing.Size(131, 69);
            this.bReglas.TabIndex = 6;
            this.bReglas.Text = "REGLAS";
            this.bReglas.UseVisualStyleBackColor = false;
            this.bReglas.Click += new System.EventHandler(this.bReglas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(94, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 210);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bReglas);
            this.Controls.Add(this.bAutor);
            this.Controls.Add(this.bJugar);
            this.Controls.Add(this.buttonCloseAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCloseAdmin;
        private System.Windows.Forms.Button bJugar;
        private System.Windows.Forms.Button bAutor;
        private System.Windows.Forms.Button bReglas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
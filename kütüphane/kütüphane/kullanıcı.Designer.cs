namespace kütüphane
{
    partial class kullanıcı
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkullanıcı = new System.Windows.Forms.TextBox();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btngiriş = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(68, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Girişi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // txtkullanıcı
            // 
            this.txtkullanıcı.Location = new System.Drawing.Point(146, 76);
            this.txtkullanıcı.Name = "txtkullanıcı";
            this.txtkullanıcı.Size = new System.Drawing.Size(159, 27);
            this.txtkullanıcı.TabIndex = 2;
            // 
            // txtsifre
            // 
            this.txtsifre.Location = new System.Drawing.Point(146, 123);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.PasswordChar = '*';
            this.txtsifre.Size = new System.Drawing.Size(159, 27);
            this.txtsifre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şifre:";
            // 
            // btngiriş
            // 
            this.btngiriş.BackColor = System.Drawing.Color.Red;
            this.btngiriş.Location = new System.Drawing.Point(146, 170);
            this.btngiriş.Name = "btngiriş";
            this.btngiriş.Size = new System.Drawing.Size(159, 41);
            this.btngiriş.TabIndex = 5;
            this.btngiriş.Text = "Giriş";
            this.btngiriş.UseVisualStyleBackColor = false;
            this.btngiriş.Click += new System.EventHandler(this.btngiriş_Click);
            // 
            // kullanıcı
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(339, 253);
            this.Controls.Add(this.btngiriş);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtkullanıcı);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kullanıcı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtkullanıcı;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btngiriş;
    }
}


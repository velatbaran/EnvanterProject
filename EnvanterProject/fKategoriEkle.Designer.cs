
namespace EnvanterProject
{
    partial class fKategoriEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fKategoriEkle));
            this.txtKategoriEkle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listKategori = new System.Windows.Forms.ListBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKategoriKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKategoriEkle
            // 
            this.txtKategoriEkle.Location = new System.Drawing.Point(51, 20);
            this.txtKategoriEkle.Name = "txtKategoriEkle";
            this.txtKategoriEkle.Size = new System.Drawing.Size(231, 20);
            this.txtKategoriEkle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ad";
            // 
            // listKategori
            // 
            this.listKategori.FormattingEnabled = true;
            this.listKategori.Location = new System.Drawing.Point(51, 46);
            this.listKategori.Name = "listKategori";
            this.listKategori.Size = new System.Drawing.Size(231, 147);
            this.listKategori.TabIndex = 2;
            this.listKategori.SelectedIndexChanged += new System.EventHandler(this.listKategori_SelectedIndexChanged);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Teal;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSil.Image = global::EnvanterProject.Properties.Resources.cancel24;
            this.btnSil.Location = new System.Drawing.Point(51, 241);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(231, 35);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKategoriKaydet
            // 
            this.btnKategoriKaydet.BackColor = System.Drawing.Color.Teal;
            this.btnKategoriKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKategoriKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategoriKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategoriKaydet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKategoriKaydet.Image = global::EnvanterProject.Properties.Resources.save24;
            this.btnKategoriKaydet.Location = new System.Drawing.Point(51, 199);
            this.btnKategoriKaydet.Name = "btnKategoriKaydet";
            this.btnKategoriKaydet.Size = new System.Drawing.Size(231, 37);
            this.btnKategoriKaydet.TabIndex = 3;
            this.btnKategoriKaydet.Text = "Kaydet";
            this.btnKategoriKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKategoriKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKategoriKaydet.UseVisualStyleBackColor = false;
            this.btnKategoriKaydet.Click += new System.EventHandler(this.btnKategoriKaydet_Click);
            // 
            // fKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(298, 288);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.listKategori);
            this.Controls.Add(this.btnKategoriKaydet);
            this.Controls.Add(this.txtKategoriEkle);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fKategoriEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategor Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fKategoriEkle_FormClosing);
            this.Load += new System.EventHandler(this.fKategoriEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKategoriEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKategoriKaydet;
        private System.Windows.Forms.ListBox listKategori;
        private System.Windows.Forms.Button btnSil;
    }
}
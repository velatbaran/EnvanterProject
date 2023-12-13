
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
            this.txtKategoriEkle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listKategori = new System.Windows.Forms.ListBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKategoriKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKategoriEkle
            // 
            this.txtKategoriEkle.Location = new System.Drawing.Point(86, 41);
            this.txtKategoriEkle.Name = "txtKategoriEkle";
            this.txtKategoriEkle.Size = new System.Drawing.Size(231, 20);
            this.txtKategoriEkle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(25, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ad";
            // 
            // listKategori
            // 
            this.listKategori.FormattingEnabled = true;
            this.listKategori.Location = new System.Drawing.Point(86, 89);
            this.listKategori.Name = "listKategori";
            this.listKategori.Size = new System.Drawing.Size(231, 147);
            this.listKategori.TabIndex = 2;
            this.listKategori.SelectedIndexChanged += new System.EventHandler(this.listKategori_SelectedIndexChanged);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSil.Image = global::EnvanterProject.Properties.Resources.cancel24;
            this.btnSil.Location = new System.Drawing.Point(220, 245);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(97, 57);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKategoriKaydet
            // 
            this.btnKategoriKaydet.BackColor = System.Drawing.Color.Green;
            this.btnKategoriKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKategoriKaydet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKategoriKaydet.Image = global::EnvanterProject.Properties.Resources.save24;
            this.btnKategoriKaydet.Location = new System.Drawing.Point(86, 245);
            this.btnKategoriKaydet.Name = "btnKategoriKaydet";
            this.btnKategoriKaydet.Size = new System.Drawing.Size(97, 57);
            this.btnKategoriKaydet.TabIndex = 3;
            this.btnKategoriKaydet.Text = "Kaydet";
            this.btnKategoriKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKategoriKaydet.UseVisualStyleBackColor = false;
            this.btnKategoriKaydet.Click += new System.EventHandler(this.btnKategoriKaydet_Click);
            // 
            // fKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(355, 314);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.listKategori);
            this.Controls.Add(this.btnKategoriKaydet);
            this.Controls.Add(this.txtKategoriEkle);
            this.Controls.Add(this.label2);
            this.Name = "fKategoriEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategor iEkle";
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
namespace Jeler_Andrei_Biblioteca
{
    partial class Eliminare_carte
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
            this.carti = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // carti
            // 
            this.carti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carti.FormattingEnabled = true;
            this.carti.ItemHeight = 20;
            this.carti.Location = new System.Drawing.Point(12, 12);
            this.carti.Name = "carti";
            this.carti.Size = new System.Drawing.Size(212, 164);
            this.carti.TabIndex = 0;
            this.carti.SelectedIndexChanged += new System.EventHandler(this.carti_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(39, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Elimina";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Eliminare_carte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Jeler_Andrei_Biblioteca.Properties.Resources.empty_book;
            this.ClientSize = new System.Drawing.Size(251, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.carti);
            this.MaximumSize = new System.Drawing.Size(267, 300);
            this.MinimumSize = new System.Drawing.Size(267, 300);
            this.Name = "Eliminare_carte";
            this.Text = "Eliminare_carte";
            this.Load += new System.EventHandler(this.Eliminare_carte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox carti;
        private System.Windows.Forms.Button button1;
    }
}
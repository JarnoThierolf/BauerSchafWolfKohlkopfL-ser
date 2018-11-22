namespace BauerSchafWolfKohlkopf
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxWeg = new System.Windows.Forms.RichTextBox();
            this.buttonStarten = new System.Windows.Forms.Button();
            this.labelBeschreibung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxWeg
            // 
            this.richTextBoxWeg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxWeg.Location = new System.Drawing.Point(12, 34);
            this.richTextBoxWeg.Name = "richTextBoxWeg";
            this.richTextBoxWeg.Size = new System.Drawing.Size(342, 333);
            this.richTextBoxWeg.TabIndex = 0;
            this.richTextBoxWeg.Text = "";
            // 
            // buttonStarten
            // 
            this.buttonStarten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStarten.Location = new System.Drawing.Point(279, 378);
            this.buttonStarten.Name = "buttonStarten";
            this.buttonStarten.Size = new System.Drawing.Size(75, 23);
            this.buttonStarten.TabIndex = 1;
            this.buttonStarten.Text = "Starten";
            this.buttonStarten.UseVisualStyleBackColor = true;
            this.buttonStarten.Click += new System.EventHandler(this.buttonStarten_Click);
            // 
            // labelBeschreibung
            // 
            this.labelBeschreibung.AutoSize = true;
            this.labelBeschreibung.Location = new System.Drawing.Point(13, 15);
            this.labelBeschreibung.Name = "labelBeschreibung";
            this.labelBeschreibung.Size = new System.Drawing.Size(324, 13);
            this.labelBeschreibung.TabIndex = 2;
            this.labelBeschreibung.Text = "Links: Schaf, Wolf, Kohl, Bauer;   Rechts: Schaf, Wolf, Kohl, Bauer";
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonStarten;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 413);
            this.Controls.Add(this.labelBeschreibung);
            this.Controls.Add(this.buttonStarten);
            this.Controls.Add(this.richTextBoxWeg);
            this.Name = "Form1";
            this.Text = "Bauer-Schaf-Wolg-Kohlkopf-Problem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxWeg;
        private System.Windows.Forms.Button buttonStarten;
        private System.Windows.Forms.Label labelBeschreibung;
    }
}


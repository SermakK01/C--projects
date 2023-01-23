namespace passwordApp
{
    partial class TestApp
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageCheckBoxList1 = new passwordApp.ListOfCheckBoxes();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // imageCheckBoxList1
            // 
            this.imageCheckBoxList1.AutoSize = true;
            this.imageCheckBoxList1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imageCheckBoxList1.Location = new System.Drawing.Point(12, 42);
            this.imageCheckBoxList1.MinLength = 8;
            this.imageCheckBoxList1.Name = "imageCheckBoxList1";
            this.imageCheckBoxList1.Size = new System.Drawing.Size(203, 164);
            this.imageCheckBoxList1.SpecialCharacters = "!@#$%^&*()_+";
            this.imageCheckBoxList1.TabIndex = 5;
            // 
            // TestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(227, 218);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageCheckBoxList1);
            this.Controls.Add(this.textBox2);
            this.Name = "TestApp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private ListOfCheckBoxes imageCheckBoxList1;
        private System.Windows.Forms.Label label1;
    }
}


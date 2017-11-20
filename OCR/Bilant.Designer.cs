namespace OCR
{
    partial class Bilant
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
            this.istoric_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nume_prenume_TextBox = new System.Windows.Forms.TextBox();
            this.acum_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // istoric_button
            // 
            this.istoric_button.Location = new System.Drawing.Point(23, 98);
            this.istoric_button.Name = "istoric_button";
            this.istoric_button.Size = new System.Drawing.Size(75, 23);
            this.istoric_button.TabIndex = 0;
            this.istoric_button.Text = "Istoric";
            this.istoric_button.UseVisualStyleBackColor = true;
            this.istoric_button.Click += new System.EventHandler(this.istoric_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Afisare ore muncite pentru : ";
            // 
            // nume_prenume_TextBox
            // 
            this.nume_prenume_TextBox.Location = new System.Drawing.Point(174, 50);
            this.nume_prenume_TextBox.Name = "nume_prenume_TextBox";
            this.nume_prenume_TextBox.Size = new System.Drawing.Size(215, 20);
            this.nume_prenume_TextBox.TabIndex = 3;
            // 
            // acum_button
            // 
            this.acum_button.Location = new System.Drawing.Point(395, 50);
            this.acum_button.Name = "acum_button";
            this.acum_button.Size = new System.Drawing.Size(62, 20);
            this.acum_button.TabIndex = 4;
            this.acum_button.Text = "acum !";
            this.acum_button.UseVisualStyleBackColor = true;
            this.acum_button.Click += new System.EventHandler(this.acum_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label1.Location = new System.Drawing.Point(192, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "( Numele si prenumele angajatului )";
            // 
            // Bilant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.acum_button);
            this.Controls.Add(this.nume_prenume_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.istoric_button);
            this.Name = "Bilant";
            this.Text = "Bilant";
            this.Load += new System.EventHandler(this.Bilant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button istoric_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nume_prenume_TextBox;
        private System.Windows.Forms.Button acum_button;
        private System.Windows.Forms.Label label1;
    }
}
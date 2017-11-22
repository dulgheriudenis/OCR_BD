namespace OCR
{
    partial class Admin
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
            this.angajat_nou_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.verify_button = new System.Windows.Forms.Button();
            this.avanasare_button = new System.Windows.Forms.Button();
            this.retrogradare_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.concediu_angajat_button = new System.Windows.Forms.Button();
            this.stergere_anagajat_button = new System.Windows.Forms.Button();
            this.introduceti_parola_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // angajat_nou_button
            // 
            this.angajat_nou_button.Location = new System.Drawing.Point(23, 95);
            this.angajat_nou_button.Name = "angajat_nou_button";
            this.angajat_nou_button.Size = new System.Drawing.Size(81, 23);
            this.angajat_nou_button.TabIndex = 0;
            this.angajat_nou_button.Text = "Angajat nou";
            this.angajat_nou_button.UseVisualStyleBackColor = true;
            this.angajat_nou_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(123, 127);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(84, 20);
            this.password_textBox.TabIndex = 1;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // verify_button
            // 
            this.verify_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.verify_button.Location = new System.Drawing.Point(228, 127);
            this.verify_button.Name = "verify_button";
            this.verify_button.Size = new System.Drawing.Size(48, 20);
            this.verify_button.TabIndex = 2;
            this.verify_button.Text = "verify !";
            this.verify_button.UseVisualStyleBackColor = true;
            this.verify_button.Click += new System.EventHandler(this.verify_button_Click);
            // 
            // avanasare_button
            // 
            this.avanasare_button.Location = new System.Drawing.Point(173, 146);
            this.avanasare_button.Name = "avanasare_button";
            this.avanasare_button.Size = new System.Drawing.Size(81, 23);
            this.avanasare_button.TabIndex = 3;
            this.avanasare_button.Text = "Avansare";
            this.avanasare_button.UseVisualStyleBackColor = true;
            this.avanasare_button.Click += new System.EventHandler(this.avanasare_button_Click);
            // 
            // retrogradare_button
            // 
            this.retrogradare_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.retrogradare_button.Location = new System.Drawing.Point(173, 95);
            this.retrogradare_button.Name = "retrogradare_button";
            this.retrogradare_button.Size = new System.Drawing.Size(81, 23);
            this.retrogradare_button.TabIndex = 4;
            this.retrogradare_button.Text = "Retrogradare";
            this.retrogradare_button.UseVisualStyleBackColor = true;
            this.retrogradare_button.Click += new System.EventHandler(this.retrogradare_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(54, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gestiune angajati";
            // 
            // concediu_angajat_button
            // 
            this.concediu_angajat_button.Location = new System.Drawing.Point(12, 146);
            this.concediu_angajat_button.Name = "concediu_angajat_button";
            this.concediu_angajat_button.Size = new System.Drawing.Size(99, 23);
            this.concediu_angajat_button.TabIndex = 6;
            this.concediu_angajat_button.Text = "Concediu angajat";
            this.concediu_angajat_button.UseVisualStyleBackColor = true;
            this.concediu_angajat_button.Click += new System.EventHandler(this.concediu_angajat_button_Click);
            // 
            // stergere_anagajat_button
            // 
            this.stergere_anagajat_button.Location = new System.Drawing.Point(87, 206);
            this.stergere_anagajat_button.Name = "stergere_anagajat_button";
            this.stergere_anagajat_button.Size = new System.Drawing.Size(99, 23);
            this.stergere_anagajat_button.TabIndex = 8;
            this.stergere_anagajat_button.Text = "Stergere angajat";
            this.stergere_anagajat_button.UseVisualStyleBackColor = true;
            this.stergere_anagajat_button.Click += new System.EventHandler(this.stergere_anagajat_button_Click);
            // 
            // introduceti_parola_label
            // 
            this.introduceti_parola_label.AutoSize = true;
            this.introduceti_parola_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.introduceti_parola_label.Location = new System.Drawing.Point(9, 128);
            this.introduceti_parola_label.Name = "introduceti_parola_label";
            this.introduceti_parola_label.Size = new System.Drawing.Size(108, 15);
            this.introduceti_parola_label.TabIndex = 9;
            this.introduceti_parola_label.Text = "Introduceti parola :";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 261);
            this.Controls.Add(this.introduceti_parola_label);
            this.Controls.Add(this.stergere_anagajat_button);
            this.Controls.Add(this.concediu_angajat_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retrogradare_button);
            this.Controls.Add(this.avanasare_button);
            this.Controls.Add(this.verify_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.angajat_nou_button);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button angajat_nou_button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button verify_button;
        private System.Windows.Forms.Button avanasare_button;
        private System.Windows.Forms.Button retrogradare_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button concediu_angajat_button;
        private System.Windows.Forms.Button stergere_anagajat_button;
        private System.Windows.Forms.Label introduceti_parola_label;
    }
}
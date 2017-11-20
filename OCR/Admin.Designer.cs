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
            this.SuspendLayout();
            // 
            // angajat_nou_button
            // 
            this.angajat_nou_button.Location = new System.Drawing.Point(23, 43);
            this.angajat_nou_button.Name = "angajat_nou_button";
            this.angajat_nou_button.Size = new System.Drawing.Size(75, 23);
            this.angajat_nou_button.TabIndex = 0;
            this.angajat_nou_button.Text = "Angajat nou";
            this.angajat_nou_button.UseVisualStyleBackColor = true;
            this.angajat_nou_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(53, 12);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(100, 20);
            this.password_textBox.TabIndex = 1;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // verify_button
            // 
            this.verify_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.verify_button.Location = new System.Drawing.Point(171, 11);
            this.verify_button.Name = "verify_button";
            this.verify_button.Size = new System.Drawing.Size(48, 20);
            this.verify_button.TabIndex = 2;
            this.verify_button.Text = "Verify";
            this.verify_button.UseVisualStyleBackColor = true;
            this.verify_button.Click += new System.EventHandler(this.verify_button_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}
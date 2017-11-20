namespace OCR
{
    partial class Angajat_Nou
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
            this.label3 = new System.Windows.Forms.Label();
            this.nume_textBox = new System.Windows.Forms.TextBox();
            this.prenume_textBox = new System.Windows.Forms.TextBox();
            this.CNP_textBox = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prenume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CNP ";
            // 
            // nume_textBox
            // 
            this.nume_textBox.Location = new System.Drawing.Point(100, 39);
            this.nume_textBox.Name = "nume_textBox";
            this.nume_textBox.Size = new System.Drawing.Size(159, 20);
            this.nume_textBox.TabIndex = 3;
            // 
            // prenume_textBox
            // 
            this.prenume_textBox.Location = new System.Drawing.Point(100, 78);
            this.prenume_textBox.Name = "prenume_textBox";
            this.prenume_textBox.Size = new System.Drawing.Size(159, 20);
            this.prenume_textBox.TabIndex = 4;
            // 
            // CNP_textBox
            // 
            this.CNP_textBox.Location = new System.Drawing.Point(100, 117);
            this.CNP_textBox.Name = "CNP_textBox";
            this.CNP_textBox.Size = new System.Drawing.Size(159, 20);
            this.CNP_textBox.TabIndex = 5;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(34, 189);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 6;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(171, 189);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 7;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // Angajat_Nou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.CNP_textBox);
            this.Controls.Add(this.prenume_textBox);
            this.Controls.Add(this.nume_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Angajat_Nou";
            this.Text = "Angajat Nou";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nume_textBox;
        private System.Windows.Forms.TextBox prenume_textBox;
        private System.Windows.Forms.TextBox CNP_textBox;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button exit_button;
    }
}
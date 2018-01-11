namespace OCR
{
    partial class ConcediuAngajat
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
            this.nume_prenume_text_box = new System.Windows.Forms.TextBox();
            this.de_la_time_picker = new System.Windows.Forms.DateTimePicker();
            this.pana_la_time_picker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.proceseaza_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numele si prenumele :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alegeti perioada";
            // 
            // nume_prenume_text_box
            // 
            this.nume_prenume_text_box.Location = new System.Drawing.Point(129, 38);
            this.nume_prenume_text_box.Name = "nume_prenume_text_box";
            this.nume_prenume_text_box.Size = new System.Drawing.Size(143, 20);
            this.nume_prenume_text_box.TabIndex = 2;
            // 
            // de_la_time_picker
            // 
            this.de_la_time_picker.Location = new System.Drawing.Point(72, 118);
            this.de_la_time_picker.Name = "de_la_time_picker";
            this.de_la_time_picker.Size = new System.Drawing.Size(200, 20);
            this.de_la_time_picker.TabIndex = 3;
            // 
            // pana_la_time_picker
            // 
            this.pana_la_time_picker.Location = new System.Drawing.Point(72, 157);
            this.pana_la_time_picker.Name = "pana_la_time_picker";
            this.pana_la_time_picker.Size = new System.Drawing.Size(200, 20);
            this.pana_la_time_picker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "De la : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pana la :";
            // 
            // proceseaza_button
            // 
            this.proceseaza_button.Location = new System.Drawing.Point(35, 210);
            this.proceseaza_button.Name = "proceseaza_button";
            this.proceseaza_button.Size = new System.Drawing.Size(88, 23);
            this.proceseaza_button.TabIndex = 7;
            this.proceseaza_button.Text = "Proceseaza !";
            this.proceseaza_button.UseVisualStyleBackColor = true;
            this.proceseaza_button.Click += new System.EventHandler(this.proceseaza_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(162, 210);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 8;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // ConcediuAngajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.proceseaza_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pana_la_time_picker);
            this.Controls.Add(this.de_la_time_picker);
            this.Controls.Add(this.nume_prenume_text_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConcediuAngajat";
            this.Text = "Concediu Angajat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nume_prenume_text_box;
        private System.Windows.Forms.DateTimePicker de_la_time_picker;
        private System.Windows.Forms.DateTimePicker pana_la_time_picker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button proceseaza_button;
        private System.Windows.Forms.Button exit_button;
    }
}
namespace OCR
{
    partial class Avansare
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
            this.introducere_nume_anagajat_label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entry_radio_button = new System.Windows.Forms.RadioButton();
            this.standard_radio_button = new System.Windows.Forms.RadioButton();
            this.manager_radio_button = new System.Windows.Forms.RadioButton();
            this.director_radio_button = new System.Windows.Forms.RadioButton();
            this.procesare_button = new System.Windows.Forms.Button();
            this.renuntare_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // introducere_nume_anagajat_label
            // 
            this.introducere_nume_anagajat_label.AutoSize = true;
            this.introducere_nume_anagajat_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.introducere_nume_anagajat_label.Location = new System.Drawing.Point(22, 34);
            this.introducere_nume_anagajat_label.Name = "introducere_nume_anagajat_label";
            this.introducere_nume_anagajat_label.Size = new System.Drawing.Size(190, 16);
            this.introducere_nume_anagajat_label.TabIndex = 0;
            this.introducere_nume_anagajat_label.Text = "Introduceti numele angajatului :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(218, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(22, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alegeti gradul la care doriti sa avansati angajatul : ";
            // 
            // entry_radio_button
            // 
            this.entry_radio_button.AutoSize = true;
            this.entry_radio_button.Location = new System.Drawing.Point(25, 102);
            this.entry_radio_button.Name = "entry_radio_button";
            this.entry_radio_button.Size = new System.Drawing.Size(49, 17);
            this.entry_radio_button.TabIndex = 3;
            this.entry_radio_button.TabStop = true;
            this.entry_radio_button.Text = "Entry";
            this.entry_radio_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.entry_radio_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.entry_radio_button.UseVisualStyleBackColor = true;
            // 
            // standard_radio_button
            // 
            this.standard_radio_button.AutoSize = true;
            this.standard_radio_button.Location = new System.Drawing.Point(25, 125);
            this.standard_radio_button.Name = "standard_radio_button";
            this.standard_radio_button.Size = new System.Drawing.Size(68, 17);
            this.standard_radio_button.TabIndex = 4;
            this.standard_radio_button.TabStop = true;
            this.standard_radio_button.Text = "Standard";
            this.standard_radio_button.UseVisualStyleBackColor = true;
            // 
            // manager_radio_button
            // 
            this.manager_radio_button.AutoSize = true;
            this.manager_radio_button.Location = new System.Drawing.Point(155, 102);
            this.manager_radio_button.Name = "manager_radio_button";
            this.manager_radio_button.Size = new System.Drawing.Size(67, 17);
            this.manager_radio_button.TabIndex = 5;
            this.manager_radio_button.TabStop = true;
            this.manager_radio_button.Text = "Manager";
            this.manager_radio_button.UseVisualStyleBackColor = true;
            // 
            // director_radio_button
            // 
            this.director_radio_button.AutoSize = true;
            this.director_radio_button.Location = new System.Drawing.Point(155, 125);
            this.director_radio_button.Name = "director_radio_button";
            this.director_radio_button.Size = new System.Drawing.Size(62, 17);
            this.director_radio_button.TabIndex = 6;
            this.director_radio_button.TabStop = true;
            this.director_radio_button.Text = "Director";
            this.director_radio_button.UseVisualStyleBackColor = true;
            // 
            // procesare_button
            // 
            this.procesare_button.Location = new System.Drawing.Point(65, 170);
            this.procesare_button.Name = "procesare_button";
            this.procesare_button.Size = new System.Drawing.Size(75, 23);
            this.procesare_button.TabIndex = 7;
            this.procesare_button.Text = "Procesare";
            this.procesare_button.UseVisualStyleBackColor = true;
            this.procesare_button.Click += new System.EventHandler(this.procesare_button_Click);
            // 
            // renuntare_button
            // 
            this.renuntare_button.Location = new System.Drawing.Point(217, 170);
            this.renuntare_button.Name = "renuntare_button";
            this.renuntare_button.Size = new System.Drawing.Size(75, 23);
            this.renuntare_button.TabIndex = 8;
            this.renuntare_button.Text = "Renuntare";
            this.renuntare_button.UseVisualStyleBackColor = true;
            this.renuntare_button.Click += new System.EventHandler(this.renuntare_button_Click);
            // 
            // Avansare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 214);
            this.Controls.Add(this.renuntare_button);
            this.Controls.Add(this.procesare_button);
            this.Controls.Add(this.director_radio_button);
            this.Controls.Add(this.manager_radio_button);
            this.Controls.Add(this.standard_radio_button);
            this.Controls.Add(this.entry_radio_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.introducere_nume_anagajat_label);
            this.Name = "Avansare";
            this.Text = "Avansare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label introducere_nume_anagajat_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton entry_radio_button;
        private System.Windows.Forms.RadioButton standard_radio_button;
        private System.Windows.Forms.RadioButton manager_radio_button;
        private System.Windows.Forms.RadioButton director_radio_button;
        private System.Windows.Forms.Button procesare_button;
        private System.Windows.Forms.Button renuntare_button;
    }
}
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
            this.afisare_salarii_button = new System.Windows.Forms.Button();
            this.cauta_functie_button = new System.Windows.Forms.Button();
            this.concediu_button = new System.Windows.Forms.Button();
            this.top_angajati_button = new System.Windows.Forms.Button();
            this.vechime_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cuprins_functii_domain = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nume_angajat_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // istoric_button
            // 
            this.istoric_button.Location = new System.Drawing.Point(37, 191);
            this.istoric_button.Name = "istoric_button";
            this.istoric_button.Size = new System.Drawing.Size(100, 23);
            this.istoric_button.TabIndex = 0;
            this.istoric_button.Text = "Istoric intrari/iesiri";
            this.istoric_button.UseVisualStyleBackColor = true;
            this.istoric_button.Click += new System.EventHandler(this.istoric_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Afisare ore muncite pentru : ";
            // 
            // nume_prenume_TextBox
            // 
            this.nume_prenume_TextBox.Location = new System.Drawing.Point(174, 31);
            this.nume_prenume_TextBox.Name = "nume_prenume_TextBox";
            this.nume_prenume_TextBox.Size = new System.Drawing.Size(215, 20);
            this.nume_prenume_TextBox.TabIndex = 3;
            // 
            // acum_button
            // 
            this.acum_button.Location = new System.Drawing.Point(395, 31);
            this.acum_button.Name = "acum_button";
            this.acum_button.Size = new System.Drawing.Size(51, 20);
            this.acum_button.TabIndex = 4;
            this.acum_button.Text = "acum !";
            this.acum_button.UseVisualStyleBackColor = true;
            this.acum_button.Click += new System.EventHandler(this.acum_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label1.Location = new System.Drawing.Point(192, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "( Numele si prenumele angajatului )";
            // 
            // afisare_salarii_button
            // 
            this.afisare_salarii_button.Location = new System.Drawing.Point(302, 191);
            this.afisare_salarii_button.Name = "afisare_salarii_button";
            this.afisare_salarii_button.Size = new System.Drawing.Size(102, 23);
            this.afisare_salarii_button.TabIndex = 6;
            this.afisare_salarii_button.Text = "Afiseaza Salarii";
            this.afisare_salarii_button.UseVisualStyleBackColor = true;
            this.afisare_salarii_button.Click += new System.EventHandler(this.calcul_salarii_button_Click);
            // 
            // cauta_functie_button
            // 
            this.cauta_functie_button.Location = new System.Drawing.Point(302, 85);
            this.cauta_functie_button.Name = "cauta_functie_button";
            this.cauta_functie_button.Size = new System.Drawing.Size(58, 20);
            this.cauta_functie_button.TabIndex = 7;
            this.cauta_functie_button.Text = "acum !";
            this.cauta_functie_button.UseVisualStyleBackColor = true;
            this.cauta_functie_button.Click += new System.EventHandler(this.cauta_functie_button_Click);
            // 
            // concediu_button
            // 
            this.concediu_button.Location = new System.Drawing.Point(361, 127);
            this.concediu_button.Name = "concediu_button";
            this.concediu_button.Size = new System.Drawing.Size(101, 22);
            this.concediu_button.TabIndex = 8;
            this.concediu_button.Text = "este in concediu .";
            this.concediu_button.UseVisualStyleBackColor = true;
            this.concediu_button.Click += new System.EventHandler(this.concediu_button_Click);
            // 
            // top_angajati_button
            // 
            this.top_angajati_button.Location = new System.Drawing.Point(302, 235);
            this.top_angajati_button.Name = "top_angajati_button";
            this.top_angajati_button.Size = new System.Drawing.Size(122, 23);
            this.top_angajati_button.TabIndex = 9;
            this.top_angajati_button.Text = "Afiseaza top 3 angajati";
            this.top_angajati_button.UseVisualStyleBackColor = true;
            this.top_angajati_button.Click += new System.EventHandler(this.top_angajati_button_Click);
            // 
            // vechime_button
            // 
            this.vechime_button.Location = new System.Drawing.Point(37, 235);
            this.vechime_button.Name = "vechime_button";
            this.vechime_button.Size = new System.Drawing.Size(204, 23);
            this.vechime_button.TabIndex = 10;
            this.vechime_button.Text = "Afiseaza angajatii in functie de vechime";
            this.vechime_button.UseVisualStyleBackColor = true;
            this.vechime_button.Click += new System.EventHandler(this.vechime_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cauta angajati dupa functia :";
            // 
            // cuprins_functii_domain
            // 
            this.cuprins_functii_domain.Location = new System.Drawing.Point(182, 85);
            this.cuprins_functii_domain.Name = "cuprins_functii_domain";
            this.cuprins_functii_domain.Size = new System.Drawing.Size(113, 20);
            this.cuprins_functii_domain.TabIndex = 13;
            this.cuprins_functii_domain.SelectedItemChanged += new System.EventHandler(this.cuprins_functii_domain_SelectedItemChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(5, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Verifica daca anagajatul :";
            // 
            // nume_angajat_text_box
            // 
            this.nume_angajat_text_box.Location = new System.Drawing.Point(161, 129);
            this.nume_angajat_text_box.Name = "nume_angajat_text_box";
            this.nume_angajat_text_box.Size = new System.Drawing.Size(194, 20);
            this.nume_angajat_text_box.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label5.Location = new System.Drawing.Point(171, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "( Numele si prenumele angajatului )";
            // 
            // Bilant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 284);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nume_angajat_text_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cuprins_functii_domain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vechime_button);
            this.Controls.Add(this.top_angajati_button);
            this.Controls.Add(this.concediu_button);
            this.Controls.Add(this.cauta_functie_button);
            this.Controls.Add(this.afisare_salarii_button);
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
        private System.Windows.Forms.Button afisare_salarii_button;
        private System.Windows.Forms.Button cauta_functie_button;
        private System.Windows.Forms.Button concediu_button;
        private System.Windows.Forms.Button top_angajati_button;
        private System.Windows.Forms.Button vechime_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DomainUpDown cuprins_functii_domain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nume_angajat_text_box;
        private System.Windows.Forms.Label label5;
    }
}
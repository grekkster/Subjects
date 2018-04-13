namespace Subjects
{
    partial class FormEditSubject
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
            System.Windows.Forms.Label poznamkaLabel;
            System.Windows.Forms.Label pscLabel;
            System.Windows.Forms.Label obecLabel;
            System.Windows.Forms.Label uliceLabel;
            System.Windows.Forms.Label nazevLabel;
            System.Windows.Forms.Label icoLabel;
            this.btnOk = new System.Windows.Forms.Button();
            this.poznamkaTextBox = new System.Windows.Forms.TextBox();
            this.obecTextBox = new System.Windows.Forms.TextBox();
            this.uliceTextBox = new System.Windows.Forms.TextBox();
            this.nazevTextBox = new System.Windows.Forms.TextBox();
            this.icoTextBox = new System.Windows.Forms.TextBox();
            this.pscTextBox = new System.Windows.Forms.TextBox();
            poznamkaLabel = new System.Windows.Forms.Label();
            pscLabel = new System.Windows.Forms.Label();
            obecLabel = new System.Windows.Forms.Label();
            uliceLabel = new System.Windows.Forms.Label();
            nazevLabel = new System.Windows.Forms.Label();
            icoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // poznamkaLabel
            // 
            poznamkaLabel.AutoSize = true;
            poznamkaLabel.Location = new System.Drawing.Point(12, 136);
            poznamkaLabel.Name = "poznamkaLabel";
            poznamkaLabel.Size = new System.Drawing.Size(60, 13);
            poznamkaLabel.TabIndex = 27;
            poznamkaLabel.Text = "Poznamka:";
            // 
            // pscLabel
            // 
            pscLabel.AutoSize = true;
            pscLabel.Location = new System.Drawing.Point(12, 110);
            pscLabel.Name = "pscLabel";
            pscLabel.Size = new System.Drawing.Size(28, 13);
            pscLabel.TabIndex = 25;
            pscLabel.Text = "Psc:";
            // 
            // obecLabel
            // 
            obecLabel.AutoSize = true;
            obecLabel.Location = new System.Drawing.Point(12, 84);
            obecLabel.Name = "obecLabel";
            obecLabel.Size = new System.Drawing.Size(36, 13);
            obecLabel.TabIndex = 23;
            obecLabel.Text = "Obec:";
            // 
            // uliceLabel
            // 
            uliceLabel.AutoSize = true;
            uliceLabel.Location = new System.Drawing.Point(12, 58);
            uliceLabel.Name = "uliceLabel";
            uliceLabel.Size = new System.Drawing.Size(34, 13);
            uliceLabel.TabIndex = 21;
            uliceLabel.Text = "Ulice:";
            // 
            // nazevLabel
            // 
            nazevLabel.AutoSize = true;
            nazevLabel.Location = new System.Drawing.Point(12, 32);
            nazevLabel.Name = "nazevLabel";
            nazevLabel.Size = new System.Drawing.Size(41, 13);
            nazevLabel.TabIndex = 19;
            nazevLabel.Text = "Nazev:";
            // 
            // icoLabel
            // 
            icoLabel.AutoSize = true;
            icoLabel.Location = new System.Drawing.Point(12, 6);
            icoLabel.Name = "icoLabel";
            icoLabel.Size = new System.Drawing.Size(25, 13);
            icoLabel.TabIndex = 17;
            icoLabel.Text = "Ico:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(182, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // poznamkaTextBox
            // 
            this.poznamkaTextBox.Location = new System.Drawing.Point(78, 136);
            this.poznamkaTextBox.MaxLength = 4000;
            this.poznamkaTextBox.Name = "poznamkaTextBox";
            this.poznamkaTextBox.Size = new System.Drawing.Size(179, 20);
            this.poznamkaTextBox.TabIndex = 28;
            // 
            // obecTextBox
            // 
            this.obecTextBox.Location = new System.Drawing.Point(78, 84);
            this.obecTextBox.MaxLength = 60;
            this.obecTextBox.Name = "obecTextBox";
            this.obecTextBox.Size = new System.Drawing.Size(179, 20);
            this.obecTextBox.TabIndex = 24;
            // 
            // uliceTextBox
            // 
            this.uliceTextBox.Location = new System.Drawing.Point(78, 58);
            this.uliceTextBox.MaxLength = 60;
            this.uliceTextBox.Name = "uliceTextBox";
            this.uliceTextBox.Size = new System.Drawing.Size(179, 20);
            this.uliceTextBox.TabIndex = 22;
            // 
            // nazevTextBox
            // 
            this.nazevTextBox.Location = new System.Drawing.Point(78, 32);
            this.nazevTextBox.MaxLength = 60;
            this.nazevTextBox.Name = "nazevTextBox";
            this.nazevTextBox.Size = new System.Drawing.Size(179, 20);
            this.nazevTextBox.TabIndex = 20;
            // 
            // icoTextBox
            // 
            this.icoTextBox.Location = new System.Drawing.Point(78, 6);
            this.icoTextBox.MaxLength = 8;
            this.icoTextBox.Name = "icoTextBox";
            this.icoTextBox.Size = new System.Drawing.Size(179, 20);
            this.icoTextBox.TabIndex = 18;
            this.icoTextBox.TextChanged += new System.EventHandler(this.icoTextBox_TextChanged);
            // 
            // pscTextBox
            // 
            this.pscTextBox.Location = new System.Drawing.Point(78, 110);
            this.pscTextBox.MaxLength = 5;
            this.pscTextBox.Name = "pscTextBox";
            this.pscTextBox.Size = new System.Drawing.Size(179, 20);
            this.pscTextBox.TabIndex = 26;
            this.pscTextBox.TextChanged += new System.EventHandler(this.pscTextBox_TextChanged);
            // 
            // FormEditSubject
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 192);
            this.Controls.Add(poznamkaLabel);
            this.Controls.Add(this.poznamkaTextBox);
            this.Controls.Add(pscLabel);
            this.Controls.Add(this.pscTextBox);
            this.Controls.Add(obecLabel);
            this.Controls.Add(this.obecTextBox);
            this.Controls.Add(uliceLabel);
            this.Controls.Add(this.uliceTextBox);
            this.Controls.Add(nazevLabel);
            this.Controls.Add(this.nazevTextBox);
            this.Controls.Add(icoLabel);
            this.Controls.Add(this.icoTextBox);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditSubject";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Subject";
            this.Load += new System.EventHandler(this.FormEditSubject_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEditSubject_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox poznamkaTextBox;
        private System.Windows.Forms.TextBox obecTextBox;
        private System.Windows.Forms.TextBox uliceTextBox;
        private System.Windows.Forms.TextBox nazevTextBox;
        private System.Windows.Forms.TextBox icoTextBox;
        private System.Windows.Forms.TextBox pscTextBox;
    }
}
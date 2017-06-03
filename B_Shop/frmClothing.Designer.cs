namespace BShop_Management
{
    partial class frmClothing
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(13, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Size:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(12, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Gender:";
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Checked = true;
            this.radioMale.Location = new System.Drawing.Point(206, 320);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(59, 21);
            this.radioMale.TabIndex = 22;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(283, 320);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(75, 21);
            this.radioFemale.TabIndex = 23;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(221, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Clothing";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(206, 281);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 22);
            this.textBox1.TabIndex = 24;
            // 
            // frmClothing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(473, 473);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioFemale);
            this.Controls.Add(this.radioMale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "frmClothing";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.radioMale, 0);
            this.Controls.SetChildIndex(this.radioFemale, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
    }
}

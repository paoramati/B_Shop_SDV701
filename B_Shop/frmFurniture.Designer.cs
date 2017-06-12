namespace BShop_Management
{
    partial class frmFurniture
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
            this.txtBoxFurnitureWeight = new System.Windows.Forms.TextBox();
            this.updownFurnitureNumParts = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.updownFurnitureNumParts)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(12, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Weight:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(12, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "No# of Parts:";
            // 
            // txtBoxFurnitureWeight
            // 
            this.txtBoxFurnitureWeight.Location = new System.Drawing.Point(206, 284);
            this.txtBoxFurnitureWeight.Name = "txtBoxFurnitureWeight";
            this.txtBoxFurnitureWeight.Size = new System.Drawing.Size(100, 22);
            this.txtBoxFurnitureWeight.TabIndex = 22;
            // 
            // updownFurnitureNumParts
            // 
            this.updownFurnitureNumParts.Location = new System.Drawing.Point(206, 323);
            this.updownFurnitureNumParts.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updownFurnitureNumParts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updownFurnitureNumParts.Name = "updownFurnitureNumParts";
            this.updownFurnitureNumParts.Size = new System.Drawing.Size(67, 22);
            this.updownFurnitureNumParts.TabIndex = 24;
            this.updownFurnitureNumParts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(221, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Furniture";
            // 
            // frmFurniture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(688, 473);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.updownFurnitureNumParts);
            this.Controls.Add(this.txtBoxFurnitureWeight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "frmFurniture";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtBoxFurnitureWeight, 0);
            this.Controls.SetChildIndex(this.updownFurnitureNumParts, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            ((System.ComponentModel.ISupportInitialize)(this.updownFurnitureNumParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxFurnitureWeight;
        private System.Windows.Forms.NumericUpDown updownFurnitureNumParts;
        private System.Windows.Forms.Label label9;
    }
}

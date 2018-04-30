namespace MarketShopp
{
    partial class RemoveProductFromDatabase
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
            this.getProductName = new System.Windows.Forms.TextBox();
            this.removeProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remove product";
            // 
            // getProductName
            // 
            this.getProductName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getProductName.Location = new System.Drawing.Point(35, 56);
            this.getProductName.MaxLength = 50;
            this.getProductName.Name = "getProductName";
            this.getProductName.Size = new System.Drawing.Size(283, 22);
            this.getProductName.TabIndex = 1;
            // 
            // removeProduct
            // 
            this.removeProduct.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeProduct.Location = new System.Drawing.Point(105, 102);
            this.removeProduct.Name = "removeProduct";
            this.removeProduct.Size = new System.Drawing.Size(150, 37);
            this.removeProduct.TabIndex = 5;
            this.removeProduct.Text = "Remove";
            this.removeProduct.UseVisualStyleBackColor = true;
            this.removeProduct.Click += new System.EventHandler(this.removeProduct_Click);
            // 
            // RemoveProductFromDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 151);
            this.Controls.Add(this.removeProduct);
            this.Controls.Add(this.getProductName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RemoveProductFromDatabase";
            this.Text = "Remove product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox getProductName;
        private System.Windows.Forms.Button removeProduct;
    }
}
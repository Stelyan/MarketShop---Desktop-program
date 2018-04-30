namespace MarketShopp
{
    partial class RemoveCategoryFromDatabase
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
            this.getCategoryName = new System.Windows.Forms.TextBox();
            this.removeCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category name";
            // 
            // getCategoryName
            // 
            this.getCategoryName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getCategoryName.Location = new System.Drawing.Point(39, 52);
            this.getCategoryName.MaxLength = 32;
            this.getCategoryName.Name = "getCategoryName";
            this.getCategoryName.Size = new System.Drawing.Size(266, 22);
            this.getCategoryName.TabIndex = 1;
            // 
            // removeCategory
            // 
            this.removeCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeCategory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeCategory.Location = new System.Drawing.Point(98, 90);
            this.removeCategory.Name = "removeCategory";
            this.removeCategory.Size = new System.Drawing.Size(140, 33);
            this.removeCategory.TabIndex = 2;
            this.removeCategory.Text = "Remove";
            this.removeCategory.UseVisualStyleBackColor = true;
            this.removeCategory.Click += new System.EventHandler(this.removeCategory_Click);
            // 
            // RemoveCategoryFromDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 135);
            this.Controls.Add(this.removeCategory);
            this.Controls.Add(this.getCategoryName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RemoveCategoryFromDatabase";
            this.Text = "Remove category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox getCategoryName;
        private System.Windows.Forms.Button removeCategory;
    }
}
namespace AutoBid.Client
{
    partial class FormMoney
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
            this.tbPackage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaxMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPackage
            // 
            this.tbPackage.Location = new System.Drawing.Point(163, 31);
            this.tbPackage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPackage.Name = "tbPackage";
            this.tbPackage.ReadOnly = true;
            this.tbPackage.Size = new System.Drawing.Size(232, 28);
            this.tbPackage.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "包裹号";
            // 
            // tbMaxMoney
            // 
            this.tbMaxMoney.Location = new System.Drawing.Point(163, 68);
            this.tbMaxMoney.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbMaxMoney.Name = "tbMaxMoney";
            this.tbMaxMoney.Size = new System.Drawing.Size(232, 28);
            this.tbMaxMoney.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "最高竞价";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(275, 127);
            this.btnSure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(120, 54);
            this.btnSure.TabIndex = 5;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // FormMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 197);
            this.Controls.Add(this.tbPackage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMaxMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSure);
            this.Name = "FormMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMoney";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPackage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMaxMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSure;
    }
}
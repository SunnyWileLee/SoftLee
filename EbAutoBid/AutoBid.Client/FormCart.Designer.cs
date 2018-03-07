namespace AutoBid.Client
{
    partial class FormCart
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSetPrice = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(183, 20);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 59);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(980, 18);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 59);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSetPrice
            // 
            this.btnSetPrice.Location = new System.Drawing.Point(12, 20);
            this.btnSetPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetPrice.Name = "btnSetPrice";
            this.btnSetPrice.Size = new System.Drawing.Size(135, 59);
            this.btnSetPrice.TabIndex = 6;
            this.btnSetPrice.Text = "设置竞价";
            this.btnSetPrice.UseVisualStyleBackColor = true;
            this.btnSetPrice.Click += new System.EventHandler(this.btnSetPrice_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 99);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 27;
            this.dgvProducts.Size = new System.Drawing.Size(1104, 756);
            this.dgvProducts.TabIndex = 5;
            this.dgvProducts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProducts_CellMouseClick);
            // 
            // FormCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 799);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSetPrice);
            this.Controls.Add(this.dgvProducts);
            this.Name = "FormCart";
            this.Text = "FormCart";
            this.Load += new System.EventHandler(this.FormCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSetPrice;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}


namespace GUI
{
    partial class frmPhanQuyen
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
            this.phanQuyenNguoiDung_DKDataGridView = new System.Windows.Forms.DataGridView();
            this.qL_NhomNguoiDungDataGridView = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.phanQuyenNguoiDung_DKDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_NhomNguoiDungDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // phanQuyenNguoiDung_DKDataGridView
            // 
            this.phanQuyenNguoiDung_DKDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.phanQuyenNguoiDung_DKDataGridView.Location = new System.Drawing.Point(402, 61);
            this.phanQuyenNguoiDung_DKDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.phanQuyenNguoiDung_DKDataGridView.Name = "phanQuyenNguoiDung_DKDataGridView";
            this.phanQuyenNguoiDung_DKDataGridView.RowHeadersWidth = 51;
            this.phanQuyenNguoiDung_DKDataGridView.Size = new System.Drawing.Size(541, 383);
            this.phanQuyenNguoiDung_DKDataGridView.TabIndex = 6;
            // 
            // qL_NhomNguoiDungDataGridView
            // 
            this.qL_NhomNguoiDungDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qL_NhomNguoiDungDataGridView.Location = new System.Drawing.Point(47, 82);
            this.qL_NhomNguoiDungDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.qL_NhomNguoiDungDataGridView.Name = "qL_NhomNguoiDungDataGridView";
            this.qL_NhomNguoiDungDataGridView.RowHeadersWidth = 51;
            this.qL_NhomNguoiDungDataGridView.Size = new System.Drawing.Size(324, 383);
            this.qL_NhomNguoiDungDataGridView.TabIndex = 5;
            this.qL_NhomNguoiDungDataGridView.SelectionChanged += new System.EventHandler(this.qL_NhomNguoiDungDataGridView_SelectionChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(47, 24);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(263, 50);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 562);
            this.Controls.Add(this.phanQuyenNguoiDung_DKDataGridView);
            this.Controls.Add(this.qL_NhomNguoiDungDataGridView);
            this.Controls.Add(this.btnLuu);
            this.Name = "frmPhanQuyen";
            this.Text = "frmPhanQuyen";
            ((System.ComponentModel.ISupportInitialize)(this.phanQuyenNguoiDung_DKDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_NhomNguoiDungDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView phanQuyenNguoiDung_DKDataGridView;
        private System.Windows.Forms.DataGridView qL_NhomNguoiDungDataGridView;
        private System.Windows.Forms.Button btnLuu;
    }
}
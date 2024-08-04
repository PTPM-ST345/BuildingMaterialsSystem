namespace GUI
{
    partial class frmBaoCaoKho
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaoCaoExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_BaoCaoKho = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoCaoKho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaoCaoExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1225, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnBaoCaoExcel
            // 
            this.btnBaoCaoExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBaoCaoExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoExcel.Location = new System.Drawing.Point(33, 38);
            this.btnBaoCaoExcel.Name = "btnBaoCaoExcel";
            this.btnBaoCaoExcel.Size = new System.Drawing.Size(159, 45);
            this.btnBaoCaoExcel.TabIndex = 1;
            this.btnBaoCaoExcel.Text = "In";
            this.btnBaoCaoExcel.UseVisualStyleBackColor = true;
            this.btnBaoCaoExcel.Click += new System.EventHandler(this.btnBaoCaoExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(440, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO KHO";
            // 
            // dgv_BaoCaoKho
            // 
            this.dgv_BaoCaoKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BaoCaoKho.Location = new System.Drawing.Point(30, 128);
            this.dgv_BaoCaoKho.Name = "dgv_BaoCaoKho";
            this.dgv_BaoCaoKho.RowTemplate.Height = 24;
            this.dgv_BaoCaoKho.Size = new System.Drawing.Size(1225, 525);
            this.dgv_BaoCaoKho.TabIndex = 6;
            // 
            // frmBaoCaoKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 683);
            this.Controls.Add(this.dgv_BaoCaoKho);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoKho";
            this.Text = "frmBaoCaoKho";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoCaoKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBaoCaoExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_BaoCaoKho;

    }
}
namespace GUI
{
    partial class frmNhomNguoiDung
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
            System.Windows.Forms.Label maNhomLabel;
            System.Windows.Forms.Label tenNhomLabel;
            System.Windows.Forms.Label ghiChuLabel;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.maNhomTextBox = new System.Windows.Forms.TextBox();
            this.tenNhomTextBox = new System.Windows.Forms.TextBox();
            this.ghiChuTextBox = new System.Windows.Forms.TextBox();
            maNhomLabel = new System.Windows.Forms.Label();
            tenNhomLabel = new System.Windows.Forms.Label();
            ghiChuLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // maNhomLabel
            // 
            maNhomLabel.AutoSize = true;
            maNhomLabel.Location = new System.Drawing.Point(138, 69);
            maNhomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            maNhomLabel.Name = "maNhomLabel";
            maNhomLabel.Size = new System.Drawing.Size(72, 17);
            maNhomLabel.TabIndex = 35;
            maNhomLabel.Text = "Ma Nhom:";
            // 
            // tenNhomLabel
            // 
            tenNhomLabel.AutoSize = true;
            tenNhomLabel.Location = new System.Drawing.Point(138, 101);
            tenNhomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            tenNhomLabel.Name = "tenNhomLabel";
            tenNhomLabel.Size = new System.Drawing.Size(78, 17);
            tenNhomLabel.TabIndex = 37;
            tenNhomLabel.Text = "Ten Nhom:";
            // 
            // ghiChuLabel
            // 
            ghiChuLabel.AutoSize = true;
            ghiChuLabel.Location = new System.Drawing.Point(138, 133);
            ghiChuLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ghiChuLabel.Name = "ghiChuLabel";
            ghiChuLabel.Size = new System.Drawing.Size(63, 17);
            ghiChuLabel.TabIndex = 39;
            ghiChuLabel.Text = "Ghi Chu:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(593, 262);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Location = new System.Drawing.Point(691, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 401);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button7.Image = global::GUI.Properties.Resources.save;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(21, 331);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(131, 52);
            this.button7.TabIndex = 4;
            this.button7.Text = "Lưu";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button3.Image = global::GUI.Properties.Resources.fix;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(26, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 52);
            this.button3.TabIndex = 3;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button4.Image = global::GUI.Properties.Resources.remove;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(26, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 52);
            this.button4.TabIndex = 2;
            this.button4.Text = "Xóa";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button5.Image = global::GUI.Properties.Resources.refresh;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(21, 266);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 52);
            this.button5.TabIndex = 1;
            this.button5.Text = "     Làm Mới";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button13.Image = global::GUI.Properties.Resources.add;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(26, 21);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(131, 52);
            this.button13.TabIndex = 0;
            this.button13.Text = "Thêm";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // maNhomTextBox
            // 
            this.maNhomTextBox.Location = new System.Drawing.Point(226, 66);
            this.maNhomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.maNhomTextBox.Name = "maNhomTextBox";
            this.maNhomTextBox.Size = new System.Drawing.Size(272, 22);
            this.maNhomTextBox.TabIndex = 36;
            // 
            // tenNhomTextBox
            // 
            this.tenNhomTextBox.Location = new System.Drawing.Point(226, 98);
            this.tenNhomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.tenNhomTextBox.Name = "tenNhomTextBox";
            this.tenNhomTextBox.Size = new System.Drawing.Size(272, 22);
            this.tenNhomTextBox.TabIndex = 38;
            // 
            // ghiChuTextBox
            // 
            this.ghiChuTextBox.Location = new System.Drawing.Point(226, 130);
            this.ghiChuTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ghiChuTextBox.Name = "ghiChuTextBox";
            this.ghiChuTextBox.Size = new System.Drawing.Size(272, 22);
            this.ghiChuTextBox.TabIndex = 40;
            // 
            // frmNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 514);
            this.Controls.Add(maNhomLabel);
            this.Controls.Add(this.maNhomTextBox);
            this.Controls.Add(tenNhomLabel);
            this.Controls.Add(this.tenNhomTextBox);
            this.Controls.Add(ghiChuLabel);
            this.Controls.Add(this.ghiChuTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmNhomNguoiDung";
            this.Text = "frmNhomNguoiDung";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox maNhomTextBox;
        private System.Windows.Forms.TextBox tenNhomTextBox;
        private System.Windows.Forms.TextBox ghiChuTextBox;
    }
}
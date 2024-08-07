namespace GUI
{
    partial class frmXepLichLamViec
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.datetimepickerBatDau = new System.Windows.Forms.DateTimePicker();
            this.datetimepickerKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboboxNhomNguoiDung = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(319, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(738, 456);
            this.dataGridView1.TabIndex = 0;
            // 
            // datetimepickerBatDau
            // 
            this.datetimepickerBatDau.Location = new System.Drawing.Point(82, 83);
            this.datetimepickerBatDau.Name = "datetimepickerBatDau";
            this.datetimepickerBatDau.Size = new System.Drawing.Size(200, 22);
            this.datetimepickerBatDau.TabIndex = 1;
            // 
            // datetimepickerKetThuc
            // 
            this.datetimepickerKetThuc.Location = new System.Drawing.Point(82, 136);
            this.datetimepickerKetThuc.Name = "datetimepickerKetThuc";
            this.datetimepickerKetThuc.Size = new System.Drawing.Size(200, 22);
            this.datetimepickerKetThuc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến";
            // 
            // comboboxNhomNguoiDung
            // 
            this.comboboxNhomNguoiDung.FormattingEnabled = true;
            this.comboboxNhomNguoiDung.Location = new System.Drawing.Point(12, 30);
            this.comboboxNhomNguoiDung.Name = "comboboxNhomNguoiDung";
            this.comboboxNhomNguoiDung.Size = new System.Drawing.Size(301, 24);
            this.comboboxNhomNguoiDung.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Image = global::GUI.Properties.Resources.notes__1_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(82, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Xếp lịch";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmXepLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboboxNhomNguoiDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datetimepickerKetThuc);
            this.Controls.Add(this.datetimepickerBatDau);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmXepLichLamViec";
            this.Text = "frmXepLichLamViec";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker datetimepickerBatDau;
        private System.Windows.Forms.DateTimePicker datetimepickerKetThuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboboxNhomNguoiDung;
        private System.Windows.Forms.Button button1;
    }
}
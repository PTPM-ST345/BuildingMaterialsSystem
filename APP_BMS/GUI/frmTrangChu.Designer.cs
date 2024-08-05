namespace GUI
{
    partial class frmTrangChu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTTKH = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.btnTTNV = new System.Windows.Forms.Button();
            this.btnTTTK = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnXuatHang = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnHangHoa = new System.Windows.Forms.Button();
            this.btnLoaiHang = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDanhSachKhachHang = new System.Windows.Forms.Button();
            this.btnBaoCaoNhap = new System.Windows.Forms.Button();
            this.btnBaoCaoXuat = new System.Windows.Forms.Button();
            this.btnBaoCaoNCC = new System.Windows.Forms.Button();
            this.btnBaoCaoLoaiSanPham = new System.Windows.Forms.Button();
            this.btnBaoCaoKho = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnPhanQuyen = new System.Windows.Forms.Button();
            this.btnThemNguoiDungVaoNhom = new System.Windows.Forms.Button();
            this.btnManHinhChucNang = new System.Windows.Forms.Button();
            this.btnNhomNguoiDung = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_myteam = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1201, 117);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnTTKH);
            this.tabPage1.Controls.Add(this.btnThoat);
            this.tabPage1.Controls.Add(this.btnDangXuat);
            this.tabPage1.Controls.Add(this.btnDoiMatKhau);
            this.tabPage1.Controls.Add(this.btnTTNV);
            this.tabPage1.Controls.Add(this.btnTTTK);
            this.tabPage1.Controls.Add(this.btnTrangChu);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1193, 88);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hệ Thống";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(944, 2);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(2, 83);
            this.label2.TabIndex = 7;
            // 
            // btnTTKH
            // 
            this.btnTTKH.Location = new System.Drawing.Point(434, 6);
            this.btnTTKH.Name = "btnTTKH";
            this.btnTTKH.Size = new System.Drawing.Size(114, 76);
            this.btnTTKH.TabIndex = 6;
            this.btnTTKH.Text = "Thông tin khách hàng";
            this.btnTTKH.UseVisualStyleBackColor = true;
            this.btnTTKH.Click += new System.EventHandler(this.btnTTKH_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1073, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(114, 76);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(953, 6);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(114, 76);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Location = new System.Drawing.Point(824, 6);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(114, 76);
            this.btnDoiMatKhau.TabIndex = 3;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnTTNV
            // 
            this.btnTTNV.Location = new System.Drawing.Point(314, 6);
            this.btnTTNV.Name = "btnTTNV";
            this.btnTTNV.Size = new System.Drawing.Size(114, 76);
            this.btnTTNV.TabIndex = 2;
            this.btnTTNV.Text = "Thông tin nhân viên";
            this.btnTTNV.UseVisualStyleBackColor = true;
            this.btnTTNV.Click += new System.EventHandler(this.btnTTNV_Click);
            // 
            // btnTTTK
            // 
            this.btnTTTK.Location = new System.Drawing.Point(704, 6);
            this.btnTTTK.Name = "btnTTTK";
            this.btnTTTK.Size = new System.Drawing.Size(114, 76);
            this.btnTTTK.TabIndex = 1;
            this.btnTTTK.Text = "Thông tin tài khoản";
            this.btnTTTK.UseVisualStyleBackColor = true;
            this.btnTTTK.Click += new System.EventHandler(this.btnTTTK_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Location = new System.Drawing.Point(6, 6);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(114, 76);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnXuatHang);
            this.tabPage2.Controls.Add(this.btnNhapHang);
            this.tabPage2.Controls.Add(this.btnHangHoa);
            this.tabPage2.Controls.Add(this.btnLoaiHang);
            this.tabPage2.Controls.Add(this.btnNCC);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1193, 88);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh Mục";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnXuatHang
            // 
            this.btnXuatHang.Location = new System.Drawing.Point(614, 3);
            this.btnXuatHang.Name = "btnXuatHang";
            this.btnXuatHang.Size = new System.Drawing.Size(114, 76);
            this.btnXuatHang.TabIndex = 9;
            this.btnXuatHang.Text = "Xuất hàng";
            this.btnXuatHang.UseVisualStyleBackColor = true;
            this.btnXuatHang.Click += new System.EventHandler(this.btnXuatHang_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Location = new System.Drawing.Point(383, 3);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(114, 76);
            this.btnNhapHang.TabIndex = 8;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.Location = new System.Drawing.Point(23, 3);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.Size = new System.Drawing.Size(114, 76);
            this.btnHangHoa.TabIndex = 7;
            this.btnHangHoa.Text = "Hàng hóa";
            this.btnHangHoa.UseVisualStyleBackColor = true;
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // btnLoaiHang
            // 
            this.btnLoaiHang.Location = new System.Drawing.Point(143, 3);
            this.btnLoaiHang.Name = "btnLoaiHang";
            this.btnLoaiHang.Size = new System.Drawing.Size(114, 76);
            this.btnLoaiHang.TabIndex = 6;
            this.btnLoaiHang.Text = "Loại hàng";
            this.btnLoaiHang.UseVisualStyleBackColor = true;
            this.btnLoaiHang.Click += new System.EventHandler(this.btnLoaiHang_Click);
            // 
            // btnNCC
            // 
            this.btnNCC.Location = new System.Drawing.Point(263, 0);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(114, 76);
            this.btnNCC.TabIndex = 5;
            this.btnNCC.Text = "Nhà cung cấp";
            this.btnNCC.UseVisualStyleBackColor = true;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDanhSachKhachHang);
            this.tabPage3.Controls.Add(this.btnBaoCaoNhap);
            this.tabPage3.Controls.Add(this.btnBaoCaoXuat);
            this.tabPage3.Controls.Add(this.btnBaoCaoNCC);
            this.tabPage3.Controls.Add(this.btnBaoCaoLoaiSanPham);
            this.tabPage3.Controls.Add(this.btnBaoCaoKho);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1193, 88);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Báo Cáo - Thống Kê";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDanhSachKhachHang
            // 
            this.btnDanhSachKhachHang.Location = new System.Drawing.Point(777, 6);
            this.btnDanhSachKhachHang.Name = "btnDanhSachKhachHang";
            this.btnDanhSachKhachHang.Size = new System.Drawing.Size(114, 76);
            this.btnDanhSachKhachHang.TabIndex = 9;
            this.btnDanhSachKhachHang.Text = "Danh sách khách hàng";
            this.btnDanhSachKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoNhap
            // 
            this.btnBaoCaoNhap.Location = new System.Drawing.Point(620, 6);
            this.btnBaoCaoNhap.Name = "btnBaoCaoNhap";
            this.btnBaoCaoNhap.Size = new System.Drawing.Size(114, 76);
            this.btnBaoCaoNhap.TabIndex = 8;
            this.btnBaoCaoNhap.Text = "Báo cáo nhập";
            this.btnBaoCaoNhap.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoXuat
            // 
            this.btnBaoCaoXuat.Location = new System.Drawing.Point(507, 6);
            this.btnBaoCaoXuat.Name = "btnBaoCaoXuat";
            this.btnBaoCaoXuat.Size = new System.Drawing.Size(114, 76);
            this.btnBaoCaoXuat.TabIndex = 7;
            this.btnBaoCaoXuat.Text = "Báo cáo xuất";
            this.btnBaoCaoXuat.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoNCC
            // 
            this.btnBaoCaoNCC.Location = new System.Drawing.Point(387, 3);
            this.btnBaoCaoNCC.Name = "btnBaoCaoNCC";
            this.btnBaoCaoNCC.Size = new System.Drawing.Size(114, 76);
            this.btnBaoCaoNCC.TabIndex = 6;
            this.btnBaoCaoNCC.Text = "Danh sách nhà cung cấp";
            this.btnBaoCaoNCC.UseVisualStyleBackColor = true;
            this.btnBaoCaoNCC.Click += new System.EventHandler(this.btnBaoCaoNCC_Click);
            // 
            // btnBaoCaoLoaiSanPham
            // 
            this.btnBaoCaoLoaiSanPham.Location = new System.Drawing.Point(267, 6);
            this.btnBaoCaoLoaiSanPham.Name = "btnBaoCaoLoaiSanPham";
            this.btnBaoCaoLoaiSanPham.Size = new System.Drawing.Size(114, 76);
            this.btnBaoCaoLoaiSanPham.TabIndex = 5;
            this.btnBaoCaoLoaiSanPham.Text = "Danh sách loại hàng hóa";
            this.btnBaoCaoLoaiSanPham.UseVisualStyleBackColor = true;
            this.btnBaoCaoLoaiSanPham.Click += new System.EventHandler(this.btnBaoCaoLoaiSanPham_Click);
            // 
            // btnBaoCaoKho
            // 
            this.btnBaoCaoKho.Location = new System.Drawing.Point(6, 6);
            this.btnBaoCaoKho.Name = "btnBaoCaoKho";
            this.btnBaoCaoKho.Size = new System.Drawing.Size(114, 76);
            this.btnBaoCaoKho.TabIndex = 4;
            this.btnBaoCaoKho.Text = "Báo cáo kho";
            this.btnBaoCaoKho.UseVisualStyleBackColor = true;
            this.btnBaoCaoKho.Click += new System.EventHandler(this.btnBaoCaoKho_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnPhanQuyen);
            this.tabPage5.Controls.Add(this.btnThemNguoiDungVaoNhom);
            this.tabPage5.Controls.Add(this.btnManHinhChucNang);
            this.tabPage5.Controls.Add(this.btnNhomNguoiDung);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1193, 88);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Phân Quyền";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Location = new System.Drawing.Point(543, 3);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(114, 76);
            this.btnPhanQuyen.TabIndex = 9;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.UseVisualStyleBackColor = true;
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // btnThemNguoiDungVaoNhom
            // 
            this.btnThemNguoiDungVaoNhom.Location = new System.Drawing.Point(338, 3);
            this.btnThemNguoiDungVaoNhom.Name = "btnThemNguoiDungVaoNhom";
            this.btnThemNguoiDungVaoNhom.Size = new System.Drawing.Size(114, 76);
            this.btnThemNguoiDungVaoNhom.TabIndex = 8;
            this.btnThemNguoiDungVaoNhom.Text = "Thêm người dùng vào nhóm";
            this.btnThemNguoiDungVaoNhom.UseVisualStyleBackColor = true;
            this.btnThemNguoiDungVaoNhom.Click += new System.EventHandler(this.btnThemNguoiDungVaoNhom_Click);
            // 
            // btnManHinhChucNang
            // 
            this.btnManHinhChucNang.Location = new System.Drawing.Point(141, 3);
            this.btnManHinhChucNang.Name = "btnManHinhChucNang";
            this.btnManHinhChucNang.Size = new System.Drawing.Size(114, 76);
            this.btnManHinhChucNang.TabIndex = 7;
            this.btnManHinhChucNang.Text = "Màn hình chức năng";
            this.btnManHinhChucNang.UseVisualStyleBackColor = true;
            this.btnManHinhChucNang.Click += new System.EventHandler(this.btnManHinhChucNang_Click);
            // 
            // btnNhomNguoiDung
            // 
            this.btnNhomNguoiDung.Location = new System.Drawing.Point(21, 3);
            this.btnNhomNguoiDung.Name = "btnNhomNguoiDung";
            this.btnNhomNguoiDung.Size = new System.Drawing.Size(114, 76);
            this.btnNhomNguoiDung.TabIndex = 6;
            this.btnNhomNguoiDung.Text = "Nhóm người dùng";
            this.btnNhomNguoiDung.UseVisualStyleBackColor = true;
            this.btnNhomNguoiDung.Click += new System.EventHandler(this.btnNhomNguoiDung_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btn_myteam);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1193, 88);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Hỗ Trợ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_myteam
            // 
            this.btn_myteam.AutoSize = true;
            this.btn_myteam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_myteam.Location = new System.Drawing.Point(20, 8);
            this.btn_myteam.Name = "btn_myteam";
            this.btn_myteam.Size = new System.Drawing.Size(96, 74);
            this.btn_myteam.TabIndex = 5;
            this.btn_myteam.Text = "My Team";
            this.btn_myteam.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_myteam.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1900, 966);
            this.panel1.TabIndex = 1;
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 953);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrangChu";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnTTNV;
        private System.Windows.Forms.Button btnTTTK;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnXuatHang;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnHangHoa;
        private System.Windows.Forms.Button btnLoaiHang;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnDanhSachKhachHang;
        private System.Windows.Forms.Button btnBaoCaoNhap;
        private System.Windows.Forms.Button btnBaoCaoXuat;
        private System.Windows.Forms.Button btnBaoCaoNCC;
        private System.Windows.Forms.Button btnBaoCaoLoaiSanPham;
        private System.Windows.Forms.Button btnBaoCaoKho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTTKH;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_myteam;
        private System.Windows.Forms.Button btnPhanQuyen;
        private System.Windows.Forms.Button btnThemNguoiDungVaoNhom;
        private System.Windows.Forms.Button btnManHinhChucNang;
        private System.Windows.Forms.Button btnNhomNguoiDung;
        private System.Windows.Forms.Label label2;
    }
}
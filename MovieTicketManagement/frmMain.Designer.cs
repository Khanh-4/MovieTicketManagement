namespace MovieTicketManagement
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            menuMain = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuThongTinCaNhan = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuDangXuat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuQLStaff = new ToolStripMenuItem();
            mnuQLPhim = new ToolStripMenuItem();
            mnuQLPhong = new ToolStripMenuItem();
            mnuQLLichChieu = new ToolStripMenuItem();
            mnuQLDoAn = new ToolStripMenuItem();
            mnuQLKhuyenMai = new ToolStripMenuItem();
            mnuBanVe = new ToolStripMenuItem();
            mnuBanVeMoi = new ToolStripMenuItem();
            mnuKiemTraVe = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuDatVeOnline = new ToolStripMenuItem();
            mnuLichSuDatVe = new ToolStripMenuItem();
            mnuHoiVien = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mnuPassVe = new ToolStripMenuItem();
            mnuMuaVePass = new ToolStripMenuItem();
            mnuViTien = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem();
            mnuDoanhThu = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            statusMain = new StatusStrip();
            lblUserInfo = new ToolStripStatusLabel();
            lblDateTime = new ToolStripStatusLabel();
            timerDateTime = new System.Windows.Forms.Timer(components);
            menuMain.SuspendLayout();
            statusMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuBanVe, mnuKhachHang, mnuBaoCao });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(1184, 24);
            menuMain.TabIndex = 1;
            menuMain.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuThongTinCaNhan, mnuDoiMatKhau, toolStripSeparator1, mnuDangXuat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(69, 20);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuThongTinCaNhan
            // 
            mnuThongTinCaNhan.Name = "mnuThongTinCaNhan";
            mnuThongTinCaNhan.Size = new Size(170, 22);
            mnuThongTinCaNhan.Text = "Thông tin cá nhân";
            mnuThongTinCaNhan.Click += mnuThongTinCaNhan_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(170, 22);
            mnuDoiMatKhau.Text = "Đổi mật khẩu";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(167, 6);
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(170, 22);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuQLStaff, mnuQLPhim, mnuQLPhong, mnuQLLichChieu, mnuQLDoAn, mnuQLKhuyenMai });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(136, 20);
            mnuQuanLy.Text = "Quản lý (Admin/Staff)";
            // 
            // mnuQLStaff
            // 
            mnuQLStaff.Name = "mnuQLStaff";
            mnuQLStaff.Size = new Size(215, 22);
            mnuQLStaff.Text = "Quản lý Staff (Admin only)";
            mnuQLStaff.Click += mnuQLStaff_Click;
            // 
            // mnuQLPhim
            // 
            mnuQLPhim.Name = "mnuQLPhim";
            mnuQLPhim.Size = new Size(215, 22);
            mnuQLPhim.Text = "Quản lý Phim";
            mnuQLPhim.Click += mnuQLPhim_Click;
            // 
            // mnuQLPhong
            // 
            mnuQLPhong.Name = "mnuQLPhong";
            mnuQLPhong.Size = new Size(215, 22);
            mnuQLPhong.Text = "Quản lý Phòng chiếu";
            mnuQLPhong.Click += mnuQLPhong_Click;
            // 
            // mnuQLLichChieu
            // 
            mnuQLLichChieu.Name = "mnuQLLichChieu";
            mnuQLLichChieu.Size = new Size(215, 22);
            mnuQLLichChieu.Text = "Quản lý Lịch chiếu";
            mnuQLLichChieu.Click += mnuQLLichChieu_Click;
            // 
            // mnuQLDoAn
            // 
            mnuQLDoAn.Name = "mnuQLDoAn";
            mnuQLDoAn.Size = new Size(215, 22);
            mnuQLDoAn.Text = "Quản lý Đồ ăn";
            mnuQLDoAn.Click += mnuQLDoAn_Click;
            // 
            // mnuQLKhuyenMai
            // 
            mnuQLKhuyenMai.Name = "mnuQLKhuyenMai";
            mnuQLKhuyenMai.Size = new Size(215, 22);
            mnuQLKhuyenMai.Text = "Quản lý Khuyến mãi";
            mnuQLKhuyenMai.Click += mnuQLKhuyenMai_Click;
            // 
            // mnuBanVe
            // 
            mnuBanVe.DropDownItems.AddRange(new ToolStripItem[] { mnuBanVeMoi, mnuKiemTraVe });
            mnuBanVe.Name = "mnuBanVe";
            mnuBanVe.Size = new Size(89, 20);
            mnuBanVe.Text = "Bán vé (Staff)";
            // 
            // mnuBanVeMoi
            // 
            mnuBanVeMoi.Name = "mnuBanVeMoi";
            mnuBanVeMoi.Size = new Size(136, 22);
            mnuBanVeMoi.Text = "Bán vé mới";
            mnuBanVeMoi.Click += mnuBanVeMoi_Click;
            // 
            // mnuKiemTraVe
            // 
            mnuKiemTraVe.Name = "mnuKiemTraVe";
            mnuKiemTraVe.Size = new Size(136, 22);
            mnuKiemTraVe.Text = "Kiểm tra vé";
            mnuKiemTraVe.Click += mnuKiemTraVe_Click;
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.DropDownItems.AddRange(new ToolStripItem[] { mnuDatVeOnline, mnuLichSuDatVe, mnuHoiVien, toolStripSeparator2, mnuPassVe, mnuMuaVePass, mnuViTien });
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(145, 20);
            mnuKhachHang.Text = "Khách hàng (Customer)";
            // 
            // mnuDatVeOnline
            // 
            mnuDatVeOnline.Name = "mnuDatVeOnline";
            mnuDatVeOnline.Size = new Size(180, 22);
            mnuDatVeOnline.Text = "Đặt vé online";
            mnuDatVeOnline.Click += mnuDatVeOnline_Click;
            // 
            // mnuLichSuDatVe
            // 
            mnuLichSuDatVe.Name = "mnuLichSuDatVe";
            mnuLichSuDatVe.Size = new Size(180, 22);
            mnuLichSuDatVe.Text = "Lịch sử đặt vé";
            mnuLichSuDatVe.Click += mnuLichSuDatVe_Click;
            // 
            // mnuHoiVien
            // 
            mnuHoiVien.Name = "mnuHoiVien";
            mnuHoiVien.Size = new Size(180, 22);
            mnuHoiVien.Text = "Hội viên";
            mnuHoiVien.Click += mnuHoiVien_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // mnuPassVe
            // 
            mnuPassVe.Name = "mnuPassVe";
            mnuPassVe.Size = new Size(180, 22);
            mnuPassVe.Text = "🎫 Pass vé";
            mnuPassVe.Click += mnuPassVe_Click;
            // 
            // mnuMuaVePass
            // 
            mnuMuaVePass.Name = "mnuMuaVePass";
            mnuMuaVePass.Size = new Size(180, 22);
            mnuMuaVePass.Text = "🏷️ Mua vé Pass";
            mnuMuaVePass.Click += mnuMuaVePass_Click;
            // 
            // mnuViTien
            // 
            mnuViTien.Name = "mnuViTien";
            mnuViTien.Size = new Size(180, 22);
            mnuViTien.Text = "💰 Ví tiền";
            mnuViTien.Click += mnuViTien_Click;
            // 
            // mnuBaoCao
            // 
            mnuBaoCao.DropDownItems.AddRange(new ToolStripItem[] { mnuDoanhThu, mnuThongKe });
            mnuBaoCao.Name = "mnuBaoCao";
            mnuBaoCao.Size = new Size(108, 20);
            mnuBaoCao.Text = "Báo cáo (Admin)";
            // 
            // mnuDoanhThu
            // 
            mnuDoanhThu.Name = "mnuDoanhThu";
            mnuDoanhThu.Size = new Size(126, 22);
            mnuDoanhThu.Text = "Doanh thu";
            mnuDoanhThu.Click += mnuDoanhThu_Click;
            // 
            // mnuThongKe
            // 
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Size = new Size(126, 22);
            mnuThongKe.Text = "Thống kê";
            mnuThongKe.Click += mnuThongKe_Click;
            // 
            // statusMain
            // 
            statusMain.Items.AddRange(new ToolStripItem[] { lblUserInfo, lblDateTime });
            statusMain.Location = new Point(0, 639);
            statusMain.Name = "statusMain";
            statusMain.Size = new Size(1184, 22);
            statusMain.TabIndex = 2;
            statusMain.Text = "statusStrip1";
            // 
            // lblUserInfo
            // 
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(77, 17);
            lblUserInfo.Text = "Người dùng: ";
            // 
            // lblDateTime
            // 
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(1092, 17);
            lblDateTime.Spring = true;
            lblDateTime.Text = "Ngày giờ: ";
            lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerDateTime
            // 
            timerDateTime.Enabled = true;
            timerDateTime.Interval = 1000;
            timerDateTime.Tick += timerDateTime_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(statusMain);
            Controls.Add(menuMain);
            IsMdiContainer = true;
            MainMenuStrip = menuMain;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movie Ticket Management System";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            statusMain.ResumeLayout(false);
            statusMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuThongTinCaNhan;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuQLStaff;
        private ToolStripMenuItem mnuQLPhim;
        private ToolStripMenuItem mnuQLPhong;
        private ToolStripMenuItem mnuQLLichChieu;
        private ToolStripMenuItem mnuQLDoAn;
        private ToolStripMenuItem mnuQLKhuyenMai;
        private ToolStripMenuItem mnuBanVe;
        private ToolStripMenuItem mnuBanVeMoi;
        private ToolStripMenuItem mnuKiemTraVe;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuDatVeOnline;
        private ToolStripMenuItem mnuLichSuDatVe;
        private ToolStripMenuItem mnuHoiVien;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuPassVe;
        private ToolStripMenuItem mnuMuaVePass;
        private ToolStripMenuItem mnuViTien;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuDoanhThu;
        private ToolStripMenuItem mnuThongKe;
        private StatusStrip statusMain;
        private ToolStripStatusLabel lblUserInfo;
        private ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;
    }
}
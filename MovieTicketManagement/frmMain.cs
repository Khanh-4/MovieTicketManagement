using MovieTicket.DTO;
using System;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    public partial class frmMain : Form
    {
        private UserDTO currentUser;

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                lblUserInfo.Text = $"Người dùng: {currentUser.FullName} ({currentUser.RoleName})";
                SetPermissions();
                this.Text = $"Movie Ticket Management System - {currentUser.RoleName}";
            }
            UpdateDateTime();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDateTime.Stop();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"Ngày giờ: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        private void SetPermissions()
        {
            mnuQuanLy.Visible = false;
            mnuBanVe.Visible = false;
            mnuKhachHang.Visible = false;
            mnuBaoCao.Visible = false;

            switch (currentUser.RoleID)
            {
                case 1: // Admin
                    mnuQuanLy.Visible = true;
                    mnuBaoCao.Visible = true;
                    mnuQLStaff.Visible = true;
                    mnuQLKhuyenMai.Visible = true;
                    break;

                case 2: // Staff
                    mnuQuanLy.Visible = true;
                    mnuBanVe.Visible = true;
                    mnuQLStaff.Visible = false;
                    mnuQLKhuyenMai.Visible = false;
                    break;

                case 3: // Customer
                    mnuKhachHang.Visible = true;
                    break;
            }
        }

        private void mnuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Họ tên: {currentUser.FullName}\n" +
                          $"Username: {currentUser.Username}\n" +
                          $"Email: {currentUser.Email}\n" +
                          $"Điện thoại: {currentUser.Phone}\n" +
                          $"Vai trò: {currentUser.RoleName}",
                          "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(currentUser.UserID);
            frm.ShowDialog();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void mnuQLStaff_Click(object sender, EventArgs e)
        {
            frmStaffManagement frm = new frmStaffManagement();
            frm.ShowDialog();
        }

        private void mnuQLPhim_Click(object sender, EventArgs e)
        {
            frmMovieManagement frm = new frmMovieManagement();
            frm.ShowDialog();
        }

        private void mnuQLPhong_Click(object sender, EventArgs e)
        {
            frmRoomManagement frm = new frmRoomManagement();
            frm.ShowDialog();
        }

        private void mnuQLLichChieu_Click(object sender, EventArgs e)
        {
            frmShowtimeManagement frm = new frmShowtimeManagement();
            frm.ShowDialog();
        }

        private void mnuQLDoAn_Click(object sender, EventArgs e)
        {
            frmFoodManagement frm = new frmFoodManagement();
            frm.ShowDialog();
        }

        private void mnuQLKhuyenMai_Click(object sender, EventArgs e)
        {
            frmPromotionManagement frm = new frmPromotionManagement();
            frm.ShowDialog();
        }

        private void mnuBanVeMoi_Click(object sender, EventArgs e)
        {
            frmBooking frm = new frmBooking(currentUser);
            frm.ShowDialog();
        }

        private void mnuKiemTraVe_Click(object sender, EventArgs e)
        {
            frmCheckTicket frm = new frmCheckTicket();
            frm.ShowDialog();
        }

        private void mnuDatVeOnline_Click(object sender, EventArgs e)
        {
            frmBooking frm = new frmBooking(currentUser);
            frm.ShowDialog();
        }

        private void mnuLichSuDatVe_Click(object sender, EventArgs e)
        {
            frmBookingHistory frm = new frmBookingHistory(currentUser);
            frm.ShowDialog();
        }

        private void mnuHoiVien_Click(object sender, EventArgs e)
        {
            frmMembership frm = new frmMembership(currentUser.UserID);
            frm.ShowDialog();
        }

        private void mnuDoanhThu_Click(object sender, EventArgs e)
        {
            frmRevenueReport frm = new frmRevenueReport();
            frm.ShowDialog();
        }

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            frmStatistics frm = new frmStatistics();
            frm.ShowDialog();
        }

        // ============================================
        // MENU PASS VÉ (MỚI)
        // ============================================

        // Pass vé cho rạp
        private void mnuPassVe_Click(object sender, EventArgs e)
        {
            frmPassTicket frm = new frmPassTicket(currentUser);
            frm.ShowDialog();
        }

        // Mua vé pass (giảm giá)
        private void mnuMuaVePass_Click(object sender, EventArgs e)
        {
            frmResaleTickets frm = new frmResaleTickets(currentUser);
            frm.ShowDialog();
        }

        // Ví tiền
        private void mnuViTien_Click(object sender, EventArgs e)
        {
            frmWallet frm = new frmWallet(currentUser);
            frm.ShowDialog();
        }
    }
}
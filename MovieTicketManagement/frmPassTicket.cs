using System;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmPassTicket : Form
    {
        private readonly ResaleBLL resaleBLL = new ResaleBLL();
        private readonly BookingBLL bookingBLL = new BookingBLL();
        private readonly WalletBLL walletBLL = new WalletBLL();
        private UserDTO currentUser;
        private RefundCalculationDTO currentCalculation;

        public frmPassTicket(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmPassTicket_Load(object sender, EventArgs e)
        {
            LoadResellableBookings();
            UpdateWalletInfo();
        }

        // Load danh sách vé có thể pass
        private void LoadResellableBookings()
        {
            try
            {
                // Lấy tất cả booking của user
                var bookings = bookingBLL.GetByUserId(currentUser.UserID);

                // Lọc chỉ lấy booking có thể pass
                var resellableBookings = new System.Collections.Generic.List<BookingDTO>();
                foreach (var booking in bookings)
                {
                    var calculation = resaleBLL.CalculateRefund(booking.BookingID);
                    if (calculation != null && calculation.CanResale)
                    {
                        resellableBookings.Add(booking);
                    }
                }

                dgvBookings.DataSource = null;
                dgvBookings.DataSource = resellableBookings;

                if (dgvBookings.Columns.Count > 0)
                {
                    // Ẩn các cột không cần
                    foreach (DataGridViewColumn col in dgvBookings.Columns)
                    {
                        col.Visible = false;
                    }

                    // Hiển thị các cột cần thiết
                    if (dgvBookings.Columns.Contains("BookingCode"))
                    {
                        dgvBookings.Columns["BookingCode"].Visible = true;
                        dgvBookings.Columns["BookingCode"].HeaderText = "Mã vé";
                        dgvBookings.Columns["BookingCode"].Width = 150;
                    }
                    if (dgvBookings.Columns.Contains("MovieTitle"))
                    {
                        dgvBookings.Columns["MovieTitle"].Visible = true;
                        dgvBookings.Columns["MovieTitle"].HeaderText = "Phim";
                        dgvBookings.Columns["MovieTitle"].Width = 150;
                    }
                    if (dgvBookings.Columns.Contains("ShowTime"))
                    {
                        dgvBookings.Columns["ShowTime"].Visible = true;
                        dgvBookings.Columns["ShowTime"].HeaderText = "Suất chiếu";
                        dgvBookings.Columns["ShowTime"].Width = 130;
                        dgvBookings.Columns["ShowTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvBookings.Columns.Contains("TotalAmount"))
                    {
                        dgvBookings.Columns["TotalAmount"].Visible = true;
                        dgvBookings.Columns["TotalAmount"].HeaderText = "Giá vé";
                        dgvBookings.Columns["TotalAmount"].Width = 100;
                        dgvBookings.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                    }
                }

                lblStatus.Text = $"Có {resellableBookings.Count} vé có thể pass";
                lblStatus.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vé: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật thông tin ví
        private void UpdateWalletInfo()
        {
            try
            {
                var wallet = walletBLL.GetWallet(currentUser.UserID);
                if (wallet != null)
                {
                    lblWalletBalance.Text = $"{wallet.Balance:N0} đ";
                }
                else
                {
                    lblWalletBalance.Text = "0 đ";
                }
            }
            catch
            {
                lblWalletBalance.Text = "0 đ";
            }
        }

        // Khi chọn booking
        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow == null)
            {
                ClearCalculation();
                return;
            }

            var booking = dgvBookings.CurrentRow.DataBoundItem as BookingDTO;
            if (booking == null)
            {
                ClearCalculation();
                return;
            }

            // Tính toán hoàn tiền
            try
            {
                currentCalculation = resaleBLL.CalculateRefund(booking.BookingID);

                if (currentCalculation != null && currentCalculation.CanResale)
                {
                    // Hiển thị thông tin
                    lblMovieValue.Text = currentCalculation.MovieTitle ?? "-";
                    lblShowtimeValue.Text = currentCalculation.ShowTime.ToString("dd/MM/yyyy HH:mm");
                    lblRoomValue.Text = currentCalculation.RoomName ?? "-";
                    lblSeatValue.Text = currentCalculation.SeatInfo ?? "-";
                    lblOriginalPriceValue.Text = currentCalculation.DisplayOriginalPrice;
                    lblDaysRemainingValue.Text = currentCalculation.DisplayDaysRemaining;
                    lblRefundPercentValue.Text = currentCalculation.DisplayRefundPercent;
                    lblRefundAmountValue.Text = currentCalculation.DisplayRefundAmount;
                    lblRefundAmountValue.ForeColor = Color.Green;

                    grpCalculation.Enabled = true;
                    btnPassTicket.Enabled = true;
                }
                else
                {
                    ClearCalculation();
                    string message = currentCalculation?.Message ?? "Không thể pass vé này!";
                    MessageBox.Show(message, "Không thể pass vé",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearCalculation();
            }
        }

        // Xóa thông tin tính toán
        private void ClearCalculation()
        {
            currentCalculation = null;
            lblMovieValue.Text = "-";
            lblShowtimeValue.Text = "-";
            lblRoomValue.Text = "-";
            lblSeatValue.Text = "-";
            lblOriginalPriceValue.Text = "-";
            lblDaysRemainingValue.Text = "-";
            lblRefundPercentValue.Text = "-";
            lblRefundAmountValue.Text = "-";
            lblRefundAmountValue.ForeColor = Color.Black;
            grpCalculation.Enabled = false;
            btnPassTicket.Enabled = false;
        }

        // Nút Pass vé
        private void btnPassTicket_Click(object sender, EventArgs e)
        {
            if (currentCalculation == null || !currentCalculation.CanResale)
            {
                MessageBox.Show("Vui lòng chọn vé cần pass!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định phương thức hoàn tiền
            string refundMethod = "Wallet";
            if (rdoPoints.Checked)
                refundMethod = "Points";
            else if (rdoBoth.Checked)
                refundMethod = "Both";

            // Xác nhận
            string confirmMessage = $"Xác nhận PASS VÉ:\n\n" +
                                   $"🎬 Phim: {currentCalculation.MovieTitle}\n" +
                                   $"📅 Suất: {currentCalculation.ShowTime:dd/MM/yyyy HH:mm}\n" +
                                   $"💺 Ghế: {currentCalculation.SeatInfo}\n\n" +
                                   $"💰 Giá gốc: {currentCalculation.OriginalPrice:N0} đ\n" +
                                   $"📊 Hoàn tiền ({currentCalculation.RefundPercent}%): {currentCalculation.RefundAmount:N0} đ\n\n" +
                                   $"💳 Hoàn vào: {GetRefundMethodText(refundMethod)}\n\n" +
                                   $"⚠️ Sau khi pass, vé sẽ không còn hiệu lực với bạn.\n\n" +
                                   $"Bạn có chắc muốn pass vé?";

            DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận Pass Vé",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var passResult = resaleBLL.PassTicket(
                        currentCalculation.BookingID,
                        refundMethod,
                        txtNotes.Text.Trim());

                    if (passResult.success)
                    {
                        MessageBox.Show(passResult.message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh
                        LoadResellableBookings();
                        UpdateWalletInfo();
                        ClearCalculation();
                        txtNotes.Clear();
                    }
                    else
                    {
                        MessageBox.Show(passResult.message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi pass vé: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetRefundMethodText(string method)
        {
            switch (method)
            {
                case "Wallet": return "Ví tiền";
                case "Points": return "Điểm tích lũy";
                case "Both": return "Ví tiền + Điểm";
                default: return method;
            }
        }

        // Nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút Xem ví
        private void btnViewWallet_Click(object sender, EventArgs e)
        {
            frmWallet frm = new frmWallet(currentUser);
            frm.ShowDialog();
            UpdateWalletInfo();
        }

        // Nút Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadResellableBookings();
            UpdateWalletInfo();
            ClearCalculation();
        }
    }
}
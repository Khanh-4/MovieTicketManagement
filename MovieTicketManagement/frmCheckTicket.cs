using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmCheckTicket : Form
    {
        private BookingBLL bookingBLL = new BookingBLL();
        private BookingDTO currentBooking = null;

        public frmCheckTicket()
        {
            InitializeComponent();
        }

        private void frmCheckTicket_Load(object sender, EventArgs e)
        {
            ClearInfo();
            txtBookingCode.Focus();
        }

        // Nhấn Enter để kiểm tra
        private void txtBookingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheck_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Kiểm tra vé
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string bookingCode = txtBookingCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(bookingCode))
            {
                MessageBox.Show("Vui lòng nhập mã vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookingCode.Focus();
                return;
            }

            try
            {
                // Tìm booking theo mã
                currentBooking = bookingBLL.GetByBookingCode(bookingCode);

                if (currentBooking == null)
                {
                    MessageBox.Show("Không tìm thấy vé với mã này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearInfo();
                    txtBookingCode.SelectAll();
                    txtBookingCode.Focus();
                    return;
                }

                // Hiển thị thông tin
                DisplayBookingInfo(currentBooking);

                // Kiểm tra trạng thái vé
                CheckTicketStatus(currentBooking);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị thông tin booking
        private void DisplayBookingInfo(BookingDTO booking)
        {
            lblBookingCodeValue.Text = booking.BookingCode;
            lblMovieValue.Text = booking.MovieTitle;
            lblShowtimeValue.Text = booking.ShowTime.ToString("dd/MM/yyyy HH:mm");
            lblRoomValue.Text = booking.RoomName;
            lblCustomerValue.Text = booking.CustomerName;

            // Lấy danh sách ghế
            List<BookingDetailDTO> details = bookingBLL.GetBookingDetails(booking.BookingID);
            if (details.Count > 0)
            {
                string seats = string.Join(", ", details.ConvertAll(d => d.SeatCode));
                lblSeatsValue.Text = seats;
            }
            else
            {
                lblSeatsValue.Text = "(Không có thông tin)";
            }
        }

        // Kiểm tra trạng thái vé
        private void CheckTicketStatus(BookingDTO booking)
        {
            // Reset
            btnConfirm.Enabled = false;

            // Vé đã hủy
            if (booking.BookingStatus == "Cancelled")
            {
                lblStatusValue.Text = "❌ VÉ ĐÃ HỦY";
                lblStatusValue.ForeColor = Color.Red;
                return;
            }

            // Vé đã sử dụng
            if (booking.IsUsed)
            {
                string usedTime = booking.UsedAt.HasValue
                    ? booking.UsedAt.Value.ToString("dd/MM/yyyy HH:mm")
                    : "";
                lblStatusValue.Text = $"⚠️ VÉ ĐÃ SỬ DỤNG ({usedTime})";
                lblStatusValue.ForeColor = Color.Orange;
                return;
            }

            // Kiểm tra thời gian
            DateTime now = DateTime.Now;
            DateTime showTime = booking.ShowTime;

            // Suất chiếu đã qua
            if (showTime.AddHours(3) < now) // Quá 3 tiếng sau giờ chiếu
            {
                lblStatusValue.Text = "❌ VÉ ĐÃ HẾT HẠN";
                lblStatusValue.ForeColor = Color.Red;
                return;
            }

            // Chưa đến giờ chiếu (sớm hơn 30 phút)
            if (showTime.AddMinutes(-30) > now)
            {
                lblStatusValue.Text = $"⏳ CHƯA ĐẾN GIỜ (còn {(int)(showTime - now).TotalMinutes} phút)";
                lblStatusValue.ForeColor = Color.Blue;
                btnConfirm.Enabled = false; // Chưa cho vào
                return;
            }

            // Vé hợp lệ - có thể vào rạp
            lblStatusValue.Text = "✅ VÉ HỢP LỆ - SẴN SÀNG VÀO RẠP";
            lblStatusValue.ForeColor = Color.Green;
            btnConfirm.Enabled = true;
        }

        // Xác nhận vào rạp
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (currentBooking == null)
            {
                MessageBox.Show("Vui lòng kiểm tra vé trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Xác nhận cho khách vào rạp?\n\n" +
                $"Mã vé: {currentBooking.BookingCode}\n" +
                $"Khách hàng: {currentBooking.CustomerName}\n" +
                $"Ghế: {lblSeatsValue.Text}",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = bookingBLL.MarkAsUsed(currentBooking.BookingID);

                    if (success)
                    {
                        MessageBox.Show("✅ Đã xác nhận vào rạp thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật trạng thái hiển thị
                        lblStatusValue.Text = $"⚠️ VÉ ĐÃ SỬ DỤNG ({DateTime.Now:dd/MM/yyyy HH:mm})";
                        lblStatusValue.ForeColor = Color.Orange;
                        btnConfirm.Enabled = false;

                        // Clear để kiểm tra vé tiếp theo
                        txtBookingCode.Clear();
                        txtBookingCode.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xác nhận vé!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa thông tin hiển thị
        private void ClearInfo()
        {
            lblBookingCodeValue.Text = "";
            lblMovieValue.Text = "";
            lblShowtimeValue.Text = "";
            lblRoomValue.Text = "";
            lblSeatsValue.Text = "";
            lblCustomerValue.Text = "";
            lblStatusValue.Text = "";
            btnConfirm.Enabled = false;
            currentBooking = null;
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
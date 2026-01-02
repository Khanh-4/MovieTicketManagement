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
        private GiftBLL giftBLL = new GiftBLL();
        private BookingDTO currentBooking = null;
        private BookingGiftInfoDTO currentGiftInfo = null;

        // Thêm biến để lưu StaffID (truyền từ frmMain)
        private int currentStaffId = 0;

        public frmCheckTicket()
        {
            InitializeComponent();
        }

        // Constructor mới nhận StaffID
        public frmCheckTicket(int staffId)
        {
            InitializeComponent();
            currentStaffId = staffId;
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

            // === MỚI: Kiểm tra quà tặng ===
            CheckGiftInfo(booking.BookingID);
        }

        // === MỚI: Kiểm tra thông tin quà tặng ===
        private void CheckGiftInfo(int bookingId)
        {
            try
            {
                currentGiftInfo = giftBLL.GetBookingGiftInfo(bookingId);

                if (currentGiftInfo != null && currentGiftInfo.HasGift)
                {
                    lblGiftValue.Visible = true;
                    btnGiveGift.Visible = true;

                    if (currentGiftInfo.GiftStatus == "Confirmed")
                    {
                        lblGiftValue.Text = $"🎁 {currentGiftInfo.GiftName} - Chờ nhận";
                        lblGiftValue.ForeColor = Color.Green;
                        btnGiveGift.Enabled = true;
                        btnGiveGift.Text = "🎁 Phát quà";
                        btnGiveGift.BackColor = Color.FromArgb(255, 193, 7); // Vàng
                    }
                    else if (currentGiftInfo.GiftStatus == "Received")
                    {
                        lblGiftValue.Text = $"🎁 {currentGiftInfo.GiftName} - ĐÃ NHẬN";
                        lblGiftValue.ForeColor = Color.Gray;
                        btnGiveGift.Enabled = false;
                        btnGiveGift.Text = "✓ Đã phát";
                        btnGiveGift.BackColor = Color.LightGray;
                    }
                    else
                    {
                        lblGiftValue.Text = $"🎁 {currentGiftInfo.GiftStatusText}";
                        lblGiftValue.ForeColor = Color.Orange;
                        btnGiveGift.Enabled = false;
                        btnGiveGift.BackColor = Color.LightGray;
                    }
                }
                else
                {
                    lblGiftValue.Text = "(Không có quà tặng)";
                    lblGiftValue.ForeColor = Color.Gray;
                    lblGiftValue.Visible = true;
                    btnGiveGift.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblGiftValue.Text = "(Lỗi kiểm tra quà)";
                lblGiftValue.ForeColor = Color.Red;
                lblGiftValue.Visible = true;
                btnGiveGift.Visible = false;
                System.Diagnostics.Debug.WriteLine($"Lỗi kiểm tra quà: {ex.Message}");
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

            // Kiểm tra xem có quà chưa nhận không
            string giftReminder = "";
            if (currentGiftInfo != null && currentGiftInfo.HasGift && currentGiftInfo.GiftStatus == "Confirmed")
            {
                giftReminder = $"\n\n🎁 LƯU Ý: Khách có quà tặng [{currentGiftInfo.GiftName}] chưa nhận!";
            }

            DialogResult result = MessageBox.Show(
                $"Xác nhận cho khách vào rạp?\n\n" +
                $"Mã vé: {currentBooking.BookingCode}\n" +
                $"Khách hàng: {currentBooking.CustomerName}\n" +
                $"Ghế: {lblSeatsValue.Text}" +
                giftReminder,
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

        // === MỚI: Phát quà ===
        private void btnGiveGift_Click(object sender, EventArgs e)
        {
            if (currentBooking == null || currentGiftInfo == null)
            {
                MessageBox.Show("Vui lòng kiểm tra vé trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!currentGiftInfo.CanReceive)
            {
                MessageBox.Show("Vé này không có quà để phát hoặc đã phát rồi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Xác nhận phát quà?\n\n" +
                $"🎁 Quà tặng: {currentGiftInfo.GiftName}\n" +
                $"👤 Khách hàng: {currentBooking.CustomerName}\n" +
                $"🎫 Mã vé: {currentBooking.BookingCode}",
                "Xác nhận phát quà",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Sử dụng StaffID được truyền vào, nếu không có thì dùng mặc định
                    int staffId = currentStaffId > 0 ? currentStaffId : 2; // 2 = staff1

                    var (success, message, giftName) = giftBLL.ReceiveGift(currentBooking.BookingID, staffId);

                    if (success)
                    {
                        MessageBox.Show(
                            $"✅ PHÁT QUÀ THÀNH CÔNG!\n\n" +
                            $"🎁 Quà: {giftName}\n" +
                            $"👤 Khách hàng: {currentBooking.CustomerName}\n\n" +
                            $"Vui lòng đưa quà cho khách!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Cập nhật hiển thị
                        lblGiftValue.Text = $"🎁 {giftName} - ĐÃ NHẬN";
                        lblGiftValue.ForeColor = Color.Gray;
                        btnGiveGift.Enabled = false;
                        btnGiveGift.Text = "✓ Đã phát";
                        btnGiveGift.BackColor = Color.LightGray;

                        // Cập nhật currentGiftInfo
                        currentGiftInfo = giftBLL.GetBookingGiftInfo(currentBooking.BookingID);
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
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

            // === MỚI: Clear quà tặng ===
            currentGiftInfo = null;
            lblGiftValue.Text = "";
            lblGiftValue.Visible = false;
            btnGiveGift.Visible = false;
            btnGiveGift.Enabled = false;
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
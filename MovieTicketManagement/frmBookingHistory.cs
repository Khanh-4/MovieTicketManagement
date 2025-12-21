using MovieTicket.BLL;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    public partial class frmBookingHistory : Form
    {
        private readonly BookingBLL bookingBLL = new BookingBLL();
        private UserDTO currentUser;
        private BookingDTO selectedBooking = null;

        // Constructor nhận thông tin user
        public frmBookingHistory(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmBookingHistory_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadBookingHistory();
            ClearDetails();
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvBookings.AutoGenerateColumns = false;
            dgvBookings.Columns.Clear();

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingID",
                HeaderText = "ID",
                DataPropertyName = "BookingID",
                Width = 50
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingCode",
                HeaderText = "Mã đặt vé",
                DataPropertyName = "BookingCode",
                Width = 120
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MovieTitle",
                HeaderText = "Phim",
                DataPropertyName = "MovieTitle",
                Width = 250
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShowTime",
                HeaderText = "Suất chiếu",
                DataPropertyName = "ShowTime",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomName",
                HeaderText = "Phòng",
                DataPropertyName = "RoomName",
                Width = 100
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Tổng tiền",
                DataPropertyName = "TotalAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BookingStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "BookingStatus",
                Width = 120
            });
        }

        // Load lịch sử đặt vé
        private void LoadBookingHistory()
        {
            try
            {
                List<BookingDTO> bookings = bookingBLL.GetBookingHistory(currentUser.UserID);

                dgvBookings.DataSource = null;
                dgvBookings.DataSource = bookings;

                if (bookings.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có vé nào!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử đặt vé: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi click vào dòng trong DataGridView
        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBookings.Rows.Count)
            {
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                if (row.DataBoundItem is BookingDTO booking)
                {
                    selectedBooking = booking;
                    DisplayBookingDetails(booking);
                    UpdateCancelButtonState();
                }
            }
        }

        // Hiển thị chi tiết đặt vé
        private void DisplayBookingDetails(BookingDTO booking)
        {
            try
            {
                // Thông tin cơ bản
                lblBookingCodeValue.Text = booking.BookingCode;
                lblMovieValue.Text = booking.MovieTitle;
                lblShowtimeValue.Text = booking.ShowTime.ToString("dd/MM/yyyy HH:mm");
                lblRoomValue.Text = booking.RoomName;
                lblTotalValue.Text = string.Format("{0:N0} VNĐ", booking.TotalAmount);

                // Trạng thái
                lblStatusValue.Text = GetStatusText(booking.BookingStatus);
                lblStatusValue.ForeColor = GetStatusColor(booking.BookingStatus);

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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật trạng thái nút Hủy vé
        private void UpdateCancelButtonState()
        {
            if (selectedBooking == null)
            {
                btnCancel.Enabled = false;
                return;
            }

            // Chỉ cho phép hủy nếu trạng thái là Pending hoặc Confirmed
            bool canCancel = selectedBooking.BookingStatus == "Pending" ||
                            selectedBooking.BookingStatus == "Confirmed";

            // Và suất chiếu còn ít nhất 2 tiếng nữa
            if (canCancel)
            {
                canCancel = selectedBooking.ShowTime > DateTime.Now.AddHours(2);
            }

            btnCancel.Enabled = canCancel;
        }

        // Xử lý hủy vé
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedBooking == null)
            {
                MessageBox.Show("Vui lòng chọn vé cần hủy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra điều kiện hủy
            if (!bookingBLL.CanCancelBooking(selectedBooking.BookingID))
            {
                MessageBox.Show("Không thể hủy vé này!\n\n" +
                    "Lý do có thể:\n" +
                    "- Vé đã bị hủy hoặc đã hoàn thành\n" +
                    "- Suất chiếu sẽ bắt đầu trong vòng 2 tiếng nữa",
                    "Không thể hủy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận hủy
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn hủy vé này?\n\n" +
                $"Mã vé: {selectedBooking.BookingCode}\n" +
                $"Phim: {selectedBooking.MovieTitle}\n" +
                $"Suất chiếu: {selectedBooking.ShowTime:dd/MM/yyyy HH:mm}\n" +
                $"Tổng tiền: {selectedBooking.TotalAmount:N0} VNĐ\n\n" +
                $"Lưu ý: Thao tác này không thể hoàn tác!",
                "Xác nhận hủy vé",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = bookingBLL.CancelBooking(selectedBooking.BookingID);

                    if (success)
                    {
                        MessageBox.Show("Hủy vé thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload danh sách và clear chi tiết
                        LoadBookingHistory();
                        ClearDetails();
                        selectedBooking = null;
                        btnCancel.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Hủy vé thất bại! Vui lòng thử lại.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hủy vé: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Chuyển BookingStatus sang tiếng Việt
        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "Pending":
                    return "Chờ xác nhận";
                case "Confirmed":
                    return "Đã xác nhận";
                case "Cancelled":
                    return "Đã hủy";
                case "Completed":
                    return "Hoàn thành";
                default:
                    return status;
            }
        }

        // Màu sắc theo trạng thái
        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Pending":
                    return Color.Orange;
                case "Confirmed":
                    return Color.Green;
                case "Cancelled":
                    return Color.Red;
                case "Completed":
                    return Color.Blue;
                default:
                    return Color.Black;
            }
        }

        // Xóa thông tin chi tiết
        private void ClearDetails()
        {
            lblBookingCodeValue.Text = "";
            lblMovieValue.Text = "";
            lblShowtimeValue.Text = "";
            lblRoomValue.Text = "";
            lblSeatsValue.Text = "";
            lblTotalValue.Text = "";
            lblStatusValue.Text = "";
            selectedBooking = null;
            btnCancel.Enabled = false;
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần in!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["BookingID"].Value);
            string status = dgvBookings.SelectedRows[0].Cells["BookingStatus"].Value.ToString();

            if (status == "Cancelled")
            {
                MessageBox.Show("Không thể in vé đã hủy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmTicketPrint frm = new frmTicketPrint(bookingId);
            frm.ShowDialog();
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
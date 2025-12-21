using MovieTicket.BLL;
using MovieTicket.DTO;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    public partial class frmBooking : Form
    {
        private readonly MovieBLL movieBLL = new MovieBLL();
        private readonly BookingBLL bookingBLL = new BookingBLL();

        private UserDTO currentUser;
        private List<SeatDTO> allSeats = new List<SeatDTO>();
        private List<int> bookedSeatIds = new List<int>();
        private List<int> selectedSeatIds = new List<int>();
        private ShowtimeDTO selectedShowtime;

        // Constructor nhận thông tin user
        public frmBooking(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            LoadMovies();
            ClearBookingInfo();
        }

        // Load danh sách phim đang chiếu
        // Load danh sách phim đang chiếu
        private void LoadMovies()
        {
            try
            {
                List<MovieDTO> movies = movieBLL.GetAll();

                cboMovies.DataSource = null;
                cboMovies.DisplayMember = "Title";
                cboMovies.ValueMember = "MovieID";
                cboMovies.DataSource = movies;
                cboMovies.SelectedIndex = -1;

                cboShowtimes.DataSource = null;
                lblShowtimeInfo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi chọn phim
        // Khi chọn phim
        private void cboMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMovies.SelectedIndex >= 0)
            {
                // Lấy movie từ SelectedItem thay vì SelectedValue
                MovieDTO movie = cboMovies.SelectedItem as MovieDTO;

                if (movie != null)
                {
                    LoadShowtimes(movie.MovieID);
                    lblMovieValue.Text = movie.Title;
                }

                // Xóa sơ đồ ghế cũ
                ClearSeats();
                ClearBookingInfo();

                // Giữ lại tên phim
                if (movie != null)
                {
                    lblMovieValue.Text = movie.Title;
                }
            }
        }

        // Load suất chiếu theo phim
        // Load suất chiếu theo phim
        private void LoadShowtimes(int movieId)
        {
            try
            {
                List<ShowtimeDTO> showtimes = bookingBLL.GetShowtimesByMovie(movieId);

                cboShowtimes.DataSource = null;
                cboShowtimes.DisplayMember = "DisplayTime";
                cboShowtimes.ValueMember = "ShowtimeID";
                cboShowtimes.DataSource = showtimes;
                cboShowtimes.SelectedIndex = -1;

                lblShowtimeInfo.Text = showtimes.Count > 0
                    ? $"Có {showtimes.Count} suất chiếu"
                    : "Không có suất chiếu nào";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải suất chiếu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi chọn suất chiếu
        // Khi chọn suất chiếu
        private void cboShowtimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShowtimes.SelectedIndex >= 0)
            {
                // Lấy showtime từ SelectedItem
                selectedShowtime = cboShowtimes.SelectedItem as ShowtimeDTO;

                if (selectedShowtime != null)
                {
                    // Cập nhật thông tin
                    lblTimeValue.Text = selectedShowtime.StartTime.ToString("dd/MM/yyyy HH:mm");
                    lblRoomValue.Text = selectedShowtime.RoomName;

                    // Load sơ đồ ghế
                    LoadSeats(selectedShowtime.RoomID, selectedShowtime.ShowtimeID);
                }

                // Xóa ghế đã chọn
                selectedSeatIds.Clear();
                UpdateSelectedSeatsInfo();
            }
        }

        // Load sơ đồ ghế
        private void LoadSeats(int roomId, int showtimeId)
        {
            try
            {
                // Xóa ghế cũ
                pnlSeats.Controls.Clear();

                // Lấy danh sách ghế và ghế đã đặt
                allSeats = bookingBLL.GetSeatsByRoom(roomId);
                bookedSeatIds = bookingBLL.GetBookedSeatIds(showtimeId);

                if (allSeats.Count == 0)
                {
                    lblStatus.Text = "Phòng này chưa có ghế!";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                // Tạo các nút ghế
                CreateSeatButtons();

                lblStatus.Text = $"Tổng số ghế: {allSeats.Count} | Đã đặt: {bookedSeatIds.Count} | Còn trống: {allSeats.Count - bookedSeatIds.Count}";
                lblStatus.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sơ đồ ghế: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo các nút ghế
        private void CreateSeatButtons()
        {
            // Nhóm ghế theo hàng
            var seatsByRow = allSeats.GroupBy(s => s.RowNumber).OrderBy(g => g.Key);

            int buttonWidth = 45;
            int buttonHeight = 35;
            int marginX = 5;
            int marginY = 5;
            int startX = 10;
            int startY = 10;
            int currentY = startY;

            foreach (var row in seatsByRow)
            {
                int currentX = startX;

                // Label hàng
                Label lblRow = new Label
                {
                    Text = row.Key,
                    Location = new Point(currentX, currentY + 8),
                    Size = new Size(20, 20),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };
                pnlSeats.Controls.Add(lblRow);
                currentX += 25;

                foreach (var seat in row.OrderBy(s => s.SeatNumber))
                {
                    Button btnSeat = new Button
                    {
                        Name = $"btnSeat_{seat.SeatID}",
                        Text = seat.SeatNumber.ToString(),
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(currentX, currentY),
                        Tag = seat,
                        Font = new Font("Segoe UI", 8),
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand
                    };

                    // Thiết lập màu theo trạng thái
                    if (bookedSeatIds.Contains(seat.SeatID))
                    {
                        // Ghế đã đặt
                        btnSeat.BackColor = Color.Red;
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Enabled = false;
                    }
                    else if (seat.TypeName == "VIP" || seat.SeatTypeID == 2)
                    {
                        // Ghế VIP
                        btnSeat.BackColor = Color.Gold;
                        btnSeat.ForeColor = Color.Black;
                    }
                    else
                    {
                        // Ghế thường
                        btnSeat.BackColor = Color.White;
                        btnSeat.ForeColor = Color.Black;
                    }

                    btnSeat.Click += BtnSeat_Click;
                    pnlSeats.Controls.Add(btnSeat);

                    currentX += buttonWidth + marginX;
                }

                currentY += buttonHeight + marginY;
            }
        }

        // Sự kiện click ghế
        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            SeatDTO seat = btn.Tag as SeatDTO;
            if (seat == null) return;

            if (selectedSeatIds.Contains(seat.SeatID))
            {
                // Bỏ chọn ghế - trả về màu gốc
                selectedSeatIds.Remove(seat.SeatID);

                if (seat.TypeName == "VIP" || seat.SeatTypeID == 2)
                {
                    btn.BackColor = Color.Gold;
                    btn.ForeColor = Color.Black;
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }
            else
            {
                // Chọn ghế
                selectedSeatIds.Add(seat.SeatID);
                btn.BackColor = Color.DodgerBlue;
                btn.ForeColor = Color.White;
            }

            UpdateSelectedSeatsInfo();
        }

        // Cập nhật thông tin ghế đã chọn và tổng tiền
        private void UpdateSelectedSeatsInfo()
        {
            if (selectedSeatIds.Count == 0)
            {
                lblSeatsValue.Text = "(Chưa chọn)";
                lblPriceValue.Text = "0 VNĐ";
                return;
            }

            // Lấy danh sách mã ghế đã chọn
            var selectedSeats = allSeats.Where(s => selectedSeatIds.Contains(s.SeatID)).ToList();
            string seatCodes = string.Join(", ", selectedSeats.Select(s => s.DisplaySeatCode));
            lblSeatsValue.Text = seatCodes;

            // Tính tổng tiền
            if (selectedShowtime != null)
            {
                decimal total = 0;
                foreach (var seat in selectedSeats)
                {
                    total += selectedShowtime.BasePrice * seat.PriceMultiplier;
                }
                lblPriceValue.Text = string.Format("{0:N0} VNĐ", total);
            }
        }

        // Xóa sơ đồ ghế
        private void ClearSeats()
        {
            pnlSeats.Controls.Clear();
            allSeats.Clear();
            bookedSeatIds.Clear();
            selectedSeatIds.Clear();
        }

        // Xóa thông tin đặt vé
        private void ClearBookingInfo()
        {
            lblMovieValue.Text = "";
            lblTimeValue.Text = "";
            lblRoomValue.Text = "";
            lblSeatsValue.Text = "(Chưa chọn)";
            lblPriceValue.Text = "0 VNĐ";
            selectedShowtime = null;
        }

        // Nút Đặt vé
        private void btnBooking_Click(object sender, EventArgs e)
        {
            // Validate
            if (cboMovies.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phim!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboShowtimes.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSeatIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận đặt vé
            string movieName = lblMovieValue.Text;
            string showtime = lblTimeValue.Text;
            string room = lblRoomValue.Text;
            string seats = lblSeatsValue.Text;
            string price = lblPriceValue.Text;

            string confirmMessage = $"Xác nhận đặt vé:\n\n" +
                                   $"Phim: {movieName}\n" +
                                   $"Suất chiếu: {showtime}\n" +
                                   $"Phòng: {room}\n" +
                                   $"Ghế: {seats}\n" +
                                   $"Tổng tiền: {price}\n\n" +
                                   $"Bạn có chắc muốn đặt vé?";

            DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận đặt vé",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Tính tổng tiền
                    decimal totalAmount = bookingBLL.CalculateTotalAmount(
                        selectedShowtime.ShowtimeID, selectedSeatIds);

                    // Tạo booking
                    var bookingResult = bookingBLL.CreateBooking(
                        currentUser.UserID,
                        selectedShowtime.ShowtimeID,
                        selectedSeatIds,
                        totalAmount);

                    if (bookingResult.success)
                    {
                        MessageBox.Show(bookingResult.message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hỏi có muốn in vé không
                        DialogResult printResult = MessageBox.Show("Bạn có muốn in vé không?", "In vé",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (printResult == DialogResult.Yes)
                        {
                            frmTicketPrint frm = new frmTicketPrint(bookingResult.bookingId);
                            frm.ShowDialog();
                        }

                        // Reload sơ đồ ghế
                        LoadSeats(selectedShowtime.RoomID, selectedShowtime.ShowtimeID);
                        selectedSeatIds.Clear();
                        UpdateSelectedSeatsInfo();
                    }
                    else
                    {
                        MessageBox.Show(bookingResult.message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đặt vé: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Xóa chọn
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa chọn tất cả ghế
            foreach (int seatId in selectedSeatIds.ToList())
            {
                Button btn = pnlSeats.Controls.Find($"btnSeat_{seatId}", false).FirstOrDefault() as Button;
                if (btn != null)
                {
                    SeatDTO seat = btn.Tag as SeatDTO;
                    if (seat != null)
                    {
                        if (seat.TypeName == "VIP" || seat.SeatTypeID == 2)
                            btn.BackColor = Color.Gold;
                        else
                            btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                    }
                }
            }

            selectedSeatIds.Clear();
            UpdateSelectedSeatsInfo();
        }

        // Nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
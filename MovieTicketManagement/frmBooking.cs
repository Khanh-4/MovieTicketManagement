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
        private readonly FoodBLL foodBLL = new FoodBLL();
        private readonly GiftBLL giftBLL = new GiftBLL();

        private UserDTO currentUser;
        private List<SeatDTO> allSeats = new List<SeatDTO>();
        private List<int> bookedSeatIds = new List<int>();
        private List<int> selectedSeatIds = new List<int>();
        private ShowtimeDTO selectedShowtime;

        // Danh sách đồ ăn đã chọn
        private List<SelectedFoodItem> selectedFoods = new List<SelectedFoodItem>();

        // === MỚI: Biến cho quà tặng ===
        private GiftCampaignDTO currentGiftCampaign = null;
        private GiftReservationResult giftReservation = null;

        // Constructor nhận thông tin user
        public frmBooking(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadFoodCategories();
            ClearBookingInfo();
        }

        #region Load Data

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

        // Load danh mục đồ ăn
        private void LoadFoodCategories()
        {
            try
            {
                var categories = foodBLL.GetAllCategories();

                // Thêm option "Tất cả"
                categories.Insert(0, new FoodCategoryDTO { CategoryID = 0, CategoryName = "-- Tất cả --" });

                cboFoodCategory.DataSource = null;
                cboFoodCategory.DisplayMember = "CategoryName";
                cboFoodCategory.ValueMember = "CategoryID";
                cboFoodCategory.DataSource = categories;
                cboFoodCategory.SelectedIndex = 0;

                LoadFoods(0); // Load tất cả đồ ăn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục đồ ăn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load đồ ăn theo danh mục
        private void LoadFoods(int categoryId)
        {
            try
            {
                List<FoodDTO> foods;

                if (categoryId == 0)
                    foods = foodBLL.GetAllActive();
                else
                    foods = foodBLL.GetByCategory(categoryId);

                dgvFoods.DataSource = null;
                dgvFoods.DataSource = foods;

                // Ẩn các cột không cần thiết
                if (dgvFoods.Columns.Count > 0)
                {
                    dgvFoods.Columns["FoodID"].Visible = false;
                    dgvFoods.Columns["CategoryID"].Visible = false;
                    dgvFoods.Columns["ImageURL"].Visible = false;
                    dgvFoods.Columns["Description"].Visible = false;
                    dgvFoods.Columns["StockQuantity"].Visible = false;
                    dgvFoods.Columns["IsActive"].Visible = false;
                    dgvFoods.Columns["CategoryName"].Visible = false;

                    dgvFoods.Columns["FoodName"].HeaderText = "Tên món";
                    dgvFoods.Columns["FoodName"].Width = 150;
                    dgvFoods.Columns["Price"].HeaderText = "Giá";
                    dgvFoods.Columns["Price"].Width = 80;
                    dgvFoods.Columns["Price"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đồ ăn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === MỚI: Kiểm tra chiến dịch quà tặng ===
        private void CheckGiftCampaign(int movieId)
        {
            try
            {
                // Reset quà tặng trước đó
                currentGiftCampaign = null;
                giftReservation = null;
                UpdateGiftDisplay();

                // Lấy chiến dịch quà đang hoạt động cho phim này
                var campaigns = giftBLL.GetActiveCampaigns(movieId);

                if (campaigns.Count > 0)
                {
                    // Lấy chiến dịch đầu tiên còn quà
                    currentGiftCampaign = campaigns.FirstOrDefault(c => c.RemainingGifts > 0);

                    if (currentGiftCampaign != null)
                    {
                        // Kiểm tra user có đủ điều kiện không
                        var (isEligible, message, remaining) = giftBLL.CheckUserGiftEligibility(
                            currentGiftCampaign.CampaignID, currentUser.UserID);

                        if (isEligible)
                        {
                            // Hiển thị thông báo có quà
                            UpdateGiftDisplay();
                        }
                        else
                        {
                            // Không đủ điều kiện (đã nhận quà trước đó)
                            currentGiftCampaign = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi kiểm tra quà: {ex.Message}");
            }
        }

        #endregion

        #region Seat Selection Events

        // Khi chọn phim
        private void cboMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMovies.SelectedIndex >= 0)
            {
                MovieDTO movie = cboMovies.SelectedItem as MovieDTO;

                // Xóa sơ đồ ghế cũ và thông tin TRƯỚC
                ClearSeats();
                ClearBookingInfo();

                if (movie != null)
                {
                    LoadShowtimes(movie.MovieID);
                    lblMovieValue.Text = movie.Title;

                    // === MỚI: Kiểm tra có chiến dịch quà tặng không (SAU khi clear) ===
                    CheckGiftCampaign(movie.MovieID);
                }
            }
        }

        // Khi chọn suất chiếu
        private void cboShowtimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShowtimes.SelectedIndex >= 0)
            {
                selectedShowtime = cboShowtimes.SelectedItem as ShowtimeDTO;

                if (selectedShowtime != null)
                {
                    lblTimeValue.Text = selectedShowtime.StartTime.ToString("dd/MM/yyyy HH:mm");
                    lblRoomValue.Text = selectedShowtime.RoomName;

                    LoadSeats(selectedShowtime.RoomID, selectedShowtime.ShowtimeID);

                    // === MỚI: Giữ chỗ quà khi chọn suất chiếu ===
                    ReserveGiftIfAvailable();
                }

                selectedSeatIds.Clear();
                UpdateSelectedSeatsInfo();
            }
        }

        // === MỚI: Giữ chỗ quà ===
        private void ReserveGiftIfAvailable()
        {
            if (currentGiftCampaign == null) return;

            try
            {
                // Giữ chỗ quà
                giftReservation = giftBLL.ReserveGift(currentGiftCampaign.CampaignID, currentUser.UserID);

                if (giftReservation.Success)
                {
                    UpdateGiftDisplay();

                    // Hiển thị thông báo
                    MessageBox.Show(
                        $"🎁 CHÚC MỪNG!\n\n" +
                        $"Bạn đã được giữ chỗ quà tặng:\n" +
                        $"► {currentGiftCampaign.GiftName}\n\n" +
                        $"Vui lòng hoàn tất thanh toán trong {giftReservation.MinutesRemaining} phút\n" +
                        $"để nhận quà khi đến rạp!",
                        "Quà tặng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi giữ chỗ quà: {ex.Message}");
            }
        }

        // === MỚI: Cập nhật hiển thị quà tặng ===
        private void UpdateGiftDisplay()
        {
            if (currentGiftCampaign != null && giftReservation != null && giftReservation.Success)
            {
                lblGiftInfo.Text = $"🎁 {currentGiftCampaign.GiftName}";
                lblGiftInfo.ForeColor = Color.Green;
                lblGiftInfo.Visible = true;

                lblGiftStatus.Text = $"⏱ Còn {giftReservation.MinutesRemaining} phút để thanh toán";
                lblGiftStatus.ForeColor = Color.OrangeRed;
                lblGiftStatus.Visible = true;
            }
            else if (currentGiftCampaign != null)
            {
                lblGiftInfo.Text = $"🎁 Có quà: {currentGiftCampaign.GiftName} (Còn {currentGiftCampaign.RemainingGifts})";
                lblGiftInfo.ForeColor = Color.Blue;
                lblGiftInfo.Visible = true;
                lblGiftStatus.Visible = false;
            }
            else
            {
                lblGiftInfo.Visible = false;
                lblGiftStatus.Visible = false;
            }
        }

        #endregion

        #region Create Seat Buttons

        // Tạo các nút ghế với màu theo loại
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

                    // Thiết lập màu theo trạng thái và loại ghế
                    if (bookedSeatIds.Contains(seat.SeatID))
                    {
                        // Ghế đã đặt - ĐỎ
                        btnSeat.BackColor = Color.Red;
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Enabled = false;
                    }
                    else if (seat.SeatTypeID == 3 || seat.TypeName == "Couple")
                    {
                        // Ghế COUPLE - TÍM
                        btnSeat.BackColor = Color.MediumOrchid;
                        btnSeat.ForeColor = Color.White;
                    }
                    else if (seat.SeatTypeID == 2 || seat.TypeName == "VIP")
                    {
                        // Ghế VIP - VÀNG
                        btnSeat.BackColor = Color.Gold;
                        btnSeat.ForeColor = Color.Black;
                    }
                    else
                    {
                        // Ghế thường - TRẮNG
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

        #endregion

        #region Seat Click Handler with Validation

        // Sự kiện click ghế - CÓ KIỂM TRA RÀNG BUỘC
        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            SeatDTO seat = btn.Tag as SeatDTO;
            if (seat == null) return;

            // === XỬ LÝ GHẾ COUPLE ===
            if (seat.IsCoupleSeat && seat.CoupleGroupID.HasValue)
            {
                HandleCoupleSeatClick(seat);
                return;
            }

            // === XỬ LÝ GHẾ THƯỜNG/VIP ===
            if (selectedSeatIds.Contains(seat.SeatID))
            {
                // BỎ CHỌN GHẾ
                // Kiểm tra nếu bỏ chọn sẽ tạo ra lỗ hổng 1 ghế
                if (!CanDeselectSeat(seat))
                {
                    MessageBox.Show(
                        "Không thể bỏ chọn ghế này!\n\n" +
                        "Lý do: Sẽ tạo ra ghế trống đơn lẻ giữa các ghế đã chọn.\n" +
                        "Vui lòng bỏ chọn các ghế bên cạnh trước.",
                        "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bỏ chọn ghế - trả về màu gốc
                selectedSeatIds.Remove(seat.SeatID);
                ResetSeatColor(btn, seat);
            }
            else
            {
                // CHỌN GHẾ MỚI
                // Kiểm tra quy tắc chọn ghế
                string validationError = ValidateSeatSelection(seat);
                if (!string.IsNullOrEmpty(validationError))
                {
                    MessageBox.Show(validationError, "Không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chọn ghế
                selectedSeatIds.Add(seat.SeatID);
                btn.BackColor = Color.DodgerBlue;
                btn.ForeColor = Color.White;
            }

            UpdateSelectedSeatsInfo();
        }

        // Xử lý click ghế Couple (chọn cả cặp)
        private void HandleCoupleSeatClick(SeatDTO clickedSeat)
        {
            // Tìm ghế còn lại trong cặp
            var coupleSeats = allSeats
                .Where(s => s.CoupleGroupID == clickedSeat.CoupleGroupID)
                .ToList();

            if (coupleSeats.Count != 2)
            {
                MessageBox.Show("Lỗi dữ liệu ghế Couple!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem cặp ghế đã được chọn chưa
            bool isSelected = selectedSeatIds.Contains(clickedSeat.SeatID);

            if (isSelected)
            {
                // BỎ CHỌN CẢ CẶP
                foreach (var seat in coupleSeats)
                {
                    if (selectedSeatIds.Contains(seat.SeatID))
                    {
                        selectedSeatIds.Remove(seat.SeatID);

                        Button btn = pnlSeats.Controls.Find($"btnSeat_{seat.SeatID}", false).FirstOrDefault() as Button;
                        if (btn != null)
                        {
                            btn.BackColor = Color.MediumOrchid;
                            btn.ForeColor = Color.White;
                        }
                    }
                }
            }
            else
            {
                // CHỌN CẢ CẶP
                // Kiểm tra xem có ghế nào trong cặp đã được đặt chưa
                foreach (var seat in coupleSeats)
                {
                    if (bookedSeatIds.Contains(seat.SeatID))
                    {
                        MessageBox.Show(
                            $"Ghế {seat.DisplaySeatCode} trong cặp đã được đặt!\n" +
                            "Vui lòng chọn cặp ghế khác.",
                            "Ghế đã đặt",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Chọn cả cặp
                foreach (var seat in coupleSeats)
                {
                    if (!selectedSeatIds.Contains(seat.SeatID))
                    {
                        selectedSeatIds.Add(seat.SeatID);

                        Button btn = pnlSeats.Controls.Find($"btnSeat_{seat.SeatID}", false).FirstOrDefault() as Button;
                        if (btn != null)
                        {
                            btn.BackColor = Color.DodgerBlue;
                            btn.ForeColor = Color.White;
                        }
                    }
                }
            }

            UpdateSelectedSeatsInfo();
        }

        #endregion

        #region Seat Validation Rules

        /// <summary>
        /// Kiểm tra quy tắc khi chọn ghế mới
        /// </summary>
        private string ValidateSeatSelection(SeatDTO newSeat)
        {
            // Nếu chưa có ghế nào được chọn -> OK
            if (selectedSeatIds.Count == 0)
                return null;

            // Lấy danh sách ghế cùng hàng
            var seatsInSameRow = allSeats
                .Where(s => s.RowNumber == newSeat.RowNumber)
                .OrderBy(s => s.SeatNumber)
                .ToList();

            // Lấy danh sách ghế đã chọn trong cùng hàng
            var selectedSeatsInRow = seatsInSameRow
                .Where(s => selectedSeatIds.Contains(s.SeatID))
                .ToList();

            // === QUY TẮC 1: Kiểm tra ghế liên tiếp ===
            if (selectedSeatsInRow.Count > 0)
            {
                int minSeatNum = selectedSeatsInRow.Min(s => s.SeatNumber);
                int maxSeatNum = selectedSeatsInRow.Max(s => s.SeatNumber);

                // Ghế mới phải ở vị trí minSeatNum - 1 hoặc maxSeatNum + 1
                if (newSeat.SeatNumber != minSeatNum - 1 && newSeat.SeatNumber != maxSeatNum + 1)
                {
                    return "Các ghế phải được chọn liền kề nhau!\n\n" +
                           $"Bạn đã chọn ghế từ {newSeat.RowNumber}{minSeatNum} đến {newSeat.RowNumber}{maxSeatNum}.\n" +
                           $"Vui lòng chọn ghế {newSeat.RowNumber}{minSeatNum - 1} hoặc {newSeat.RowNumber}{maxSeatNum + 1}.";
                }
            }

            // === QUY TẮC 2: Kiểm tra không để trống 1 ghế ===
            var tempSelectedIds = new List<int>(selectedSeatIds) { newSeat.SeatID };

            string gapError = CheckSingleGapInRow(newSeat.RowNumber, tempSelectedIds);
            if (!string.IsNullOrEmpty(gapError))
                return gapError;

            return null;
        }

        /// <summary>
        /// Kiểm tra có để trống 1 ghế đơn lẻ trong hàng không
        /// </summary>
        private string CheckSingleGapInRow(string rowNumber, List<int> selectedIds)
        {
            var seatsInRow = allSeats
                .Where(s => s.RowNumber == rowNumber)
                .OrderBy(s => s.SeatNumber)
                .ToList();

            for (int i = 0; i < seatsInRow.Count; i++)
            {
                var currentSeat = seatsInRow[i];

                if (bookedSeatIds.Contains(currentSeat.SeatID) || selectedIds.Contains(currentSeat.SeatID))
                    continue;

                bool hasLeftOccupied = false;
                if (i > 0)
                {
                    var leftSeat = seatsInRow[i - 1];
                    hasLeftOccupied = bookedSeatIds.Contains(leftSeat.SeatID) || selectedIds.Contains(leftSeat.SeatID);
                }
                else
                {
                    hasLeftOccupied = true;
                }

                bool hasRightOccupied = false;
                if (i < seatsInRow.Count - 1)
                {
                    var rightSeat = seatsInRow[i + 1];
                    hasRightOccupied = bookedSeatIds.Contains(rightSeat.SeatID) || selectedIds.Contains(rightSeat.SeatID);
                }
                else
                {
                    hasRightOccupied = true;
                }

                if (hasLeftOccupied && hasRightOccupied)
                {
                    return $"Không thể chọn ghế này!\n\n" +
                           $"Lý do: Sẽ để lại ghế {currentSeat.DisplaySeatCode} trống đơn lẻ.\n" +
                           $"Quy định: Không được để trống 1 ghế giữa các ghế đã đặt.\n\n" +
                           $"Gợi ý: Hãy chọn thêm ghế {currentSeat.DisplaySeatCode} hoặc chọn vị trí khác.";
                }
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra có thể bỏ chọn ghế không
        /// </summary>
        private bool CanDeselectSeat(SeatDTO seat)
        {
            var tempSelectedIds = selectedSeatIds.Where(id => id != seat.SeatID).ToList();

            if (tempSelectedIds.Count == 0)
                return true;

            var selectedSeatsInRow = allSeats
                .Where(s => s.RowNumber == seat.RowNumber && tempSelectedIds.Contains(s.SeatID))
                .OrderBy(s => s.SeatNumber)
                .ToList();

            if (selectedSeatsInRow.Count <= 1)
                return true;

            for (int i = 1; i < selectedSeatsInRow.Count; i++)
            {
                if (selectedSeatsInRow[i].SeatNumber - selectedSeatsInRow[i - 1].SeatNumber != 1)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Reset màu ghế về trạng thái ban đầu
        /// </summary>
        private void ResetSeatColor(Button btn, SeatDTO seat)
        {
            if (seat.SeatTypeID == 3 || seat.TypeName == "Couple")
            {
                btn.BackColor = Color.MediumOrchid;
                btn.ForeColor = Color.White;
            }
            else if (seat.SeatTypeID == 2 || seat.TypeName == "VIP")
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

        #endregion

        #region Food Selection

        // Khi chọn danh mục đồ ăn
        private void cboFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFoodCategory.SelectedIndex >= 0)
            {
                var category = cboFoodCategory.SelectedItem as FoodCategoryDTO;
                if (category != null)
                {
                    LoadFoods(category.CategoryID);
                }
            }
        }

        // Thêm đồ ăn vào giỏ
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (dgvFoods.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var food = dgvFoods.CurrentRow.DataBoundItem as FoodDTO;
            if (food == null) return;

            int quantity = (int)nudQuantity.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem đã có trong giỏ chưa
            var existingItem = selectedFoods.FirstOrDefault(f => f.FoodID == food.FoodID);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                selectedFoods.Add(new SelectedFoodItem
                {
                    FoodID = food.FoodID,
                    FoodName = food.FoodName,
                    UnitPrice = food.Price,
                    Quantity = quantity
                });
            }

            RefreshFoodCart();
            nudQuantity.Value = 1;
        }

        // Xóa đồ ăn khỏi giỏ
        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            if (dgvSelectedFoods.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = dgvSelectedFoods.CurrentRow.DataBoundItem as SelectedFoodItem;
            if (item != null)
            {
                selectedFoods.Remove(item);
                RefreshFoodCart();
            }
        }

        // Refresh giỏ đồ ăn
        private void RefreshFoodCart()
        {
            dgvSelectedFoods.DataSource = null;
            dgvSelectedFoods.DataSource = selectedFoods.ToList();

            if (dgvSelectedFoods.Columns.Count > 0)
            {
                dgvSelectedFoods.Columns["FoodID"].Visible = false;
                dgvSelectedFoods.Columns["UnitPrice"].Visible = false;
                dgvSelectedFoods.Columns["TotalPrice"].Visible = false;

                dgvSelectedFoods.Columns["FoodName"].HeaderText = "Món";
                dgvSelectedFoods.Columns["FoodName"].Width = 120;
                dgvSelectedFoods.Columns["Quantity"].HeaderText = "SL";
                dgvSelectedFoods.Columns["Quantity"].Width = 40;
                dgvSelectedFoods.Columns["DisplayUnitPrice"].HeaderText = "Đơn giá";
                dgvSelectedFoods.Columns["DisplayUnitPrice"].Width = 70;
                dgvSelectedFoods.Columns["DisplayTotal"].HeaderText = "Thành tiền";
                dgvSelectedFoods.Columns["DisplayTotal"].Width = 80;
            }

            UpdateTotalAmount();
        }

        #endregion

        #region Update Info

        // Cập nhật thông tin ghế đã chọn và tổng tiền
        private void UpdateSelectedSeatsInfo()
        {
            if (selectedSeatIds.Count == 0)
            {
                lblSeatsValue.Text = "(Chưa chọn)";
            }
            else
            {
                var selectedSeats = allSeats.Where(s => selectedSeatIds.Contains(s.SeatID)).ToList();
                string seatCodes = string.Join(", ", selectedSeats.Select(s => s.DisplaySeatCode));
                lblSeatsValue.Text = seatCodes;
            }

            UpdateTotalAmount();
        }

        // Cập nhật tổng tiền (vé + đồ ăn)
        private void UpdateTotalAmount()
        {
            decimal ticketTotal = 0;
            decimal foodTotal = 0;

            // Tính tiền vé
            if (selectedShowtime != null && selectedSeatIds.Count > 0)
            {
                var selectedSeats = allSeats.Where(s => selectedSeatIds.Contains(s.SeatID));
                foreach (var seat in selectedSeats)
                {
                    ticketTotal += selectedShowtime.BasePrice * seat.PriceMultiplier;
                }
            }

            // Tính tiền đồ ăn
            foodTotal = selectedFoods.Sum(f => f.TotalPrice);

            // Hiển thị
            lblTicketPrice.Text = string.Format("{0:N0} đ", ticketTotal);
            lblFoodPrice.Text = string.Format("{0:N0} đ", foodTotal);
            lblTotalPrice.Text = string.Format("{0:N0} đ", ticketTotal + foodTotal);

            lblPriceValue.Text = string.Format("{0:N0} VNĐ", ticketTotal + foodTotal);
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
            lblTicketPrice.Text = "0 đ";
            lblFoodPrice.Text = "0 đ";
            lblTotalPrice.Text = "0 đ";
            selectedShowtime = null;
            selectedFoods.Clear();
            RefreshFoodCart();

            // Clear quà tặng
            currentGiftCampaign = null;
            giftReservation = null;
            UpdateGiftDisplay();
        }

        #endregion

        #region Booking Actions

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

            // Tính tổng tiền
            decimal ticketTotal = 0;
            var selectedSeats = allSeats.Where(s => selectedSeatIds.Contains(s.SeatID));
            foreach (var seat in selectedSeats)
            {
                ticketTotal += selectedShowtime.BasePrice * seat.PriceMultiplier;
            }
            decimal foodTotal = selectedFoods.Sum(f => f.TotalPrice);
            decimal grandTotal = ticketTotal + foodTotal;

            // Thông tin quà tặng
            string giftInfo = "";
            if (giftReservation != null && giftReservation.Success && currentGiftCampaign != null)
            {
                giftInfo = $"\n🎁 QUÀ TẶNG: {currentGiftCampaign.GiftName}";
            }

            // Xác nhận đặt vé
            string foodList = selectedFoods.Count > 0
                ? string.Join("\n", selectedFoods.Select(f => $"  - {f.FoodName} x{f.Quantity}: {f.DisplayTotal}"))
                : "  (Không có)";

            string confirmMessage = $"Xác nhận đặt vé:\n\n" +
                                   $"Phim: {lblMovieValue.Text}\n" +
                                   $"Suất chiếu: {lblTimeValue.Text}\n" +
                                   $"Phòng: {lblRoomValue.Text}\n" +
                                   $"Ghế: {lblSeatsValue.Text}\n" +
                                   $"Tiền vé: {ticketTotal:N0} đ\n\n" +
                                   $"Đồ ăn/thức uống:\n{foodList}\n" +
                                   $"Tiền đồ ăn: {foodTotal:N0} đ\n" +
                                   giftInfo + "\n\n" +
                                   $"═══════════════════\n" +
                                   $"TỔNG CỘNG: {grandTotal:N0} đ\n" +
                                   $"═══════════════════\n\n" +
                                   $"Bạn có chắc muốn đặt vé?";

            DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận đặt vé",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Tạo booking VỚI đồ ăn
                    var bookingResult = bookingBLL.CreateBookingWithFoods(
                        currentUser.UserID,
                        selectedShowtime.ShowtimeID,
                        selectedSeatIds,
                        ticketTotal,
                        selectedFoods);

                    if (bookingResult.success)
                    {
                        // === MỚI: Xác nhận quà tặng ===
                        string giftMessage = "";
                        if (giftReservation != null && giftReservation.Success && giftReservation.ReservationID > 0)
                        {
                            var (giftSuccess, giftMsg) = giftBLL.ConfirmGift(
                                giftReservation.ReservationID,
                                bookingResult.bookingId);

                            if (giftSuccess)
                            {
                                giftMessage = $"\n\n🎁 QUÀ TẶNG: {currentGiftCampaign?.GiftName}\n" +
                                             "Vui lòng đến quầy để nhận quà khi vào rạp!";
                            }
                        }

                        MessageBox.Show(bookingResult.message + giftMessage, "Thành công",
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
                        selectedFoods.Clear();
                        RefreshFoodCart();
                        UpdateSelectedSeatsInfo();

                        // Reset quà tặng
                        currentGiftCampaign = null;
                        giftReservation = null;
                        UpdateGiftDisplay();
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
                        ResetSeatColor(btn, seat);
                    }
                }
            }

            selectedSeatIds.Clear();
            UpdateSelectedSeatsInfo();
        }

        // Nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Hủy reservation quà nếu có
            if (giftReservation != null && giftReservation.Success && giftReservation.ReservationID > 0)
            {
                try
                {
                    giftBLL.CancelGiftReservation(giftReservation.ReservationID, "Người dùng đóng form đặt vé", true);
                }
                catch { }
            }

            this.Close();
        }

        #endregion
    }
}
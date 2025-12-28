namespace MovieTicketManagement
{
    partial class frmBooking
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSelectMovie = new Label();
            cboMovies = new ComboBox();
            lblSelectShowtime = new Label();
            cboShowtimes = new ComboBox();
            lblShowtimeInfo = new Label();
            lblScreen = new Label();
            pnlSeats = new Panel();

            // Chú thích ghế
            lblLegend = new Label();
            lblColorAvailable = new Label();
            lblTextAvailable = new Label();
            lblColorSelected = new Label();
            lblTextSelected = new Label();
            lblColorBooked = new Label();
            lblTextBooked = new Label();
            lblColorVIP = new Label();
            lblTextVIP = new Label();
            lblColorCouple = new Label();
            lblTextCouple = new Label();

            // Thông tin đặt vé
            grpBookingInfo = new GroupBox();
            lblMovieInfo = new Label();
            lblMovieValue = new Label();
            lblTimeInfo = new Label();
            lblTimeValue = new Label();
            lblRoomInfo = new Label();
            lblRoomValue = new Label();
            lblSeatsInfo = new Label();
            lblSeatsValue = new Label();
            lblLine = new Label();
            lblTicketPriceInfo = new Label();
            lblTicketPrice = new Label();
            lblFoodPriceInfo = new Label();
            lblFoodPrice = new Label();
            lblLine2 = new Label();
            lblTotalPriceInfo = new Label();
            lblTotalPrice = new Label();
            lblPriceInfo = new Label();
            lblPriceValue = new Label();

            // Phần đồ ăn
            grpFood = new GroupBox();
            lblFoodCategory = new Label();
            cboFoodCategory = new ComboBox();
            dgvFoods = new DataGridView();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            btnAddFood = new Button();
            lblSelectedFoods = new Label();
            dgvSelectedFoods = new DataGridView();
            btnRemoveFood = new Button();

            // Buttons
            btnBooking = new Button();
            btnClear = new Button();
            btnClose = new Button();
            lblStatus = new Label();

            grpBookingInfo.SuspendLayout();
            grpFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoods).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedFoods).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();

            // ==================== TITLE ====================
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(450, 14);
            lblTitle.Text = "🎬 ĐẶT VÉ XEM PHIM";

            // ==================== CHỌN PHIM ====================
            lblSelectMovie.AutoSize = true;
            lblSelectMovie.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblSelectMovie.Location = new Point(12, 60);
            lblSelectMovie.Text = "Chọn phim:";

            cboMovies.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMovies.Location = new Point(88, 56);
            cboMovies.Size = new Size(280, 23);
            cboMovies.SelectedIndexChanged += cboMovies_SelectedIndexChanged;

            // ==================== CHỌN SUẤT CHIẾU ====================
            lblSelectShowtime.AutoSize = true;
            lblSelectShowtime.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblSelectShowtime.Location = new Point(12, 95);
            lblSelectShowtime.Text = "Chọn suất chiếu:";

            cboShowtimes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShowtimes.Location = new Point(125, 91);
            cboShowtimes.Size = new Size(243, 23);
            cboShowtimes.SelectedIndexChanged += cboShowtimes_SelectedIndexChanged;

            lblShowtimeInfo.AutoSize = true;
            lblShowtimeInfo.ForeColor = Color.Blue;
            lblShowtimeInfo.Location = new Point(12, 125);

            // ==================== MÀN HÌNH ====================
            lblScreen.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            lblScreen.ForeColor = Color.DarkGray;
            lblScreen.Location = new Point(180, 155);
            lblScreen.Size = new Size(250, 25);
            lblScreen.Text = "════════ MÀN HÌNH ════════";
            lblScreen.TextAlign = ContentAlignment.MiddleCenter;

            // ==================== PANEL GHẾ ====================
            pnlSeats.BorderStyle = BorderStyle.FixedSingle;
            pnlSeats.Location = new Point(12, 185);
            pnlSeats.Size = new Size(600, 320);
            pnlSeats.AutoScroll = true;
            pnlSeats.BackColor = Color.WhiteSmoke;

            // ==================== CHÚ THÍCH GHẾ ====================
            lblLegend.AutoSize = true;
            lblLegend.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblLegend.Location = new Point(12, 515);
            lblLegend.Text = "Chú thích:";

            // Ghế trống - Trắng
            lblColorAvailable.BackColor = Color.White;
            lblColorAvailable.BorderStyle = BorderStyle.FixedSingle;
            lblColorAvailable.Location = new Point(85, 513);
            lblColorAvailable.Size = new Size(20, 20);

            lblTextAvailable.AutoSize = true;
            lblTextAvailable.Location = new Point(108, 515);
            lblTextAvailable.Text = "Trống";

            // Đang chọn - Xanh dương
            lblColorSelected.BackColor = Color.DodgerBlue;
            lblColorSelected.BorderStyle = BorderStyle.FixedSingle;
            lblColorSelected.Location = new Point(160, 513);
            lblColorSelected.Size = new Size(20, 20);

            lblTextSelected.AutoSize = true;
            lblTextSelected.Location = new Point(183, 515);
            lblTextSelected.Text = "Đang chọn";

            // Đã đặt - Đỏ
            lblColorBooked.BackColor = Color.Red;
            lblColorBooked.BorderStyle = BorderStyle.FixedSingle;
            lblColorBooked.Location = new Point(260, 513);
            lblColorBooked.Size = new Size(20, 20);

            lblTextBooked.AutoSize = true;
            lblTextBooked.Location = new Point(283, 515);
            lblTextBooked.Text = "Đã đặt";

            // VIP - Vàng
            lblColorVIP.BackColor = Color.Gold;
            lblColorVIP.BorderStyle = BorderStyle.FixedSingle;
            lblColorVIP.Location = new Point(340, 513);
            lblColorVIP.Size = new Size(20, 20);

            lblTextVIP.AutoSize = true;
            lblTextVIP.Location = new Point(363, 515);
            lblTextVIP.Text = "VIP";

            // Couple - Tím
            lblColorCouple.BackColor = Color.MediumOrchid;
            lblColorCouple.BorderStyle = BorderStyle.FixedSingle;
            lblColorCouple.Location = new Point(400, 513);
            lblColorCouple.Size = new Size(20, 20);

            lblTextCouple.AutoSize = true;
            lblTextCouple.Location = new Point(423, 515);
            lblTextCouple.Text = "Couple";

            // ==================== THÔNG TIN ĐẶT VÉ ====================
            grpBookingInfo.Font = new Font("Arial", 9F, FontStyle.Bold);
            grpBookingInfo.Location = new Point(630, 50);
            grpBookingInfo.Size = new Size(280, 260);
            grpBookingInfo.Text = "📋 Thông tin đặt vé";

            lblMovieInfo.AutoSize = true;
            lblMovieInfo.Font = new Font("Arial", 9F);
            lblMovieInfo.Location = new Point(10, 30);
            lblMovieInfo.Text = "Phim:";

            lblMovieValue.AutoSize = true;
            lblMovieValue.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblMovieValue.ForeColor = Color.DarkBlue;
            lblMovieValue.Location = new Point(80, 30);
            lblMovieValue.MaximumSize = new Size(180, 0);

            lblTimeInfo.AutoSize = true;
            lblTimeInfo.Font = new Font("Arial", 9F);
            lblTimeInfo.Location = new Point(10, 55);
            lblTimeInfo.Text = "Suất chiếu:";

            lblTimeValue.AutoSize = true;
            lblTimeValue.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTimeValue.Location = new Point(80, 55);

            lblRoomInfo.AutoSize = true;
            lblRoomInfo.Font = new Font("Arial", 9F);
            lblRoomInfo.Location = new Point(10, 80);
            lblRoomInfo.Text = "Phòng:";

            lblRoomValue.AutoSize = true;
            lblRoomValue.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblRoomValue.Location = new Point(80, 80);

            lblSeatsInfo.AutoSize = true;
            lblSeatsInfo.Font = new Font("Arial", 9F);
            lblSeatsInfo.Location = new Point(10, 105);
            lblSeatsInfo.Text = "Ghế:";

            lblSeatsValue.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblSeatsValue.ForeColor = Color.Green;
            lblSeatsValue.Location = new Point(80, 105);
            lblSeatsValue.Size = new Size(180, 40);
            lblSeatsValue.Text = "(Chưa chọn)";

            lblLine.BorderStyle = BorderStyle.Fixed3D;
            lblLine.Location = new Point(10, 150);
            lblLine.Size = new Size(255, 2);

            lblTicketPriceInfo.AutoSize = true;
            lblTicketPriceInfo.Font = new Font("Arial", 9F);
            lblTicketPriceInfo.Location = new Point(10, 160);
            lblTicketPriceInfo.Text = "Tiền vé:";

            lblTicketPrice.AutoSize = true;
            lblTicketPrice.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTicketPrice.Location = new Point(150, 160);
            lblTicketPrice.Text = "0 đ";

            lblFoodPriceInfo.AutoSize = true;
            lblFoodPriceInfo.Font = new Font("Arial", 9F);
            lblFoodPriceInfo.Location = new Point(10, 185);
            lblFoodPriceInfo.Text = "Tiền đồ ăn:";

            lblFoodPrice.AutoSize = true;
            lblFoodPrice.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblFoodPrice.Location = new Point(150, 185);
            lblFoodPrice.Text = "0 đ";

            lblLine2.BorderStyle = BorderStyle.Fixed3D;
            lblLine2.Location = new Point(10, 210);
            lblLine2.Size = new Size(255, 2);

            lblTotalPriceInfo.AutoSize = true;
            lblTotalPriceInfo.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblTotalPriceInfo.Location = new Point(10, 220);
            lblTotalPriceInfo.Text = "TỔNG CỘNG:";

            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotalPrice.ForeColor = Color.Red;
            lblTotalPrice.Location = new Point(130, 218);
            lblTotalPrice.Text = "0 đ";

            // Hidden - để tương thích code cũ
            lblPriceInfo.Visible = false;
            lblPriceValue.Visible = false;
            lblPriceValue.Text = "0 VNĐ";

            grpBookingInfo.Controls.Add(lblMovieInfo);
            grpBookingInfo.Controls.Add(lblMovieValue);
            grpBookingInfo.Controls.Add(lblTimeInfo);
            grpBookingInfo.Controls.Add(lblTimeValue);
            grpBookingInfo.Controls.Add(lblRoomInfo);
            grpBookingInfo.Controls.Add(lblRoomValue);
            grpBookingInfo.Controls.Add(lblSeatsInfo);
            grpBookingInfo.Controls.Add(lblSeatsValue);
            grpBookingInfo.Controls.Add(lblLine);
            grpBookingInfo.Controls.Add(lblTicketPriceInfo);
            grpBookingInfo.Controls.Add(lblTicketPrice);
            grpBookingInfo.Controls.Add(lblFoodPriceInfo);
            grpBookingInfo.Controls.Add(lblFoodPrice);
            grpBookingInfo.Controls.Add(lblLine2);
            grpBookingInfo.Controls.Add(lblTotalPriceInfo);
            grpBookingInfo.Controls.Add(lblTotalPrice);

            // ==================== PHẦN ĐỒ ĂN ====================
            grpFood.Font = new Font("Arial", 9F, FontStyle.Bold);
            grpFood.Location = new Point(630, 320);
            grpFood.Size = new Size(540, 230);
            grpFood.Text = "🍿 Đồ ăn & Thức uống";

            lblFoodCategory.AutoSize = true;
            lblFoodCategory.Font = new Font("Arial", 9F);
            lblFoodCategory.Location = new Point(10, 25);
            lblFoodCategory.Text = "Danh mục:";

            cboFoodCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFoodCategory.Font = new Font("Arial", 9F);
            cboFoodCategory.Location = new Point(80, 22);
            cboFoodCategory.Size = new Size(150, 23);
            cboFoodCategory.SelectedIndexChanged += cboFoodCategory_SelectedIndexChanged;

            dgvFoods.Location = new Point(10, 52);
            dgvFoods.Size = new Size(250, 130);
            dgvFoods.Font = new Font("Arial", 8F);
            dgvFoods.AllowUserToAddRows = false;
            dgvFoods.AllowUserToDeleteRows = false;
            dgvFoods.ReadOnly = true;
            dgvFoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoods.MultiSelect = false;
            dgvFoods.RowHeadersVisible = false;
            dgvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Arial", 9F);
            lblQuantity.Location = new Point(10, 192);
            lblQuantity.Text = "Số lượng:";

            nudQuantity.Location = new Point(80, 190);
            nudQuantity.Size = new Size(60, 23);
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 10;
            nudQuantity.Value = 1;

            btnAddFood.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnAddFood.Location = new Point(150, 188);
            btnAddFood.Size = new Size(110, 28);
            btnAddFood.Text = "➕ Thêm";
            btnAddFood.BackColor = Color.LightGreen;
            btnAddFood.Click += btnAddFood_Click;

            lblSelectedFoods.AutoSize = true;
            lblSelectedFoods.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblSelectedFoods.Location = new Point(275, 25);
            lblSelectedFoods.Text = "Đã chọn:";

            dgvSelectedFoods.Location = new Point(275, 52);
            dgvSelectedFoods.Size = new Size(250, 130);
            dgvSelectedFoods.Font = new Font("Arial", 8F);
            dgvSelectedFoods.AllowUserToAddRows = false;
            dgvSelectedFoods.AllowUserToDeleteRows = false;
            dgvSelectedFoods.ReadOnly = true;
            dgvSelectedFoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSelectedFoods.MultiSelect = false;
            dgvSelectedFoods.RowHeadersVisible = false;
            dgvSelectedFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnRemoveFood.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnRemoveFood.Location = new Point(400, 188);
            btnRemoveFood.Size = new Size(120, 28);
            btnRemoveFood.Text = "➖ Xóa món";
            btnRemoveFood.BackColor = Color.LightCoral;
            btnRemoveFood.Click += btnRemoveFood_Click;

            grpFood.Controls.Add(lblFoodCategory);
            grpFood.Controls.Add(cboFoodCategory);
            grpFood.Controls.Add(dgvFoods);
            grpFood.Controls.Add(lblQuantity);
            grpFood.Controls.Add(nudQuantity);
            grpFood.Controls.Add(btnAddFood);
            grpFood.Controls.Add(lblSelectedFoods);
            grpFood.Controls.Add(dgvSelectedFoods);
            grpFood.Controls.Add(btnRemoveFood);

            // ==================== BUTTONS ====================
            btnBooking.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnBooking.Location = new Point(630, 560);
            btnBooking.Size = new Size(140, 40);
            btnBooking.Text = "🎫 ĐẶT VÉ";
            btnBooking.BackColor = Color.Gold;
            btnBooking.Click += btnBooking_Click;

            btnClear.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnClear.Location = new Point(785, 560);
            btnClear.Size = new Size(100, 40);
            btnClear.Text = "🔄 Xóa chọn";
            btnClear.Click += btnClear_Click;

            btnClose.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnClose.Location = new Point(900, 560);
            btnClose.Size = new Size(100, 40);
            btnClose.Text = "❌ Đóng";
            btnClose.Click += btnClose_Click;

            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Location = new Point(12, 545);

            // ==================== FORM ====================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1184, 611);

            Controls.Add(lblTitle);
            Controls.Add(lblSelectMovie);
            Controls.Add(cboMovies);
            Controls.Add(lblSelectShowtime);
            Controls.Add(cboShowtimes);
            Controls.Add(lblShowtimeInfo);
            Controls.Add(lblScreen);
            Controls.Add(pnlSeats);
            Controls.Add(lblLegend);
            Controls.Add(lblColorAvailable);
            Controls.Add(lblTextAvailable);
            Controls.Add(lblColorSelected);
            Controls.Add(lblTextSelected);
            Controls.Add(lblColorBooked);
            Controls.Add(lblTextBooked);
            Controls.Add(lblColorVIP);
            Controls.Add(lblTextVIP);
            Controls.Add(lblColorCouple);
            Controls.Add(lblTextCouple);
            Controls.Add(grpBookingInfo);
            Controls.Add(grpFood);
            Controls.Add(btnBooking);
            Controls.Add(btnClear);
            Controls.Add(btnClose);
            Controls.Add(lblStatus);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đặt vé xem phim - Movie Ticket System";
            Load += frmBooking_Load;

            grpBookingInfo.ResumeLayout(false);
            grpBookingInfo.PerformLayout();
            grpFood.ResumeLayout(false);
            grpFood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoods).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedFoods).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSelectMovie;
        private ComboBox cboMovies;
        private Label lblSelectShowtime;
        private ComboBox cboShowtimes;
        private Label lblShowtimeInfo;
        private Label lblScreen;
        private Panel pnlSeats;

        // Chú thích
        private Label lblLegend;
        private Label lblColorAvailable;
        private Label lblTextAvailable;
        private Label lblColorSelected;
        private Label lblTextSelected;
        private Label lblColorBooked;
        private Label lblTextBooked;
        private Label lblColorVIP;
        private Label lblTextVIP;
        private Label lblColorCouple;
        private Label lblTextCouple;

        // Thông tin đặt vé
        private GroupBox grpBookingInfo;
        private Label lblMovieInfo;
        private Label lblMovieValue;
        private Label lblTimeInfo;
        private Label lblTimeValue;
        private Label lblRoomInfo;
        private Label lblRoomValue;
        private Label lblSeatsInfo;
        private Label lblSeatsValue;
        private Label lblLine;
        private Label lblTicketPriceInfo;
        private Label lblTicketPrice;
        private Label lblFoodPriceInfo;
        private Label lblFoodPrice;
        private Label lblLine2;
        private Label lblTotalPriceInfo;
        private Label lblTotalPrice;
        private Label lblPriceInfo;
        private Label lblPriceValue;

        // Phần đồ ăn
        private GroupBox grpFood;
        private Label lblFoodCategory;
        private ComboBox cboFoodCategory;
        private DataGridView dgvFoods;
        private Label lblQuantity;
        private NumericUpDown nudQuantity;
        private Button btnAddFood;
        private Label lblSelectedFoods;
        private DataGridView dgvSelectedFoods;
        private Button btnRemoveFood;

        // Buttons
        private Button btnBooking;
        private Button btnClear;
        private Button btnClose;
        private Label lblStatus;
    }
}
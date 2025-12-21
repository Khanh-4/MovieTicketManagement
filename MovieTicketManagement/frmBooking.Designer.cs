namespace MovieTicketManagement
{
    partial class frmBooking
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
            lblTitle = new Label();
            lblSelectMovie = new Label();
            cboMovies = new ComboBox();
            lblSelectShowtime = new Label();
            cboShowtimes = new ComboBox();
            lblShowtimeInfo = new Label();
            lblScreen = new Label();
            pnlSeats = new Panel();
            lblLegend = new Label();
            lblTextAvailable = new Label();
            lblTextSelected = new Label();
            lblTextVIP = new Label();
            grpBookingInfo = new GroupBox();
            lblPriceValue = new Label();
            lblLine = new Label();
            lblPriceInfo = new Label();
            lblSeatsValue = new Label();
            lblSeatsInfo = new Label();
            lblRoomValue = new Label();
            lblRoomInfo = new Label();
            lblTimeValue = new Label();
            lblTimeInfo = new Label();
            lblMovieValue = new Label();
            lblMovieInfo = new Label();
            lblColorAvailable = new Label();
            lblColorSelected = new Label();
            lblColorVIP = new Label();
            lblColorBooked = new Label();
            lblTextBooked = new Label();
            btnBooking = new Button();
            btnClear = new Button();
            btnClose = new Button();
            lblStatus = new Label();
            grpBookingInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(363, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐẶT VÉ XEM PHIM";
            // 
            // lblSelectMovie
            // 
            lblSelectMovie.AutoSize = true;
            lblSelectMovie.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectMovie.Location = new Point(12, 72);
            lblSelectMovie.Name = "lblSelectMovie";
            lblSelectMovie.Size = new Size(70, 15);
            lblSelectMovie.TabIndex = 1;
            lblSelectMovie.Text = "Chọn phim:";
            // 
            // cboMovies
            // 
            cboMovies.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMovies.FormattingEnabled = true;
            cboMovies.Location = new Point(88, 64);
            cboMovies.Name = "cboMovies";
            cboMovies.Size = new Size(274, 23);
            cboMovies.TabIndex = 2;
            cboMovies.SelectedIndexChanged += cboMovies_SelectedIndexChanged;
            // 
            // lblSelectShowtime
            // 
            lblSelectShowtime.AutoSize = true;
            lblSelectShowtime.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectShowtime.Location = new Point(12, 115);
            lblSelectShowtime.Name = "lblSelectShowtime";
            lblSelectShowtime.Size = new Size(101, 15);
            lblSelectShowtime.TabIndex = 3;
            lblSelectShowtime.Text = "Chọn suất chiếu:";
            // 
            // cboShowtimes
            // 
            cboShowtimes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShowtimes.FormattingEnabled = true;
            cboShowtimes.Location = new Point(119, 107);
            cboShowtimes.Name = "cboShowtimes";
            cboShowtimes.Size = new Size(243, 23);
            cboShowtimes.TabIndex = 4;
            cboShowtimes.SelectedIndexChanged += cboShowtimes_SelectedIndexChanged;
            // 
            // lblShowtimeInfo
            // 
            lblShowtimeInfo.AutoSize = true;
            lblShowtimeInfo.ForeColor = Color.Blue;
            lblShowtimeInfo.Location = new Point(12, 151);
            lblShowtimeInfo.Name = "lblShowtimeInfo";
            lblShowtimeInfo.Size = new Size(0, 15);
            lblShowtimeInfo.TabIndex = 5;
            // 
            // lblScreen
            // 
            lblScreen.AutoSize = true;
            lblScreen.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScreen.Location = new Point(229, 192);
            lblScreen.Name = "lblScreen";
            lblScreen.Size = new Size(156, 18);
            lblScreen.TabIndex = 6;
            lblScreen.Text = "═══ MÀN HÌNH ═══";
            lblScreen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSeats
            // 
            pnlSeats.BorderStyle = BorderStyle.FixedSingle;
            pnlSeats.Location = new Point(12, 213);
            pnlSeats.Name = "pnlSeats";
            pnlSeats.Size = new Size(600, 350);
            pnlSeats.TabIndex = 7;
            // 
            // lblLegend
            // 
            lblLegend.AutoSize = true;
            lblLegend.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLegend.Location = new Point(12, 566);
            lblLegend.Name = "lblLegend";
            lblLegend.Size = new Size(63, 15);
            lblLegend.TabIndex = 8;
            lblLegend.Text = "Chú thích:";
            // 
            // lblTextAvailable
            // 
            lblTextAvailable.AutoSize = true;
            lblTextAvailable.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            lblTextAvailable.Location = new Point(57, 598);
            lblTextAvailable.Name = "lblTextAvailable";
            lblTextAvailable.Size = new Size(43, 16);
            lblTextAvailable.TabIndex = 9;
            lblTextAvailable.Text = "Trống";
            // 
            // lblTextSelected
            // 
            lblTextSelected.AutoSize = true;
            lblTextSelected.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            lblTextSelected.Location = new Point(140, 598);
            lblTextSelected.Name = "lblTextSelected";
            lblTextSelected.Size = new Size(75, 16);
            lblTextSelected.TabIndex = 10;
            lblTextSelected.Text = "Đang chọn";
            // 
            // lblTextVIP
            // 
            lblTextVIP.AutoSize = true;
            lblTextVIP.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            lblTextVIP.Location = new Point(351, 598);
            lblTextVIP.Name = "lblTextVIP";
            lblTextVIP.Size = new Size(29, 16);
            lblTextVIP.TabIndex = 12;
            lblTextVIP.Text = "VIP";
            // 
            // grpBookingInfo
            // 
            grpBookingInfo.Controls.Add(lblPriceValue);
            grpBookingInfo.Controls.Add(lblLine);
            grpBookingInfo.Controls.Add(lblPriceInfo);
            grpBookingInfo.Controls.Add(lblSeatsValue);
            grpBookingInfo.Controls.Add(lblSeatsInfo);
            grpBookingInfo.Controls.Add(lblRoomValue);
            grpBookingInfo.Controls.Add(lblRoomInfo);
            grpBookingInfo.Controls.Add(lblTimeValue);
            grpBookingInfo.Controls.Add(lblTimeInfo);
            grpBookingInfo.Controls.Add(lblMovieValue);
            grpBookingInfo.Controls.Add(lblMovieInfo);
            grpBookingInfo.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpBookingInfo.Location = new Point(662, 213);
            grpBookingInfo.Name = "grpBookingInfo";
            grpBookingInfo.Size = new Size(310, 269);
            grpBookingInfo.TabIndex = 13;
            grpBookingInfo.TabStop = false;
            grpBookingInfo.Text = "Thông tin đặt vé";
            // 
            // lblPriceValue
            // 
            lblPriceValue.AutoSize = true;
            lblPriceValue.ForeColor = Color.Red;
            lblPriceValue.Location = new Point(74, 205);
            lblPriceValue.Name = "lblPriceValue";
            lblPriceValue.Size = new Size(42, 15);
            lblPriceValue.TabIndex = 11;
            lblPriceValue.Text = "0 VNĐ";
            // 
            // lblLine
            // 
            lblLine.AutoSize = true;
            lblLine.Location = new Point(82, 174);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(160, 15);
            lblLine.TabIndex = 10;
            lblLine.Text = "─────────────────";
            // 
            // lblPriceInfo
            // 
            lblPriceInfo.AutoSize = true;
            lblPriceInfo.Location = new Point(6, 205);
            lblPriceInfo.Name = "lblPriceInfo";
            lblPriceInfo.Size = new Size(62, 15);
            lblPriceInfo.TabIndex = 8;
            lblPriceInfo.Text = "Tổng tiền:";
            // 
            // lblSeatsValue
            // 
            lblSeatsValue.AutoSize = true;
            lblSeatsValue.ForeColor = Color.Blue;
            lblSeatsValue.Location = new Point(92, 135);
            lblSeatsValue.Name = "lblSeatsValue";
            lblSeatsValue.Size = new Size(0, 15);
            lblSeatsValue.TabIndex = 7;
            // 
            // lblSeatsInfo
            // 
            lblSeatsInfo.AutoSize = true;
            lblSeatsInfo.Location = new Point(6, 135);
            lblSeatsInfo.Name = "lblSeatsInfo";
            lblSeatsInfo.Size = new Size(80, 15);
            lblSeatsInfo.TabIndex = 6;
            lblSeatsInfo.Text = "Ghế đã chọn:";
            // 
            // lblRoomValue
            // 
            lblRoomValue.AutoSize = true;
            lblRoomValue.Location = new Point(58, 105);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(0, 15);
            lblRoomValue.TabIndex = 5;
            // 
            // lblRoomInfo
            // 
            lblRoomInfo.AutoSize = true;
            lblRoomInfo.Location = new Point(6, 105);
            lblRoomInfo.Name = "lblRoomInfo";
            lblRoomInfo.Size = new Size(46, 15);
            lblRoomInfo.TabIndex = 4;
            lblRoomInfo.Text = "Phòng:";
            // 
            // lblTimeValue
            // 
            lblTimeValue.AutoSize = true;
            lblTimeValue.Location = new Point(82, 76);
            lblTimeValue.Name = "lblTimeValue";
            lblTimeValue.Size = new Size(0, 15);
            lblTimeValue.TabIndex = 3;
            // 
            // lblTimeInfo
            // 
            lblTimeInfo.AutoSize = true;
            lblTimeInfo.Location = new Point(6, 76);
            lblTimeInfo.Name = "lblTimeInfo";
            lblTimeInfo.Size = new Size(70, 15);
            lblTimeInfo.TabIndex = 2;
            lblTimeInfo.Text = "Suất chiếu:";
            // 
            // lblMovieValue
            // 
            lblMovieValue.AutoSize = true;
            lblMovieValue.Location = new Point(51, 47);
            lblMovieValue.Name = "lblMovieValue";
            lblMovieValue.Size = new Size(0, 15);
            lblMovieValue.TabIndex = 1;
            // 
            // lblMovieInfo
            // 
            lblMovieInfo.AutoSize = true;
            lblMovieInfo.Location = new Point(6, 47);
            lblMovieInfo.Name = "lblMovieInfo";
            lblMovieInfo.Size = new Size(39, 15);
            lblMovieInfo.TabIndex = 0;
            lblMovieInfo.Text = "Phim:";
            // 
            // lblColorAvailable
            // 
            lblColorAvailable.BackColor = Color.White;
            lblColorAvailable.BorderStyle = BorderStyle.FixedSingle;
            lblColorAvailable.Location = new Point(35, 596);
            lblColorAvailable.Name = "lblColorAvailable";
            lblColorAvailable.Size = new Size(20, 20);
            lblColorAvailable.TabIndex = 16;
            // 
            // lblColorSelected
            // 
            lblColorSelected.BackColor = Color.DodgerBlue;
            lblColorSelected.BorderStyle = BorderStyle.FixedSingle;
            lblColorSelected.Location = new Point(118, 596);
            lblColorSelected.Name = "lblColorSelected";
            lblColorSelected.Size = new Size(20, 20);
            lblColorSelected.TabIndex = 17;
            // 
            // lblColorVIP
            // 
            lblColorVIP.BackColor = Color.Gold;
            lblColorVIP.BorderStyle = BorderStyle.FixedSingle;
            lblColorVIP.Location = new Point(329, 596);
            lblColorVIP.Name = "lblColorVIP";
            lblColorVIP.Size = new Size(20, 20);
            lblColorVIP.TabIndex = 19;
            // 
            // lblColorBooked
            // 
            lblColorBooked.BackColor = Color.Red;
            lblColorBooked.BorderStyle = BorderStyle.FixedSingle;
            lblColorBooked.Location = new Point(237, 596);
            lblColorBooked.Name = "lblColorBooked";
            lblColorBooked.Size = new Size(20, 20);
            lblColorBooked.TabIndex = 21;
            // 
            // lblTextBooked
            // 
            lblTextBooked.AutoSize = true;
            lblTextBooked.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            lblTextBooked.Location = new Point(259, 598);
            lblTextBooked.Name = "lblTextBooked";
            lblTextBooked.Size = new Size(48, 16);
            lblTextBooked.TabIndex = 20;
            lblTextBooked.Text = "Đã đặt";
            // 
            // btnBooking
            // 
            btnBooking.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBooking.Location = new Point(673, 503);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(100, 30);
            btnBooking.TabIndex = 22;
            btnBooking.Text = "Đặt vé";
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(673, 540);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 23;
            btnClear.Text = "Xóa chọn";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(754, 540);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 24;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(12, 637);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 25;
            // 
            // frmBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(984, 661);
            Controls.Add(lblStatus);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnBooking);
            Controls.Add(lblColorBooked);
            Controls.Add(lblTextBooked);
            Controls.Add(lblColorVIP);
            Controls.Add(lblColorSelected);
            Controls.Add(lblColorAvailable);
            Controls.Add(grpBookingInfo);
            Controls.Add(lblTextVIP);
            Controls.Add(lblTextSelected);
            Controls.Add(lblTextAvailable);
            Controls.Add(lblLegend);
            Controls.Add(pnlSeats);
            Controls.Add(lblScreen);
            Controls.Add(lblShowtimeInfo);
            Controls.Add(cboShowtimes);
            Controls.Add(lblSelectShowtime);
            Controls.Add(cboMovies);
            Controls.Add(lblSelectMovie);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đặt vé xem phim";
            Load += frmBooking_Load;
            grpBookingInfo.ResumeLayout(false);
            grpBookingInfo.PerformLayout();
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
        private Label lblLegend;
        private Label lblTextAvailable;
        private Label lblTextSelected;
        private Label lblTextVIP;
        private GroupBox grpBookingInfo;
        private Label lblRoomInfo;
        private Label lblTimeValue;
        private Label lblTimeInfo;
        private Label lblMovieValue;
        private Label lblMovieInfo;
        private Label lblPriceInfo;
        private Label lblSeatsValue;
        private Label lblSeatsInfo;
        private Label lblRoomValue;
        private Label lblPriceValue;
        private Label lblLine;
        private Label lblColorAvailable;
        private Label lblColorSelected;
        private Label lblColorVIP;
        private Label lblColorBooked;
        private Label lblTextBooked;
        private Button btnBooking;
        private Button btnClear;
        private Button btnClose;
        private Label lblStatus;
    }
}
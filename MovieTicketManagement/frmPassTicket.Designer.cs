using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmPassTicket
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
            grpBookings = new GroupBox();
            dgvBookings = new DataGridView();
            lblStatus = new Label();
            btnRefresh = new Button();

            grpCalculation = new GroupBox();
            lblMovie = new Label();
            lblMovieValue = new Label();
            lblShowtime = new Label();
            lblShowtimeValue = new Label();
            lblRoom = new Label();
            lblRoomValue = new Label();
            lblSeat = new Label();
            lblSeatValue = new Label();
            lblLine1 = new Label();
            lblOriginalPrice = new Label();
            lblOriginalPriceValue = new Label();
            lblDaysRemaining = new Label();
            lblDaysRemainingValue = new Label();
            lblRefundPercent = new Label();
            lblRefundPercentValue = new Label();
            lblLine2 = new Label();
            lblRefundAmount = new Label();
            lblRefundAmountValue = new Label();

            grpRefundMethod = new GroupBox();
            rdoWallet = new RadioButton();
            rdoPoints = new RadioButton();
            rdoBoth = new RadioButton();

            lblNotes = new Label();
            txtNotes = new TextBox();

            grpWallet = new GroupBox();
            lblWalletTitle = new Label();
            lblWalletBalance = new Label();
            btnViewWallet = new Button();

            btnPassTicket = new Button();
            btnClose = new Button();

            grpBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            grpCalculation.SuspendLayout();
            grpRefundMethod.SuspendLayout();
            grpWallet.SuspendLayout();
            SuspendLayout();

            // ==================== TITLE ====================
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(280, 15);
            lblTitle.Text = "🎫 PASS VÉ CHO RẠP";

            // ==================== DANH SÁCH VÉ ====================
            grpBookings.Text = "📋 Danh sách vé có thể pass";
            grpBookings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpBookings.Location = new Point(15, 55);
            grpBookings.Size = new Size(450, 280);

            dgvBookings.Location = new Point(10, 25);
            dgvBookings.Size = new Size(430, 210);
            dgvBookings.Font = new Font("Segoe UI", 9F);
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.ReadOnly = true;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect = false;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.SelectionChanged += dgvBookings_SelectionChanged;

            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(10, 245);
            lblStatus.Size = new Size(300, 20);
            lblStatus.ForeColor = Color.Blue;

            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(350, 242);
            btnRefresh.Size = new Size(90, 28);
            btnRefresh.Click += btnRefresh_Click;

            grpBookings.Controls.Add(dgvBookings);
            grpBookings.Controls.Add(lblStatus);
            grpBookings.Controls.Add(btnRefresh);

            // ==================== TÍNH TOÁN HOÀN TIỀN ====================
            grpCalculation.Text = "💰 Tính toán hoàn tiền";
            grpCalculation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpCalculation.Location = new Point(480, 55);
            grpCalculation.Size = new Size(300, 280);
            grpCalculation.Enabled = false;

            int y = 25;
            int valueX = 115;

            lblMovie.Text = "Phim:";
            lblMovie.Font = new Font("Segoe UI", 9F);
            lblMovie.Location = new Point(10, y);
            lblMovie.Size = new Size(100, 20);

            lblMovieValue.Text = "-";
            lblMovieValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMovieValue.ForeColor = Color.DarkRed;
            lblMovieValue.Location = new Point(valueX, y);
            lblMovieValue.Size = new Size(175, 20);
            y += 25;

            lblShowtime.Text = "Suất chiếu:";
            lblShowtime.Font = new Font("Segoe UI", 9F);
            lblShowtime.Location = new Point(10, y);

            lblShowtimeValue.Text = "-";
            lblShowtimeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShowtimeValue.Location = new Point(valueX, y);
            lblShowtimeValue.Size = new Size(175, 20);
            y += 25;

            lblRoom.Text = "Phòng:";
            lblRoom.Font = new Font("Segoe UI", 9F);
            lblRoom.Location = new Point(10, y);

            lblRoomValue.Text = "-";
            lblRoomValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoomValue.Location = new Point(valueX, y);
            lblRoomValue.Size = new Size(175, 20);
            y += 25;

            lblSeat.Text = "Ghế:";
            lblSeat.Font = new Font("Segoe UI", 9F);
            lblSeat.Location = new Point(10, y);

            lblSeatValue.Text = "-";
            lblSeatValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSeatValue.ForeColor = Color.Blue;
            lblSeatValue.Location = new Point(valueX, y);
            lblSeatValue.Size = new Size(175, 20);
            y += 30;

            lblLine1.Text = "─────────────────────────────";
            lblLine1.ForeColor = Color.Gray;
            lblLine1.Location = new Point(10, y);
            lblLine1.Size = new Size(280, 15);
            y += 20;

            lblOriginalPrice.Text = "Giá gốc:";
            lblOriginalPrice.Font = new Font("Segoe UI", 9F);
            lblOriginalPrice.Location = new Point(10, y);

            lblOriginalPriceValue.Text = "-";
            lblOriginalPriceValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOriginalPriceValue.Location = new Point(valueX, y);
            lblOriginalPriceValue.Size = new Size(175, 20);
            y += 25;

            lblDaysRemaining.Text = "Còn lại:";
            lblDaysRemaining.Font = new Font("Segoe UI", 9F);
            lblDaysRemaining.Location = new Point(10, y);

            lblDaysRemainingValue.Text = "-";
            lblDaysRemainingValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDaysRemainingValue.ForeColor = Color.Orange;
            lblDaysRemainingValue.Location = new Point(valueX, y);
            lblDaysRemainingValue.Size = new Size(175, 20);
            y += 25;

            lblRefundPercent.Text = "Mức hoàn:";
            lblRefundPercent.Font = new Font("Segoe UI", 9F);
            lblRefundPercent.Location = new Point(10, y);

            lblRefundPercentValue.Text = "-";
            lblRefundPercentValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRefundPercentValue.Location = new Point(valueX, y);
            lblRefundPercentValue.Size = new Size(175, 20);
            y += 30;

            lblLine2.Text = "═════════════════════════════";
            lblLine2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLine2.Location = new Point(10, y);
            lblLine2.Size = new Size(280, 15);
            y += 20;

            lblRefundAmount.Text = "HOÀN TIỀN:";
            lblRefundAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRefundAmount.Location = new Point(10, y);

            lblRefundAmountValue.Text = "-";
            lblRefundAmountValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRefundAmountValue.ForeColor = Color.Green;
            lblRefundAmountValue.Location = new Point(valueX, y);
            lblRefundAmountValue.Size = new Size(175, 25);

            grpCalculation.Controls.Add(lblMovie);
            grpCalculation.Controls.Add(lblMovieValue);
            grpCalculation.Controls.Add(lblShowtime);
            grpCalculation.Controls.Add(lblShowtimeValue);
            grpCalculation.Controls.Add(lblRoom);
            grpCalculation.Controls.Add(lblRoomValue);
            grpCalculation.Controls.Add(lblSeat);
            grpCalculation.Controls.Add(lblSeatValue);
            grpCalculation.Controls.Add(lblLine1);
            grpCalculation.Controls.Add(lblOriginalPrice);
            grpCalculation.Controls.Add(lblOriginalPriceValue);
            grpCalculation.Controls.Add(lblDaysRemaining);
            grpCalculation.Controls.Add(lblDaysRemainingValue);
            grpCalculation.Controls.Add(lblRefundPercent);
            grpCalculation.Controls.Add(lblRefundPercentValue);
            grpCalculation.Controls.Add(lblLine2);
            grpCalculation.Controls.Add(lblRefundAmount);
            grpCalculation.Controls.Add(lblRefundAmountValue);

            // ==================== PHƯƠNG THỨC HOÀN TIỀN ====================
            grpRefundMethod.Text = "💳 Hoàn tiền vào";
            grpRefundMethod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpRefundMethod.Location = new Point(15, 345);
            grpRefundMethod.Size = new Size(250, 100);

            rdoWallet.Text = "Ví tiền (dùng mua vé sau)";
            rdoWallet.Font = new Font("Segoe UI", 9F);
            rdoWallet.Location = new Point(15, 25);
            rdoWallet.Size = new Size(220, 22);
            rdoWallet.Checked = true;

            rdoPoints.Text = "Điểm tích lũy";
            rdoPoints.Font = new Font("Segoe UI", 9F);
            rdoPoints.Location = new Point(15, 50);
            rdoPoints.Size = new Size(220, 22);

            rdoBoth.Text = "Cả hai (Ví + Điểm)";
            rdoBoth.Font = new Font("Segoe UI", 9F);
            rdoBoth.Location = new Point(15, 75);
            rdoBoth.Size = new Size(220, 22);

            grpRefundMethod.Controls.Add(rdoWallet);
            grpRefundMethod.Controls.Add(rdoPoints);
            grpRefundMethod.Controls.Add(rdoBoth);

            // ==================== GHI CHÚ ====================
            lblNotes.Text = "📝 Ghi chú (tùy chọn):";
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.Location = new Point(280, 345);
            lblNotes.Size = new Size(150, 20);

            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.Location = new Point(280, 368);
            txtNotes.Size = new Size(185, 70);
            txtNotes.Multiline = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;

            // ==================== VÍ TIỀN ====================
            grpWallet.Text = "💰 Ví của tôi";
            grpWallet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpWallet.Location = new Point(480, 345);
            grpWallet.Size = new Size(300, 100);

            lblWalletTitle.Text = "Số dư hiện tại:";
            lblWalletTitle.Font = new Font("Segoe UI", 9F);
            lblWalletTitle.Location = new Point(15, 30);
            lblWalletTitle.Size = new Size(100, 20);

            lblWalletBalance.Text = "0 đ";
            lblWalletBalance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWalletBalance.ForeColor = Color.Green;
            lblWalletBalance.Location = new Point(120, 25);
            lblWalletBalance.Size = new Size(165, 30);

            btnViewWallet.Text = "📋 Xem chi tiết ví";
            btnViewWallet.Font = new Font("Segoe UI", 9F);
            btnViewWallet.Location = new Point(15, 60);
            btnViewWallet.Size = new Size(270, 30);
            btnViewWallet.Click += btnViewWallet_Click;

            grpWallet.Controls.Add(lblWalletTitle);
            grpWallet.Controls.Add(lblWalletBalance);
            grpWallet.Controls.Add(btnViewWallet);

            // ==================== BUTTONS ====================
            btnPassTicket.Text = "✅ XÁC NHẬN PASS VÉ";
            btnPassTicket.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPassTicket.BackColor = Color.MediumSeaGreen;
            btnPassTicket.ForeColor = Color.White;
            btnPassTicket.FlatStyle = FlatStyle.Flat;
            btnPassTicket.Location = new Point(480, 460);
            btnPassTicket.Size = new Size(180, 40);
            btnPassTicket.Enabled = false;
            btnPassTicket.Click += btnPassTicket_Click;

            btnClose.Text = "❌ Đóng";
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(680, 460);
            btnClose.Size = new Size(100, 40);
            btnClose.Click += btnClose_Click;

            // ==================== FORM ====================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 515);
            Controls.Add(lblTitle);
            Controls.Add(grpBookings);
            Controls.Add(grpCalculation);
            Controls.Add(grpRefundMethod);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(grpWallet);
            Controls.Add(btnPassTicket);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pass vé - Movie Ticket System";
            Load += frmPassTicket_Load;

            grpBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            grpCalculation.ResumeLayout(false);
            grpRefundMethod.ResumeLayout(false);
            grpWallet.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpBookings;
        private DataGridView dgvBookings;
        private Label lblStatus;
        private Button btnRefresh;

        private GroupBox grpCalculation;
        private Label lblMovie;
        private Label lblMovieValue;
        private Label lblShowtime;
        private Label lblShowtimeValue;
        private Label lblRoom;
        private Label lblRoomValue;
        private Label lblSeat;
        private Label lblSeatValue;
        private Label lblLine1;
        private Label lblOriginalPrice;
        private Label lblOriginalPriceValue;
        private Label lblDaysRemaining;
        private Label lblDaysRemainingValue;
        private Label lblRefundPercent;
        private Label lblRefundPercentValue;
        private Label lblLine2;
        private Label lblRefundAmount;
        private Label lblRefundAmountValue;

        private GroupBox grpRefundMethod;
        private RadioButton rdoWallet;
        private RadioButton rdoPoints;
        private RadioButton rdoBoth;

        private Label lblNotes;
        private TextBox txtNotes;

        private GroupBox grpWallet;
        private Label lblWalletTitle;
        private Label lblWalletBalance;
        private Button btnViewWallet;

        private Button btnPassTicket;
        private Button btnClose;
    }
}
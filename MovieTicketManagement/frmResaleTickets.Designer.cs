using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmResaleTickets
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
            lblSubtitle = new Label();
            grpResales = new GroupBox();
            dgvResales = new DataGridView();
            lblStatus = new Label();
            btnRefresh = new Button();

            grpDetail = new GroupBox();
            lblMovie = new Label();
            lblMovieValue = new Label();
            lblShowtime = new Label();
            lblShowtimeValue = new Label();
            lblRoom = new Label();
            lblRoomValue = new Label();
            lblSeat = new Label();
            lblSeatValue = new Label();
            lblSeller = new Label();
            lblSellerValue = new Label();
            lblTimeRemaining = new Label();
            lblTimeRemainingValue = new Label();
            lblLine1 = new Label();
            lblOriginalPrice = new Label();
            lblOriginalPriceValue = new Label();
            lblResalePrice = new Label();
            lblResalePriceValue = new Label();
            lblDiscount = new Label();
            lblDiscountValue = new Label();

            grpPayment = new GroupBox();
            rdoWallet = new RadioButton();
            rdoCash = new RadioButton();

            grpWallet = new GroupBox();
            lblWalletTitle = new Label();
            lblWalletBalance = new Label();
            btnViewWallet = new Button();

            btnBuyTicket = new Button();
            btnClose = new Button();

            grpResales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResales).BeginInit();
            grpDetail.SuspendLayout();
            grpPayment.SuspendLayout();
            grpWallet.SuspendLayout();
            SuspendLayout();

            // ==================== TITLE ====================
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(260, 12);
            lblTitle.Text = "🏷️ VÉ PASS - GIÁ ƯU ĐÃI";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(230, 45);
            lblSubtitle.Text = "Mua vé từ khách hàng khác với giá GIẢM 15%!";

            // ==================== DANH SÁCH VÉ PASS ====================
            grpResales.Text = "📋 Danh sách vé pass đang bán";
            grpResales.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpResales.Location = new Point(15, 75);
            grpResales.Size = new Size(550, 300);

            dgvResales.Location = new Point(10, 25);
            dgvResales.Size = new Size(530, 230);
            dgvResales.Font = new Font("Segoe UI", 9F);
            dgvResales.AllowUserToAddRows = false;
            dgvResales.AllowUserToDeleteRows = false;
            dgvResales.ReadOnly = true;
            dgvResales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResales.MultiSelect = false;
            dgvResales.RowHeadersVisible = false;
            dgvResales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResales.SelectionChanged += dgvResales_SelectionChanged;

            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(10, 265);
            lblStatus.Size = new Size(350, 20);
            lblStatus.ForeColor = Color.Blue;

            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(450, 262);
            btnRefresh.Size = new Size(90, 28);
            btnRefresh.Click += btnRefresh_Click;

            grpResales.Controls.Add(dgvResales);
            grpResales.Controls.Add(lblStatus);
            grpResales.Controls.Add(btnRefresh);

            // ==================== CHI TIẾT VÉ ====================
            grpDetail.Text = "🎫 Chi tiết vé đã chọn";
            grpDetail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpDetail.Location = new Point(580, 75);
            grpDetail.Size = new Size(280, 300);
            grpDetail.Enabled = false;

            int y = 25;
            int valueX = 100;

            lblMovie.Text = "Phim:";
            lblMovie.Font = new Font("Segoe UI", 9F);
            lblMovie.Location = new Point(10, y);

            lblMovieValue.Text = "-";
            lblMovieValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMovieValue.ForeColor = Color.DarkRed;
            lblMovieValue.Location = new Point(valueX, y);
            lblMovieValue.Size = new Size(170, 20);
            y += 25;

            lblShowtime.Text = "Suất chiếu:";
            lblShowtime.Font = new Font("Segoe UI", 9F);
            lblShowtime.Location = new Point(10, y);

            lblShowtimeValue.Text = "-";
            lblShowtimeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShowtimeValue.Location = new Point(valueX, y);
            lblShowtimeValue.Size = new Size(170, 20);
            y += 25;

            lblRoom.Text = "Phòng:";
            lblRoom.Font = new Font("Segoe UI", 9F);
            lblRoom.Location = new Point(10, y);

            lblRoomValue.Text = "-";
            lblRoomValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoomValue.Location = new Point(valueX, y);
            lblRoomValue.Size = new Size(170, 20);
            y += 25;

            lblSeat.Text = "Ghế:";
            lblSeat.Font = new Font("Segoe UI", 9F);
            lblSeat.Location = new Point(10, y);

            lblSeatValue.Text = "-";
            lblSeatValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSeatValue.ForeColor = Color.Blue;
            lblSeatValue.Location = new Point(valueX, y);
            lblSeatValue.Size = new Size(170, 20);
            y += 25;

            lblSeller.Text = "Người bán:";
            lblSeller.Font = new Font("Segoe UI", 9F);
            lblSeller.Location = new Point(10, y);

            lblSellerValue.Text = "-";
            lblSellerValue.Font = new Font("Segoe UI", 9F);
            lblSellerValue.Location = new Point(valueX, y);
            lblSellerValue.Size = new Size(170, 20);
            y += 25;

            lblTimeRemaining.Text = "Còn lại:";
            lblTimeRemaining.Font = new Font("Segoe UI", 9F);
            lblTimeRemaining.Location = new Point(10, y);

            lblTimeRemainingValue.Text = "-";
            lblTimeRemainingValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimeRemainingValue.ForeColor = Color.Orange;
            lblTimeRemainingValue.Location = new Point(valueX, y);
            lblTimeRemainingValue.Size = new Size(170, 20);
            y += 30;

            lblLine1.Text = "═══════════════════════════";
            lblLine1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLine1.Location = new Point(10, y);
            lblLine1.Size = new Size(260, 15);
            y += 20;

            lblOriginalPrice.Text = "Giá gốc:";
            lblOriginalPrice.Font = new Font("Segoe UI", 9F);
            lblOriginalPrice.Location = new Point(10, y);

            lblOriginalPriceValue.Text = "-";
            lblOriginalPriceValue.Font = new Font("Segoe UI", 9F);
            lblOriginalPriceValue.ForeColor = Color.Gray;
            lblOriginalPriceValue.Location = new Point(valueX, y);
            lblOriginalPriceValue.Size = new Size(170, 20);
            y += 25;

            lblResalePrice.Text = "Giá pass:";
            lblResalePrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResalePrice.Location = new Point(10, y);

            lblResalePriceValue.Text = "-";
            lblResalePriceValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResalePriceValue.ForeColor = Color.Green;
            lblResalePriceValue.Location = new Point(valueX, y);
            lblResalePriceValue.Size = new Size(100, 25);

            lblDiscount.Text = "";
            lblDiscount.Font = new Font("Segoe UI", 9F);
            lblDiscount.Location = new Point(200, y + 3);

            lblDiscountValue.Text = "";
            lblDiscountValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiscountValue.ForeColor = Color.Red;
            lblDiscountValue.Location = new Point(200, y + 3);
            lblDiscountValue.Size = new Size(60, 20);

            grpDetail.Controls.Add(lblMovie);
            grpDetail.Controls.Add(lblMovieValue);
            grpDetail.Controls.Add(lblShowtime);
            grpDetail.Controls.Add(lblShowtimeValue);
            grpDetail.Controls.Add(lblRoom);
            grpDetail.Controls.Add(lblRoomValue);
            grpDetail.Controls.Add(lblSeat);
            grpDetail.Controls.Add(lblSeatValue);
            grpDetail.Controls.Add(lblSeller);
            grpDetail.Controls.Add(lblSellerValue);
            grpDetail.Controls.Add(lblTimeRemaining);
            grpDetail.Controls.Add(lblTimeRemainingValue);
            grpDetail.Controls.Add(lblLine1);
            grpDetail.Controls.Add(lblOriginalPrice);
            grpDetail.Controls.Add(lblOriginalPriceValue);
            grpDetail.Controls.Add(lblResalePrice);
            grpDetail.Controls.Add(lblResalePriceValue);
            grpDetail.Controls.Add(lblDiscount);
            grpDetail.Controls.Add(lblDiscountValue);

            // ==================== PHƯƠNG THỨC THANH TOÁN ====================
            grpPayment.Text = "💳 Phương thức thanh toán";
            grpPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpPayment.Location = new Point(15, 385);
            grpPayment.Size = new Size(280, 80);

            rdoWallet.Text = "Ví tiền";
            rdoWallet.Font = new Font("Segoe UI", 9F);
            rdoWallet.Location = new Point(15, 25);
            rdoWallet.Size = new Size(120, 22);
            rdoWallet.Checked = true;

            rdoCash.Text = "Tiền mặt";
            rdoCash.Font = new Font("Segoe UI", 9F);
            rdoCash.Location = new Point(15, 50);
            rdoCash.Size = new Size(120, 22);

            grpPayment.Controls.Add(rdoWallet);
            grpPayment.Controls.Add(rdoCash);

            // ==================== VÍ TIỀN ====================
            grpWallet.Text = "💰 Ví của tôi";
            grpWallet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpWallet.Location = new Point(310, 385);
            grpWallet.Size = new Size(255, 80);

            lblWalletTitle.Text = "Số dư:";
            lblWalletTitle.Font = new Font("Segoe UI", 9F);
            lblWalletTitle.Location = new Point(15, 28);
            lblWalletTitle.Size = new Size(50, 20);

            lblWalletBalance.Text = "0 đ";
            lblWalletBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWalletBalance.ForeColor = Color.Green;
            lblWalletBalance.Location = new Point(65, 25);
            lblWalletBalance.Size = new Size(120, 25);

            btnViewWallet.Text = "📋 Chi tiết";
            btnViewWallet.Font = new Font("Segoe UI", 9F);
            btnViewWallet.Location = new Point(15, 50);
            btnViewWallet.Size = new Size(225, 25);
            btnViewWallet.Click += btnViewWallet_Click;

            grpWallet.Controls.Add(lblWalletTitle);
            grpWallet.Controls.Add(lblWalletBalance);
            grpWallet.Controls.Add(btnViewWallet);

            // ==================== BUTTONS ====================
            btnBuyTicket.Text = "🛒 MUA VÉ NGAY";
            btnBuyTicket.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBuyTicket.BackColor = Color.RoyalBlue;
            btnBuyTicket.ForeColor = Color.White;
            btnBuyTicket.FlatStyle = FlatStyle.Flat;
            btnBuyTicket.Location = new Point(580, 395);
            btnBuyTicket.Size = new Size(170, 45);
            btnBuyTicket.Enabled = false;
            btnBuyTicket.Click += btnBuyTicket_Click;

            btnClose.Text = "❌ Đóng";
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(760, 395);
            btnClose.Size = new Size(100, 45);
            btnClose.Click += btnClose_Click;

            // ==================== FORM ====================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 480);
            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(grpResales);
            Controls.Add(grpDetail);
            Controls.Add(grpPayment);
            Controls.Add(grpWallet);
            Controls.Add(btnBuyTicket);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vé pass - Movie Ticket System";
            Load += frmResaleTickets_Load;

            grpResales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResales).EndInit();
            grpDetail.ResumeLayout(false);
            grpPayment.ResumeLayout(false);
            grpWallet.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpResales;
        private DataGridView dgvResales;
        private Label lblStatus;
        private Button btnRefresh;

        private GroupBox grpDetail;
        private Label lblMovie;
        private Label lblMovieValue;
        private Label lblShowtime;
        private Label lblShowtimeValue;
        private Label lblRoom;
        private Label lblRoomValue;
        private Label lblSeat;
        private Label lblSeatValue;
        private Label lblSeller;
        private Label lblSellerValue;
        private Label lblTimeRemaining;
        private Label lblTimeRemainingValue;
        private Label lblLine1;
        private Label lblOriginalPrice;
        private Label lblOriginalPriceValue;
        private Label lblResalePrice;
        private Label lblResalePriceValue;
        private Label lblDiscount;
        private Label lblDiscountValue;

        private GroupBox grpPayment;
        private RadioButton rdoWallet;
        private RadioButton rdoCash;

        private GroupBox grpWallet;
        private Label lblWalletTitle;
        private Label lblWalletBalance;
        private Button btnViewWallet;

        private Button btnBuyTicket;
        private Button btnClose;
    }
}
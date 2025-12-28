using System.Drawing;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    partial class frmTicketPrint
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
            pnlTicket = new Panel();
            lblCinemaName = new Label();
            lblLine1 = new Label();
            picQRCode = new PictureBox();
            lblLine2 = new Label();
            lblMovieTitle = new Label();
            lblMovieValue = new Label();
            lblShowtime = new Label();
            lblShowtimeValue = new Label();
            lblRoom = new Label();
            lblRoomValue = new Label();
            lblSeats = new Label();
            lblSeatsValue = new Label();
            lblLine3 = new Label();

            // MỚI: Labels cho đồ ăn
            lblFoodList = new Label();
            lblFoodListValue = new Label();
            lblLine4 = new Label();

            lblCustomer = new Label();
            lblCustomerValue = new Label();

            // MỚI: Labels cho tiền vé và tiền đồ ăn
            lblTicketAmount = new Label();
            lblTicketAmountValue = new Label();
            lblFoodAmount = new Label();
            lblFoodAmountValue = new Label();
            lblLine5 = new Label();

            lblTotal = new Label();
            lblTotalValue = new Label();
            lblBookingCode = new Label();
            lblBookingCodeValue = new Label();
            btnPrint = new Button();
            btnClose = new Button();

            pnlTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();

            // pnlTicket
            pnlTicket.BorderStyle = BorderStyle.FixedSingle;
            pnlTicket.AutoScroll = true;
            pnlTicket.Controls.Add(lblBookingCodeValue);
            pnlTicket.Controls.Add(lblBookingCode);
            pnlTicket.Controls.Add(lblTotalValue);
            pnlTicket.Controls.Add(lblTotal);
            pnlTicket.Controls.Add(lblLine5);
            pnlTicket.Controls.Add(lblFoodAmountValue);
            pnlTicket.Controls.Add(lblFoodAmount);
            pnlTicket.Controls.Add(lblTicketAmountValue);
            pnlTicket.Controls.Add(lblTicketAmount);
            pnlTicket.Controls.Add(lblCustomerValue);
            pnlTicket.Controls.Add(lblCustomer);
            pnlTicket.Controls.Add(lblLine4);
            pnlTicket.Controls.Add(lblFoodListValue);
            pnlTicket.Controls.Add(lblFoodList);
            pnlTicket.Controls.Add(lblLine3);
            pnlTicket.Controls.Add(lblSeatsValue);
            pnlTicket.Controls.Add(lblSeats);
            pnlTicket.Controls.Add(lblRoomValue);
            pnlTicket.Controls.Add(lblRoom);
            pnlTicket.Controls.Add(lblShowtimeValue);
            pnlTicket.Controls.Add(lblShowtime);
            pnlTicket.Controls.Add(lblMovieValue);
            pnlTicket.Controls.Add(lblMovieTitle);
            pnlTicket.Controls.Add(lblLine2);
            pnlTicket.Controls.Add(picQRCode);
            pnlTicket.Controls.Add(lblLine1);
            pnlTicket.Controls.Add(lblCinemaName);
            pnlTicket.Location = new Point(20, 20);
            pnlTicket.Name = "pnlTicket";
            pnlTicket.Size = new Size(390, 650);
            pnlTicket.TabIndex = 0;

            // lblCinemaName
            lblCinemaName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblCinemaName.ForeColor = Color.DarkBlue;
            lblCinemaName.Location = new Point(80, 15);
            lblCinemaName.Size = new Size(230, 35);
            lblCinemaName.Text = "🎬 MOVIE TICKET";

            // lblLine1
            lblLine1.ForeColor = Color.Gray;
            lblLine1.Location = new Point(20, 50);
            lblLine1.Size = new Size(350, 20);
            lblLine1.Text = "───────────────────────────";

            // picQRCode
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.Location = new Point(125, 75);
            picQRCode.Size = new Size(140, 140);
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;

            // lblLine2
            lblLine2.ForeColor = Color.Gray;
            lblLine2.Location = new Point(20, 220);
            lblLine2.Size = new Size(350, 20);
            lblLine2.Text = "───────────────────────────";

            // lblMovieTitle
            lblMovieTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMovieTitle.Location = new Point(20, 245);
            lblMovieTitle.Size = new Size(350, 20);
            lblMovieTitle.Text = "Tên phim:";

            // lblMovieValue
            lblMovieValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMovieValue.ForeColor = Color.DarkRed;
            lblMovieValue.Location = new Point(20, 265);
            lblMovieValue.Size = new Size(350, 25);

            // lblShowtime
            lblShowtime.Location = new Point(20, 295);
            lblShowtime.Size = new Size(170, 20);
            lblShowtime.Text = "Suất chiếu:";

            // lblShowtimeValue
            lblShowtimeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShowtimeValue.Location = new Point(20, 315);
            lblShowtimeValue.Size = new Size(170, 20);

            // lblRoom
            lblRoom.Location = new Point(200, 295);
            lblRoom.Size = new Size(170, 20);
            lblRoom.Text = "Phòng:";

            // lblRoomValue
            lblRoomValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoomValue.Location = new Point(200, 315);
            lblRoomValue.Size = new Size(170, 20);

            // lblSeats
            lblSeats.Location = new Point(20, 340);
            lblSeats.Size = new Size(350, 20);
            lblSeats.Text = "Ghế:";

            // lblSeatsValue
            lblSeatsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSeatsValue.ForeColor = Color.Blue;
            lblSeatsValue.Location = new Point(20, 360);
            lblSeatsValue.Size = new Size(350, 25);

            // lblLine3
            lblLine3.ForeColor = Color.Gray;
            lblLine3.Location = new Point(20, 390);
            lblLine3.Size = new Size(350, 20);
            lblLine3.Text = "───────────────────────────";

            // === MỚI: Đồ ăn ===
            // lblFoodList
            lblFoodList.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFoodList.Location = new Point(20, 415);
            lblFoodList.Size = new Size(350, 20);
            lblFoodList.Text = "Đồ ăn/Thức uống:";

            // lblFoodListValue
            lblFoodListValue.Location = new Point(20, 435);
            lblFoodListValue.Size = new Size(350, 40);
            lblFoodListValue.ForeColor = Color.DarkOrange;

            // lblLine4
            lblLine4.ForeColor = Color.Gray;
            lblLine4.Location = new Point(20, 480);
            lblLine4.Size = new Size(350, 20);
            lblLine4.Text = "───────────────────────────";

            // lblCustomer
            lblCustomer.Location = new Point(20, 505);
            lblCustomer.Size = new Size(170, 20);
            lblCustomer.Text = "Khách hàng:";

            // lblCustomerValue
            lblCustomerValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerValue.Location = new Point(20, 525);
            lblCustomerValue.Size = new Size(170, 20);

            // === MỚI: Tiền vé ===
            lblTicketAmount.Location = new Point(20, 550);
            lblTicketAmount.Size = new Size(100, 20);
            lblTicketAmount.Text = "Tiền vé:";

            lblTicketAmountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTicketAmountValue.Location = new Point(120, 550);
            lblTicketAmountValue.Size = new Size(100, 20);

            // === MỚI: Tiền đồ ăn ===
            lblFoodAmount.Location = new Point(200, 550);
            lblFoodAmount.Size = new Size(80, 20);
            lblFoodAmount.Text = "Đồ ăn:";

            lblFoodAmountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFoodAmountValue.Location = new Point(270, 550);
            lblFoodAmountValue.Size = new Size(100, 20);

            // lblLine5
            lblLine5.ForeColor = Color.Black;
            lblLine5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLine5.Location = new Point(20, 575);
            lblLine5.Size = new Size(350, 20);
            lblLine5.Text = "═══════════════════════════";

            // lblTotal
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 598);
            lblTotal.Size = new Size(100, 25);
            lblTotal.Text = "TỔNG CỘNG:";

            // lblTotalValue
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.Green;
            lblTotalValue.Location = new Point(130, 595);
            lblTotalValue.Size = new Size(150, 30);

            // lblBookingCode
            lblBookingCode.Location = new Point(20, 625);
            lblBookingCode.Size = new Size(350, 20);
            lblBookingCode.Text = "Mã vé:";

            // lblBookingCodeValue
            lblBookingCodeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookingCodeValue.Location = new Point(70, 625);
            lblBookingCodeValue.Size = new Size(280, 20);

            // btnPrint
            btnPrint.BackColor = Color.RoyalBlue;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(100, 690);
            btnPrint.Size = new Size(100, 35);
            btnPrint.Text = "🖨️ In vé";
            btnPrint.Click += btnPrint_Click;

            // btnClose
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClose.Location = new Point(230, 690);
            btnClose.Size = new Size(100, 35);
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;

            // frmTicketPrint
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(434, 741);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(pnlTicket);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "In vé";
            Load += frmTicketPrint_Load;

            pnlTicket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTicket;
        private Label lblCinemaName;
        private Label lblLine1;
        private PictureBox picQRCode;
        private Label lblLine2;
        private Label lblMovieTitle;
        private Label lblMovieValue;
        private Label lblShowtime;
        private Label lblShowtimeValue;
        private Label lblRoom;
        private Label lblRoomValue;
        private Label lblSeats;
        private Label lblSeatsValue;
        private Label lblLine3;

        // MỚI: Đồ ăn
        private Label lblFoodList;
        private Label lblFoodListValue;
        private Label lblLine4;

        private Label lblCustomer;
        private Label lblCustomerValue;

        // MỚI: Tiền vé và đồ ăn
        private Label lblTicketAmount;
        private Label lblTicketAmountValue;
        private Label lblFoodAmount;
        private Label lblFoodAmountValue;
        private Label lblLine5;

        private Label lblTotal;
        private Label lblTotalValue;
        private Label lblBookingCode;
        private Label lblBookingCodeValue;
        private Button btnPrint;
        private Button btnClose;
    }
}
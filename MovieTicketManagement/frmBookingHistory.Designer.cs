using System.Drawing;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    partial class frmBookingHistory
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
            dgvBookings = new DataGridView();
            btnClose = new Button();
            btnCancel = new Button();
            btnPrintTicket = new Button();
            grpDetails = new GroupBox();
            lblStatusValue = new Label();
            lblStatus = new Label();
            lblTotalValue = new Label();
            lblTotal = new Label();
            lblSeatsValue = new Label();
            lblSeats = new Label();
            lblRoomValue = new Label();
            lblRoom = new Label();
            lblShowtimeValue = new Label();
            lblShowtime = new Label();
            lblMovieValue = new Label();
            lblMovie = new Label();
            lblBookingCodeValue = new Label();
            lblBookingCode = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(400, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LỊCH SỬ ĐẶT VÉ";
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToResizeColumns = false;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(20, 60);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1050, 350);
            dgvBookings.TabIndex = 1;
            dgvBookings.CellClick += dgvBookings_CellClick;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(lblStatusValue);
            grpDetails.Controls.Add(lblStatus);
            grpDetails.Controls.Add(lblTotalValue);
            grpDetails.Controls.Add(lblTotal);
            grpDetails.Controls.Add(lblSeatsValue);
            grpDetails.Controls.Add(lblSeats);
            grpDetails.Controls.Add(lblRoomValue);
            grpDetails.Controls.Add(lblRoom);
            grpDetails.Controls.Add(lblShowtimeValue);
            grpDetails.Controls.Add(lblShowtime);
            grpDetails.Controls.Add(lblMovieValue);
            grpDetails.Controls.Add(lblMovie);
            grpDetails.Controls.Add(lblBookingCodeValue);
            grpDetails.Controls.Add(lblBookingCode);
            grpDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDetails.Location = new Point(20, 420);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(1050, 180);
            grpDetails.TabIndex = 4;
            grpDetails.TabStop = false;
            grpDetails.Text = "Chi tiết đặt vé";
            // 
            // lblBookingCode
            // 
            lblBookingCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookingCode.Location = new Point(20, 35);
            lblBookingCode.Name = "lblBookingCode";
            lblBookingCode.Size = new Size(100, 23);
            lblBookingCode.TabIndex = 0;
            lblBookingCode.Text = "Mã đặt vé:";
            // 
            // lblBookingCodeValue
            // 
            lblBookingCodeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingCodeValue.ForeColor = Color.Black;
            lblBookingCodeValue.Location = new Point(130, 35);
            lblBookingCodeValue.Name = "lblBookingCodeValue";
            lblBookingCodeValue.Size = new Size(250, 23);
            lblBookingCodeValue.TabIndex = 1;
            // 
            // lblMovie
            // 
            lblMovie.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMovie.Location = new Point(20, 65);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(100, 23);
            lblMovie.TabIndex = 2;
            lblMovie.Text = "Phim:";
            // 
            // lblMovieValue
            // 
            lblMovieValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieValue.Location = new Point(130, 65);
            lblMovieValue.Name = "lblMovieValue";
            lblMovieValue.Size = new Size(400, 23);
            lblMovieValue.TabIndex = 3;
            // 
            // lblShowtime
            // 
            lblShowtime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowtime.Location = new Point(20, 95);
            lblShowtime.Name = "lblShowtime";
            lblShowtime.Size = new Size(100, 23);
            lblShowtime.TabIndex = 4;
            lblShowtime.Text = "Suất chiếu:";
            // 
            // lblShowtimeValue
            // 
            lblShowtimeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowtimeValue.Location = new Point(130, 95);
            lblShowtimeValue.Name = "lblShowtimeValue";
            lblShowtimeValue.Size = new Size(200, 23);
            lblShowtimeValue.TabIndex = 5;
            // 
            // lblRoom
            // 
            lblRoom.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(20, 125);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(100, 23);
            lblRoom.TabIndex = 6;
            lblRoom.Text = "Phòng:";
            // 
            // lblRoomValue
            // 
            lblRoomValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomValue.Location = new Point(130, 125);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(200, 23);
            lblRoomValue.TabIndex = 7;
            // 
            // lblSeats
            // 
            lblSeats.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeats.Location = new Point(550, 35);
            lblSeats.Name = "lblSeats";
            lblSeats.Size = new Size(100, 23);
            lblSeats.TabIndex = 8;
            lblSeats.Text = "Ghế:";
            // 
            // lblSeatsValue
            // 
            lblSeatsValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatsValue.ForeColor = Color.DarkBlue;
            lblSeatsValue.Location = new Point(660, 35);
            lblSeatsValue.Name = "lblSeatsValue";
            lblSeatsValue.Size = new Size(370, 45);
            lblSeatsValue.TabIndex = 9;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(550, 95);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Tổng tiền:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalValue.ForeColor = Color.Red;
            lblTotalValue.Location = new Point(660, 93);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(180, 25);
            lblTotalValue.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(550, 125);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusValue.Location = new Point(660, 125);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(150, 23);
            lblStatusValue.TabIndex = 13;
            // 
            // btnPrintTicket
            // 
            btnPrintTicket.BackColor = Color.Teal;
            btnPrintTicket.FlatStyle = FlatStyle.Flat;
            btnPrintTicket.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintTicket.ForeColor = Color.White;
            btnPrintTicket.Location = new Point(740, 615);
            btnPrintTicket.Name = "btnPrintTicket";
            btnPrintTicket.Size = new Size(110, 35);
            btnPrintTicket.TabIndex = 6;
            btnPrintTicket.Text = "🖨️ In vé";
            btnPrintTicket.UseVisualStyleBackColor = false;
            btnPrintTicket.Click += btnPrintTicket_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Enabled = false;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(860, 615);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "🚫 Hủy vé";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(980, 615);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmBookingHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1090, 665);
            Controls.Add(btnPrintTicket);
            Controls.Add(btnCancel);
            Controls.Add(grpDetails);
            Controls.Add(btnClose);
            Controls.Add(dgvBookings);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBookingHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử đặt vé";
            Load += frmBookingHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            grpDetails.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvBookings;
        private Button btnClose;
        private Button btnCancel;
        private Button btnPrintTicket;
        private GroupBox grpDetails;
        private Label lblBookingCode;
        private Label lblBookingCodeValue;
        private Label lblMovie;
        private Label lblMovieValue;
        private Label lblShowtime;
        private Label lblShowtimeValue;
        private Label lblRoom;
        private Label lblRoomValue;
        private Label lblSeats;
        private Label lblSeatsValue;
        private Label lblTotal;
        private Label lblTotalValue;
        private Label lblStatus;
        private Label lblStatusValue;
    }
}
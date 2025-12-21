using System.Drawing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmCheckTicket
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
            lblCode = new Label();
            txtBookingCode = new TextBox();
            btnCheck = new Button();
            grpTicketInfo = new GroupBox();
            lblBookingCode = new Label();
            lblBookingCodeValue = new Label();
            lblMovie = new Label();
            lblMovieValue = new Label();
            lblShowtime = new Label();
            lblShowtimeValue = new Label();
            lblRoom = new Label();
            lblRoomValue = new Label();
            lblSeats = new Label();
            lblSeatsValue = new Label();
            lblCustomer = new Label();
            lblCustomerValue = new Label();
            lblStatus = new Label();
            lblStatusValue = new Label();
            btnConfirm = new Button();
            btnClose = new Button();
            grpTicketInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(200, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "KIỂM TRA VÉ";
            // 
            // lblCode
            // 
            lblCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCode.Location = new Point(30, 65);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(100, 25);
            lblCode.TabIndex = 1;
            lblCode.Text = "Nhập mã vé:";
            // 
            // txtBookingCode
            // 
            txtBookingCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookingCode.Location = new Point(135, 62);
            txtBookingCode.Name = "txtBookingCode";
            txtBookingCode.Size = new Size(250, 25);
            txtBookingCode.TabIndex = 2;
            txtBookingCode.KeyDown += txtBookingCode_KeyDown;
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.RoyalBlue;
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheck.ForeColor = Color.White;
            btnCheck.Location = new Point(400, 60);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(110, 30);
            btnCheck.TabIndex = 3;
            btnCheck.Text = "🔍 Kiểm tra";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += btnCheck_Click;
            // 
            // grpTicketInfo
            // 
            grpTicketInfo.Controls.Add(lblStatusValue);
            grpTicketInfo.Controls.Add(lblStatus);
            grpTicketInfo.Controls.Add(lblCustomerValue);
            grpTicketInfo.Controls.Add(lblCustomer);
            grpTicketInfo.Controls.Add(lblSeatsValue);
            grpTicketInfo.Controls.Add(lblSeats);
            grpTicketInfo.Controls.Add(lblRoomValue);
            grpTicketInfo.Controls.Add(lblRoom);
            grpTicketInfo.Controls.Add(lblShowtimeValue);
            grpTicketInfo.Controls.Add(lblShowtime);
            grpTicketInfo.Controls.Add(lblMovieValue);
            grpTicketInfo.Controls.Add(lblMovie);
            grpTicketInfo.Controls.Add(lblBookingCodeValue);
            grpTicketInfo.Controls.Add(lblBookingCode);
            grpTicketInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpTicketInfo.Location = new Point(30, 110);
            grpTicketInfo.Name = "grpTicketInfo";
            grpTicketInfo.Size = new Size(480, 280);
            grpTicketInfo.TabIndex = 4;
            grpTicketInfo.TabStop = false;
            grpTicketInfo.Text = "Thông tin vé";
            // 
            // lblBookingCode
            // 
            lblBookingCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookingCode.Location = new Point(20, 35);
            lblBookingCode.Name = "lblBookingCode";
            lblBookingCode.Size = new Size(100, 23);
            lblBookingCode.TabIndex = 0;
            lblBookingCode.Text = "Mã vé:";
            // 
            // lblBookingCodeValue
            // 
            lblBookingCodeValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingCodeValue.ForeColor = Color.DarkBlue;
            lblBookingCodeValue.Location = new Point(130, 35);
            lblBookingCodeValue.Name = "lblBookingCodeValue";
            lblBookingCodeValue.Size = new Size(320, 23);
            lblBookingCodeValue.TabIndex = 1;
            // 
            // lblMovie
            // 
            lblMovie.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMovie.Location = new Point(20, 70);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(100, 23);
            lblMovie.TabIndex = 2;
            lblMovie.Text = "Phim:";
            // 
            // lblMovieValue
            // 
            lblMovieValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieValue.Location = new Point(130, 70);
            lblMovieValue.Name = "lblMovieValue";
            lblMovieValue.Size = new Size(320, 23);
            lblMovieValue.TabIndex = 3;
            // 
            // lblShowtime
            // 
            lblShowtime.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowtime.Location = new Point(20, 105);
            lblShowtime.Name = "lblShowtime";
            lblShowtime.Size = new Size(100, 23);
            lblShowtime.TabIndex = 4;
            lblShowtime.Text = "Suất chiếu:";
            // 
            // lblShowtimeValue
            // 
            lblShowtimeValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowtimeValue.Location = new Point(130, 105);
            lblShowtimeValue.Name = "lblShowtimeValue";
            lblShowtimeValue.Size = new Size(150, 23);
            lblShowtimeValue.TabIndex = 5;
            // 
            // lblRoom
            // 
            lblRoom.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(280, 105);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(60, 23);
            lblRoom.TabIndex = 6;
            lblRoom.Text = "Phòng:";
            // 
            // lblRoomValue
            // 
            lblRoomValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomValue.Location = new Point(350, 105);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(100, 23);
            lblRoomValue.TabIndex = 7;
            // 
            // lblSeats
            // 
            lblSeats.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeats.Location = new Point(20, 140);
            lblSeats.Name = "lblSeats";
            lblSeats.Size = new Size(100, 23);
            lblSeats.TabIndex = 8;
            lblSeats.Text = "Ghế:";
            // 
            // lblSeatsValue
            // 
            lblSeatsValue.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatsValue.ForeColor = Color.Blue;
            lblSeatsValue.Location = new Point(130, 140);
            lblSeatsValue.Name = "lblSeatsValue";
            lblSeatsValue.Size = new Size(320, 23);
            lblSeatsValue.TabIndex = 9;
            // 
            // lblCustomer
            // 
            lblCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(20, 175);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(100, 23);
            lblCustomer.TabIndex = 10;
            lblCustomer.Text = "Khách hàng:";
            // 
            // lblCustomerValue
            // 
            lblCustomerValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerValue.Location = new Point(130, 175);
            lblCustomerValue.Name = "lblCustomerValue";
            lblCustomerValue.Size = new Size(320, 23);
            lblCustomerValue.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(20, 220);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusValue.Location = new Point(130, 218);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(330, 50);
            lblStatusValue.TabIndex = 13;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Green;
            btnConfirm.Enabled = false;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(150, 405);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(150, 40);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "✅ Xác nhận vào rạp";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(320, 405);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 6;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmCheckTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(534, 461);
            Controls.Add(btnClose);
            Controls.Add(btnConfirm);
            Controls.Add(grpTicketInfo);
            Controls.Add(btnCheck);
            Controls.Add(txtBookingCode);
            Controls.Add(lblCode);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCheckTicket";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kiểm tra vé";
            Load += frmCheckTicket_Load;
            grpTicketInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCode;
        private TextBox txtBookingCode;
        private Button btnCheck;
        private GroupBox grpTicketInfo;
        private Label lblShowtime;
        private Label lblMovieValue;
        private Label lblMovie;
        private Label lblBookingCodeValue;
        private Label lblBookingCode;
        private Label lblStatus;
        private Label lblCustomerValue;
        private Label lblCustomer;
        private Label lblSeatsValue;
        private Label lblSeats;
        private Label lblRoomValue;
        private Label lblRoom;
        private Label lblShowtimeValue;
        private Label lblStatusValue;
        private Button btnConfirm;
        private Button btnClose;
    }
}
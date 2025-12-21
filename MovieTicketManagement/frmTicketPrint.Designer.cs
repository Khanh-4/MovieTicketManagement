using System.Drawing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmTicketPrint
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
            lblCustomer = new Label();
            lblCustomerValue = new Label();
            lblTotal = new Label();
            lblTotalValue = new Label();
            lblBookingCode = new Label();
            lblBookingCodeValue = new Label();
            btnPrint = new Button();
            btnClose = new Button();
            pnlTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();
            // 
            // pnlTicket
            // 
            pnlTicket.BorderStyle = BorderStyle.FixedSingle;
            pnlTicket.Controls.Add(lblBookingCodeValue);
            pnlTicket.Controls.Add(lblBookingCode);
            pnlTicket.Controls.Add(lblTotalValue);
            pnlTicket.Controls.Add(lblTotal);
            pnlTicket.Controls.Add(lblCustomerValue);
            pnlTicket.Controls.Add(lblCustomer);
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
            pnlTicket.Size = new Size(390, 520);
            pnlTicket.TabIndex = 0;
            // 
            // lblCinemaName
            // 
            lblCinemaName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCinemaName.ForeColor = Color.DarkBlue;
            lblCinemaName.Location = new Point(80, 15);
            lblCinemaName.Name = "lblCinemaName";
            lblCinemaName.Size = new Size(230, 35);
            lblCinemaName.TabIndex = 0;
            lblCinemaName.Text = "🎬 MOVIE TICKET";
            // 
            // lblLine1
            // 
            lblLine1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLine1.ForeColor = Color.Gray;
            lblLine1.Location = new Point(20, 50);
            lblLine1.Name = "lblLine1";
            lblLine1.Size = new Size(350, 20);
            lblLine1.TabIndex = 1;
            lblLine1.Text = "───────────────────────";
            // 
            // picQRCode
            // 
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.Location = new Point(125, 75);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(140, 140);
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            picQRCode.TabIndex = 2;
            picQRCode.TabStop = false;
            // 
            // lblLine2
            // 
            lblLine2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLine2.ForeColor = Color.Gray;
            lblLine2.Location = new Point(20, 220);
            lblLine2.Name = "lblLine2";
            lblLine2.Size = new Size(350, 20);
            lblLine2.TabIndex = 3;
            lblLine2.Text = "───────────────────────";
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieTitle.Location = new Point(20, 250);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(350, 25);
            lblMovieTitle.TabIndex = 4;
            lblMovieTitle.Text = "Tên phim:";
            // 
            // lblMovieValue
            // 
            lblMovieValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMovieValue.ForeColor = Color.DarkRed;
            lblMovieValue.Location = new Point(20, 275);
            lblMovieValue.Name = "lblMovieValue";
            lblMovieValue.Size = new Size(350, 25);
            lblMovieValue.TabIndex = 5;
            // 
            // lblShowtime
            // 
            lblShowtime.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowtime.Location = new Point(20, 305);
            lblShowtime.Name = "lblShowtime";
            lblShowtime.Size = new Size(170, 23);
            lblShowtime.TabIndex = 6;
            lblShowtime.Text = "Suất chiếu:";
            // 
            // lblShowtimeValue
            // 
            lblShowtimeValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowtimeValue.Location = new Point(20, 328);
            lblShowtimeValue.Name = "lblShowtimeValue";
            lblShowtimeValue.Size = new Size(170, 23);
            lblShowtimeValue.TabIndex = 7;
            // 
            // lblRoom
            // 
            lblRoom.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(200, 305);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(170, 23);
            lblRoom.TabIndex = 8;
            lblRoom.Text = "Phòng:";
            // 
            // lblRoomValue
            // 
            lblRoomValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomValue.Location = new Point(200, 328);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(170, 23);
            lblRoomValue.TabIndex = 9;
            // 
            // lblSeats
            // 
            lblSeats.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeats.Location = new Point(20, 355);
            lblSeats.Name = "lblSeats";
            lblSeats.Size = new Size(350, 23);
            lblSeats.TabIndex = 10;
            lblSeats.Text = "Ghế:";
            // 
            // lblSeatsValue
            // 
            lblSeatsValue.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatsValue.ForeColor = Color.Blue;
            lblSeatsValue.Location = new Point(20, 378);
            lblSeatsValue.Name = "lblSeatsValue";
            lblSeatsValue.Size = new Size(350, 23);
            lblSeatsValue.TabIndex = 11;
            // 
            // lblLine3
            // 
            lblLine3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLine3.ForeColor = Color.Gray;
            lblLine3.Location = new Point(20, 405);
            lblLine3.Name = "lblLine3";
            lblLine3.Size = new Size(350, 20);
            lblLine3.TabIndex = 12;
            lblLine3.Text = "───────────────────────";
            // 
            // lblCustomer
            // 
            lblCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(20, 430);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(170, 23);
            lblCustomer.TabIndex = 13;
            lblCustomer.Text = "Khách hàng:";
            // 
            // lblCustomerValue
            // 
            lblCustomerValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerValue.Location = new Point(20, 453);
            lblCustomerValue.Name = "lblCustomerValue";
            lblCustomerValue.Size = new Size(170, 23);
            lblCustomerValue.TabIndex = 14;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(200, 430);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(170, 23);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Tổng tiền:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalValue.ForeColor = Color.Green;
            lblTotalValue.Location = new Point(200, 453);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(170, 25);
            lblTotalValue.TabIndex = 16;
            // 
            // lblBookingCode
            // 
            lblBookingCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookingCode.Location = new Point(20, 483);
            lblBookingCode.Name = "lblBookingCode";
            lblBookingCode.Size = new Size(350, 23);
            lblBookingCode.TabIndex = 17;
            lblBookingCode.Text = "Mã vé:";
            // 
            // lblBookingCodeValue
            // 
            lblBookingCodeValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingCodeValue.Location = new Point(20, 503);
            lblBookingCodeValue.Name = "lblBookingCodeValue";
            lblBookingCodeValue.Size = new Size(350, 23);
            lblBookingCodeValue.TabIndex = 18;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.RoyalBlue;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(100, 560);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 35);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "🖨️ In vé";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(230, 560);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmTicketPrint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(434, 611);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(pnlTicket);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTicketPrint";
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
        private Label lblShowtimeValue;
        private Label lblShowtime;
        private Label lblMovieValue;
        private Label lblMovieTitle;
        private Label lblLine2;
        private PictureBox picQRCode;
        private Label lblLine1;
        private Label lblTotal;
        private Label lblCustomerValue;
        private Label lblCustomer;
        private Label lblLine3;
        private Label lblSeatsValue;
        private Label lblSeats;
        private Label lblRoomValue;
        private Label lblRoom;
        private Label lblBookingCodeValue;
        private Label lblBookingCode;
        private Label lblTotalValue;
        private Button btnPrint;
        private Button btnClose;
    }
}
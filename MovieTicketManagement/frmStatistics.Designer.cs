using System.Drawing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmStatistics
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
            grpFilter = new GroupBox();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnView = new Button();
            btnExport = new Button();
            grpSummary = new GroupBox();
            lblTotalRevenueTitle = new Label();
            lblTotalRevenue = new Label();
            lblTotalTicketsTitle = new Label();
            lblTotalTickets = new Label();
            lblTotalBookingsTitle = new Label();
            lblTotalBookings = new Label();
            lblTotalCustomersTitle = new Label();
            lblTotalCustomers = new Label();
            lblBestMovieTitle = new Label();
            lblBestMovie = new Label();
            lblMostUsedRoomTitle = new Label();
            lblMostUsedRoom = new Label();
            grpChart = new GroupBox();
            pnlChart = new Panel();
            grpDailyRevenue = new GroupBox();
            dgvDailyRevenue = new DataGridView();
            grpMovieRevenue = new GroupBox();
            dgvMovieRevenue = new DataGridView();
            btnClose = new Button();
            grpFilter.SuspendLayout();
            grpSummary.SuspendLayout();
            grpChart.SuspendLayout();
            grpDailyRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDailyRevenue).BeginInit();
            grpMovieRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovieRevenue).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(450, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THỐNG KÊ";
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(btnExport);
            grpFilter.Controls.Add(btnView);
            grpFilter.Controls.Add(dtpToDate);
            grpFilter.Controls.Add(lblToDate);
            grpFilter.Controls.Add(dtpFromDate);
            grpFilter.Controls.Add(lblFromDate);
            grpFilter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFilter.Location = new Point(20, 50);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(1060, 60);
            grpFilter.TabIndex = 1;
            grpFilter.TabStop = false;
            grpFilter.Text = "Bộ lọc";
            // 
            // lblFromDate
            // 
            lblFromDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFromDate.Location = new Point(15, 25);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(70, 23);
            lblFromDate.TabIndex = 0;
            lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(90, 22);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(120, 25);
            dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            lblToDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblToDate.Location = new Point(230, 25);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(70, 23);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(305, 22);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(120, 25);
            dtpToDate.TabIndex = 3;
            // 
            // btnView
            // 
            btnView.BackColor = Color.RoyalBlue;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(450, 19);
            btnView.Name = "btnView";
            btnView.Size = new Size(120, 30);
            btnView.TabIndex = 4;
            btnView.Text = "📊 Xem thống kê";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Green;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(580, 19);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 30);
            btnExport.TabIndex = 5;
            btnExport.Text = "📁 Xuất CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // grpSummary
            // 
            grpSummary.Controls.Add(lblMostUsedRoom);
            grpSummary.Controls.Add(lblMostUsedRoomTitle);
            grpSummary.Controls.Add(lblBestMovie);
            grpSummary.Controls.Add(lblBestMovieTitle);
            grpSummary.Controls.Add(lblTotalCustomers);
            grpSummary.Controls.Add(lblTotalCustomersTitle);
            grpSummary.Controls.Add(lblTotalBookings);
            grpSummary.Controls.Add(lblTotalBookingsTitle);
            grpSummary.Controls.Add(lblTotalTickets);
            grpSummary.Controls.Add(lblTotalTicketsTitle);
            grpSummary.Controls.Add(lblTotalRevenue);
            grpSummary.Controls.Add(lblTotalRevenueTitle);
            grpSummary.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSummary.Location = new Point(20, 120);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(1060, 100);
            grpSummary.TabIndex = 2;
            grpSummary.TabStop = false;
            grpSummary.Text = "Tổng quan";
            // 
            // lblTotalRevenueTitle
            // 
            lblTotalRevenueTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRevenueTitle.Location = new Point(20, 25);
            lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            lblTotalRevenueTitle.Size = new Size(100, 18);
            lblTotalRevenueTitle.TabIndex = 0;
            lblTotalRevenueTitle.Text = "Tổng doanh thu:";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.ForeColor = Color.Green;
            lblTotalRevenue.Location = new Point(20, 43);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(160, 25);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 VNĐ";
            // 
            // lblTotalTicketsTitle
            // 
            lblTotalTicketsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalTicketsTitle.Location = new Point(200, 25);
            lblTotalTicketsTitle.Name = "lblTotalTicketsTitle";
            lblTotalTicketsTitle.Size = new Size(80, 18);
            lblTotalTicketsTitle.TabIndex = 2;
            lblTotalTicketsTitle.Text = "Tổng số vé:";
            // 
            // lblTotalTickets
            // 
            lblTotalTickets.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTickets.ForeColor = Color.RoyalBlue;
            lblTotalTickets.Location = new Point(200, 43);
            lblTotalTickets.Name = "lblTotalTickets";
            lblTotalTickets.Size = new Size(100, 25);
            lblTotalTickets.TabIndex = 3;
            lblTotalTickets.Text = "0 vé";
            // 
            // lblTotalBookingsTitle
            // 
            lblTotalBookingsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBookingsTitle.Location = new Point(320, 25);
            lblTotalBookingsTitle.Name = "lblTotalBookingsTitle";
            lblTotalBookingsTitle.Size = new Size(80, 18);
            lblTotalBookingsTitle.TabIndex = 4;
            lblTotalBookingsTitle.Text = "Tổng số đơn:";
            // 
            // lblTotalBookings
            // 
            lblTotalBookings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBookings.ForeColor = Color.DarkOrange;
            lblTotalBookings.Location = new Point(320, 43);
            lblTotalBookings.Name = "lblTotalBookings";
            lblTotalBookings.Size = new Size(100, 25);
            lblTotalBookings.TabIndex = 5;
            lblTotalBookings.Text = "0 đơn";
            // 
            // lblTotalCustomersTitle
            // 
            lblTotalCustomersTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalCustomersTitle.Location = new Point(440, 25);
            lblTotalCustomersTitle.Name = "lblTotalCustomersTitle";
            lblTotalCustomersTitle.Size = new Size(100, 18);
            lblTotalCustomersTitle.TabIndex = 6;
            lblTotalCustomersTitle.Text = "Tổng khách hàng:";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCustomers.ForeColor = Color.Purple;
            lblTotalCustomers.Location = new Point(440, 43);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(100, 25);
            lblTotalCustomers.TabIndex = 7;
            lblTotalCustomers.Text = "0 khách";
            // 
            // lblBestMovieTitle
            // 
            lblBestMovieTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBestMovieTitle.Location = new Point(580, 25);
            lblBestMovieTitle.Name = "lblBestMovieTitle";
            lblBestMovieTitle.Size = new Size(120, 18);
            lblBestMovieTitle.TabIndex = 8;
            lblBestMovieTitle.Text = "Phim bán chạy nhất:";
            // 
            // lblBestMovie
            // 
            lblBestMovie.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBestMovie.ForeColor = Color.Crimson;
            lblBestMovie.Location = new Point(580, 43);
            lblBestMovie.Name = "lblBestMovie";
            lblBestMovie.Size = new Size(200, 50);
            lblBestMovie.TabIndex = 9;
            lblBestMovie.Text = "Chưa có dữ liệu";
            // 
            // lblMostUsedRoomTitle
            // 
            lblMostUsedRoomTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMostUsedRoomTitle.Location = new Point(820, 25);
            lblMostUsedRoomTitle.Name = "lblMostUsedRoomTitle";
            lblMostUsedRoomTitle.Size = new Size(130, 18);
            lblMostUsedRoomTitle.TabIndex = 10;
            lblMostUsedRoomTitle.Text = "Phòng chiếu nhiều nhất:";
            // 
            // lblMostUsedRoom
            // 
            lblMostUsedRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMostUsedRoom.ForeColor = Color.Teal;
            lblMostUsedRoom.Location = new Point(820, 43);
            lblMostUsedRoom.Name = "lblMostUsedRoom";
            lblMostUsedRoom.Size = new Size(150, 25);
            lblMostUsedRoom.TabIndex = 11;
            lblMostUsedRoom.Text = "Chưa có dữ liệu";
            // 
            // grpChart
            // 
            grpChart.Controls.Add(pnlChart);
            grpChart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpChart.Location = new Point(20, 230);
            grpChart.Name = "grpChart";
            grpChart.Size = new Size(620, 200);
            grpChart.TabIndex = 3;
            grpChart.TabStop = false;
            grpChart.Text = "Biểu đồ doanh thu theo ngày";
            // 
            // pnlChart
            // 
            pnlChart.BackColor = Color.White;
            pnlChart.BorderStyle = BorderStyle.FixedSingle;
            pnlChart.Location = new Point(10, 25);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(600, 165);
            pnlChart.TabIndex = 0;
            // 
            // grpDailyRevenue
            // 
            grpDailyRevenue.Controls.Add(dgvDailyRevenue);
            grpDailyRevenue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDailyRevenue.Location = new Point(20, 440);
            grpDailyRevenue.Name = "grpDailyRevenue";
            grpDailyRevenue.Size = new Size(400, 200);
            grpDailyRevenue.TabIndex = 4;
            grpDailyRevenue.TabStop = false;
            grpDailyRevenue.Text = "Doanh thu theo ngày";
            // 
            // dgvDailyRevenue
            // 
            dgvDailyRevenue.AllowUserToAddRows = false;
            dgvDailyRevenue.AllowUserToDeleteRows = false;
            dgvDailyRevenue.BackgroundColor = Color.White;
            dgvDailyRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDailyRevenue.Location = new Point(10, 25);
            dgvDailyRevenue.MultiSelect = false;
            dgvDailyRevenue.Name = "dgvDailyRevenue";
            dgvDailyRevenue.ReadOnly = true;
            dgvDailyRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDailyRevenue.Size = new Size(380, 165);
            dgvDailyRevenue.TabIndex = 0;
            // 
            // grpMovieRevenue
            // 
            grpMovieRevenue.Controls.Add(dgvMovieRevenue);
            grpMovieRevenue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpMovieRevenue.Location = new Point(650, 230);
            grpMovieRevenue.Name = "grpMovieRevenue";
            grpMovieRevenue.Size = new Size(430, 410);
            grpMovieRevenue.TabIndex = 5;
            grpMovieRevenue.TabStop = false;
            grpMovieRevenue.Text = "Doanh thu theo phim";
            // 
            // dgvMovieRevenue
            // 
            dgvMovieRevenue.AllowUserToAddRows = false;
            dgvMovieRevenue.AllowUserToDeleteRows = false;
            dgvMovieRevenue.BackgroundColor = Color.White;
            dgvMovieRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovieRevenue.Location = new Point(10, 25);
            dgvMovieRevenue.MultiSelect = false;
            dgvMovieRevenue.Name = "dgvMovieRevenue";
            dgvMovieRevenue.ReadOnly = true;
            dgvMovieRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovieRevenue.Size = new Size(410, 375);
            dgvMovieRevenue.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(320, 650);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 6;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1100, 700);
            Controls.Add(btnClose);
            Controls.Add(grpMovieRevenue);
            Controls.Add(grpDailyRevenue);
            Controls.Add(grpChart);
            Controls.Add(grpSummary);
            Controls.Add(grpFilter);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmStatistics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê doanh thu";
            Load += frmStatistics_Load;
            grpFilter.ResumeLayout(false);
            grpSummary.ResumeLayout(false);
            grpChart.ResumeLayout(false);
            grpDailyRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDailyRevenue).EndInit();
            grpMovieRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovieRevenue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpFilter;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnView;
        private Button btnExport;
        private GroupBox grpSummary;
        private Label lblTotalRevenueTitle;
        private Label lblTotalRevenue;
        private Label lblTotalTicketsTitle;
        private Label lblTotalTickets;
        private Label lblTotalBookingsTitle;
        private Label lblTotalBookings;
        private Label lblTotalCustomersTitle;
        private Label lblTotalCustomers;
        private Label lblBestMovieTitle;
        private Label lblBestMovie;
        private Label lblMostUsedRoomTitle;
        private Label lblMostUsedRoom;
        private GroupBox grpChart;
        private Panel pnlChart;
        private GroupBox grpDailyRevenue;
        private DataGridView dgvDailyRevenue;
        private GroupBox grpMovieRevenue;
        private DataGridView dgvMovieRevenue;
        private Button btnClose;
    }
}
namespace MovieTicketManagement
{
    partial class frmRevenueReport
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
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnFilter = new Button();
            btnExport = new Button();
            grpSummary = new GroupBox();
            lblBestRoomValue = new Label();
            lblBestRoom = new Label();
            lblBestMovieValue = new Label();
            lblBestMovie = new Label();
            lblTotalCustomersValue = new Label();
            lblTotalCustomers = new Label();
            lblTotalTicketsValue = new Label();
            lblTotalTickets = new Label();
            lblTotalBookingsValue = new Label();
            lblTotalBookings = new Label();
            lblTotalRevenueValue = new Label();
            lblTotalRevenue = new Label();
            tabReport = new TabControl();
            tabDaily = new TabPage();
            dgvDaily = new DataGridView();
            tabMovie = new TabPage();
            dgvMovie = new DataGridView();
            tabRoom = new TabPage();
            dgvRoom = new DataGridView();
            btnClose = new Button();
            grpSummary.SuspendLayout();
            tabReport.SuspendLayout();
            tabDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDaily).BeginInit();
            tabMovie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovie).BeginInit();
            tabRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(350, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(274, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁO CÁO DOANH THU";
            // 
            // lblFromDate
            // 
            lblFromDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFromDate.Location = new Point(30, 65);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(60, 23);
            lblFromDate.TabIndex = 1;
            lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(95, 62);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(130, 23);
            dtpFromDate.TabIndex = 2;
            // 
            // lblToDate
            // 
            lblToDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblToDate.Location = new Point(240, 65);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(70, 23);
            lblToDate.TabIndex = 3;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(315, 62);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(130, 23);
            dtpToDate.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.RoyalBlue;
            btnFilter.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(460, 60);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(90, 28);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "🔍 Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.RoyalBlue;
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(560, 60);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 28);
            btnExport.TabIndex = 6;
            btnExport.Text = "📊 Xuất CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // grpSummary
            // 
            grpSummary.Controls.Add(lblBestRoomValue);
            grpSummary.Controls.Add(lblBestRoom);
            grpSummary.Controls.Add(lblBestMovieValue);
            grpSummary.Controls.Add(lblBestMovie);
            grpSummary.Controls.Add(lblTotalCustomersValue);
            grpSummary.Controls.Add(lblTotalCustomers);
            grpSummary.Controls.Add(lblTotalTicketsValue);
            grpSummary.Controls.Add(lblTotalTickets);
            grpSummary.Controls.Add(lblTotalBookingsValue);
            grpSummary.Controls.Add(lblTotalBookings);
            grpSummary.Controls.Add(lblTotalRevenueValue);
            grpSummary.Controls.Add(lblTotalRevenue);
            grpSummary.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSummary.Location = new Point(30, 100);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(880, 100);
            grpSummary.TabIndex = 7;
            grpSummary.TabStop = false;
            grpSummary.Text = "Tổng quan";
            // 
            // lblBestRoomValue
            // 
            lblBestRoomValue.Location = new Point(690, 60);
            lblBestRoomValue.Name = "lblBestRoomValue";
            lblBestRoomValue.Size = new Size(170, 23);
            lblBestRoomValue.TabIndex = 11;
            lblBestRoomValue.Text = "-";
            // 
            // lblBestRoom
            // 
            lblBestRoom.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBestRoom.Location = new Point(550, 60);
            lblBestRoom.Name = "lblBestRoom";
            lblBestRoom.Size = new Size(140, 23);
            lblBestRoom.TabIndex = 10;
            lblBestRoom.Text = "Phòng chiếu nhiều nhất:";
            // 
            // lblBestMovieValue
            // 
            lblBestMovieValue.ForeColor = Color.DarkOrange;
            lblBestMovieValue.Location = new Point(680, 30);
            lblBestMovieValue.Name = "lblBestMovieValue";
            lblBestMovieValue.Size = new Size(180, 23);
            lblBestMovieValue.TabIndex = 9;
            lblBestMovieValue.Text = "-";
            // 
            // lblBestMovie
            // 
            lblBestMovie.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBestMovie.Location = new Point(550, 30);
            lblBestMovie.Name = "lblBestMovie";
            lblBestMovie.Size = new Size(130, 23);
            lblBestMovie.TabIndex = 8;
            lblBestMovie.Text = "Phim bán chạy nhất:";
            // 
            // lblTotalCustomersValue
            // 
            lblTotalCustomersValue.Location = new Point(420, 60);
            lblTotalCustomersValue.Name = "lblTotalCustomersValue";
            lblTotalCustomersValue.Size = new Size(80, 23);
            lblTotalCustomersValue.TabIndex = 7;
            lblTotalCustomersValue.Text = "0";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalCustomers.Location = new Point(320, 60);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(100, 23);
            lblTotalCustomers.TabIndex = 6;
            lblTotalCustomers.Text = "Số khách hàng:";
            // 
            // lblTotalTicketsValue
            // 
            lblTotalTicketsValue.Location = new Point(420, 30);
            lblTotalTicketsValue.Name = "lblTotalTicketsValue";
            lblTotalTicketsValue.Size = new Size(80, 23);
            lblTotalTicketsValue.TabIndex = 5;
            lblTotalTicketsValue.Text = "0";
            // 
            // lblTotalTickets
            // 
            lblTotalTickets.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalTickets.Location = new Point(320, 30);
            lblTotalTickets.Name = "lblTotalTickets";
            lblTotalTickets.Size = new Size(100, 23);
            lblTotalTickets.TabIndex = 4;
            lblTotalTickets.Text = "Tổng vé bán:";
            // 
            // lblTotalBookingsValue
            // 
            lblTotalBookingsValue.Location = new Point(130, 60);
            lblTotalBookingsValue.Name = "lblTotalBookingsValue";
            lblTotalBookingsValue.Size = new Size(80, 23);
            lblTotalBookingsValue.TabIndex = 3;
            lblTotalBookingsValue.Text = "0";
            // 
            // lblTotalBookings
            // 
            lblTotalBookings.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBookings.Location = new Point(20, 60);
            lblTotalBookings.Name = "lblTotalBookings";
            lblTotalBookings.Size = new Size(100, 23);
            lblTotalBookings.TabIndex = 2;
            lblTotalBookings.Text = "Tổng đơn đặt:";
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenueValue.ForeColor = Color.Green;
            lblTotalRevenueValue.Location = new Point(130, 30);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new Size(180, 23);
            lblTotalRevenueValue.TabIndex = 1;
            lblTotalRevenueValue.Text = "0 VNĐ";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRevenue.Location = new Point(20, 30);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(110, 23);
            lblTotalRevenue.TabIndex = 0;
            lblTotalRevenue.Text = "Tổng doanh thu:";
            // 
            // tabReport
            // 
            tabReport.Controls.Add(tabDaily);
            tabReport.Controls.Add(tabMovie);
            tabReport.Controls.Add(tabRoom);
            tabReport.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabReport.Location = new Point(30, 210);
            tabReport.Name = "tabReport";
            tabReport.SelectedIndex = 0;
            tabReport.Size = new Size(880, 350);
            tabReport.TabIndex = 8;
            // 
            // tabDaily
            // 
            tabDaily.Controls.Add(dgvDaily);
            tabDaily.Location = new Point(4, 26);
            tabDaily.Name = "tabDaily";
            tabDaily.Padding = new Padding(3);
            tabDaily.Size = new Size(872, 320);
            tabDaily.TabIndex = 0;
            tabDaily.Text = "Theo ngày";
            tabDaily.UseVisualStyleBackColor = true;
            // 
            // dgvDaily
            // 
            dgvDaily.AllowUserToAddRows = false;
            dgvDaily.BackgroundColor = Color.White;
            dgvDaily.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDaily.Location = new Point(5, 5);
            dgvDaily.Name = "dgvDaily";
            dgvDaily.ReadOnly = true;
            dgvDaily.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDaily.Size = new Size(860, 310);
            dgvDaily.TabIndex = 0;
            // 
            // tabMovie
            // 
            tabMovie.Controls.Add(dgvMovie);
            tabMovie.Location = new Point(4, 26);
            tabMovie.Name = "tabMovie";
            tabMovie.Padding = new Padding(3);
            tabMovie.Size = new Size(872, 320);
            tabMovie.TabIndex = 1;
            tabMovie.Text = "Theo phim";
            tabMovie.UseVisualStyleBackColor = true;
            // 
            // dgvMovie
            // 
            dgvMovie.AllowUserToAddRows = false;
            dgvMovie.BackgroundColor = Color.White;
            dgvMovie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovie.Location = new Point(5, 5);
            dgvMovie.Name = "dgvMovie";
            dgvMovie.ReadOnly = true;
            dgvMovie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovie.Size = new Size(860, 310);
            dgvMovie.TabIndex = 0;
            // 
            // tabRoom
            // 
            tabRoom.Controls.Add(dgvRoom);
            tabRoom.Location = new Point(4, 26);
            tabRoom.Name = "tabRoom";
            tabRoom.Padding = new Padding(3);
            tabRoom.Size = new Size(872, 320);
            tabRoom.TabIndex = 2;
            tabRoom.Text = "Theo phòng";
            tabRoom.UseVisualStyleBackColor = true;
            // 
            // dgvRoom
            // 
            dgvRoom.AllowUserToAddRows = false;
            dgvRoom.BackgroundColor = Color.White;
            dgvRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoom.Location = new Point(5, 5);
            dgvRoom.Name = "dgvRoom";
            dgvRoom.ReadOnly = true;
            dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoom.Size = new Size(860, 310);
            dgvRoom.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(820, 566);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 10;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmRevenueReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 611);
            Controls.Add(btnClose);
            Controls.Add(tabReport);
            Controls.Add(grpSummary);
            Controls.Add(btnExport);
            Controls.Add(btnFilter);
            Controls.Add(dtpToDate);
            Controls.Add(lblToDate);
            Controls.Add(dtpFromDate);
            Controls.Add(lblFromDate);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmRevenueReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo doanh thu";
            Load += frmRevenueReport_Load;
            grpSummary.ResumeLayout(false);
            tabReport.ResumeLayout(false);
            tabDaily.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDaily).EndInit();
            tabMovie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovie).EndInit();
            tabRoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnFilter;
        private Button btnExport;
        private GroupBox grpSummary;
        private Label lblTotalRevenueValue;
        private Label lblTotalRevenue;
        private Label lblTotalBookingsValue;
        private Label lblTotalBookings;
        private Label lblTotalCustomersValue;
        private Label lblTotalCustomers;
        private Label lblTotalTicketsValue;
        private Label lblTotalTickets;
        private Label lblBestMovieValue;
        private Label lblBestMovie;
        private Label lblBestRoom;
        private Label lblBestRoomValue;
        private TabControl tabReport;
        private TabPage tabDaily;
        private TabPage tabMovie;
        private DataGridView dgvDaily;
        private TabPage tabRoom;
        private DataGridView dgvMovie;
        private DataGridView dgvRoom;
        private Button btnClose;
    }
}
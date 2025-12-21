using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmRevenueReport : Form
    {
        private ReportBLL reportBLL = new ReportBLL();

        public frmRevenueReport()
        {
            InitializeComponent();
        }

        private void frmRevenueReport_Load(object sender, EventArgs e)
        {
            // Mặc định: từ đầu tháng đến hôm nay
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            SetupDataGridViews();
            LoadReport();
        }

        private void SetupDataGridViews()
        {
            // Setup dgvDaily
            dgvDaily.AutoGenerateColumns = false;
            dgvDaily.Columns.Clear();
            dgvDaily.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Ngày",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvDaily.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalBookings",
                HeaderText = "Số đơn",
                Width = 100
            });
            dgvDaily.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalTickets",
                HeaderText = "Số vé",
                Width = 100
            });
            dgvDaily.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalRevenue",
                HeaderText = "Doanh thu (VNĐ)",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Setup dgvMovie
            dgvMovie.AutoGenerateColumns = false;
            dgvMovie.Columns.Clear();
            dgvMovie.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MovieTitle",
                HeaderText = "Tên phim",
                Width = 300
            });
            dgvMovie.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalBookings",
                HeaderText = "Số đơn",
                Width = 100
            });
            dgvMovie.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalTickets",
                HeaderText = "Số vé",
                Width = 100
            });
            dgvMovie.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalRevenue",
                HeaderText = "Doanh thu (VNĐ)",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Setup dgvRoom
            dgvRoom.AutoGenerateColumns = false;
            dgvRoom.Columns.Clear();
            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomName",
                HeaderText = "Phòng chiếu",
                Width = 180
            });
            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalShowtimes",
                HeaderText = "Số suất chiếu",
                Width = 120
            });
            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalTickets",
                HeaderText = "Số vé",
                Width = 100
            });
            dgvRoom.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalRevenue",
                HeaderText = "Doanh thu (VNĐ)",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Load tổng quan
                RevenueSummaryDTO summary = reportBLL.GetSummary(fromDate, toDate);
                lblTotalRevenueValue.Text = string.Format("{0:N0} VNĐ", summary.TotalRevenue);
                lblTotalBookingsValue.Text = summary.TotalBookings.ToString();
                lblTotalTicketsValue.Text = summary.TotalTickets.ToString();
                lblTotalCustomersValue.Text = summary.TotalCustomers.ToString();
                lblBestMovieValue.Text = summary.BestSellingMovie ?? "Chưa có dữ liệu";
                lblBestRoomValue.Text = summary.MostUsedRoom ?? "Chưa có dữ liệu";

                // Load doanh thu theo ngày
                List<DailyRevenueDTO> dailyRevenue = reportBLL.GetDailyRevenue(fromDate, toDate);
                dgvDaily.DataSource = null;
                dgvDaily.DataSource = dailyRevenue;

                // Load doanh thu theo phim
                List<MovieRevenueDTO> movieRevenue = reportBLL.GetMovieRevenue(fromDate, toDate);
                dgvMovie.DataSource = null;
                dgvMovie.DataSource = movieRevenue;

                // Load doanh thu theo phòng
                List<RoomRevenueDTO> roomRevenue = reportBLL.GetRoomRevenue(fromDate, toDate);
                dgvRoom.DataSource = null;
                dgvRoom.DataSource = roomRevenue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveDialog.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Ghi header
                        writer.WriteLine("BÁO CÁO DOANH THU");
                        writer.WriteLine($"Từ ngày: {dtpFromDate.Value:dd/MM/yyyy} - Đến ngày: {dtpToDate.Value:dd/MM/yyyy}");
                        writer.WriteLine();

                        // Ghi tổng quan
                        writer.WriteLine("TỔNG QUAN");
                        writer.WriteLine($"Tổng doanh thu,{lblTotalRevenueValue.Text}");
                        writer.WriteLine($"Tổng đơn đặt,{lblTotalBookingsValue.Text}");
                        writer.WriteLine($"Tổng vé bán,{lblTotalTicketsValue.Text}");
                        writer.WriteLine($"Số khách hàng,{lblTotalCustomersValue.Text}");
                        writer.WriteLine($"Phim bán chạy nhất,{lblBestMovieValue.Text}");
                        writer.WriteLine($"Phòng chiếu nhiều nhất,{lblBestRoomValue.Text}");
                        writer.WriteLine();

                        // Ghi chi tiết theo ngày
                        writer.WriteLine("CHI TIẾT THEO NGÀY");
                        writer.WriteLine("Ngày,Số đơn,Số vé,Doanh thu");
                        foreach (DataGridViewRow row in dgvDaily.Rows)
                        {
                            if (row.DataBoundItem is DailyRevenueDTO item)
                            {
                                writer.WriteLine($"{item.Date:dd/MM/yyyy},{item.TotalBookings},{item.TotalTickets},{item.TotalRevenue}");
                            }
                        }
                        writer.WriteLine();

                        // Ghi chi tiết theo phim
                        writer.WriteLine("CHI TIẾT THEO PHIM");
                        writer.WriteLine("Tên phim,Số đơn,Số vé,Doanh thu");
                        foreach (DataGridViewRow row in dgvMovie.Rows)
                        {
                            if (row.DataBoundItem is MovieRevenueDTO item)
                            {
                                writer.WriteLine($"{item.MovieTitle},{item.TotalBookings},{item.TotalTickets},{item.TotalRevenue}");
                            }
                        }
                        writer.WriteLine();

                        // Ghi chi tiết theo phòng
                        writer.WriteLine("CHI TIẾT THEO PHÒNG");
                        writer.WriteLine("Phòng chiếu,Số suất chiếu,Số vé,Doanh thu");
                        foreach (DataGridViewRow row in dgvRoom.Rows)
                        {
                            if (row.DataBoundItem is RoomRevenueDTO item)
                            {
                                writer.WriteLine($"{item.RoomName},{item.TotalShowtimes},{item.TotalTickets},{item.TotalRevenue}");
                            }
                        }
                    }

                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
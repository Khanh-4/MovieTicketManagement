using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmStatistics : Form
    {
        private ReportBLL reportBLL = new ReportBLL();

        public frmStatistics()
        {
            InitializeComponent();
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            // Mặc định: tháng hiện tại
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            SetupDataGridViews();
            LoadStatistics();
        }

        // Cấu hình DataGridView
        private void SetupDataGridViews()
        {
            // DataGridView doanh thu theo ngày
            dgvDailyRevenue.AutoGenerateColumns = false;
            dgvDailyRevenue.Columns.Clear();

            dgvDailyRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Ngày",
                DataPropertyName = "Date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvDailyRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalBookings",
                HeaderText = "Số đơn",
                DataPropertyName = "TotalBookings",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDailyRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalTickets",
                HeaderText = "Số vé",
                DataPropertyName = "TotalTickets",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDailyRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalRevenue",
                HeaderText = "Doanh thu",
                DataPropertyName = "TotalRevenue",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // DataGridView doanh thu theo phim
            dgvMovieRevenue.AutoGenerateColumns = false;
            dgvMovieRevenue.Columns.Clear();

            dgvMovieRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rank",
                HeaderText = "#",
                Width = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvMovieRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MovieTitle",
                HeaderText = "Tên phim",
                DataPropertyName = "MovieTitle",
                Width = 180
            });

            dgvMovieRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalTickets",
                HeaderText = "Số vé",
                DataPropertyName = "TotalTickets",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvMovieRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalRevenue",
                HeaderText = "Doanh thu",
                DataPropertyName = "TotalRevenue",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        // Load thống kê
        private void LoadStatistics()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Load tổng quan
                LoadSummary(fromDate, toDate);

                // Load doanh thu theo ngày
                LoadDailyRevenue(fromDate, toDate);

                // Load doanh thu theo phim
                LoadMovieRevenue(fromDate, toDate);

                // Vẽ biểu đồ
                DrawChart(fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load tổng quan
        private void LoadSummary(DateTime fromDate, DateTime toDate)
        {
            RevenueSummaryDTO summary = reportBLL.GetSummary(fromDate, toDate);

            lblTotalRevenue.Text = summary.TotalRevenue.ToString("N0") + " VNĐ";
            lblTotalTickets.Text = summary.TotalTickets.ToString("N0") + " vé";
            lblTotalBookings.Text = summary.TotalBookings.ToString("N0") + " đơn";
            lblTotalCustomers.Text = summary.TotalCustomers.ToString("N0") + " khách";
            lblBestMovie.Text = summary.BestSellingMovie;
            lblMostUsedRoom.Text = summary.MostUsedRoom;
        }

        // Load doanh thu theo ngày
        private void LoadDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            List<DailyRevenueDTO> dailyRevenue = reportBLL.GetDailyRevenue(fromDate, toDate);
            dgvDailyRevenue.DataSource = null;
            dgvDailyRevenue.DataSource = dailyRevenue;
        }

        // Load doanh thu theo phim
        private void LoadMovieRevenue(DateTime fromDate, DateTime toDate)
        {
            List<MovieRevenueDTO> movieRevenue = reportBLL.GetMovieRevenue(fromDate, toDate);
            dgvMovieRevenue.DataSource = null;
            dgvMovieRevenue.DataSource = movieRevenue;

            // Thêm số thứ tự
            for (int i = 0; i < dgvMovieRevenue.Rows.Count; i++)
            {
                dgvMovieRevenue.Rows[i].Cells["Rank"].Value = i + 1;
            }
        }

        // Vẽ biểu đồ đơn giản bằng Panel
        private void DrawChart(DateTime fromDate, DateTime toDate)
        {
            List<DailyRevenueDTO> dailyRevenue = reportBLL.GetDailyRevenue(fromDate, toDate);

            // Xóa các bar cũ
            pnlChart.Controls.Clear();

            if (dailyRevenue.Count == 0)
            {
                Label lblNoData = new Label
                {
                    Text = "Không có dữ liệu",
                    AutoSize = false,
                    Size = new Size(pnlChart.Width, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, pnlChart.Height / 2 - 15)
                };
                pnlChart.Controls.Add(lblNoData);
                return;
            }

            // Tìm giá trị max để scale
            decimal maxValue = dailyRevenue.Max(r => r.TotalRevenue);
            if (maxValue == 0) maxValue = 1;

            int barWidth = Math.Max(20, (pnlChart.Width - 40) / Math.Min(dailyRevenue.Count, 15));
            int maxBarHeight = pnlChart.Height - 50;
            int startX = 10;

            // Chỉ hiển thị tối đa 15 ngày gần nhất
            var displayData = dailyRevenue.TakeLast(15).ToList();

            for (int i = 0; i < displayData.Count; i++)
            {
                var item = displayData[i];
                int barHeight = (int)((double)item.TotalRevenue / (double)maxValue * maxBarHeight);
                barHeight = Math.Max(barHeight, 5);

                // Bar
                Panel bar = new Panel
                {
                    BackColor = Color.RoyalBlue,
                    Size = new Size(barWidth - 5, barHeight),
                    Location = new Point(startX + i * barWidth, maxBarHeight - barHeight + 10)
                };

                // Tooltip
                ToolTip tip = new ToolTip();
                tip.SetToolTip(bar, $"{item.Date:dd/MM}\n{item.TotalRevenue:N0} VNĐ\n{item.TotalTickets} vé");

                // Label ngày
                Label lblDate = new Label
                {
                    Text = item.Date.ToString("dd"),
                    Size = new Size(barWidth - 5, 20),
                    Location = new Point(startX + i * barWidth, maxBarHeight + 15),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 7)
                };

                pnlChart.Controls.Add(bar);
                pnlChart.Controls.Add(lblDate);
            }
        }

        // Nút Xem thống kê
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        // Nút Xuất CSV
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = $"ThongKe_{dtpFromDate.Value:yyyyMMdd}_{dtpToDate.Value:yyyyMMdd}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Header
                        sw.WriteLine("BÁO CÁO THỐNG KÊ DOANH THU");
                        sw.WriteLine($"Từ ngày: {dtpFromDate.Value:dd/MM/yyyy} - Đến ngày: {dtpToDate.Value:dd/MM/yyyy}");
                        sw.WriteLine();

                        // Tổng quan
                        sw.WriteLine("TỔNG QUAN");
                        sw.WriteLine($"Tổng doanh thu,{lblTotalRevenue.Text}");
                        sw.WriteLine($"Tổng số vé,{lblTotalTickets.Text}");
                        sw.WriteLine($"Tổng số đơn,{lblTotalBookings.Text}");
                        sw.WriteLine($"Tổng khách hàng,{lblTotalCustomers.Text}");
                        sw.WriteLine($"Phim bán chạy nhất,{lblBestMovie.Text}");
                        sw.WriteLine($"Phòng chiếu nhiều nhất,{lblMostUsedRoom.Text}");
                        sw.WriteLine();

                        // Doanh thu theo ngày
                        sw.WriteLine("DOANH THU THEO NGÀY");
                        sw.WriteLine("Ngày,Số đơn,Số vé,Doanh thu");

                        foreach (DataGridViewRow row in dgvDailyRevenue.Rows)
                        {
                            if (row.DataBoundItem is DailyRevenueDTO item)
                            {
                                sw.WriteLine($"{item.Date:dd/MM/yyyy},{item.TotalBookings},{item.TotalTickets},{item.TotalRevenue}");
                            }
                        }

                        sw.WriteLine();

                        // Doanh thu theo phim
                        sw.WriteLine("DOANH THU THEO PHIM");
                        sw.WriteLine("STT,Tên phim,Số vé,Doanh thu");

                        int rank = 1;
                        foreach (DataGridViewRow row in dgvMovieRevenue.Rows)
                        {
                            if (row.DataBoundItem is MovieRevenueDTO item)
                            {
                                sw.WriteLine($"{rank},{item.MovieTitle},{item.TotalTickets},{item.TotalRevenue}");
                                rank++;
                            }
                        }
                    }

                    MessageBox.Show("Xuất file thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
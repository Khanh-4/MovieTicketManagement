using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmShowtimeManagement : Form
    {
        private readonly ShowtimeBLL showtimeBLL = new ShowtimeBLL();
        private int selectedShowtimeId = 0;
        private int selectedMovieDuration = 120;

        public frmShowtimeManagement()
        {
            InitializeComponent();
        }

        private void frmShowtimeManagement_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadRooms();
            LoadShowtimes();
            SetupDataGridView();
            ClearForm();
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvShowtimes.AutoGenerateColumns = false;
            dgvShowtimes.Columns.Clear();

            dgvShowtimes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ShowtimeID",
                HeaderText = "ID",
                DataPropertyName = "ShowtimeID",
                Width = 50
            });

            dgvShowtimes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MovieTitle",
                HeaderText = "Phim",
                DataPropertyName = "MovieTitle",
                Width = 180
            });

            dgvShowtimes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomName",
                HeaderText = "Phòng",
                DataPropertyName = "RoomName",
                Width = 80
            });

            dgvShowtimes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartTime",
                HeaderText = "Bắt đầu",
                DataPropertyName = "StartTime",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvShowtimes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BasePrice",
                HeaderText = "Giá vé",
                DataPropertyName = "BasePrice",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvShowtimes.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Hoạt động",
                DataPropertyName = "IsActive",
                Width = 70
            });
        }

        // Load danh sách phim
        private void LoadMovies()
        {
            try
            {
                List<MovieDTO> movies = showtimeBLL.GetAllMovies();
                cboMovies.DataSource = null;
                cboMovies.DisplayMember = "Title";
                cboMovies.ValueMember = "MovieID";
                cboMovies.DataSource = movies;
                cboMovies.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách phòng
        private void LoadRooms()
        {
            try
            {
                List<RoomDTO> rooms = showtimeBLL.GetAllRooms();
                cboRooms.DataSource = null;
                cboRooms.DisplayMember = "RoomName";
                cboRooms.ValueMember = "RoomID";
                cboRooms.DataSource = rooms;
                cboRooms.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách suất chiếu
        private void LoadShowtimes()
        {
            try
            {
                List<ShowtimeDTO> showtimes = showtimeBLL.GetAll();
                dgvShowtimes.DataSource = null;
                dgvShowtimes.DataSource = showtimes;
                lblStatus.Text = $"Tổng số: {showtimes.Count} suất chiếu";
                lblStatus.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách suất chiếu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi chọn phim -> cập nhật thời lượng
        private void cboMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMovies.SelectedIndex >= 0)
            {
                MovieDTO movie = cboMovies.SelectedItem as MovieDTO;
                if (movie != null)
                {
                    selectedMovieDuration = movie.Duration;
                    nudDuration.Value = movie.Duration;
                    UpdateEndTime();
                }
            }
        }

        // Khi thay đổi ngày bắt đầu
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndTime();
        }

        // Khi thay đổi giờ bắt đầu
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndTime();
        }

        // Cập nhật thời gian kết thúc
        private void UpdateEndTime()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            DateTime startDateTime = startDate.Add(startTime);
            DateTime endDateTime = startDateTime.AddMinutes((double)nudDuration.Value);

            lblEndTimeValue.Text = endDateTime.ToString("dd/MM/yyyy HH:mm");
        }

        // Xóa form
        private void ClearForm()
        {
            selectedShowtimeId = 0;
            cboMovies.SelectedIndex = -1;
            cboRooms.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now.Date.AddDays(1);
            dtpStartTime.Value = DateTime.Parse("18:00");
            nudDuration.Value = 120;
            nudPrice.Value = 85000;
            chkIsActive.Checked = true;
            lblEndTimeValue.Text = "";

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        // Hiển thị thông tin suất chiếu lên form
        private void DisplayShowtimeInfo(ShowtimeDTO showtime)
        {
            selectedShowtimeId = showtime.ShowtimeID;

            // Chọn phim
            for (int i = 0; i < cboMovies.Items.Count; i++)
            {
                MovieDTO movie = cboMovies.Items[i] as MovieDTO;
                if (movie != null && movie.MovieID == showtime.MovieID)
                {
                    cboMovies.SelectedIndex = i;
                    break;
                }
            }

            // Chọn phòng
            for (int i = 0; i < cboRooms.Items.Count; i++)
            {
                RoomDTO room = cboRooms.Items[i] as RoomDTO;
                if (room != null && room.RoomID == showtime.RoomID)
                {
                    cboRooms.SelectedIndex = i;
                    break;
                }
            }

            dtpStartDate.Value = showtime.StartTime.Date;
            dtpStartTime.Value = showtime.StartTime;
            nudPrice.Value = showtime.BasePrice;
            chkIsActive.Checked = showtime.IsActive;

            // Tính thời lượng từ StartTime và EndTime
            TimeSpan duration = showtime.EndTime - showtime.StartTime;
            nudDuration.Value = (decimal)duration.TotalMinutes;

            UpdateEndTime();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        // Lấy thông tin từ form
        private ShowtimeDTO GetShowtimeFromForm()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            DateTime startDateTime = startDate.Add(startTime);
            DateTime endDateTime = startDateTime.AddMinutes((double)nudDuration.Value);

            MovieDTO selectedMovie = cboMovies.SelectedItem as MovieDTO;
            RoomDTO selectedRoom = cboRooms.SelectedItem as RoomDTO;

            return new ShowtimeDTO
            {
                ShowtimeID = selectedShowtimeId,
                MovieID = selectedMovie?.MovieID ?? 0,
                RoomID = selectedRoom?.RoomID ?? 0,
                StartTime = startDateTime,
                EndTime = endDateTime,
                BasePrice = nudPrice.Value,
                IsActive = chkIsActive.Checked
            };
        }

        // Click vào dòng trong DataGridView
        private void dgvShowtimes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvShowtimes.Rows.Count)
            {
                DataGridViewRow row = dgvShowtimes.Rows[e.RowIndex];
                if (row.DataBoundItem is ShowtimeDTO showtime)
                {
                    DisplayShowtimeInfo(showtime);
                }
            }
        }

        // Thêm suất chiếu mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate
            if (cboMovies.SelectedIndex < 0)
            {
                lblStatus.Text = "Vui lòng chọn phim!";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (cboRooms.SelectedIndex < 0)
            {
                lblStatus.Text = "Vui lòng chọn phòng chiếu!";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            try
            {
                ShowtimeDTO showtime = GetShowtimeFromForm();
                var result = showtimeBLL.AddShowtime(showtime);

                if (result.success)
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = Color.Green;
                    LoadShowtimes();
                    ClearForm();
                    MessageBox.Show(result.message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show(result.message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm suất chiếu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật suất chiếu
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedShowtimeId == 0)
            {
                lblStatus.Text = "Vui lòng chọn suất chiếu cần cập nhật!";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (cboMovies.SelectedIndex < 0)
            {
                lblStatus.Text = "Vui lòng chọn phim!";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            if (cboRooms.SelectedIndex < 0)
            {
                lblStatus.Text = "Vui lòng chọn phòng chiếu!";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            try
            {
                ShowtimeDTO showtime = GetShowtimeFromForm();
                var result = showtimeBLL.UpdateShowtime(showtime);

                if (result.success)
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = Color.Green;
                    LoadShowtimes();
                    MessageBox.Show(result.message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show(result.message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật suất chiếu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa suất chiếu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedShowtimeId == 0)
            {
                lblStatus.Text = "Vui lòng chọn suất chiếu cần xóa!";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa suất chiếu này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var result = showtimeBLL.DeleteShowtime(selectedShowtimeId);

                    if (result.success)
                    {
                        lblStatus.Text = result.message;
                        lblStatus.ForeColor = Color.Green;
                        LoadShowtimes();
                        ClearForm();
                        MessageBox.Show(result.message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblStatus.Text = result.message;
                        lblStatus.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa suất chiếu: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblStatus.Text = "";
        }
    }
}
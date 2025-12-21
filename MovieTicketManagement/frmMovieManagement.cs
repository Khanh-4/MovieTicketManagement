using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmMovieManagement : Form
    {
        private readonly MovieBLL movieBLL = new MovieBLL();
        private int selectedMovieId = 0;

        public frmMovieManagement()
        {
            InitializeComponent();
        }

        private void frmMovieManagement_Load(object sender, EventArgs e)
        {
            LoadMovies();
            SetupDataGridView();
            ClearForm();
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvMovies.AutoGenerateColumns = false;
            dgvMovies.Columns.Clear();

            // Thêm các cột
            dgvMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MovieID",
                HeaderText = "ID",
                DataPropertyName = "MovieID",
                Width = 50
            });

            dgvMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Tên phim",
                DataPropertyName = "Title",
                Width = 200
            });

            dgvMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Duration",
                HeaderText = "Thời lượng",
                DataPropertyName = "Duration",
                Width = 80
            });

            dgvMovies.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Director",
                HeaderText = "Đạo diễn",
                DataPropertyName = "Director",
                Width = 120
            });

            dgvMovies.Columns.Add(new DataGridViewCheckBoxColumn
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
                List<MovieDTO> movies = movieBLL.GetAll();
                dgvMovies.DataSource = null;
                dgvMovies.DataSource = movies;
                lblStatus.Text = $"Tổng số: {movies.Count} phim";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa form nhập liệu
        private void ClearForm()
        {
            selectedMovieId = 0;
            txtMovieTitle.Clear();
            nudDuration.Value = 90;
            txtDirector.Clear();
            txtActors.Clear();
            txtCountry.Clear();
            dtpReleaseDate.Value = DateTime.Now;
            nudAgeRating.Value = 13;
            txtDescription.Clear();
            chkIsActive.Checked = true;
            chkIsTrending.Checked = false;

            txtMovieTitle.Focus();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        // Hiển thị thông tin phim lên form
        private void DisplayMovieInfo(MovieDTO movie)
        {
            selectedMovieId = movie.MovieID;
            txtMovieTitle.Text = movie.Title;
            nudDuration.Value = movie.Duration;
            txtDirector.Text = movie.Director ?? "";
            txtActors.Text = movie.Actors ?? "";
            txtCountry.Text = movie.Country ?? "";
            dtpReleaseDate.Value = movie.ReleaseDate ?? DateTime.Now;
            nudAgeRating.Value = movie.AgeRating;
            txtDescription.Text = movie.Description ?? "";
            chkIsActive.Checked = movie.IsActive;
            chkIsTrending.Checked = movie.IsTrending;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        // Lấy thông tin phim từ form
        private MovieDTO GetMovieFromForm()
        {
            return new MovieDTO
            {
                MovieID = selectedMovieId,
                Title = txtMovieTitle.Text.Trim(),
                Duration = (int)nudDuration.Value,
                Director = txtDirector.Text.Trim(),
                Actors = txtActors.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                ReleaseDate = dtpReleaseDate.Value,
                AgeRating = (int)nudAgeRating.Value,
                Description = txtDescription.Text.Trim(),
                IsActive = chkIsActive.Checked,
                IsTrending = chkIsTrending.Checked
            };
        }

        // Sự kiện click vào dòng trong DataGridView
        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMovies.Rows.Count)
            {
                DataGridViewRow row = dgvMovies.Rows[e.RowIndex];
                if (row.DataBoundItem is MovieDTO movie)
                {
                    DisplayMovieInfo(movie);
                }
            }
        }

        // Tìm kiếm phim
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                List<MovieDTO> movies = movieBLL.Search(keyword);
                dgvMovies.DataSource = null;
                dgvMovies.DataSource = movies;
                lblStatus.Text = $"Tìm thấy: {movies.Count} phim";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới danh sách
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMovies();
            ClearForm();
        }

        // Thêm phim mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtMovieTitle.Text))
            {
                lblStatus.Text = "Vui lòng nhập tên phim!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                txtMovieTitle.Focus();
                return;
            }

            try
            {
                MovieDTO movie = GetMovieFromForm();
                var result = movieBLL.AddMovie(movie, null);

                if (result.success)
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    LoadMovies();
                    ClearForm();
                    MessageBox.Show(result.message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật phim
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMovieId == 0)
            {
                lblStatus.Text = "Vui lòng chọn phim cần cập nhật!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMovieTitle.Text))
            {
                lblStatus.Text = "Vui lòng nhập tên phim!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                txtMovieTitle.Focus();
                return;
            }

            try
            {
                MovieDTO movie = GetMovieFromForm();
                var result = movieBLL.UpdateMovie(movie, null);

                if (result.success)
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    LoadMovies();
                    MessageBox.Show(result.message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = result.message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa phim
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMovieId == 0)
            {
                lblStatus.Text = "Vui lòng chọn phim cần xóa!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa phim '{txtMovieTitle.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var result = movieBLL.DeleteMovie(selectedMovieId);

                    if (result.success)
                    {
                        lblStatus.Text = result.message;
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        LoadMovies();
                        ClearForm();
                        MessageBox.Show(result.message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblStatus.Text = result.message;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phim: {ex.Message}", "Lỗi",
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
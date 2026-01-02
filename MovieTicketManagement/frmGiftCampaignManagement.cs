using MovieTicket.BLL;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    public partial class frmGiftCampaignManagement : Form
    {
        private readonly GiftBLL giftBLL = new GiftBLL();
        private readonly MovieBLL movieBLL = new MovieBLL();
        private UserDTO currentUser;
        private List<GiftCampaignDTO> campaigns;
        private GiftCampaignDTO selectedCampaign;

        public frmGiftCampaignManagement(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmGiftCampaignManagement_Load(object sender, EventArgs e)
        {
            SetupForm();
            LoadMovies();
            LoadCampaigns();
            ClearInputs();
        }

        #region Setup

        private void SetupForm()
        {
            // Setup DataGridView
            dgvCampaigns.AutoGenerateColumns = false;
            dgvCampaigns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCampaigns.MultiSelect = false;
            dgvCampaigns.ReadOnly = true;
            dgvCampaigns.AllowUserToAddRows = false;
            dgvCampaigns.AllowUserToDeleteRows = false;
            dgvCampaigns.RowHeadersVisible = false;
            dgvCampaigns.BackgroundColor = Color.White;
            dgvCampaigns.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvCampaigns.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Tạo columns
            dgvCampaigns.Columns.Clear();
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colID",
                HeaderText = "ID",
                DataPropertyName = "CampaignID",
                Width = 50
            });
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Tên chiến dịch",
                DataPropertyName = "CampaignName",
                Width = 180
            });
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGiftName",
                HeaderText = "Quà tặng",
                DataPropertyName = "GiftName",
                Width = 120
            });
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMovie",
                HeaderText = "Áp dụng",
                DataPropertyName = "ApplyToText",
                Width = 120
            });
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGiftStatus",
                HeaderText = "Còn lại",
                DataPropertyName = "GiftStatusText",
                Width = 100
            });
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaxPerUser",
                HeaderText = "Max/User",
                DataPropertyName = "MaxPerUser",
                Width = 70
            });
            dgvCampaigns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "StatusText",
                Width = 100
            });

            // Default values
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            nudTotalGifts.Minimum = 1;
            nudTotalGifts.Maximum = 10000;
            nudTotalGifts.Value = 100;
            nudMaxPerUser.Minimum = 1;
            nudMaxPerUser.Maximum = 100;
            nudMaxPerUser.Value = 1;
            nudHoldTimeout.Minimum = 1;
            nudHoldTimeout.Maximum = 60;
            nudHoldTimeout.Value = 10;
            chkIsActive.Checked = true;
        }

        private void LoadMovies()
        {
            try
            {
                var movies = movieBLL.GetAll();

                // Thêm option "Tất cả phim"
                movies.Insert(0, new MovieDTO { MovieID = 0, Title = "-- Tất cả phim --" });

                cboMovie.DataSource = null;
                cboMovie.DisplayMember = "Title";
                cboMovie.ValueMember = "MovieID";
                cboMovie.DataSource = movies;
                cboMovie.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCampaigns()
        {
            try
            {
                campaigns = giftBLL.GetAllCampaigns();
                dgvCampaigns.DataSource = null;
                dgvCampaigns.DataSource = campaigns;

                lblTotalCampaigns.Text = $"Tổng: {campaigns.Count} chiến dịch";

                // Tô màu theo trạng thái
                foreach (DataGridViewRow row in dgvCampaigns.Rows)
                {
                    var campaign = row.DataBoundItem as GiftCampaignDTO;
                    if (campaign != null)
                    {
                        if (!campaign.IsActive)
                            row.DefaultCellStyle.ForeColor = Color.Gray;
                        else if (campaign.RemainingGifts <= 0)
                            row.DefaultCellStyle.ForeColor = Color.Red;
                        else if (campaign.IsRunning)
                            row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chiến dịch: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void dgvCampaigns_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCampaigns.CurrentRow != null && dgvCampaigns.CurrentRow.DataBoundItem != null)
            {
                selectedCampaign = dgvCampaigns.CurrentRow.DataBoundItem as GiftCampaignDTO;
                DisplayCampaignDetails(selectedCampaign);
            }
        }

        private void DisplayCampaignDetails(GiftCampaignDTO campaign)
        {
            if (campaign == null) return;

            txtCampaignName.Text = campaign.CampaignName;
            txtGiftName.Text = campaign.GiftName;
            txtDescription.Text = campaign.Description;

            // Chọn phim
            if (campaign.MovieID.HasValue && campaign.MovieID.Value > 0)
                cboMovie.SelectedValue = campaign.MovieID.Value;
            else
                cboMovie.SelectedIndex = 0;

            nudTotalGifts.Value = campaign.TotalGifts;
            nudMaxPerUser.Value = campaign.MaxPerUser;
            nudHoldTimeout.Value = campaign.HoldTimeoutMinutes;
            dtpStartDate.Value = campaign.StartDate;
            dtpEndDate.Value = campaign.EndDate;
            chkIsActive.Checked = campaign.IsActive;

            // Hiển thị thông tin bổ sung
            lblRemainingGifts.Text = $"Còn lại: {campaign.RemainingGifts}/{campaign.TotalGifts} quà";
            lblHoldingGifts.Text = $"Đang giữ: {campaign.HoldingGifts} quà";
            lblConfirmedGifts.Text = $"Đã xác nhận: {campaign.ConfirmedGifts} quà";
            lblCampaignStatus.Text = $"Trạng thái: {campaign.StatusText}";
            lblTimeRemaining.Text = campaign.TimeRemainingText;

            // Đổi màu trạng thái
            lblCampaignStatus.ForeColor = campaign.IsRunning ? Color.Green :
                (campaign.RemainingGifts <= 0 ? Color.Red : Color.Gray);

            btnUpdate.Enabled = true;
            btnToggleActive.Enabled = true;
            btnToggleActive.Text = campaign.IsActive ? "Tạm dừng" : "Kích hoạt";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var campaign = new GiftCampaignDTO
            {
                CampaignName = txtCampaignName.Text.Trim(),
                GiftName = txtGiftName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                MovieID = (int)cboMovie.SelectedValue == 0 ? null : (int?)cboMovie.SelectedValue,
                TotalGifts = (int)nudTotalGifts.Value,
                MaxPerUser = (int)nudMaxPerUser.Value,
                HoldTimeoutMinutes = (int)nudHoldTimeout.Value,
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                IsActive = chkIsActive.Checked,
                CreatedBy = currentUser.UserID
            };

            var (success, message, campaignId) = giftBLL.AddCampaign(campaign);

            if (success)
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCampaigns();
                ClearInputs();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCampaign == null)
            {
                MessageBox.Show("Vui lòng chọn chiến dịch cần cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            selectedCampaign.CampaignName = txtCampaignName.Text.Trim();
            selectedCampaign.GiftName = txtGiftName.Text.Trim();
            selectedCampaign.Description = txtDescription.Text.Trim();
            selectedCampaign.MovieID = (int)cboMovie.SelectedValue == 0 ? null : (int?)cboMovie.SelectedValue;
            selectedCampaign.TotalGifts = (int)nudTotalGifts.Value;
            selectedCampaign.MaxPerUser = (int)nudMaxPerUser.Value;
            selectedCampaign.HoldTimeoutMinutes = (int)nudHoldTimeout.Value;
            selectedCampaign.StartDate = dtpStartDate.Value;
            selectedCampaign.EndDate = dtpEndDate.Value;
            selectedCampaign.IsActive = chkIsActive.Checked;

            var (success, message) = giftBLL.UpdateCampaign(selectedCampaign);

            if (success)
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCampaigns();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (selectedCampaign == null)
            {
                MessageBox.Show("Vui lòng chọn chiến dịch!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool newStatus = !selectedCampaign.IsActive;
            string action = newStatus ? "kích hoạt" : "tạm dừng";

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn {action} chiến dịch \"{selectedCampaign.CampaignName}\"?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (success, message) = giftBLL.SetCampaignActive(selectedCampaign.CampaignID, newStatus);

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCampaigns();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCampaigns();

            // Giải phóng reservation hết hạn
            int released = giftBLL.ReleaseExpiredReservations();
            if (released > 0)
            {
                MessageBox.Show($"Đã giải phóng {released} giữ chỗ quà hết hạn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCampaigns();
            }
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            if (selectedCampaign == null)
            {
                MessageBox.Show("Vui lòng chọn chiến dịch để xem thống kê!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thống kê chi tiết
            string stats = $"═══ THỐNG KÊ CHIẾN DỊCH ═══\n\n" +
                          $"Tên: {selectedCampaign.CampaignName}\n" +
                          $"Quà tặng: {selectedCampaign.GiftName}\n" +
                          $"Áp dụng: {selectedCampaign.ApplyToText}\n\n" +
                          $"───────────────────────\n" +
                          $"Tổng số quà: {selectedCampaign.TotalGifts}\n" +
                          $"Còn lại: {selectedCampaign.RemainingGifts}\n" +
                          $"Đang giữ: {selectedCampaign.HoldingGifts}\n" +
                          $"Đã xác nhận: {selectedCampaign.ConfirmedGifts}\n" +
                          $"───────────────────────\n" +
                          $"Tỷ lệ còn: {selectedCampaign.RemainingPercentage:F1}%\n" +
                          $"Trạng thái: {selectedCampaign.StatusText}\n" +
                          $"Thời gian: {selectedCampaign.TimeRemainingText}\n" +
                          $"───────────────────────\n" +
                          $"Bắt đầu: {selectedCampaign.StartDate:dd/MM/yyyy HH:mm}\n" +
                          $"Kết thúc: {selectedCampaign.EndDate:dd/MM/yyyy HH:mm}";

            MessageBox.Show(stats, "Thống kê chiến dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Helper Methods

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCampaignName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chiến dịch!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCampaignName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGiftName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên quà tặng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiftName.Focus();
                return false;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtCampaignName.Text = "";
            txtGiftName.Text = "";
            txtDescription.Text = "";
            cboMovie.SelectedIndex = 0;
            nudTotalGifts.Value = 100;
            nudMaxPerUser.Value = 1;
            nudHoldTimeout.Value = 10;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            chkIsActive.Checked = true;

            selectedCampaign = null;
            btnUpdate.Enabled = false;
            btnToggleActive.Enabled = false;

            lblRemainingGifts.Text = "Còn lại: --";
            lblHoldingGifts.Text = "Đang giữ: --";
            lblConfirmedGifts.Text = "Đã xác nhận: --";
            lblCampaignStatus.Text = "Trạng thái: --";
            lblTimeRemaining.Text = "";

            dgvCampaigns.ClearSelection();
        }

        #endregion
    }
}
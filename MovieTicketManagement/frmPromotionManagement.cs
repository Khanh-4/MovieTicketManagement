using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmPromotionManagement : Form
    {
        private PromotionBLL promotionBLL = new PromotionBLL();
        private int selectedPromotionId = 0;
        private bool isAddMode = true;

        public frmPromotionManagement()
        {
            InitializeComponent();
        }

        private void frmPromotionManagement_Load(object sender, EventArgs e)
        {
            LoadDiscountTypes();
            SetupDataGridView();
            LoadPromotions();
            SetAddMode();
        }

        // Load danh sách loại giảm giá
        private void LoadDiscountTypes()
        {
            cboDiscountType.Items.Clear();
            cboDiscountType.Items.Add("Percent");   // Giảm theo %
            cboDiscountType.Items.Add("Amount");    // Giảm số tiền cố định
            cboDiscountType.SelectedIndex = 0;
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.Columns.Clear();

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PromotionID",
                HeaderText = "ID",
                DataPropertyName = "PromotionID",
                Width = 40
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PromotionCode",
                HeaderText = "Mã KM",
                DataPropertyName = "PromotionCode",
                Width = 90
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PromotionName",
                HeaderText = "Tên khuyến mãi",
                DataPropertyName = "PromotionName",
                Width = 140
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountType",
                HeaderText = "Loại",
                DataPropertyName = "DiscountType",
                Width = 70
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountValue",
                HeaderText = "Giá trị",
                DataPropertyName = "DiscountValue",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                HeaderText = "Bắt đầu",
                DataPropertyName = "StartDate",
                Width = 85,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EndDate",
                HeaderText = "Kết thúc",
                DataPropertyName = "EndDate",
                Width = 85,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "SL",
                DataPropertyName = "Quantity",
                Width = 50
            });

            dgvPromotions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UsedCount",
                HeaderText = "Đã dùng",
                DataPropertyName = "UsedCount",
                Width = 65
            });

            dgvPromotions.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Hoạt động",
                DataPropertyName = "IsActive",
                Width = 70
            });
        }

        // Load danh sách khuyến mãi
        private void LoadPromotions()
        {
            try
            {
                List<PromotionDTO> promotions = promotionBLL.GetAll();
                dgvPromotions.DataSource = null;
                dgvPromotions.DataSource = promotions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khuyến mãi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi click vào dòng trong DataGridView
        private void dgvPromotions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPromotions.Rows.Count)
            {
                DataGridViewRow row = dgvPromotions.Rows[e.RowIndex];
                if (row.DataBoundItem is PromotionDTO promotion)
                {
                    selectedPromotionId = promotion.PromotionID;
                    DisplayPromotionInfo(promotion);
                    SetEditMode();
                }
            }
        }

        // Hiển thị thông tin khuyến mãi lên form
        private void DisplayPromotionInfo(PromotionDTO promotion)
        {
            txtCode.Text = promotion.PromotionCode;
            txtName.Text = promotion.PromotionName;
            cboDiscountType.SelectedItem = promotion.DiscountType;
            nudDiscountValue.Value = promotion.DiscountValue;
            nudMinOrder.Value = promotion.MinOrderAmount;
            nudMaxDiscount.Value = promotion.MaxDiscountAmount ?? 0;
            dtpStartDate.Value = promotion.StartDate;
            dtpEndDate.Value = promotion.EndDate;
            nudQuantity.Value = promotion.Quantity;
            lblUsedCountValue.Text = promotion.UsedCount.ToString();
            chkIsActive.Checked = promotion.IsActive;
        }

        // Chế độ thêm mới
        private void SetAddMode()
        {
            isAddMode = true;
            selectedPromotionId = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtCode.Enabled = true;
            grpPromotionInfo.Text = "Thông tin khuyến mãi (Thêm mới)";
        }

        // Chế độ chỉnh sửa
        private void SetEditMode()
        {
            isAddMode = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            txtCode.Enabled = false; // Không cho sửa mã KM
            grpPromotionInfo.Text = "Thông tin khuyến mãi (Chỉnh sửa)";
        }

        // Xóa form
        private void ClearForm()
        {
            txtCode.Text = "";
            txtName.Text = "";
            cboDiscountType.SelectedIndex = 0;
            nudDiscountValue.Value = 10;
            nudMinOrder.Value = 0;
            nudMaxDiscount.Value = 0;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            nudQuantity.Value = 100;
            lblUsedCountValue.Text = "0";
            chkIsActive.Checked = true;

            selectedPromotionId = 0;
            SetAddMode();
        }

        // Kiểm tra dữ liệu nhập
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (nudDiscountValue.Value <= 0)
            {
                MessageBox.Show("Giá trị giảm phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDiscountValue.Focus();
                return false;
            }

            // Nếu là giảm theo %, giá trị không quá 100
            if (cboDiscountType.SelectedItem.ToString() == "Percent" && nudDiscountValue.Value > 100)
            {
                MessageBox.Show("Giảm theo % không được vượt quá 100!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDiscountValue.Focus();
                return false;
            }

            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQuantity.Focus();
                return false;
            }

            return true;
        }

        // Lấy dữ liệu từ form
        private PromotionDTO GetPromotionFromForm()
        {
            return new PromotionDTO
            {
                PromotionID = selectedPromotionId,
                PromotionCode = txtCode.Text.Trim().ToUpper(),
                PromotionName = txtName.Text.Trim(),
                DiscountType = cboDiscountType.SelectedItem.ToString(),
                DiscountValue = nudDiscountValue.Value,
                MinOrderAmount = nudMinOrder.Value,
                MaxDiscountAmount = nudMaxDiscount.Value > 0 ? nudMaxDiscount.Value : null,
                StartDate = dtpStartDate.Value.Date,
                EndDate = dtpEndDate.Value.Date,
                Quantity = (int)nudQuantity.Value,
                IsActive = chkIsActive.Checked
            };
        }

        // Thêm khuyến mãi mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                PromotionDTO promotion = GetPromotionFromForm();
                int newId = promotionBLL.Insert(promotion);

                if (newId > 0)
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPromotions();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm khuyến mãi thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật khuyến mãi
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPromotionId == 0)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                PromotionDTO promotion = GetPromotionFromForm();
                bool success = promotionBLL.Update(promotion);

                if (success)
                {
                    MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPromotions();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa khuyến mãi
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPromotionId == 0)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa khuyến mãi '{txtName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = promotionBLL.Delete(selectedPromotionId);

                    if (success)
                    {
                        MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPromotions();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khuyến mãi thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Làm mới form
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
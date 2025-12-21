using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmFoodManagement : Form
    {
        private FoodBLL foodBLL = new FoodBLL();
        private int selectedFoodId = 0;
        private bool isAddMode = true;

        public frmFoodManagement()
        {
            InitializeComponent();
        }

        private void frmFoodManagement_Load(object sender, EventArgs e)
        {
            LoadCategories();
            SetupDataGridView();
            LoadFoods();
            SetAddMode();
        }

        // Load danh mục vào ComboBox
        private void LoadCategories()
        {
            try
            {
                List<FoodCategoryDTO> categories = foodBLL.GetAllCategories();

                cboCategory.DataSource = null;
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";
                cboCategory.DataSource = categories;

                if (categories.Count > 0)
                {
                    cboCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvFoods.AutoGenerateColumns = false;
            dgvFoods.Columns.Clear();

            dgvFoods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FoodID",
                HeaderText = "ID",
                DataPropertyName = "FoodID",
                Width = 50
            });

            dgvFoods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FoodName",
                HeaderText = "Tên đồ ăn",
                DataPropertyName = "FoodName",
                Width = 150
            });

            dgvFoods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Danh mục",
                DataPropertyName = "CategoryName",
                Width = 100
            });

            dgvFoods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Giá bán",
                DataPropertyName = "Price",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvFoods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockQuantity",
                HeaderText = "Tồn kho",
                DataPropertyName = "StockQuantity",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvFoods.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Kinh doanh",
                DataPropertyName = "IsActive",
                Width = 80
            });
        }

        // Load danh sách đồ ăn
        private void LoadFoods()
        {
            try
            {
                List<FoodDTO> foods = foodBLL.GetAll();
                dgvFoods.DataSource = null;
                dgvFoods.DataSource = foods;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đồ ăn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi click vào dòng trong DataGridView
        private void dgvFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvFoods.Rows.Count)
            {
                DataGridViewRow row = dgvFoods.Rows[e.RowIndex];
                if (row.DataBoundItem is FoodDTO food)
                {
                    selectedFoodId = food.FoodID;
                    DisplayFoodInfo(food);
                    SetEditMode();
                }
            }
        }

        // Hiển thị thông tin đồ ăn lên form
        private void DisplayFoodInfo(FoodDTO food)
        {
            txtName.Text = food.FoodName;
            cboCategory.SelectedValue = food.CategoryID;
            nudPrice.Value = food.Price;
            nudStock.Value = food.StockQuantity;
            txtDescription.Text = food.Description;
            chkIsActive.Checked = food.IsActive;
        }

        // Chế độ thêm mới
        private void SetAddMode()
        {
            isAddMode = true;
            selectedFoodId = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            grpFoodInfo.Text = "Thông tin đồ ăn (Thêm mới)";
        }

        // Chế độ chỉnh sửa
        private void SetEditMode()
        {
            isAddMode = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            grpFoodInfo.Text = "Thông tin đồ ăn (Chỉnh sửa)";
        }

        // Xóa form
        private void ClearForm()
        {
            txtName.Text = "";
            if (cboCategory.Items.Count > 0)
            {
                cboCategory.SelectedIndex = 0;
            }
            nudPrice.Value = 0;
            nudStock.Value = 100;
            txtDescription.Text = "";
            chkIsActive.Checked = true;

            selectedFoodId = 0;
            SetAddMode();
        }

        // Kiểm tra dữ liệu nhập
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đồ ăn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Giá bán phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPrice.Focus();
                return false;
            }

            return true;
        }

        // Lấy dữ liệu từ form
        private FoodDTO GetFoodFromForm()
        {
            return new FoodDTO
            {
                FoodID = selectedFoodId,
                FoodName = txtName.Text.Trim(),
                CategoryID = Convert.ToInt32(cboCategory.SelectedValue),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                Description = txtDescription.Text.Trim(),
                IsActive = chkIsActive.Checked
            };
        }

        // Thêm đồ ăn mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                FoodDTO food = GetFoodFromForm();
                int newId = foodBLL.Insert(food);

                if (newId > 0)
                {
                    MessageBox.Show("Thêm đồ ăn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoods();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm đồ ăn thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật đồ ăn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedFoodId == 0)
            {
                MessageBox.Show("Vui lòng chọn đồ ăn cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                FoodDTO food = GetFoodFromForm();
                bool success = foodBLL.Update(food);

                if (success)
                {
                    MessageBox.Show("Cập nhật đồ ăn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoods();
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

        // Xóa đồ ăn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedFoodId == 0)
            {
                MessageBox.Show("Vui lòng chọn đồ ăn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa đồ ăn '{txtName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = foodBLL.Delete(selectedFoodId);

                    if (success)
                    {
                        MessageBox.Show("Xóa đồ ăn thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFoods();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đồ ăn thất bại!", "Lỗi",
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
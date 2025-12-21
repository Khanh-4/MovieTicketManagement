using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmStaffManagement : Form
    {
        private UserBLL userBLL = new UserBLL();
        private int selectedUserId = 0;
        private bool isAddMode = true;

        public frmStaffManagement()
        {
            InitializeComponent();
        }

        private void frmStaffManagement_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadStaffList();
            SetAddMode();
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns.Clear();

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserID",
                HeaderText = "ID",
                DataPropertyName = "UserID",
                Width = 50
            });

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Tên đăng nhập",
                DataPropertyName = "Username",
                Width = 120
            });

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Họ và tên",
                DataPropertyName = "FullName",
                Width = 150
            });

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            });

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                HeaderText = "Điện thoại",
                DataPropertyName = "Phone",
                Width = 100
            });

            dgvStaff.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Hoạt động",
                DataPropertyName = "IsActive",
                Width = 70
            });
        }

        // Load danh sách Staff
        private void LoadStaffList()
        {
            try
            {
                List<UserDTO> staffList = userBLL.GetAllStaff();
                dgvStaff.DataSource = null;
                dgvStaff.DataSource = staffList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi click vào dòng trong DataGridView
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvStaff.Rows.Count)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                if (row.DataBoundItem is UserDTO user)
                {
                    selectedUserId = user.UserID;
                    DisplayUserInfo(user);
                    SetEditMode();
                }
            }
        }

        // Hiển thị thông tin user lên form
        private void DisplayUserInfo(UserDTO user)
        {
            txtUsername.Text = user.Username;
            txtPassword.Text = ""; // Không hiển thị password
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
            chkIsActive.Checked = user.IsActive;
            lblCreatedAtValue.Text = user.CreatedAt.ToString("dd/MM/yyyy HH:mm");
        }

        // Chế độ thêm mới
        private void SetAddMode()
        {
            isAddMode = true;
            selectedUserId = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnResetPwd.Enabled = false;

            txtUsername.Enabled = true;
            lblPasswordNote.Text = "(bắt buộc)";
            grpStaffInfo.Text = "Thông tin nhân viên (Thêm mới)";
        }

        // Chế độ chỉnh sửa
        private void SetEditMode()
        {
            isAddMode = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnResetPwd.Enabled = true;

            txtUsername.Enabled = false; // Không cho sửa username
            lblPasswordNote.Text = "(để trống nếu không đổi)";
            grpStaffInfo.Text = "Thông tin nhân viên (Chỉnh sửa)";
        }

        // Xóa form
        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            chkIsActive.Checked = true;
            lblCreatedAtValue.Text = "";

            selectedUserId = 0;
            SetAddMode();
        }

        // Kiểm tra dữ liệu nhập
        private bool ValidateInput(bool isNew)
        {
            // Kiểm tra username (chỉ khi thêm mới)
            if (isNew && string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (isNew && txtUsername.Text.Trim().Length < 4)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 4 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Kiểm tra password (bắt buộc khi thêm mới)
            if (isNew && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            return true;
        }

        // Lấy dữ liệu từ form
        private UserDTO GetUserFromForm()
        {
            return new UserDTO
            {
                UserID = selectedUserId,
                Username = txtUsername.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                IsActive = chkIsActive.Checked,
                RoleID = 2 // Staff
            };
        }

        // Thêm nhân viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(true)) return;

            try
            {
                UserDTO user = GetUserFromForm();
                string password = txtPassword.Text;

                int newUserId = userBLL.InsertStaff(user, password);

                if (newUserId > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffList();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật nhân viên
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(false)) return;

            try
            {
                UserDTO user = GetUserFromForm();
                bool success = userBLL.UpdateStaff(user);

                if (success)
                {
                    // Nếu có nhập password mới thì cập nhật password
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        userBLL.ResetPassword(selectedUserId, txtPassword.Text);
                    }

                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffList();
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

        // Xóa nhân viên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên '{txtFullName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = userBLL.DeleteStaff(selectedUserId);

                    if (success)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaffList();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi",
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

        // Reset mật khẩu
        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần reset mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Reset mật khẩu của '{txtFullName.Text}' về '123456'?",
                "Xác nhận reset mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = userBLL.ResetPassword(selectedUserId, "123456");

                    if (success)
                    {
                        MessageBox.Show("Reset mật khẩu thành công!\nMật khẩu mới: 123456", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Reset mật khẩu thất bại!", "Lỗi",
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
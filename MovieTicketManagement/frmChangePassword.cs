using System;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmChangePassword : Form
    {
        private UserBLL userBLL = new UserBLL();
        private int userId;

        public frmChangePassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtOldPassword.Focus();
        }

        // Toggle hiển thị mật khẩu cũ
        private void chkShowOld_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowOld.Checked)
            {
                txtOldPassword.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                txtOldPassword.PasswordChar = '●'; // Ẩn mật khẩu
            }
        }

        // Toggle hiển thị mật khẩu mới
        private void chkShowNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowNew.Checked)
            {
                txtNewPassword.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword.PasswordChar = '●';
            }
        }

        // Toggle hiển thị xác nhận mật khẩu
        private void chkShowConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowConfirm.Checked)
            {
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtConfirmPassword.PasswordChar = '●';
            }
        }

        // Lưu mật khẩu mới
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtOldPassword.Text == txtNewPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            try
            {
                var result = userBLL.ChangePassword(userId, txtOldPassword.Text, txtNewPassword.Text);

                if (result.success)
                {
                    MessageBox.Show(result.message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPassword.Focus();
                    txtOldPassword.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hủy
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
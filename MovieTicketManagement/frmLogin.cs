using MovieTicket.BLL;
using MovieTicket.DTO;
using MovieTicket.GUI;
using System;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    public partial class frmLogin : Form
    {
        private readonly UserBLL userBLL = new UserBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            txtUsername.Focus();
            txtPassword.PasswordChar = '●';
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            UserDTO user = userBLL.Login(username, password);

            if (user != null)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Đăng nhập thành công!";

                // Ẩn form login
                this.Hide();

                // Mở form Main và truyền thông tin user
                frmMain mainForm = new frmMain(user);
                mainForm.ShowDialog();

                // Đóng form login sau khi đóng form Main
                this.Close();
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            registerForm.ShowDialog();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click_1(sender, e);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        // Toggle show/hide password
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Hiện password
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Ẩn password
            }
        }

        private void btnResetPW_Click(object sender, EventArgs e)
        {
            try
            {
                string password = "123456";
                string salt = MovieTicket.Common.PasswordHelper.GenerateSalt();
                string hash = MovieTicket.Common.PasswordHelper.HashPassword(password, salt);

                string query = "UPDATE USERS SET Salt = @Salt, PasswordHash = @Hash";

                using (var conn = MovieTicket.DAL.DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Salt", salt);
                        cmd.Parameters.AddWithValue("@Hash", hash);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Đã reset password '123456' cho {rows} users!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // MỚI: Xử lý click vào link Quên mật khẩu
        // ============================================
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmForgotPassword frm = new frmForgotPassword())
            {
                this.Hide(); // Ẩn form login
                frm.ShowDialog();
                this.Show(); // Hiện lại form login
                txtUsername.Focus();
            }
        }
    }
}
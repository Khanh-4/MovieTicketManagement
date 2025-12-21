using System;
using System.Windows.Forms;
using MovieTicket.BLL;

namespace MovieTicketManagement
{
    public partial class frmRegister : Form
    {
        private readonly UserBLL userBLL = new UserBLL();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            // Thêm dữ liệu cho ComboBox giới tính
            cboGender.Items.Clear();
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.Items.Add("Khác");
            cboGender.SelectedIndex = 0;

            // Đặt ngày sinh mặc định (18 tuổi trước)
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);

            // Xóa trạng thái
            lblStatus.Text = "";
            txtUsername.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ form
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Reset trạng thái
            lblStatus.ForeColor = System.Drawing.Color.Red;

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(username))
            {
                lblStatus.Text = "Vui lòng nhập tên đăng nhập!";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Vui lòng nhập mật khẩu!";
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                lblStatus.Text = "Vui lòng xác nhận mật khẩu!";
                txtConfirmPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                lblStatus.Text = "Mật khẩu xác nhận không khớp!";
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                lblStatus.Text = "Vui lòng nhập họ và tên!";
                txtFullName.Focus();
                return;
            }

            // Gọi BLL để đăng ký
            var result = userBLL.Register(username, password, fullName, email, phone);

            if (result.success)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = result.message;

                MessageBox.Show("Đăng ký thành công!\nBạn có thể đăng nhập ngay bây giờ.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                lblStatus.Text = result.message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;

namespace MovieTicket.GUI
{
    public partial class frmForgotPassword : Form
    {
        private readonly UserBLL userBLL = new UserBLL();

        // Các bước của wizard
        private int currentStep = 1;
        private string userEmail = "";
        private int userId = 0;

        // Timer đếm ngược để gửi lại OTP
        private System.Windows.Forms.Timer resendTimer;
        private int resendCountdown = 0;

        public frmForgotPassword()
        {
            InitializeComponent();
            SetupForm();
            ShowStep(1);
        }

        private void SetupForm()
        {
            // Setup Timer cho nút gửi lại
            resendTimer = new System.Windows.Forms.Timer();
            resendTimer.Interval = 1000; // 1 giây
            resendTimer.Tick += ResendTimer_Tick;
        }

        #region Step Navigation

        private void ShowStep(int step)
        {
            currentStep = step;

            // Ẩn tất cả panels
            panelStep1.Visible = false;
            panelStep2.Visible = false;
            panelStep3.Visible = false;

            // Cập nhật progress
            UpdateProgress(step);

            // Hiện panel tương ứng
            switch (step)
            {
                case 1:
                    panelStep1.Visible = true;
                    txtEmail.Focus();
                    break;
                case 2:
                    panelStep2.Visible = true;
                    txtOTP.Clear();
                    txtOTP.Focus();
                    StartResendCountdown();
                    break;
                case 3:
                    panelStep3.Visible = true;
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                    txtNewPassword.Focus();
                    break;
            }
        }

        private void UpdateProgress(int step)
        {
            // Cập nhật màu sắc progress indicators
            lblStep1.BackColor = step >= 1 ? Color.FromArgb(255, 215, 0) : Color.Gray;
            lblStep2.BackColor = step >= 2 ? Color.FromArgb(255, 215, 0) : Color.Gray;
            lblStep3.BackColor = step >= 3 ? Color.FromArgb(255, 215, 0) : Color.Gray;

            // Cập nhật text màu
            lblStepText1.ForeColor = step >= 1 ? Color.FromArgb(255, 215, 0) : Color.Gray;
            lblStepText2.ForeColor = step >= 2 ? Color.FromArgb(255, 215, 0) : Color.Gray;
            lblStepText3.ForeColor = step >= 3 ? Color.FromArgb(255, 215, 0) : Color.Gray;
        }

        #endregion

        #region Step 1: Nhập Email

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                ShowError("Vui lòng nhập email!");
                txtEmail.Focus();
                return;
            }

            // Hiển thị loading
            btnSendOTP.Enabled = false;
            btnSendOTP.Text = "Đang gửi...";
            lblError.Visible = false;
            Application.DoEvents();

            try
            {
                // Gọi BLL để gửi OTP
                var result = userBLL.SendResetPasswordOTP(email);

                if (result.success)
                {
                    userEmail = email;
                    lblEmailSent.Text = $"Mã xác nhận đã được gửi đến:\n{email}";
                    ShowStep(2);
                }
                else
                {
                    ShowError(result.message);
                }
            }
            catch (Exception ex)
            {
                ShowError("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                btnSendOTP.Enabled = true;
                btnSendOTP.Text = "Gửi mã xác nhận";
            }
        }

        #endregion

        #region Step 2: Nhập OTP

        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string otp = txtOTP.Text.Trim();

            if (string.IsNullOrEmpty(otp))
            {
                ShowError("Vui lòng nhập mã xác nhận!");
                txtOTP.Focus();
                return;
            }

            if (otp.Length != 6)
            {
                ShowError("Mã xác nhận phải có 6 chữ số!");
                txtOTP.Focus();
                return;
            }

            // Hiển thị loading
            btnVerifyOTP.Enabled = false;
            btnVerifyOTP.Text = "Đang xác thực...";
            lblError.Visible = false;
            Application.DoEvents();

            try
            {
                // Xác thực OTP
                var result = userBLL.VerifyOTP(userEmail, otp);

                if (result.success)
                {
                    userId = result.userId;
                    resendTimer.Stop();
                    ShowStep(3);
                }
                else
                {
                    ShowError(result.message);
                }
            }
            catch (Exception ex)
            {
                ShowError("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                btnVerifyOTP.Enabled = true;
                btnVerifyOTP.Text = "Xác nhận";
            }
        }

        private void btnResendOTP_Click(object sender, EventArgs e)
        {
            if (resendCountdown > 0) return;

            btnResendOTP.Enabled = false;
            btnResendOTP.Text = "Đang gửi...";
            Application.DoEvents();

            try
            {
                var result = userBLL.SendResetPasswordOTP(userEmail);

                if (result.success)
                {
                    MessageBox.Show("Đã gửi lại mã xác nhận!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartResendCountdown();
                }
                else
                {
                    ShowError(result.message);
                    btnResendOTP.Enabled = true;
                    btnResendOTP.Text = "Gửi lại mã";
                }
            }
            catch (Exception ex)
            {
                ShowError("Có lỗi xảy ra: " + ex.Message);
                btnResendOTP.Enabled = true;
                btnResendOTP.Text = "Gửi lại mã";
            }
        }

        private void StartResendCountdown()
        {
            resendCountdown = 60; // 60 giây
            btnResendOTP.Enabled = false;
            btnResendOTP.Text = $"Gửi lại ({resendCountdown}s)";
            resendTimer.Start();
        }

        private void ResendTimer_Tick(object sender, EventArgs e)
        {
            resendCountdown--;

            if (resendCountdown <= 0)
            {
                resendTimer.Stop();
                btnResendOTP.Enabled = true;
                btnResendOTP.Text = "Gửi lại mã";
            }
            else
            {
                btnResendOTP.Text = $"Gửi lại ({resendCountdown}s)";
            }
        }

        private void btnBackToStep1_Click(object sender, EventArgs e)
        {
            resendTimer.Stop();
            ShowStep(1);
        }

        // Chỉ cho phép nhập số vào ô OTP
        private void txtOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Step 3: Đặt mật khẩu mới

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate
            if (string.IsNullOrEmpty(newPassword))
            {
                ShowError("Vui lòng nhập mật khẩu mới!");
                txtNewPassword.Focus();
                return;
            }

            if (newPassword.Length < 6)
            {
                ShowError("Mật khẩu phải có ít nhất 6 ký tự!");
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                ShowError("Mật khẩu xác nhận không khớp!");
                txtConfirmPassword.Focus();
                return;
            }

            // Hiển thị loading
            btnResetPassword.Enabled = false;
            btnResetPassword.Text = "Đang xử lý...";
            lblError.Visible = false;
            Application.DoEvents();

            try
            {
                var result = userBLL.ResetPasswordWithOTP(userEmail, newPassword, confirmPassword);

                if (result.success)
                {
                    MessageBox.Show(
                        "Đặt lại mật khẩu thành công!\n\nVui lòng đăng nhập với mật khẩu mới.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError(result.message);
                }
            }
            catch (Exception ex)
            {
                ShowError("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                btnResetPassword.Enabled = true;
                btnResetPassword.Text = "Đặt lại mật khẩu";
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
            txtConfirmPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        #endregion

        #region Helper Methods

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmForgotPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            resendTimer?.Stop();
            resendTimer?.Dispose();
        }

        #endregion
    }
}
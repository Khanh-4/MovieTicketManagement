namespace MovieTicket.GUI
{
    partial class frmForgotPassword
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Main Panel
            this.panelMain = new System.Windows.Forms.Panel();

            // Header
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            // Progress Indicators
            this.panelProgress = new System.Windows.Forms.Panel();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStepText1 = new System.Windows.Forms.Label();
            this.lblStepText2 = new System.Windows.Forms.Label();
            this.lblStepText3 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();

            // Step 1: Email
            this.panelStep1 = new System.Windows.Forms.Panel();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSendOTP = new System.Windows.Forms.Button();

            // Step 2: OTP
            this.panelStep2 = new System.Windows.Forms.Panel();
            this.lblEmailSent = new System.Windows.Forms.Label();
            this.lblOTPLabel = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.btnResendOTP = new System.Windows.Forms.Button();
            this.btnBackToStep1 = new System.Windows.Forms.Button();

            // Step 3: New Password
            this.panelStep3 = new System.Windows.Forms.Panel();
            this.lblNewPasswordLabel = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnResetPassword = new System.Windows.Forms.Button();

            // Common
            this.lblError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();

            this.panelMain.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelStep1.SuspendLayout();
            this.panelStep2.SuspendLayout();
            this.panelStep3.SuspendLayout();
            this.SuspendLayout();

            // ==================== FORM ====================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.ClientSize = new System.Drawing.Size(500, 580);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quên mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmForgotPassword_FormClosing);

            // ==================== MAIN PANEL ====================
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Size = new System.Drawing.Size(460, 540);

            // ==================== HEADER ====================
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Text = "🔐 Quên mật khẩu";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubtitle.Location = new System.Drawing.Point(100, 60);
            this.lblSubtitle.Text = "Làm theo các bước để đặt lại mật khẩu";

            // ==================== PROGRESS ====================
            this.panelProgress.BackColor = System.Drawing.Color.Transparent;
            this.panelProgress.Location = new System.Drawing.Point(30, 100);
            this.panelProgress.Size = new System.Drawing.Size(400, 60);

            // Step indicators (circles)
            this.lblStep1.BackColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.lblStep1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStep1.ForeColor = System.Drawing.Color.Black;
            this.lblStep1.Location = new System.Drawing.Point(50, 0);
            this.lblStep1.Size = new System.Drawing.Size(35, 35);
            this.lblStep1.Text = "1";
            this.lblStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblStep2.BackColor = System.Drawing.Color.Gray;
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStep2.ForeColor = System.Drawing.Color.White;
            this.lblStep2.Location = new System.Drawing.Point(180, 0);
            this.lblStep2.Size = new System.Drawing.Size(35, 35);
            this.lblStep2.Text = "2";
            this.lblStep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblStep3.BackColor = System.Drawing.Color.Gray;
            this.lblStep3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStep3.ForeColor = System.Drawing.Color.White;
            this.lblStep3.Location = new System.Drawing.Point(310, 0);
            this.lblStep3.Size = new System.Drawing.Size(35, 35);
            this.lblStep3.Text = "3";
            this.lblStep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Lines between steps
            this.lblLine1.BackColor = System.Drawing.Color.Gray;
            this.lblLine1.Location = new System.Drawing.Point(90, 15);
            this.lblLine1.Size = new System.Drawing.Size(85, 3);

            this.lblLine2.BackColor = System.Drawing.Color.Gray;
            this.lblLine2.Location = new System.Drawing.Point(220, 15);
            this.lblLine2.Size = new System.Drawing.Size(85, 3);

            // Step labels
            this.lblStepText1.AutoSize = true;
            this.lblStepText1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStepText1.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.lblStepText1.Location = new System.Drawing.Point(40, 40);
            this.lblStepText1.Text = "Nhập email";

            this.lblStepText2.AutoSize = true;
            this.lblStepText2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStepText2.ForeColor = System.Drawing.Color.Gray;
            this.lblStepText2.Location = new System.Drawing.Point(170, 40);
            this.lblStepText2.Text = "Xác thực";

            this.lblStepText3.AutoSize = true;
            this.lblStepText3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStepText3.ForeColor = System.Drawing.Color.Gray;
            this.lblStepText3.Location = new System.Drawing.Point(295, 40);
            this.lblStepText3.Text = "Mật khẩu mới";

            this.panelProgress.Controls.Add(this.lblStep1);
            this.panelProgress.Controls.Add(this.lblStep2);
            this.panelProgress.Controls.Add(this.lblStep3);
            this.panelProgress.Controls.Add(this.lblLine1);
            this.panelProgress.Controls.Add(this.lblLine2);
            this.panelProgress.Controls.Add(this.lblStepText1);
            this.panelProgress.Controls.Add(this.lblStepText2);
            this.panelProgress.Controls.Add(this.lblStepText3);

            // ==================== STEP 1: EMAIL ====================
            this.panelStep1.BackColor = System.Drawing.Color.Transparent;
            this.panelStep1.Location = new System.Drawing.Point(30, 180);
            this.panelStep1.Size = new System.Drawing.Size(400, 250);

            this.lblEmailLabel.AutoSize = true;
            this.lblEmailLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmailLabel.ForeColor = System.Drawing.Color.White;
            this.lblEmailLabel.Location = new System.Drawing.Point(0, 20);
            this.lblEmailLabel.Text = "Nhập email đã đăng ký tài khoản:";

            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(0, 55);
            this.txtEmail.Size = new System.Drawing.Size(400, 34);

            this.btnSendOTP.BackColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.btnSendOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendOTP.FlatAppearance.BorderSize = 0;
            this.btnSendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSendOTP.ForeColor = System.Drawing.Color.Black;
            this.btnSendOTP.Location = new System.Drawing.Point(0, 120);
            this.btnSendOTP.Size = new System.Drawing.Size(400, 45);
            this.btnSendOTP.Text = "Gửi mã xác nhận";
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);

            this.panelStep1.Controls.Add(this.lblEmailLabel);
            this.panelStep1.Controls.Add(this.txtEmail);
            this.panelStep1.Controls.Add(this.btnSendOTP);

            // ==================== STEP 2: OTP ====================
            this.panelStep2.BackColor = System.Drawing.Color.Transparent;
            this.panelStep2.Location = new System.Drawing.Point(30, 180);
            this.panelStep2.Size = new System.Drawing.Size(400, 280);
            this.panelStep2.Visible = false;

            this.lblEmailSent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmailSent.ForeColor = System.Drawing.Color.LightGreen;
            this.lblEmailSent.Location = new System.Drawing.Point(0, 0);
            this.lblEmailSent.Size = new System.Drawing.Size(400, 45);
            this.lblEmailSent.Text = "Mã xác nhận đã được gửi đến:\nemail@example.com";
            this.lblEmailSent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblOTPLabel.AutoSize = true;
            this.lblOTPLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOTPLabel.ForeColor = System.Drawing.Color.White;
            this.lblOTPLabel.Location = new System.Drawing.Point(0, 60);
            this.lblOTPLabel.Text = "Nhập mã xác nhận (6 số):";

            this.txtOTP.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOTP.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.txtOTP.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.txtOTP.Location = new System.Drawing.Point(75, 95);
            this.txtOTP.MaxLength = 6;
            this.txtOTP.Size = new System.Drawing.Size(250, 57);
            this.txtOTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOTP_KeyPress);

            this.btnVerifyOTP.BackColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.btnVerifyOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerifyOTP.FlatAppearance.BorderSize = 0;
            this.btnVerifyOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyOTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVerifyOTP.ForeColor = System.Drawing.Color.Black;
            this.btnVerifyOTP.Location = new System.Drawing.Point(0, 170);
            this.btnVerifyOTP.Size = new System.Drawing.Size(400, 45);
            this.btnVerifyOTP.Text = "Xác nhận";
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);

            this.btnResendOTP.BackColor = System.Drawing.Color.Transparent;
            this.btnResendOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResendOTP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.btnResendOTP.FlatAppearance.BorderSize = 1;
            this.btnResendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResendOTP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnResendOTP.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.btnResendOTP.Location = new System.Drawing.Point(205, 225);
            this.btnResendOTP.Size = new System.Drawing.Size(195, 35);
            this.btnResendOTP.Text = "Gửi lại mã";
            this.btnResendOTP.Click += new System.EventHandler(this.btnResendOTP_Click);

            this.btnBackToStep1.BackColor = System.Drawing.Color.Transparent;
            this.btnBackToStep1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToStep1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBackToStep1.FlatAppearance.BorderSize = 1;
            this.btnBackToStep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToStep1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBackToStep1.ForeColor = System.Drawing.Color.Gray;
            this.btnBackToStep1.Location = new System.Drawing.Point(0, 225);
            this.btnBackToStep1.Size = new System.Drawing.Size(195, 35);
            this.btnBackToStep1.Text = "← Quay lại";
            this.btnBackToStep1.Click += new System.EventHandler(this.btnBackToStep1_Click);

            this.panelStep2.Controls.Add(this.lblEmailSent);
            this.panelStep2.Controls.Add(this.lblOTPLabel);
            this.panelStep2.Controls.Add(this.txtOTP);
            this.panelStep2.Controls.Add(this.btnVerifyOTP);
            this.panelStep2.Controls.Add(this.btnResendOTP);
            this.panelStep2.Controls.Add(this.btnBackToStep1);

            // ==================== STEP 3: NEW PASSWORD ====================
            this.panelStep3.BackColor = System.Drawing.Color.Transparent;
            this.panelStep3.Location = new System.Drawing.Point(30, 180);
            this.panelStep3.Size = new System.Drawing.Size(400, 280);
            this.panelStep3.Visible = false;

            this.lblNewPasswordLabel.AutoSize = true;
            this.lblNewPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNewPasswordLabel.ForeColor = System.Drawing.Color.White;
            this.lblNewPasswordLabel.Location = new System.Drawing.Point(0, 0);
            this.lblNewPasswordLabel.Text = "Mật khẩu mới:";

            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.Location = new System.Drawing.Point(0, 30);
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.Size = new System.Drawing.Size(400, 34);

            this.lblConfirmPasswordLabel.AutoSize = true;
            this.lblConfirmPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblConfirmPasswordLabel.ForeColor = System.Drawing.Color.White;
            this.lblConfirmPasswordLabel.Location = new System.Drawing.Point(0, 80);
            this.lblConfirmPasswordLabel.Text = "Xác nhận mật khẩu:";

            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Location = new System.Drawing.Point(0, 110);
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(400, 34);

            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.Silver;
            this.chkShowPassword.Location = new System.Drawing.Point(0, 155);
            this.chkShowPassword.Text = "Hiện mật khẩu";
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);

            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(0, 200);
            this.btnResetPassword.Size = new System.Drawing.Size(400, 45);
            this.btnResetPassword.Text = "✓ Đặt lại mật khẩu";
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            this.panelStep3.Controls.Add(this.lblNewPasswordLabel);
            this.panelStep3.Controls.Add(this.txtNewPassword);
            this.panelStep3.Controls.Add(this.lblConfirmPasswordLabel);
            this.panelStep3.Controls.Add(this.txtConfirmPassword);
            this.panelStep3.Controls.Add(this.chkShowPassword);
            this.panelStep3.Controls.Add(this.btnResetPassword);

            // ==================== ERROR LABEL ====================
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblError.Location = new System.Drawing.Point(30, 440);
            this.lblError.Size = new System.Drawing.Size(400, 40);
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;

            // ==================== CANCEL BUTTON ====================
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(165, 490);
            this.btnCancel.Size = new System.Drawing.Size(130, 35);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ==================== ADD CONTROLS ====================
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblSubtitle);
            this.panelMain.Controls.Add(this.panelProgress);
            this.panelMain.Controls.Add(this.panelStep1);
            this.panelMain.Controls.Add(this.panelStep2);
            this.panelMain.Controls.Add(this.panelStep3);
            this.panelMain.Controls.Add(this.lblError);
            this.panelMain.Controls.Add(this.btnCancel);

            this.Controls.Add(this.panelMain);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.panelStep1.ResumeLayout(false);
            this.panelStep1.PerformLayout();
            this.panelStep2.ResumeLayout(false);
            this.panelStep2.PerformLayout();
            this.panelStep3.ResumeLayout(false);
            this.panelStep3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        // Progress
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStepText1;
        private System.Windows.Forms.Label lblStepText2;
        private System.Windows.Forms.Label lblStepText3;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine2;

        // Step 1
        private System.Windows.Forms.Panel panelStep1;
        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSendOTP;

        // Step 2
        private System.Windows.Forms.Panel panelStep2;
        private System.Windows.Forms.Label lblEmailSent;
        private System.Windows.Forms.Label lblOTPLabel;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnVerifyOTP;
        private System.Windows.Forms.Button btnResendOTP;
        private System.Windows.Forms.Button btnBackToStep1;

        // Step 3
        private System.Windows.Forms.Panel panelStep3;
        private System.Windows.Forms.Label lblNewPasswordLabel;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPasswordLabel;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnResetPassword;

        // Common
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnCancel;
    }
}
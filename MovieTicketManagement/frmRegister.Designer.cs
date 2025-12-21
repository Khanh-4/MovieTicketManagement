namespace MovieTicketManagement
{
    partial class frmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            btnRegister = new Button();
            btnCancel = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(235, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(10, 55);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(105, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Tên đăng nhập (*):";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(12, 82);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(296, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 146);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(296, 23);
            txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(10, 119);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu (*):";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(12, 213);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(296, 23);
            txtConfirmPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.Location = new Point(10, 186);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(128, 15);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Xác nhận mật khẩu (*):";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(12, 280);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(296, 23);
            txtFullName.TabIndex = 9;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullName.Location = new Point(12, 250);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(77, 15);
            lblFullName.TabIndex = 10;
            lblFullName.Text = "Họ và tên (*):";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(12, 316);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 343);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(296, 23);
            txtEmail.TabIndex = 12;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(378, 55);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(80, 15);
            lblPhone.TabIndex = 13;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(378, 82);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(296, 23);
            txtPhone.TabIndex = 14;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGender.Location = new Point(378, 119);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(55, 15);
            lblGender.TabIndex = 15;
            lblGender.Text = "Giới tính:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(378, 146);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(80, 23);
            cboGender.TabIndex = 16;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateOfBirth.Location = new Point(474, 119);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(63, 15);
            lblDateOfBirth.TabIndex = 17;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(474, 146);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 23);
            dtpDateOfBirth.TabIndex = 18;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(439, 213);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 40);
            btnRegister.TabIndex = 19;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(520, 213);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 40);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(338, 438);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 21;
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(684, 511);
            Controls.Add(lblStatus);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(lblDateOfBirth);
            Controls.Add(cboGender);
            Controls.Add(lblGender);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản - Movie Ticket";
            Load += frmRegister_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private TextBox txtFullName;
        private Label lblFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Button btnRegister;
        private Button btnCancel;
        private Label lblStatus;
    }
}
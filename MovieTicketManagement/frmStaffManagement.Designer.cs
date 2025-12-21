namespace MovieTicketManagement
{
    partial class frmStaffManagement
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
            dgvStaff = new DataGridView();
            grpStaffInfo = new GroupBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordNote = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            chkIsActive = new CheckBox();
            lblCreatedAt = new Label();
            lblCreatedAtValue = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnResetPwd = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            grpStaffInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(350, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.BackgroundColor = Color.White;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(20, 60);
            dgvStaff.MultiSelect = false;
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.Size = new Size(550, 400);
            dgvStaff.TabIndex = 1;
            dgvStaff.CellClick += dgvStaff_CellClick;
            // 
            // grpStaffInfo
            // 
            grpStaffInfo.Controls.Add(lblCreatedAtValue);
            grpStaffInfo.Controls.Add(lblCreatedAt);
            grpStaffInfo.Controls.Add(chkIsActive);
            grpStaffInfo.Controls.Add(txtPhone);
            grpStaffInfo.Controls.Add(lblPhone);
            grpStaffInfo.Controls.Add(txtEmail);
            grpStaffInfo.Controls.Add(lblEmail);
            grpStaffInfo.Controls.Add(txtFullName);
            grpStaffInfo.Controls.Add(lblFullName);
            grpStaffInfo.Controls.Add(lblPasswordNote);
            grpStaffInfo.Controls.Add(txtPassword);
            grpStaffInfo.Controls.Add(lblPassword);
            grpStaffInfo.Controls.Add(txtUsername);
            grpStaffInfo.Controls.Add(lblUsername);
            grpStaffInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpStaffInfo.Location = new Point(590, 60);
            grpStaffInfo.Name = "grpStaffInfo";
            grpStaffInfo.Size = new Size(330, 320);
            grpStaffInfo.TabIndex = 2;
            grpStaffInfo.TabStop = false;
            grpStaffInfo.Text = "Thông tin nhân viên";
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(20, 35);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(110, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(135, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(170, 25);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(20, 70);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(110, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(135, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(170, 25);
            txtPassword.TabIndex = 3;
            // 
            // lblPasswordNote
            // 
            lblPasswordNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPasswordNote.ForeColor = Color.Gray;
            lblPasswordNote.Location = new Point(135, 95);
            lblPasswordNote.Name = "lblPasswordNote";
            lblPasswordNote.Size = new Size(170, 20);
            lblPasswordNote.TabIndex = 4;
            lblPasswordNote.Text = "(bắt buộc)";
            // 
            // lblFullName
            // 
            lblFullName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFullName.Location = new Point(20, 120);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(110, 23);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(135, 117);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(170, 25);
            txtFullName.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(20, 155);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(110, 23);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(135, 152);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(170, 25);
            txtEmail.TabIndex = 8;
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(20, 190);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(110, 23);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "Điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(135, 187);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(170, 25);
            txtPhone.TabIndex = 10;
            // 
            // chkIsActive
            // 
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkIsActive.Location = new Point(135, 225);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(150, 25);
            chkIsActive.TabIndex = 11;
            chkIsActive.Text = "Đang hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreatedAt.Location = new Point(20, 260);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(110, 23);
            lblCreatedAt.TabIndex = 12;
            lblCreatedAt.Text = "Ngày tạo:";
            // 
            // lblCreatedAtValue
            // 
            lblCreatedAtValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedAtValue.Location = new Point(135, 260);
            lblCreatedAtValue.Name = "lblCreatedAtValue";
            lblCreatedAtValue.Size = new Size(170, 23);
            lblCreatedAtValue.TabIndex = 13;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(590, 395);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "➕ Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.RoyalBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(690, 395);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 35);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "✏️ Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(790, 395);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 35);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(590, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 35);
            btnClear.TabIndex = 6;
            btnClear.Text = "🔄 Mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnResetPwd
            // 
            btnResetPwd.BackColor = Color.DarkOrange;
            btnResetPwd.FlatStyle = FlatStyle.Flat;
            btnResetPwd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetPwd.ForeColor = Color.White;
            btnResetPwd.Location = new Point(690, 440);
            btnResetPwd.Name = "btnResetPwd";
            btnResetPwd.Size = new Size(120, 35);
            btnResetPwd.TabIndex = 7;
            btnResetPwd.Text = "🔑 Reset MK";
            btnResetPwd.UseVisualStyleBackColor = false;
            btnResetPwd.Click += btnResetPwd_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(830, 520);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 8;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmStaffManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(934, 561);
            Controls.Add(btnClose);
            Controls.Add(btnResetPwd);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(grpStaffInfo);
            Controls.Add(dgvStaff);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmStaffManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";
            Load += frmStaffManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            grpStaffInfo.ResumeLayout(false);
            grpStaffInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvStaff;
        private GroupBox grpStaffInfo;
        private Label lblFullName;
        private Label lblPasswordNote;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtFullName;
        private Label lblCreatedAtValue;
        private Label lblCreatedAt;
        private CheckBox chkIsActive;
        private TextBox txtPhone;
        private Label lblPhone;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnResetPwd;
        private Button btnClose;
    }
}
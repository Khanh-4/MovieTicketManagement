using System.Drawing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmChangePassword
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
            lblOldPwd = new Label();
            txtOldPassword = new TextBox();
            chkShowOld = new CheckBox();
            lblNewPwd = new Label();
            txtNewPassword = new TextBox();
            chkShowNew = new CheckBox();
            lblConfirmPwd = new Label();
            txtConfirmPassword = new TextBox();
            chkShowConfirm = new CheckBox();
            lblNote = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(130, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐỔI MẬT KHẨU";
            // 
            // lblOldPwd
            // 
            lblOldPwd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOldPwd.Location = new Point(30, 65);
            lblOldPwd.Name = "lblOldPwd";
            lblOldPwd.Size = new Size(100, 23);
            lblOldPwd.TabIndex = 1;
            lblOldPwd.Text = "Mật khẩu cũ:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOldPassword.Location = new Point(140, 62);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '●';
            txtOldPassword.Size = new Size(200, 25);
            txtOldPassword.TabIndex = 2;
            // 
            // chkShowOld
            // 
            chkShowOld.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowOld.Location = new Point(345, 62);
            chkShowOld.Name = "chkShowOld";
            chkShowOld.Size = new Size(40, 25);
            chkShowOld.TabIndex = 3;
            chkShowOld.Text = "👁";
            chkShowOld.UseVisualStyleBackColor = true;
            chkShowOld.CheckedChanged += chkShowOld_CheckedChanged;
            // 
            // lblNewPwd
            // 
            lblNewPwd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPwd.Location = new Point(30, 105);
            lblNewPwd.Name = "lblNewPwd";
            lblNewPwd.Size = new Size(100, 23);
            lblNewPwd.TabIndex = 4;
            lblNewPwd.Text = "Mật khẩu mới:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(140, 102);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(200, 25);
            txtNewPassword.TabIndex = 5;
            // 
            // chkShowNew
            // 
            chkShowNew.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowNew.Location = new Point(345, 102);
            chkShowNew.Name = "chkShowNew";
            chkShowNew.Size = new Size(40, 25);
            chkShowNew.TabIndex = 6;
            chkShowNew.Text = "👁";
            chkShowNew.UseVisualStyleBackColor = true;
            chkShowNew.CheckedChanged += chkShowNew_CheckedChanged;
            // 
            // lblConfirmPwd
            // 
            lblConfirmPwd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPwd.Location = new Point(30, 145);
            lblConfirmPwd.Name = "lblConfirmPwd";
            lblConfirmPwd.Size = new Size(100, 23);
            lblConfirmPwd.TabIndex = 7;
            lblConfirmPwd.Text = "Xác nhận MK:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(140, 142);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(200, 25);
            txtConfirmPassword.TabIndex = 8;
            // 
            // chkShowConfirm
            // 
            chkShowConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowConfirm.Location = new Point(345, 142);
            chkShowConfirm.Name = "chkShowConfirm";
            chkShowConfirm.Size = new Size(40, 25);
            chkShowConfirm.TabIndex = 9;
            chkShowConfirm.Text = "👁";
            chkShowConfirm.UseVisualStyleBackColor = true;
            chkShowConfirm.CheckedChanged += chkShowConfirm_CheckedChanged;
            // 
            // lblNote
            // 
            lblNote.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNote.ForeColor = Color.Gray;
            lblNote.Location = new Point(140, 175);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(200, 20);
            lblNote.TabIndex = 10;
            lblNote.Text = "* Mật khẩu tối thiểu 6 ký tự";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(100, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 11;
            btnSave.Text = "💾 Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(220, 210);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(404, 261);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblNote);
            Controls.Add(chkShowConfirm);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPwd);
            Controls.Add(chkShowNew);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPwd);
            Controls.Add(chkShowOld);
            Controls.Add(txtOldPassword);
            Controls.Add(lblOldPwd);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";
            Load += frmChangePassword_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblOldPwd;
        private TextBox txtOldPassword;
        private CheckBox chkShowOld;
        private Label lblNewPwd;
        private TextBox txtNewPassword;
        private CheckBox chkShowNew;
        private Label lblConfirmPwd;
        private TextBox txtConfirmPassword;
        private CheckBox chkShowConfirm;
        private Label lblNote;
        private Button btnSave;
        private Button btnCancel;
    }
}
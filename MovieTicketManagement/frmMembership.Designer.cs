using System.Drawing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmMembership
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
            grpMemberInfo = new GroupBox();
            lblName = new Label();
            lblNameValue = new Label();
            lblType = new Label();
            lblTypeValue = new Label();
            lblPoints = new Label();
            lblPointsValue = new Label();
            lblJoinDate = new Label();
            lblJoinDateValue = new Label();
            lblDiscount = new Label();
            lblDiscountValue = new Label();
            lblBenefits = new Label();
            lblBenefitsValue = new Label();
            lblProgress = new Label();
            progressBar = new ProgressBar();
            lblProgressPercent = new Label();
            lblNextLevel = new Label();
            grpHistory = new GroupBox();
            dgvHistory = new DataGridView();
            btnClose = new Button();
            grpMemberInfo.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(230, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN HỘI VIÊN";
            // 
            // grpMemberInfo
            // 
            grpMemberInfo.Controls.Add(lblBenefitsValue);
            grpMemberInfo.Controls.Add(lblBenefits);
            grpMemberInfo.Controls.Add(lblDiscountValue);
            grpMemberInfo.Controls.Add(lblDiscount);
            grpMemberInfo.Controls.Add(lblJoinDateValue);
            grpMemberInfo.Controls.Add(lblJoinDate);
            grpMemberInfo.Controls.Add(lblPointsValue);
            grpMemberInfo.Controls.Add(lblPoints);
            grpMemberInfo.Controls.Add(lblTypeValue);
            grpMemberInfo.Controls.Add(lblType);
            grpMemberInfo.Controls.Add(lblNameValue);
            grpMemberInfo.Controls.Add(lblName);
            grpMemberInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpMemberInfo.Location = new Point(20, 60);
            grpMemberInfo.Name = "grpMemberInfo";
            grpMemberInfo.Size = new Size(640, 180);
            grpMemberInfo.TabIndex = 1;
            grpMemberInfo.TabStop = false;
            grpMemberInfo.Text = "Thông tin thành viên";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(20, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Họ tên:";
            // 
            // lblNameValue
            // 
            lblNameValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameValue.Location = new Point(130, 35);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(200, 23);
            lblNameValue.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.Location = new Point(350, 35);
            lblType.Name = "lblType";
            lblType.Size = new Size(110, 23);
            lblType.TabIndex = 2;
            lblType.Text = "Hạng hội viên:";
            // 
            // lblTypeValue
            // 
            lblTypeValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTypeValue.ForeColor = Color.DarkOrange;
            lblTypeValue.Location = new Point(470, 35);
            lblTypeValue.Name = "lblTypeValue";
            lblTypeValue.Size = new Size(150, 23);
            lblTypeValue.TabIndex = 3;
            // 
            // lblPoints
            // 
            lblPoints.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPoints.Location = new Point(20, 75);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(100, 23);
            lblPoints.TabIndex = 4;
            lblPoints.Text = "Điểm tích lũy:";
            // 
            // lblPointsValue
            // 
            lblPointsValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPointsValue.ForeColor = Color.Green;
            lblPointsValue.Location = new Point(130, 70);
            lblPointsValue.Name = "lblPointsValue";
            lblPointsValue.Size = new Size(150, 30);
            lblPointsValue.TabIndex = 5;
            lblPointsValue.Text = "0";
            // 
            // lblJoinDate
            // 
            lblJoinDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJoinDate.Location = new Point(350, 75);
            lblJoinDate.Name = "lblJoinDate";
            lblJoinDate.Size = new Size(110, 23);
            lblJoinDate.TabIndex = 6;
            lblJoinDate.Text = "Ngày tham gia:";
            // 
            // lblJoinDateValue
            // 
            lblJoinDateValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJoinDateValue.Location = new Point(470, 75);
            lblJoinDateValue.Name = "lblJoinDateValue";
            lblJoinDateValue.Size = new Size(150, 23);
            lblJoinDateValue.TabIndex = 7;
            // 
            // lblDiscount
            // 
            lblDiscount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscount.Location = new Point(20, 115);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(100, 23);
            lblDiscount.TabIndex = 8;
            lblDiscount.Text = "Ưu đãi:";
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiscountValue.ForeColor = Color.Crimson;
            lblDiscountValue.Location = new Point(130, 115);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(200, 23);
            lblDiscountValue.TabIndex = 9;
            // 
            // lblBenefits
            // 
            lblBenefits.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBenefits.Location = new Point(20, 145);
            lblBenefits.Name = "lblBenefits";
            lblBenefits.Size = new Size(100, 23);
            lblBenefits.TabIndex = 10;
            lblBenefits.Text = "Quyền lợi:";
            // 
            // lblBenefitsValue
            // 
            lblBenefitsValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBenefitsValue.ForeColor = Color.Blue;
            lblBenefitsValue.Location = new Point(130, 145);
            lblBenefitsValue.Name = "lblBenefitsValue";
            lblBenefitsValue.Size = new Size(490, 23);
            lblBenefitsValue.TabIndex = 11;
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgress.Location = new Point(20, 250);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(130, 23);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "Tiến độ nâng hạng:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(155, 250);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(400, 25);
            progressBar.TabIndex = 3;
            // 
            // lblProgressPercent
            // 
            lblProgressPercent.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgressPercent.Location = new Point(565, 250);
            lblProgressPercent.Name = "lblProgressPercent";
            lblProgressPercent.Size = new Size(80, 23);
            lblProgressPercent.TabIndex = 4;
            lblProgressPercent.Text = "0%";
            // 
            // lblNextLevel
            // 
            lblNextLevel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNextLevel.ForeColor = Color.Gray;
            lblNextLevel.Location = new Point(155, 280);
            lblNextLevel.Name = "lblNextLevel";
            lblNextLevel.Size = new Size(400, 23);
            lblNextLevel.TabIndex = 5;
            // 
            // grpHistory
            // 
            grpHistory.Controls.Add(dgvHistory);
            grpHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpHistory.Location = new Point(20, 310);
            grpHistory.Name = "grpHistory";
            grpHistory.Size = new Size(640, 150);
            grpHistory.TabIndex = 6;
            grpHistory.TabStop = false;
            grpHistory.Text = "Lịch sử tích điểm";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(15, 25);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(610, 115);
            dgvHistory.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(560, 470);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 7;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmMembership
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(684, 521);
            Controls.Add(btnClose);
            Controls.Add(grpHistory);
            Controls.Add(lblNextLevel);
            Controls.Add(lblProgressPercent);
            Controls.Add(progressBar);
            Controls.Add(lblProgress);
            Controls.Add(grpMemberInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMembership";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin Hội viên";
            Load += frmMembership_Load;
            grpMemberInfo.ResumeLayout(false);
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpMemberInfo;
        private Label lblName;
        private Label lblNameValue;
        private Label lblType;
        private Label lblTypeValue;
        private Label lblPoints;
        private Label lblPointsValue;
        private Label lblJoinDate;
        private Label lblJoinDateValue;
        private Label lblDiscount;
        private Label lblDiscountValue;
        private Label lblBenefits;
        private Label lblBenefitsValue;
        private Label lblProgress;
        private ProgressBar progressBar;
        private Label lblProgressPercent;
        private Label lblNextLevel;
        private GroupBox grpHistory;
        private DataGridView dgvHistory;
        private Button btnClose;
    }
}
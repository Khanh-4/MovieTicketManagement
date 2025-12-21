using System.Drawing;
using System.Windows.Forms;

namespace MovieTicketManagement
{
    partial class frmPromotionManagement
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
            dgvPromotions = new DataGridView();
            grpPromotionInfo = new GroupBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblDiscountType = new Label();
            cboDiscountType = new ComboBox();
            lblDiscountValue = new Label();
            nudDiscountValue = new NumericUpDown();
            lblMinOrder = new Label();
            nudMinOrder = new NumericUpDown();
            lblMaxDiscount = new Label();
            nudMaxDiscount = new NumericUpDown();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            lblUsedCount = new Label();
            lblUsedCountValue = new Label();
            chkIsActive = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPromotions).BeginInit();
            grpPromotionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscountValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinOrder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(420, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ KHUYẾN MÃI";
            // 
            // dgvPromotions
            // 
            dgvPromotions.AllowUserToAddRows = false;
            dgvPromotions.AllowUserToDeleteRows = false;
            dgvPromotions.BackgroundColor = Color.White;
            dgvPromotions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromotions.Location = new Point(20, 60);
            dgvPromotions.MultiSelect = false;
            dgvPromotions.Name = "dgvPromotions";
            dgvPromotions.ReadOnly = true;
            dgvPromotions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromotions.Size = new Size(680, 420);
            dgvPromotions.TabIndex = 1;
            dgvPromotions.CellClick += dgvPromotions_CellClick;
            // 
            // grpPromotionInfo
            // 
            grpPromotionInfo.Controls.Add(chkIsActive);
            grpPromotionInfo.Controls.Add(lblUsedCountValue);
            grpPromotionInfo.Controls.Add(lblUsedCount);
            grpPromotionInfo.Controls.Add(nudQuantity);
            grpPromotionInfo.Controls.Add(lblQuantity);
            grpPromotionInfo.Controls.Add(dtpEndDate);
            grpPromotionInfo.Controls.Add(lblEndDate);
            grpPromotionInfo.Controls.Add(dtpStartDate);
            grpPromotionInfo.Controls.Add(lblStartDate);
            grpPromotionInfo.Controls.Add(nudMaxDiscount);
            grpPromotionInfo.Controls.Add(lblMaxDiscount);
            grpPromotionInfo.Controls.Add(nudMinOrder);
            grpPromotionInfo.Controls.Add(lblMinOrder);
            grpPromotionInfo.Controls.Add(nudDiscountValue);
            grpPromotionInfo.Controls.Add(lblDiscountValue);
            grpPromotionInfo.Controls.Add(cboDiscountType);
            grpPromotionInfo.Controls.Add(lblDiscountType);
            grpPromotionInfo.Controls.Add(txtName);
            grpPromotionInfo.Controls.Add(lblName);
            grpPromotionInfo.Controls.Add(txtCode);
            grpPromotionInfo.Controls.Add(lblCode);
            grpPromotionInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPromotionInfo.Location = new Point(720, 60);
            grpPromotionInfo.Name = "grpPromotionInfo";
            grpPromotionInfo.Size = new Size(350, 370);
            grpPromotionInfo.TabIndex = 2;
            grpPromotionInfo.TabStop = false;
            grpPromotionInfo.Text = "Thông tin khuyến mãi";
            // 
            // lblCode
            // 
            lblCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCode.Location = new Point(20, 30);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(110, 23);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã KM:";
            // 
            // txtCode
            // 
            txtCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCode.Location = new Point(135, 27);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(180, 25);
            txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(20, 60);
            lblName.Name = "lblName";
            lblName.Size = new Size(110, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Tên KM:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(135, 57);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 25);
            txtName.TabIndex = 3;
            // 
            // lblDiscountType
            // 
            lblDiscountType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscountType.Location = new Point(20, 90);
            lblDiscountType.Name = "lblDiscountType";
            lblDiscountType.Size = new Size(110, 23);
            lblDiscountType.TabIndex = 4;
            lblDiscountType.Text = "Loại giảm:";
            // 
            // cboDiscountType
            // 
            cboDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDiscountType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboDiscountType.FormattingEnabled = true;
            cboDiscountType.Location = new Point(135, 87);
            cboDiscountType.Name = "cboDiscountType";
            cboDiscountType.Size = new Size(180, 25);
            cboDiscountType.TabIndex = 5;
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscountValue.Location = new Point(20, 120);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(110, 23);
            lblDiscountValue.TabIndex = 6;
            lblDiscountValue.Text = "Giá trị giảm:";
            // 
            // nudDiscountValue
            // 
            nudDiscountValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudDiscountValue.Location = new Point(135, 117);
            nudDiscountValue.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudDiscountValue.Name = "nudDiscountValue";
            nudDiscountValue.Size = new Size(100, 25);
            nudDiscountValue.TabIndex = 7;
            nudDiscountValue.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblMinOrder
            // 
            lblMinOrder.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMinOrder.Location = new Point(20, 150);
            lblMinOrder.Name = "lblMinOrder";
            lblMinOrder.Size = new Size(110, 23);
            lblMinOrder.TabIndex = 8;
            lblMinOrder.Text = "Đơn tối thiểu:";
            // 
            // nudMinOrder
            // 
            nudMinOrder.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudMinOrder.Location = new Point(135, 147);
            nudMinOrder.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudMinOrder.Name = "nudMinOrder";
            nudMinOrder.Size = new Size(120, 25);
            nudMinOrder.TabIndex = 9;
            // 
            // lblMaxDiscount
            // 
            lblMaxDiscount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaxDiscount.Location = new Point(20, 180);
            lblMaxDiscount.Name = "lblMaxDiscount";
            lblMaxDiscount.Size = new Size(110, 23);
            lblMaxDiscount.TabIndex = 10;
            lblMaxDiscount.Text = "Giảm tối đa:";
            // 
            // nudMaxDiscount
            // 
            nudMaxDiscount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudMaxDiscount.Location = new Point(135, 177);
            nudMaxDiscount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudMaxDiscount.Name = "nudMaxDiscount";
            nudMaxDiscount.Size = new Size(120, 25);
            nudMaxDiscount.TabIndex = 11;
            // 
            // lblStartDate
            // 
            lblStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStartDate.Location = new Point(20, 210);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(110, 23);
            lblStartDate.TabIndex = 12;
            lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(135, 207);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(180, 25);
            dtpStartDate.TabIndex = 13;
            // 
            // lblEndDate
            // 
            lblEndDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEndDate.Location = new Point(20, 240);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(110, 23);
            lblEndDate.TabIndex = 14;
            lblEndDate.Text = "Ngày kết thúc:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(135, 237);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(180, 25);
            dtpEndDate.TabIndex = 15;
            // 
            // lblQuantity
            // 
            lblQuantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(20, 270);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(110, 23);
            lblQuantity.TabIndex = 16;
            lblQuantity.Text = "Số lượng:";
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudQuantity.Location = new Point(135, 267);
            nudQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(100, 25);
            nudQuantity.TabIndex = 17;
            nudQuantity.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblUsedCount
            // 
            lblUsedCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsedCount.Location = new Point(20, 300);
            lblUsedCount.Name = "lblUsedCount";
            lblUsedCount.Size = new Size(110, 23);
            lblUsedCount.TabIndex = 18;
            lblUsedCount.Text = "Đã dùng:";
            // 
            // lblUsedCountValue
            // 
            lblUsedCountValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsedCountValue.ForeColor = Color.Blue;
            lblUsedCountValue.Location = new Point(135, 300);
            lblUsedCountValue.Name = "lblUsedCountValue";
            lblUsedCountValue.Size = new Size(80, 23);
            lblUsedCountValue.TabIndex = 19;
            lblUsedCountValue.Text = "0";
            // 
            // chkIsActive
            // 
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkIsActive.Location = new Point(135, 330);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(150, 25);
            chkIsActive.TabIndex = 20;
            chkIsActive.Text = "Đang hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(720, 445);
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
            btnUpdate.Location = new Point(820, 445);
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
            btnDelete.Location = new Point(920, 445);
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
            btnClear.Location = new Point(720, 490);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 35);
            btnClear.TabIndex = 6;
            btnClear.Text = "🔄 Mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(980, 490);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 7;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmPromotionManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1084, 541);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(grpPromotionInfo);
            Controls.Add(dgvPromotions);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPromotionManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khuyến mãi";
            Load += frmPromotionManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPromotions).EndInit();
            grpPromotionInfo.ResumeLayout(false);
            grpPromotionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscountValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinOrder).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvPromotions;
        private GroupBox grpPromotionInfo;
        private Label lblName;
        private TextBox txtCode;
        private Label lblCode;
        private Label lblDiscountType;
        private TextBox txtName;
        private Label lblMinOrder;
        private NumericUpDown nudDiscountValue;
        private Label lblDiscountValue;
        private ComboBox cboDiscountType;
        private DateTimePicker dtpStartDate;
        private Label lblStartDate;
        private NumericUpDown nudMaxDiscount;
        private Label lblMaxDiscount;
        private NumericUpDown nudMinOrder;
        private Label lblUsedCountValue;
        private Label lblUsedCount;
        private NumericUpDown nudQuantity;
        private Label lblQuantity;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private CheckBox chkIsActive;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnClose;
    }
}
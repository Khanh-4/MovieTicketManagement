using System.Drawing;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmFoodManagement
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
            dgvFoods = new DataGridView();
            grpFoodInfo = new GroupBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            nudPrice = new NumericUpDown();
            lblStock = new Label();
            nudStock = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            chkIsActive = new CheckBox();
            btnClose = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFoods).BeginInit();
            grpFoodInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(350, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ ĐỒ ĂN & THỨC UỐNG";
            // 
            // dgvFoods
            // 
            dgvFoods.AllowUserToAddRows = false;
            dgvFoods.AllowUserToDeleteRows = false;
            dgvFoods.BackgroundColor = Color.White;
            dgvFoods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoods.Location = new Point(20, 60);
            dgvFoods.MultiSelect = false;
            dgvFoods.Name = "dgvFoods";
            dgvFoods.ReadOnly = true;
            dgvFoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoods.Size = new Size(600, 420);
            dgvFoods.TabIndex = 1;
            dgvFoods.CellClick += dgvFoods_CellClick;
            // 
            // grpFoodInfo
            // 
            grpFoodInfo.Controls.Add(chkIsActive);
            grpFoodInfo.Controls.Add(txtDescription);
            grpFoodInfo.Controls.Add(lblDescription);
            grpFoodInfo.Controls.Add(nudStock);
            grpFoodInfo.Controls.Add(lblStock);
            grpFoodInfo.Controls.Add(nudPrice);
            grpFoodInfo.Controls.Add(lblPrice);
            grpFoodInfo.Controls.Add(cboCategory);
            grpFoodInfo.Controls.Add(lblCategory);
            grpFoodInfo.Controls.Add(txtName);
            grpFoodInfo.Controls.Add(lblName);
            grpFoodInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFoodInfo.Location = new Point(640, 60);
            grpFoodInfo.Name = "grpFoodInfo";
            grpFoodInfo.Size = new Size(330, 350);
            grpFoodInfo.TabIndex = 2;
            grpFoodInfo.TabStop = false;
            grpFoodInfo.Text = "Thông tin đồ ăn";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(20, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Tên đồ ăn:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(125, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 25);
            txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(20, 70);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Danh mục:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(125, 67);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(180, 25);
            cboCategory.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(20, 105);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Giá bán:";
            // 
            // nudPrice
            // 
            nudPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrice.Location = new Point(125, 102);
            nudPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(120, 25);
            nudPrice.TabIndex = 5;
            nudPrice.ThousandsSeparator = true;
            // 
            // lblStock
            // 
            lblStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(20, 140);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 6;
            lblStock.Text = "Tồn kho:";
            // 
            // nudStock
            // 
            nudStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudStock.Location = new Point(125, 137);
            nudStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(80, 25);
            nudStock.TabIndex = 7;
            nudStock.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(20, 175);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(125, 172);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(180, 80);
            txtDescription.TabIndex = 9;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkIsActive.Location = new Point(125, 265);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(134, 21);
            chkIsActive.TabIndex = 10;
            chkIsActive.Text = "Đang kinh doanh";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(640, 425);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.TabIndex = 4;
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
            btnUpdate.Location = new Point(740, 425);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 35);
            btnUpdate.TabIndex = 5;
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
            btnDelete.Location = new Point(840, 425);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 35);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.WhiteSmoke;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(640, 475);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 35);
            btnClear.TabIndex = 7;
            btnClear.Text = "🔄 Mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(880, 475);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmFoodManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 530);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnClose);
            Controls.Add(grpFoodInfo);
            Controls.Add(dgvFoods);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmFoodManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Đồ ăn & Thức uống";
            Load += frmFoodManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFoods).EndInit();
            grpFoodInfo.ResumeLayout(false);
            grpFoodInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvFoods;
        private GroupBox grpFoodInfo;
        private Label lblCategory;
        private TextBox txtName;
        private Label lblName;
        private NumericUpDown nudStock;
        private Label lblStock;
        private NumericUpDown nudPrice;
        private Label lblPrice;
        private ComboBox cboCategory;
        private CheckBox chkIsActive;
        private TextBox txtDescription;
        private Label lblDescription;
        private Button btnClose;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}
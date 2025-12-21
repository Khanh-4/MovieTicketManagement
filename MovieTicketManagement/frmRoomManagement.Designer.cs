namespace MovieTicketManagement
{
    partial class frmRoomManagement
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
            dgvRooms = new DataGridView();
            grpRoomInfo = new GroupBox();
            lblRoomName = new Label();
            txtRoomName = new TextBox();
            lblRoomType = new Label();
            cboRoomType = new ComboBox();
            lblRows = new Label();
            nudRows = new NumericUpDown();
            lblSeatsPerRow = new Label();
            nudSeatsPerRow = new NumericUpDown();
            lblVipRow = new Label();
            nudVipRow = new NumericUpDown();
            lblVipNote = new Label();
            lblTotalSeats = new Label();
            lblTotalSeatsValue = new Label();
            chkIsActive = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            grpSeatPreview = new GroupBox();
            pnlSeats = new Panel();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            grpRoomInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSeatsPerRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudVipRow).BeginInit();
            grpSeatPreview.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(350, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ PHÒNG CHIẾU";
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(20, 60);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(550, 320);
            dgvRooms.TabIndex = 1;
            dgvRooms.CellClick += dgvRooms_CellClick;
            // 
            // grpRoomInfo
            // 
            grpRoomInfo.Controls.Add(chkIsActive);
            grpRoomInfo.Controls.Add(lblTotalSeatsValue);
            grpRoomInfo.Controls.Add(lblTotalSeats);
            grpRoomInfo.Controls.Add(lblVipNote);
            grpRoomInfo.Controls.Add(nudVipRow);
            grpRoomInfo.Controls.Add(lblVipRow);
            grpRoomInfo.Controls.Add(nudSeatsPerRow);
            grpRoomInfo.Controls.Add(lblSeatsPerRow);
            grpRoomInfo.Controls.Add(nudRows);
            grpRoomInfo.Controls.Add(lblRows);
            grpRoomInfo.Controls.Add(cboRoomType);
            grpRoomInfo.Controls.Add(lblRoomType);
            grpRoomInfo.Controls.Add(txtRoomName);
            grpRoomInfo.Controls.Add(lblRoomName);
            grpRoomInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpRoomInfo.Location = new Point(590, 60);
            grpRoomInfo.Name = "grpRoomInfo";
            grpRoomInfo.Size = new Size(380, 280);
            grpRoomInfo.TabIndex = 2;
            grpRoomInfo.TabStop = false;
            grpRoomInfo.Text = "Thông tin phòng";
            // 
            // lblRoomName
            // 
            lblRoomName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomName.Location = new Point(20, 35);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(100, 23);
            lblRoomName.TabIndex = 0;
            lblRoomName.Text = "Tên phòng:";
            // 
            // txtRoomName
            // 
            txtRoomName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomName.Location = new Point(130, 32);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(220, 25);
            txtRoomName.TabIndex = 1;
            // 
            // lblRoomType
            // 
            lblRoomType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomType.Location = new Point(20, 70);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(100, 23);
            lblRoomType.TabIndex = 2;
            lblRoomType.Text = "Loại phòng:";
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(130, 67);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(220, 25);
            cboRoomType.TabIndex = 3;
            // 
            // lblRows
            // 
            lblRows.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRows.Location = new Point(20, 110);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(100, 23);
            lblRows.TabIndex = 4;
            lblRows.Text = "Số hàng ghế:";
            // 
            // nudRows
            // 
            nudRows.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudRows.Location = new Point(130, 107);
            nudRows.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRows.Name = "nudRows";
            nudRows.Size = new Size(80, 25);
            nudRows.TabIndex = 5;
            nudRows.Value = new decimal(new int[] { 8, 0, 0, 0 });
            nudRows.ValueChanged += nudRows_ValueChanged;
            // 
            // lblSeatsPerRow
            // 
            lblSeatsPerRow.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeatsPerRow.Location = new Point(20, 145);
            lblSeatsPerRow.Name = "lblSeatsPerRow";
            lblSeatsPerRow.Size = new Size(100, 23);
            lblSeatsPerRow.TabIndex = 6;
            lblSeatsPerRow.Text = "Ghế mỗi hàng:";
            // 
            // nudSeatsPerRow
            // 
            nudSeatsPerRow.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudSeatsPerRow.Location = new Point(130, 142);
            nudSeatsPerRow.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudSeatsPerRow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSeatsPerRow.Name = "nudSeatsPerRow";
            nudSeatsPerRow.Size = new Size(80, 25);
            nudSeatsPerRow.TabIndex = 7;
            nudSeatsPerRow.Value = new decimal(new int[] { 10, 0, 0, 0 });
            nudSeatsPerRow.ValueChanged += nudSeatsPerRow_ValueChanged;
            // 
            // lblVipRow
            // 
            lblVipRow.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVipRow.Location = new Point(20, 180);
            lblVipRow.Name = "lblVipRow";
            lblVipRow.Size = new Size(100, 23);
            lblVipRow.TabIndex = 8;
            lblVipRow.Text = "Hàng VIP từ:";
            // 
            // nudVipRow
            // 
            nudVipRow.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudVipRow.Location = new Point(130, 177);
            nudVipRow.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudVipRow.Name = "nudVipRow";
            nudVipRow.Size = new Size(80, 25);
            nudVipRow.TabIndex = 9;
            // 
            // lblVipNote
            // 
            lblVipNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVipNote.ForeColor = Color.Gray;
            lblVipNote.Location = new Point(220, 180);
            lblVipNote.Name = "lblVipNote";
            lblVipNote.Size = new Size(130, 23);
            lblVipNote.TabIndex = 10;
            lblVipNote.Text = "(0 = không có VIP)";
            // 
            // lblTotalSeats
            // 
            lblTotalSeats.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSeats.Location = new Point(20, 215);
            lblTotalSeats.Name = "lblTotalSeats";
            lblTotalSeats.Size = new Size(100, 23);
            lblTotalSeats.TabIndex = 11;
            lblTotalSeats.Text = "Tổng số ghế:";
            // 
            // lblTotalSeatsValue
            // 
            lblTotalSeatsValue.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalSeatsValue.ForeColor = Color.Blue;
            lblTotalSeatsValue.Location = new Point(130, 215);
            lblTotalSeatsValue.Name = "lblTotalSeatsValue";
            lblTotalSeatsValue.Size = new Size(100, 23);
            lblTotalSeatsValue.TabIndex = 12;
            lblTotalSeatsValue.Text = "80";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkIsActive.Location = new Point(130, 245);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(128, 21);
            chkIsActive.TabIndex = 13;
            chkIsActive.Text = "Đang hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(590, 355);
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
            btnUpdate.Location = new Point(690, 355);
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
            btnDelete.Location = new Point(790, 355);
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
            btnClear.Location = new Point(890, 355);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 35);
            btnClear.TabIndex = 6;
            btnClear.Text = "🔄 Mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // grpSeatPreview
            // 
            grpSeatPreview.Controls.Add(pnlSeats);
            grpSeatPreview.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSeatPreview.Location = new Point(20, 400);
            grpSeatPreview.Name = "grpSeatPreview";
            grpSeatPreview.Size = new Size(950, 230);
            grpSeatPreview.TabIndex = 7;
            grpSeatPreview.TabStop = false;
            grpSeatPreview.Text = "Sơ đồ ghế (xem trước)";
            // 
            // pnlSeats
            // 
            pnlSeats.AutoScroll = true;
            pnlSeats.BackColor = Color.White;
            pnlSeats.BorderStyle = BorderStyle.FixedSingle;
            pnlSeats.Location = new Point(10, 25);
            pnlSeats.Name = "pnlSeats";
            pnlSeats.Size = new Size(930, 195);
            pnlSeats.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(880, 640);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 35);
            btnClose.TabIndex = 8;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmRoomManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(994, 681);
            Controls.Add(btnClose);
            Controls.Add(grpSeatPreview);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(grpRoomInfo);
            Controls.Add(dgvRooms);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmRoomManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng chiếu";
            Load += frmRoomManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            grpRoomInfo.ResumeLayout(false);
            grpRoomInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSeatsPerRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudVipRow).EndInit();
            grpSeatPreview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvRooms;
        private GroupBox grpRoomInfo;
        private Label lblRoomName;
        private ComboBox cboRoomType;
        private Label lblRoomType;
        private TextBox txtRoomName;
        private NumericUpDown nudSeatsPerRow;
        private Label lblSeatsPerRow;
        private NumericUpDown nudRows;
        private Label lblRows;
        private Label lblTotalSeatsValue;
        private Label lblTotalSeats;
        private Label lblVipNote;
        private NumericUpDown nudVipRow;
        private Label lblVipRow;
        private CheckBox chkIsActive;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpSeatPreview;
        private Panel pnlSeats;
        private Button btnClose;
    }
}
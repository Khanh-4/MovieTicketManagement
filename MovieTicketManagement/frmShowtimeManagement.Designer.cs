namespace MovieTicketManagement
{
    partial class frmShowtimeManagement
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
            dgvShowtimes = new DataGridView();
            lblMovie = new Label();
            cboMovies = new ComboBox();
            lblRoom = new Label();
            cboRooms = new ComboBox();
            lblStartTime = new Label();
            dtpStartDate = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            lblDuration = new Label();
            nudDuration = new NumericUpDown();
            lblEndTime = new Label();
            lblEndTimeValue = new Label();
            lblPrice = new Label();
            nudPrice = new NumericUpDown();
            chkIsActive = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvShowtimes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(345, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(222, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LỊCH CHIẾU";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvShowtimes
            // 
            dgvShowtimes.AllowUserToAddRows = false;
            dgvShowtimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShowtimes.Location = new Point(12, 61);
            dgvShowtimes.Name = "dgvShowtimes";
            dgvShowtimes.ReadOnly = true;
            dgvShowtimes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShowtimes.Size = new Size(550, 450);
            dgvShowtimes.TabIndex = 1;
            dgvShowtimes.CellClick += dgvShowtimes_CellClick;
            // 
            // lblMovie
            // 
            lblMovie.AutoSize = true;
            lblMovie.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovie.Location = new Point(627, 61);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(86, 15);
            lblMovie.TabIndex = 2;
            lblMovie.Text = "Chọn phim (*):";
            // 
            // cboMovies
            // 
            cboMovies.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMovies.FormattingEnabled = true;
            cboMovies.Location = new Point(627, 88);
            cboMovies.Name = "cboMovies";
            cboMovies.Size = new Size(250, 23);
            cboMovies.TabIndex = 3;
            cboMovies.SelectedIndexChanged += cboMovies_SelectedIndexChanged;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(627, 133);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(93, 15);
            lblRoom.TabIndex = 4;
            lblRoom.Text = "Chọn phòng (*):";
            // 
            // cboRooms
            // 
            cboRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRooms.FormattingEnabled = true;
            cboRooms.Location = new Point(627, 160);
            cboRooms.Name = "cboRooms";
            cboRooms.Size = new Size(250, 23);
            cboRooms.TabIndex = 5;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartTime.Location = new Point(627, 204);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(122, 15);
            lblStartTime.TabIndex = 6;
            lblStartTime.Text = "Thời gian bắt đầu (*):";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(627, 231);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(120, 23);
            dtpStartDate.TabIndex = 7;
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(786, 231);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(100, 23);
            dtpStartTime.TabIndex = 8;
            dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuration.Location = new Point(627, 279);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(110, 15);
            lblDuration.TabIndex = 9;
            lblDuration.Text = "Thời lượng (phút):";
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(743, 271);
            nudDuration.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudDuration.Name = "nudDuration";
            nudDuration.ReadOnly = true;
            nudDuration.Size = new Size(80, 23);
            nudDuration.TabIndex = 10;
            nudDuration.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndTime.Location = new Point(627, 316);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(112, 15);
            lblEndTime.TabIndex = 11;
            lblEndTime.Text = "Thời gian kết thúc:";
            // 
            // lblEndTimeValue
            // 
            lblEndTimeValue.AutoSize = true;
            lblEndTimeValue.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndTimeValue.Location = new Point(745, 316);
            lblEndTimeValue.Name = "lblEndTimeValue";
            lblEndTimeValue.Size = new Size(0, 15);
            lblEndTimeValue.TabIndex = 12;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(627, 354);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(60, 15);
            lblPrice.TabIndex = 13;
            lblPrice.Text = "Giá vé (*):";
            // 
            // nudPrice
            // 
            nudPrice.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
            nudPrice.Location = new Point(693, 346);
            nudPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudPrice.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(120, 23);
            nudPrice.TabIndex = 14;
            nudPrice.Value = new decimal(new int[] { 85000, 0, 0, 0 });
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkIsActive.Location = new Point(627, 392);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(115, 19);
            chkIsActive.TabIndex = 15;
            chkIsActive.Text = "Đang hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(627, 431);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(739, 431);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(627, 478);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(739, 478);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 19;
            btnClear.Text = "Xóa form";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Location = new Point(12, 537);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 20;
            // 
            // frmShowtimeManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(984, 561);
            Controls.Add(lblStatus);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(chkIsActive);
            Controls.Add(nudPrice);
            Controls.Add(lblPrice);
            Controls.Add(lblEndTimeValue);
            Controls.Add(lblEndTime);
            Controls.Add(nudDuration);
            Controls.Add(lblDuration);
            Controls.Add(dtpStartTime);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStartTime);
            Controls.Add(cboRooms);
            Controls.Add(lblRoom);
            Controls.Add(cboMovies);
            Controls.Add(lblMovie);
            Controls.Add(dgvShowtimes);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmShowtimeManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Lịch chiếu";
            Load += frmShowtimeManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvShowtimes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvShowtimes;
        private Label lblMovie;
        private ComboBox cboMovies;
        private Label lblRoom;
        private ComboBox cboRooms;
        private Label lblStartTime;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpStartTime;
        private Label lblDuration;
        private NumericUpDown nudDuration;
        private Label lblEndTime;
        private Label lblEndTimeValue;
        private Label lblPrice;
        private NumericUpDown nudPrice;
        private CheckBox chkIsActive;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label lblStatus;
    }
}
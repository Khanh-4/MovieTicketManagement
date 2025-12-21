namespace MovieTicketManagement
{
    partial class frmMovieManagement
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
            dgvMovies = new DataGridView();
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            lblMovieTitle = new Label();
            txtMovieTitle = new TextBox();
            lblDuration = new Label();
            nudDuration = new NumericUpDown();
            lblDirector = new Label();
            txtDirector = new TextBox();
            lblActors = new Label();
            txtActors = new TextBox();
            lblCountry = new Label();
            txtCountry = new TextBox();
            lblReleaseDate = new Label();
            dtpReleaseDate = new DateTimePicker();
            lblAgeRating = new Label();
            nudAgeRating = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            chkIsActive = new CheckBox();
            chkIsTrending = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAgeRating).BeginInit();
            SuspendLayout();
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToAddRows = false;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovies.Location = new Point(12, 117);
            dgvMovies.Name = "dgvMovies";
            dgvMovies.ReadOnly = true;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(500, 450);
            dgvMovies.TabIndex = 0;
            dgvMovies.CellClick += dgvMovies_CellClick;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(442, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "QUẢN LÝ PHIM";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(12, 60);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(62, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(80, 52);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(286, 52);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(71, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(12, 78);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblMovieTitle
            // 
            lblMovieTitle.AutoSize = true;
            lblMovieTitle.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieTitle.Location = new Point(643, 60);
            lblMovieTitle.Name = "lblMovieTitle";
            lblMovieTitle.Size = new Size(78, 15);
            lblMovieTitle.TabIndex = 6;
            lblMovieTitle.Text = "Tên phim (*):";
            // 
            // txtMovieTitle
            // 
            txtMovieTitle.Location = new Point(727, 52);
            txtMovieTitle.Name = "txtMovieTitle";
            txtMovieTitle.Size = new Size(345, 23);
            txtMovieTitle.TabIndex = 7;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuration.Location = new Point(643, 98);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(110, 15);
            lblDuration.TabIndex = 8;
            lblDuration.Text = "Thời lượng (phút):";
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(759, 90);
            nudDuration.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(107, 23);
            nudDuration.TabIndex = 10;
            nudDuration.Value = new decimal(new int[] { 90, 0, 0, 0 });
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDirector.Location = new Point(643, 134);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(60, 15);
            lblDirector.TabIndex = 11;
            lblDirector.Text = "Đạo diễn:";
            // 
            // txtDirector
            // 
            txtDirector.Location = new Point(709, 126);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(157, 23);
            txtDirector.TabIndex = 12;
            // 
            // lblActors
            // 
            lblActors.AutoSize = true;
            lblActors.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActors.Location = new Point(643, 179);
            lblActors.Name = "lblActors";
            lblActors.Size = new Size(61, 15);
            lblActors.TabIndex = 13;
            lblActors.Text = "Diễn viên:";
            // 
            // txtActors
            // 
            txtActors.Location = new Point(710, 171);
            txtActors.Name = "txtActors";
            txtActors.Size = new Size(100, 23);
            txtActors.TabIndex = 14;
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountry.Location = new Point(643, 223);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(60, 15);
            lblCountry.TabIndex = 15;
            lblCountry.Text = "Quốc gia:";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(709, 215);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(109, 23);
            txtCountry.TabIndex = 16;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReleaseDate.Location = new Point(643, 265);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(101, 15);
            lblReleaseDate.TabIndex = 17;
            lblReleaseDate.Text = "Ngày khởi chiếu:";
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.Location = new Point(750, 257);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(179, 23);
            dtpReleaseDate.TabIndex = 18;
            // 
            // lblAgeRating
            // 
            lblAgeRating.AutoSize = true;
            lblAgeRating.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgeRating.Location = new Point(643, 305);
            lblAgeRating.Name = "lblAgeRating";
            lblAgeRating.Size = new Size(81, 15);
            lblAgeRating.TabIndex = 19;
            lblAgeRating.Text = "Giới hạn tuổi:";
            // 
            // nudAgeRating
            // 
            nudAgeRating.Location = new Point(730, 297);
            nudAgeRating.Maximum = new decimal(new int[] { 21, 0, 0, 0 });
            nudAgeRating.Name = "nudAgeRating";
            nudAgeRating.Size = new Size(120, 23);
            nudAgeRating.TabIndex = 20;
            nudAgeRating.Value = new decimal(new int[] { 13, 0, 0, 0 });
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(643, 341);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(41, 15);
            lblDescription.TabIndex = 21;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(643, 369);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(300, 80);
            txtDescription.TabIndex = 22;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(643, 464);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(112, 19);
            chkIsActive.TabIndex = 23;
            chkIsActive.Text = "Đang hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkIsTrending
            // 
            chkIsTrending.AutoSize = true;
            chkIsTrending.Location = new Point(847, 464);
            chkIsTrending.Name = "chkIsTrending";
            chkIsTrending.Size = new Size(75, 19);
            chkIsTrending.TabIndex = 24;
            chkIsTrending.Text = "Phim hot";
            chkIsTrending.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnAdd.Location = new Point(643, 507);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 25;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnUpdate.Location = new Point(724, 507);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 26;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnDelete.Location = new Point(805, 507);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Arial", 9F, FontStyle.Bold);
            btnClear.Location = new Point(886, 507);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 28;
            btnClear.Text = "Xóa form";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(12, 587);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 29;
            // 
            // frmMovieManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1084, 611);
            Controls.Add(lblStatus);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(chkIsTrending);
            Controls.Add(chkIsActive);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(nudAgeRating);
            Controls.Add(lblAgeRating);
            Controls.Add(dtpReleaseDate);
            Controls.Add(lblReleaseDate);
            Controls.Add(txtCountry);
            Controls.Add(lblCountry);
            Controls.Add(txtActors);
            Controls.Add(lblActors);
            Controls.Add(txtDirector);
            Controls.Add(lblDirector);
            Controls.Add(nudDuration);
            Controls.Add(lblDuration);
            Controls.Add(txtMovieTitle);
            Controls.Add(lblMovieTitle);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Controls.Add(dgvMovies);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMovieManagement";
            Text = "Quản lý Phim";
            Load += frmMovieManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAgeRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMovies;
        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Label lblMovieTitle;
        private TextBox txtMovieTitle;
        private Label lblDuration;
        private NumericUpDown nudDuration;
        private Label lblDirector;
        private TextBox txtDirector;
        private Label lblActors;
        private TextBox txtActors;
        private Label lblCountry;
        private TextBox txtCountry;
        private Label lblReleaseDate;
        private DateTimePicker dtpReleaseDate;
        private Label lblAgeRating;
        private NumericUpDown nudAgeRating;
        private Label lblDescription;
        private TextBox txtDescription;
        private CheckBox chkIsActive;
        private CheckBox chkIsTrending;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label lblStatus;
    }
}
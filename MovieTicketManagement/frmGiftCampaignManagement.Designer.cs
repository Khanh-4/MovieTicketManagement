namespace MovieTicketManagement
{
    partial class frmGiftCampaignManagement
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpCampaignInfo = new System.Windows.Forms.GroupBox();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.lblCampaignStatus = new System.Windows.Forms.Label();
            this.lblConfirmedGifts = new System.Windows.Forms.Label();
            this.lblHoldingGifts = new System.Windows.Forms.Label();
            this.lblRemainingGifts = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.nudHoldTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblHoldTimeout = new System.Windows.Forms.Label();
            this.nudMaxPerUser = new System.Windows.Forms.NumericUpDown();
            this.lblMaxPerUser = new System.Windows.Forms.Label();
            this.nudTotalGifts = new System.Windows.Forms.NumericUpDown();
            this.lblTotalGifts = new System.Windows.Forms.Label();
            this.cboMovie = new System.Windows.Forms.ComboBox();
            this.lblMovie = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtGiftName = new System.Windows.Forms.TextBox();
            this.lblGiftName = new System.Windows.Forms.Label();
            this.txtCampaignName = new System.Windows.Forms.TextBox();
            this.lblCampaignName = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewStats = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvCampaigns = new System.Windows.Forms.DataGridView();
            this.lblTotalCampaigns = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpCampaignInfo.SuspendLayout();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoldTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPerUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalGifts)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampaigns)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1100, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎁 QUẢN LÝ CHIẾN DỊCH QUÀ TẶNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpCampaignInfo);
            this.pnlLeft.Controls.Add(this.grpInput);
            this.pnlLeft.Controls.Add(this.pnlButtons);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 60);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(380, 590);
            this.pnlLeft.TabIndex = 1;
            // 
            // grpCampaignInfo
            // 
            this.grpCampaignInfo.Controls.Add(this.lblTimeRemaining);
            this.grpCampaignInfo.Controls.Add(this.lblCampaignStatus);
            this.grpCampaignInfo.Controls.Add(this.lblConfirmedGifts);
            this.grpCampaignInfo.Controls.Add(this.lblHoldingGifts);
            this.grpCampaignInfo.Controls.Add(this.lblRemainingGifts);
            this.grpCampaignInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCampaignInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCampaignInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.grpCampaignInfo.Location = new System.Drawing.Point(10, 420);
            this.grpCampaignInfo.Name = "grpCampaignInfo";
            this.grpCampaignInfo.Size = new System.Drawing.Size(360, 110);
            this.grpCampaignInfo.TabIndex = 2;
            this.grpCampaignInfo.TabStop = false;
            this.grpCampaignInfo.Text = "📊 Thông tin chiến dịch đang chọn";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.Gray;
            this.lblTimeRemaining.Location = new System.Drawing.Point(15, 85);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(330, 20);
            this.lblTimeRemaining.TabIndex = 4;
            this.lblTimeRemaining.Text = "";
            // 
            // lblCampaignStatus
            // 
            this.lblCampaignStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCampaignStatus.ForeColor = System.Drawing.Color.Black;
            this.lblCampaignStatus.Location = new System.Drawing.Point(180, 55);
            this.lblCampaignStatus.Name = "lblCampaignStatus";
            this.lblCampaignStatus.Size = new System.Drawing.Size(165, 20);
            this.lblCampaignStatus.TabIndex = 3;
            this.lblCampaignStatus.Text = "Trạng thái: --";
            // 
            // lblConfirmedGifts
            // 
            this.lblConfirmedGifts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmedGifts.ForeColor = System.Drawing.Color.Green;
            this.lblConfirmedGifts.Location = new System.Drawing.Point(180, 35);
            this.lblConfirmedGifts.Name = "lblConfirmedGifts";
            this.lblConfirmedGifts.Size = new System.Drawing.Size(165, 20);
            this.lblConfirmedGifts.TabIndex = 2;
            this.lblConfirmedGifts.Text = "Đã xác nhận: --";
            // 
            // lblHoldingGifts
            // 
            this.lblHoldingGifts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoldingGifts.ForeColor = System.Drawing.Color.Orange;
            this.lblHoldingGifts.Location = new System.Drawing.Point(15, 55);
            this.lblHoldingGifts.Name = "lblHoldingGifts";
            this.lblHoldingGifts.Size = new System.Drawing.Size(150, 20);
            this.lblHoldingGifts.TabIndex = 1;
            this.lblHoldingGifts.Text = "Đang giữ: --";
            // 
            // lblRemainingGifts
            // 
            this.lblRemainingGifts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRemainingGifts.ForeColor = System.Drawing.Color.Blue;
            this.lblRemainingGifts.Location = new System.Drawing.Point(15, 35);
            this.lblRemainingGifts.Name = "lblRemainingGifts";
            this.lblRemainingGifts.Size = new System.Drawing.Size(150, 20);
            this.lblRemainingGifts.TabIndex = 0;
            this.lblRemainingGifts.Text = "Còn lại: --";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.chkIsActive);
            this.grpInput.Controls.Add(this.dtpEndDate);
            this.grpInput.Controls.Add(this.lblEndDate);
            this.grpInput.Controls.Add(this.dtpStartDate);
            this.grpInput.Controls.Add(this.lblStartDate);
            this.grpInput.Controls.Add(this.nudHoldTimeout);
            this.grpInput.Controls.Add(this.lblHoldTimeout);
            this.grpInput.Controls.Add(this.nudMaxPerUser);
            this.grpInput.Controls.Add(this.lblMaxPerUser);
            this.grpInput.Controls.Add(this.nudTotalGifts);
            this.grpInput.Controls.Add(this.lblTotalGifts);
            this.grpInput.Controls.Add(this.cboMovie);
            this.grpInput.Controls.Add(this.lblMovie);
            this.grpInput.Controls.Add(this.txtDescription);
            this.grpInput.Controls.Add(this.lblDescription);
            this.grpInput.Controls.Add(this.txtGiftName);
            this.grpInput.Controls.Add(this.lblGiftName);
            this.grpInput.Controls.Add(this.txtCampaignName);
            this.grpInput.Controls.Add(this.lblCampaignName);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.grpInput.Location = new System.Drawing.Point(10, 10);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(360, 410);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "📝 Thông tin chiến dịch";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkIsActive.ForeColor = System.Drawing.Color.Black;
            this.chkIsActive.Location = new System.Drawing.Point(120, 378);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(78, 19);
            this.chkIsActive.TabIndex = 18;
            this.chkIsActive.Text = "Hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(120, 345);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(220, 23);
            this.dtpEndDate.TabIndex = 17;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDate.ForeColor = System.Drawing.Color.Black;
            this.lblEndDate.Location = new System.Drawing.Point(15, 348);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(100, 20);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "Ngày kết thúc:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(120, 312);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(220, 23);
            this.dtpStartDate.TabIndex = 15;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDate.ForeColor = System.Drawing.Color.Black;
            this.lblStartDate.Location = new System.Drawing.Point(15, 315);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(100, 20);
            this.lblStartDate.TabIndex = 14;
            this.lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // nudHoldTimeout
            // 
            this.nudHoldTimeout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudHoldTimeout.Location = new System.Drawing.Point(120, 279);
            this.nudHoldTimeout.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.nudHoldTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudHoldTimeout.Name = "nudHoldTimeout";
            this.nudHoldTimeout.Size = new System.Drawing.Size(80, 23);
            this.nudHoldTimeout.TabIndex = 13;
            this.nudHoldTimeout.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblHoldTimeout
            // 
            this.lblHoldTimeout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoldTimeout.ForeColor = System.Drawing.Color.Black;
            this.lblHoldTimeout.Location = new System.Drawing.Point(15, 281);
            this.lblHoldTimeout.Name = "lblHoldTimeout";
            this.lblHoldTimeout.Size = new System.Drawing.Size(100, 20);
            this.lblHoldTimeout.TabIndex = 12;
            this.lblHoldTimeout.Text = "Timeout (phút):";
            // 
            // nudMaxPerUser
            // 
            this.nudMaxPerUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudMaxPerUser.Location = new System.Drawing.Point(120, 246);
            this.nudMaxPerUser.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudMaxPerUser.Name = "nudMaxPerUser";
            this.nudMaxPerUser.Size = new System.Drawing.Size(80, 23);
            this.nudMaxPerUser.TabIndex = 11;
            this.nudMaxPerUser.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMaxPerUser
            // 
            this.lblMaxPerUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxPerUser.ForeColor = System.Drawing.Color.Black;
            this.lblMaxPerUser.Location = new System.Drawing.Point(15, 248);
            this.lblMaxPerUser.Name = "lblMaxPerUser";
            this.lblMaxPerUser.Size = new System.Drawing.Size(100, 20);
            this.lblMaxPerUser.TabIndex = 10;
            this.lblMaxPerUser.Text = "Max/Người:";
            // 
            // nudTotalGifts
            // 
            this.nudTotalGifts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudTotalGifts.Location = new System.Drawing.Point(120, 213);
            this.nudTotalGifts.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudTotalGifts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudTotalGifts.Name = "nudTotalGifts";
            this.nudTotalGifts.Size = new System.Drawing.Size(100, 23);
            this.nudTotalGifts.TabIndex = 9;
            this.nudTotalGifts.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblTotalGifts
            // 
            this.lblTotalGifts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalGifts.ForeColor = System.Drawing.Color.Black;
            this.lblTotalGifts.Location = new System.Drawing.Point(15, 215);
            this.lblTotalGifts.Name = "lblTotalGifts";
            this.lblTotalGifts.Size = new System.Drawing.Size(100, 20);
            this.lblTotalGifts.TabIndex = 8;
            this.lblTotalGifts.Text = "Số lượng quà:";
            // 
            // cboMovie
            // 
            this.cboMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMovie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMovie.FormattingEnabled = true;
            this.cboMovie.Location = new System.Drawing.Point(120, 180);
            this.cboMovie.Name = "cboMovie";
            this.cboMovie.Size = new System.Drawing.Size(220, 23);
            this.cboMovie.TabIndex = 7;
            // 
            // lblMovie
            // 
            this.lblMovie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMovie.ForeColor = System.Drawing.Color.Black;
            this.lblMovie.Location = new System.Drawing.Point(15, 183);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(100, 20);
            this.lblMovie.TabIndex = 6;
            this.lblMovie.Text = "Áp dụng phim:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(120, 108);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(220, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(15, 111);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Mô tả:";
            // 
            // txtGiftName
            // 
            this.txtGiftName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiftName.Location = new System.Drawing.Point(120, 75);
            this.txtGiftName.Name = "txtGiftName";
            this.txtGiftName.Size = new System.Drawing.Size(220, 23);
            this.txtGiftName.TabIndex = 3;
            // 
            // lblGiftName
            // 
            this.lblGiftName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiftName.ForeColor = System.Drawing.Color.Black;
            this.lblGiftName.Location = new System.Drawing.Point(15, 78);
            this.lblGiftName.Name = "lblGiftName";
            this.lblGiftName.Size = new System.Drawing.Size(100, 20);
            this.lblGiftName.TabIndex = 2;
            this.lblGiftName.Text = "Tên quà tặng:";
            // 
            // txtCampaignName
            // 
            this.txtCampaignName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCampaignName.Location = new System.Drawing.Point(120, 42);
            this.txtCampaignName.Name = "txtCampaignName";
            this.txtCampaignName.Size = new System.Drawing.Size(220, 23);
            this.txtCampaignName.TabIndex = 1;
            // 
            // lblCampaignName
            // 
            this.lblCampaignName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCampaignName.ForeColor = System.Drawing.Color.Black;
            this.lblCampaignName.Location = new System.Drawing.Point(15, 45);
            this.lblCampaignName.Name = "lblCampaignName";
            this.lblCampaignName.Size = new System.Drawing.Size(100, 20);
            this.lblCampaignName.TabIndex = 0;
            this.lblCampaignName.Text = "Tên chiến dịch:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnViewStats);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnToggleActive);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(10, 535);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(5);
            this.pnlButtons.Size = new System.Drawing.Size(360, 45);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(310, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewStats
            // 
            this.btnViewStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnViewStats.FlatAppearance.BorderSize = 0;
            this.btnViewStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStats.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnViewStats.ForeColor = System.Drawing.Color.White;
            this.btnViewStats.Location = new System.Drawing.Point(260, 8);
            this.btnViewStats.Name = "btnViewStats";
            this.btnViewStats.Size = new System.Drawing.Size(45, 30);
            this.btnViewStats.TabIndex = 5;
            this.btnViewStats.Text = "📊";
            this.btnViewStats.UseVisualStyleBackColor = false;
            this.btnViewStats.Click += new System.EventHandler(this.btnViewStats_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(210, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "🔄";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(160, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(45, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnToggleActive
            // 
            this.btnToggleActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnToggleActive.Enabled = false;
            this.btnToggleActive.FlatAppearance.BorderSize = 0;
            this.btnToggleActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleActive.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnToggleActive.ForeColor = System.Drawing.Color.White;
            this.btnToggleActive.Location = new System.Drawing.Point(110, 8);
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size = new System.Drawing.Size(45, 30);
            this.btnToggleActive.TabIndex = 2;
            this.btnToggleActive.Text = "Dừng";
            this.btnToggleActive.UseVisualStyleBackColor = false;
            this.btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(58, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(47, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(5, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvCampaigns);
            this.pnlRight.Controls.Add(this.lblTotalCampaigns);
            this.pnlRight.Controls.Add(this.lblListTitle);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(380, 60);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(720, 590);
            this.pnlRight.TabIndex = 2;
            // 
            // dgvCampaigns
            // 
            this.dgvCampaigns.AllowUserToAddRows = false;
            this.dgvCampaigns.AllowUserToDeleteRows = false;
            this.dgvCampaigns.BackgroundColor = System.Drawing.Color.White;
            this.dgvCampaigns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampaigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCampaigns.Location = new System.Drawing.Point(10, 55);
            this.dgvCampaigns.MultiSelect = false;
            this.dgvCampaigns.Name = "dgvCampaigns";
            this.dgvCampaigns.ReadOnly = true;
            this.dgvCampaigns.RowHeadersVisible = false;
            this.dgvCampaigns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCampaigns.Size = new System.Drawing.Size(700, 525);
            this.dgvCampaigns.TabIndex = 2;
            this.dgvCampaigns.SelectionChanged += new System.EventHandler(this.dgvCampaigns_SelectionChanged);
            // 
            // lblTotalCampaigns
            // 
            this.lblTotalCampaigns.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalCampaigns.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalCampaigns.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalCampaigns.Location = new System.Drawing.Point(10, 35);
            this.lblTotalCampaigns.Name = "lblTotalCampaigns";
            this.lblTotalCampaigns.Size = new System.Drawing.Size(700, 20);
            this.lblTotalCampaigns.TabIndex = 1;
            this.lblTotalCampaigns.Text = "Tổng: 0 chiến dịch";
            // 
            // lblListTitle
            // 
            this.lblListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblListTitle.Location = new System.Drawing.Point(10, 10);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(700, 25);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "📋 DANH SÁCH CHIẾN DỊCH QUÀ TẶNG";
            // 
            // frmGiftCampaignManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGiftCampaignManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Chiến dịch Quà tặng";
            this.Load += new System.EventHandler(this.frmGiftCampaignManagement_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpCampaignInfo.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoldTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPerUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalGifts)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampaigns)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.DataGridView dgvCampaigns;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblCampaignName;
        private System.Windows.Forms.TextBox txtCampaignName;
        private System.Windows.Forms.Label lblGiftName;
        private System.Windows.Forms.TextBox txtGiftName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.ComboBox cboMovie;
        private System.Windows.Forms.Label lblTotalGifts;
        private System.Windows.Forms.NumericUpDown nudTotalGifts;
        private System.Windows.Forms.Label lblMaxPerUser;
        private System.Windows.Forms.NumericUpDown nudMaxPerUser;
        private System.Windows.Forms.Label lblHoldTimeout;
        private System.Windows.Forms.NumericUpDown nudHoldTimeout;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnToggleActive;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewStats;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalCampaigns;
        private System.Windows.Forms.GroupBox grpCampaignInfo;
        private System.Windows.Forms.Label lblRemainingGifts;
        private System.Windows.Forms.Label lblHoldingGifts;
        private System.Windows.Forms.Label lblConfirmedGifts;
        private System.Windows.Forms.Label lblCampaignStatus;
        private System.Windows.Forms.Label lblTimeRemaining;
    }
}
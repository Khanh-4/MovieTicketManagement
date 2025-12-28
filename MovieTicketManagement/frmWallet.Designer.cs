using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace MovieTicketManagement
{
    partial class frmWallet
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
            lblTitle = new Label();
            pnlBalance = new Panel();
            lblBalanceTitle = new Label();
            lblBalanceValue = new Label();
            lblUserName = new Label();
            btnDeposit = new Button();

            grpTransactions = new GroupBox();
            dgvTransactions = new DataGridView();
            lblTransactionCount = new Label();
            btnRefresh = new Button();

            btnClose = new Button();

            pnlBalance.SuspendLayout();
            grpTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();

            // ==================== TITLE ====================
            lblTitle.Text = "💰 VÍ CỦA TÔI";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(220, 15);
            lblTitle.AutoSize = true;

            // ==================== BALANCE PANEL ====================
            pnlBalance.BackColor = Color.FromArgb(240, 248, 255);
            pnlBalance.BorderStyle = BorderStyle.FixedSingle;
            pnlBalance.Location = new Point(20, 55);
            pnlBalance.Size = new Size(560, 100);

            lblUserName.Text = "Xin chào, Khách hàng";
            lblUserName.Font = new Font("Segoe UI", 10F);
            lblUserName.ForeColor = Color.Gray;
            lblUserName.Location = new Point(20, 15);
            lblUserName.Size = new Size(300, 20);

            lblBalanceTitle.Text = "Số dư hiện tại:";
            lblBalanceTitle.Font = new Font("Segoe UI", 11F);
            lblBalanceTitle.Location = new Point(20, 45);
            lblBalanceTitle.Size = new Size(120, 25);

            lblBalanceValue.Text = "0 đ";
            lblBalanceValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBalanceValue.ForeColor = Color.Green;
            lblBalanceValue.Location = new Point(140, 35);
            lblBalanceValue.Size = new Size(250, 45);

            btnDeposit.Text = "💳 Nạp tiền";
            btnDeposit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeposit.BackColor = Color.RoyalBlue;
            btnDeposit.ForeColor = Color.White;
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.Location = new Point(420, 35);
            btnDeposit.Size = new Size(120, 40);
            btnDeposit.Click += btnDeposit_Click;

            pnlBalance.Controls.Add(lblUserName);
            pnlBalance.Controls.Add(lblBalanceTitle);
            pnlBalance.Controls.Add(lblBalanceValue);
            pnlBalance.Controls.Add(btnDeposit);

            // ==================== TRANSACTIONS ====================
            grpTransactions.Text = "📜 Lịch sử giao dịch";
            grpTransactions.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpTransactions.Location = new Point(20, 165);
            grpTransactions.Size = new Size(560, 280);

            dgvTransactions.Location = new Point(10, 25);
            dgvTransactions.Size = new Size(540, 210);
            dgvTransactions.Font = new Font("Segoe UI", 9F);
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.BackgroundColor = Color.White;

            lblTransactionCount.Text = "Có 0 giao dịch";
            lblTransactionCount.Font = new Font("Segoe UI", 9F);
            lblTransactionCount.ForeColor = Color.Gray;
            lblTransactionCount.Location = new Point(10, 245);
            lblTransactionCount.Size = new Size(200, 20);

            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(455, 242);
            btnRefresh.Size = new Size(95, 28);
            btnRefresh.Click += btnRefresh_Click;

            grpTransactions.Controls.Add(dgvTransactions);
            grpTransactions.Controls.Add(lblTransactionCount);
            grpTransactions.Controls.Add(btnRefresh);

            // ==================== BUTTONS ====================
            btnClose.Text = "❌ Đóng";
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(480, 460);
            btnClose.Size = new Size(100, 35);
            btnClose.Click += btnClose_Click;

            // ==================== FORM ====================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 510);
            Controls.Add(lblTitle);
            Controls.Add(pnlBalance);
            Controls.Add(grpTransactions);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ví của tôi - Movie Ticket System";
            Load += frmWallet_Load;

            pnlBalance.ResumeLayout(false);
            grpTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlBalance;
        private Label lblUserName;
        private Label lblBalanceTitle;
        private Label lblBalanceValue;
        private Button btnDeposit;

        private GroupBox grpTransactions;
        private DataGridView dgvTransactions;
        private Label lblTransactionCount;
        private Button btnRefresh;

        private Button btnClose;
    }
}
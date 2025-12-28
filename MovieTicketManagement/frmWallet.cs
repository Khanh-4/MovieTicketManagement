using System;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmWallet : Form
    {
        private readonly WalletBLL walletBLL = new WalletBLL();
        private UserDTO currentUser;

        public frmWallet(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmWallet_Load(object sender, EventArgs e)
        {
            LoadWalletInfo();
            LoadTransactionHistory();
        }

        // Load thông tin ví
        private void LoadWalletInfo()
        {
            try
            {
                var wallet = walletBLL.GetWallet(currentUser.UserID);
                lblBalanceValue.Text = $"{wallet.Balance:N0} đ";
                lblUserName.Text = $"Xin chào, {currentUser.FullName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin ví: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load lịch sử giao dịch
        private void LoadTransactionHistory()
        {
            try
            {
                var transactions = walletBLL.GetTransactionHistory(currentUser.UserID);

                dgvTransactions.DataSource = null;
                dgvTransactions.DataSource = transactions;

                if (dgvTransactions.Columns.Count > 0)
                {
                    // Ẩn tất cả cột
                    foreach (DataGridViewColumn col in dgvTransactions.Columns)
                    {
                        col.Visible = false;
                    }

                    // Hiển thị các cột cần thiết
                    if (dgvTransactions.Columns.Contains("CreatedAt"))
                    {
                        dgvTransactions.Columns["CreatedAt"].Visible = true;
                        dgvTransactions.Columns["CreatedAt"].HeaderText = "Ngày";
                        dgvTransactions.Columns["CreatedAt"].Width = 130;
                        dgvTransactions.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvTransactions.Columns.Contains("DisplayType"))
                    {
                        dgvTransactions.Columns["DisplayType"].Visible = true;
                        dgvTransactions.Columns["DisplayType"].HeaderText = "Loại";
                        dgvTransactions.Columns["DisplayType"].Width = 130;
                    }
                    if (dgvTransactions.Columns.Contains("Description"))
                    {
                        dgvTransactions.Columns["Description"].Visible = true;
                        dgvTransactions.Columns["Description"].HeaderText = "Mô tả";
                        dgvTransactions.Columns["Description"].Width = 200;
                    }
                    if (dgvTransactions.Columns.Contains("DisplayAmount"))
                    {
                        dgvTransactions.Columns["DisplayAmount"].Visible = true;
                        dgvTransactions.Columns["DisplayAmount"].HeaderText = "Số tiền";
                        dgvTransactions.Columns["DisplayAmount"].Width = 100;
                    }
                }

                // Tô màu số tiền
                foreach (DataGridViewRow row in dgvTransactions.Rows)
                {
                    var transaction = row.DataBoundItem as WalletTransactionDTO;
                    if (transaction != null && dgvTransactions.Columns.Contains("DisplayAmount"))
                    {
                        if (transaction.Amount >= 0)
                        {
                            row.Cells["DisplayAmount"].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            row.Cells["DisplayAmount"].Style.ForeColor = Color.Red;
                        }
                        row.Cells["DisplayAmount"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }

                lblTransactionCount.Text = $"Có {transactions.Count} giao dịch";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử giao dịch: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Nạp tiền
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            using (var dialog = new frmDeposit(currentUser))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadWalletInfo();
                    LoadTransactionHistory();
                }
            }
        }

        // Nút Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWalletInfo();
            LoadTransactionHistory();
        }

        // Nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // ============================================
    // FORM NẠP TIỀN (Dialog)
    // ============================================
    public class frmDeposit : Form
    {
        private Label lblTitle;
        private Label lblAmount;
        private NumericUpDown nudAmount;
        private Label lblNote;
        private TextBox txtNote;
        private Button btnDeposit;
        private Button btnCancel;

        private readonly WalletBLL walletBLL = new WalletBLL();
        private UserDTO currentUser;

        public frmDeposit(UserDTO user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblAmount = new Label();
            nudAmount = new NumericUpDown();
            lblNote = new Label();
            txtNote = new TextBox();
            btnDeposit = new Button();
            btnCancel = new Button();

            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();

            // Title
            lblTitle.Text = "💰 NẠP TIỀN VÀO VÍ";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(90, 15);
            lblTitle.AutoSize = true;

            // Amount
            lblAmount.Text = "Số tiền nạp:";
            lblAmount.Font = new Font("Segoe UI", 10F);
            lblAmount.Location = new Point(20, 60);
            lblAmount.Size = new Size(100, 25);

            nudAmount.Font = new Font("Segoe UI", 11F);
            nudAmount.Location = new Point(120, 57);
            nudAmount.Size = new Size(180, 30);
            nudAmount.Minimum = 10000;
            nudAmount.Maximum = 10000000;
            nudAmount.Value = 100000;
            nudAmount.Increment = 10000;
            nudAmount.ThousandsSeparator = true;

            // Note
            lblNote.Text = "Ghi chú:";
            lblNote.Font = new Font("Segoe UI", 10F);
            lblNote.Location = new Point(20, 100);
            lblNote.Size = new Size(100, 25);

            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(120, 97);
            txtNote.Size = new Size(180, 25);
            txtNote.Text = "Nạp tiền vào ví";

            // Buttons
            btnDeposit.Text = "✅ Nạp tiền";
            btnDeposit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeposit.BackColor = Color.MediumSeaGreen;
            btnDeposit.ForeColor = Color.White;
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.Location = new Point(50, 145);
            btnDeposit.Size = new Size(110, 35);
            btnDeposit.Click += BtnDeposit_Click;

            btnCancel.Text = "❌ Hủy";
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(180, 145);
            btnCancel.Size = new Size(110, 35);
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // Form
            Text = "Nạp tiền";
            ClientSize = new Size(330, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            Controls.Add(lblTitle);
            Controls.Add(lblAmount);
            Controls.Add(nudAmount);
            Controls.Add(lblNote);
            Controls.Add(txtNote);
            Controls.Add(btnDeposit);
            Controls.Add(btnCancel);

            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = nudAmount.Value;
                string note = txtNote.Text.Trim();

                if (amount < 10000)
                {
                    MessageBox.Show("Số tiền nạp tối thiểu là 10,000đ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận
                DialogResult result = MessageBox.Show(
                    $"Xác nhận nạp {amount:N0}đ vào ví?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = walletBLL.Deposit(currentUser.UserID, amount, note);
                    if (success)
                    {
                        MessageBox.Show($"Nạp tiền thành công!\n+{amount:N0}đ", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Nạp tiền thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
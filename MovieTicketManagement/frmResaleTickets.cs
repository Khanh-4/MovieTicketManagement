using System;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmResaleTickets : Form
    {
        private readonly ResaleBLL resaleBLL = new ResaleBLL();
        private readonly WalletBLL walletBLL = new WalletBLL();
        private UserDTO currentUser;
        private TicketResaleDTO selectedResale;

        public frmResaleTickets(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmResaleTickets_Load(object sender, EventArgs e)
        {
            LoadAvailableResales();
            UpdateWalletInfo();
        }

        // Load danh sách vé pass đang bán
        private void LoadAvailableResales()
        {
            try
            {
                var resales = resaleBLL.GetAvailableResales();

                dgvResales.DataSource = null;
                dgvResales.DataSource = resales;

                if (dgvResales.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn col in dgvResales.Columns)
                    {
                        col.Visible = false;
                    }

                    if (dgvResales.Columns.Contains("MovieTitle"))
                    {
                        dgvResales.Columns["MovieTitle"].Visible = true;
                        dgvResales.Columns["MovieTitle"].HeaderText = "Phim";
                        dgvResales.Columns["MovieTitle"].Width = 150;
                    }
                    if (dgvResales.Columns.Contains("DisplayShowTime"))
                    {
                        dgvResales.Columns["DisplayShowTime"].Visible = true;
                        dgvResales.Columns["DisplayShowTime"].HeaderText = "Suất chiếu";
                        dgvResales.Columns["DisplayShowTime"].Width = 120;
                    }
                    if (dgvResales.Columns.Contains("RoomName"))
                    {
                        dgvResales.Columns["RoomName"].Visible = true;
                        dgvResales.Columns["RoomName"].HeaderText = "Phòng";
                        dgvResales.Columns["RoomName"].Width = 70;
                    }
                    if (dgvResales.Columns.Contains("SeatInfo"))
                    {
                        dgvResales.Columns["SeatInfo"].Visible = true;
                        dgvResales.Columns["SeatInfo"].HeaderText = "Ghế";
                        dgvResales.Columns["SeatInfo"].Width = 80;
                    }
                    if (dgvResales.Columns.Contains("DisplayOriginalPrice"))
                    {
                        dgvResales.Columns["DisplayOriginalPrice"].Visible = true;
                        dgvResales.Columns["DisplayOriginalPrice"].HeaderText = "Giá gốc";
                        dgvResales.Columns["DisplayOriginalPrice"].Width = 90;
                    }
                    if (dgvResales.Columns.Contains("DisplayResalePrice"))
                    {
                        dgvResales.Columns["DisplayResalePrice"].Visible = true;
                        dgvResales.Columns["DisplayResalePrice"].HeaderText = "Giá pass";
                        dgvResales.Columns["DisplayResalePrice"].Width = 90;
                    }
                    if (dgvResales.Columns.Contains("DisplayDiscount"))
                    {
                        dgvResales.Columns["DisplayDiscount"].Visible = true;
                        dgvResales.Columns["DisplayDiscount"].HeaderText = "Giảm";
                        dgvResales.Columns["DisplayDiscount"].Width = 60;
                    }
                    if (dgvResales.Columns.Contains("DisplayTimeRemaining"))
                    {
                        dgvResales.Columns["DisplayTimeRemaining"].Visible = true;
                        dgvResales.Columns["DisplayTimeRemaining"].HeaderText = "Còn lại";
                        dgvResales.Columns["DisplayTimeRemaining"].Width = 100;
                    }
                }

                // Tô màu
                foreach (DataGridViewRow row in dgvResales.Rows)
                {
                    if (dgvResales.Columns.Contains("DisplayResalePrice"))
                    {
                        row.Cells["DisplayResalePrice"].Style.ForeColor = Color.Green;
                        row.Cells["DisplayResalePrice"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    if (dgvResales.Columns.Contains("DisplayDiscount"))
                    {
                        row.Cells["DisplayDiscount"].Style.ForeColor = Color.Red;
                        row.Cells["DisplayDiscount"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }

                lblStatus.Text = $"Có {resales.Count} vé pass đang bán";
                lblStatus.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật thông tin ví
        private void UpdateWalletInfo()
        {
            try
            {
                var wallet = walletBLL.GetWallet(currentUser.UserID);
                lblWalletBalance.Text = $"{wallet.Balance:N0} đ";
            }
            catch { }
        }

        // Khi chọn vé pass
        private void dgvResales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResales.CurrentRow == null)
            {
                ClearSelection();
                return;
            }

            selectedResale = dgvResales.CurrentRow.DataBoundItem as TicketResaleDTO;
            if (selectedResale == null)
            {
                ClearSelection();
                return;
            }

            // Hiển thị thông tin chi tiết
            lblMovieValue.Text = selectedResale.MovieTitle;
            lblShowtimeValue.Text = selectedResale.DisplayShowTime;
            lblRoomValue.Text = selectedResale.RoomName;
            lblSeatValue.Text = selectedResale.SeatInfo;
            lblOriginalPriceValue.Text = selectedResale.DisplayOriginalPrice;
            lblResalePriceValue.Text = selectedResale.DisplayResalePrice;
            lblDiscountValue.Text = selectedResale.DisplayDiscount;
            lblTimeRemainingValue.Text = selectedResale.DisplayTimeRemaining;
            lblSellerValue.Text = selectedResale.SellerName;

            grpDetail.Enabled = true;
            btnBuyTicket.Enabled = true;
        }

        // Xóa selection
        private void ClearSelection()
        {
            selectedResale = null;
            lblMovieValue.Text = "-";
            lblShowtimeValue.Text = "-";
            lblRoomValue.Text = "-";
            lblSeatValue.Text = "-";
            lblOriginalPriceValue.Text = "-";
            lblResalePriceValue.Text = "-";
            lblDiscountValue.Text = "-";
            lblTimeRemainingValue.Text = "-";
            lblSellerValue.Text = "-";

            grpDetail.Enabled = false;
            btnBuyTicket.Enabled = false;
        }

        // Nút Mua vé
        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            if (selectedResale == null)
            {
                MessageBox.Show("Vui lòng chọn vé cần mua!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra không mua vé của chính mình
            if (selectedResale.SellerUserID == currentUser.UserID)
            {
                MessageBox.Show("Bạn không thể mua vé của chính mình!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định phương thức thanh toán
            string paymentMethod = "Cash";
            if (rdoWallet.Checked)
            {
                paymentMethod = "Wallet";

                // Kiểm tra số dư
                var wallet = walletBLL.GetWallet(currentUser.UserID);
                if (wallet.Balance < selectedResale.ResalePrice)
                {
                    MessageBox.Show($"Số dư ví không đủ!\n\nCần: {selectedResale.ResalePrice:N0} đ\nHiện có: {wallet.Balance:N0} đ",
                        "Không đủ tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Xác nhận mua
            decimal savings = selectedResale.OriginalPrice - selectedResale.ResalePrice;
            string confirmMessage = $"Xác nhận MUA VÉ PASS:\n\n" +
                                   $"🎬 Phim: {selectedResale.MovieTitle}\n" +
                                   $"📅 Suất: {selectedResale.DisplayShowTime}\n" +
                                   $"🏠 Phòng: {selectedResale.RoomName}\n" +
                                   $"💺 Ghế: {selectedResale.SeatInfo}\n\n" +
                                   $"💰 Giá gốc: {selectedResale.OriginalPrice:N0} đ\n" +
                                   $"🏷️ Giá pass: {selectedResale.ResalePrice:N0} đ ({selectedResale.DisplayDiscount})\n" +
                                   $"💳 Thanh toán: {(paymentMethod == "Wallet" ? "Ví tiền" : "Tiền mặt")}\n\n" +
                                   $"🎉 Bạn tiết kiệm: {savings:N0} đ!\n\n" +
                                   $"Xác nhận mua vé?";

            DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận mua vé",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var buyResult = resaleBLL.BuyResaleTicket(
                        selectedResale.ResaleID,
                        currentUser.UserID,
                        paymentMethod);

                    if (buyResult.success)
                    {
                        MessageBox.Show(buyResult.message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hỏi có muốn in vé không
                        DialogResult printResult = MessageBox.Show("Bạn có muốn in vé không?",
                            "In vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (printResult == DialogResult.Yes)
                        {
                            try
                            {
                                frmTicketPrint frmPrint = new frmTicketPrint(buyResult.newBookingId);
                                frmPrint.ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Không thể mở form in vé: {ex.Message}", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        // Refresh
                        LoadAvailableResales();
                        UpdateWalletInfo();
                        ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show(buyResult.message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mua vé: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAvailableResales();
            UpdateWalletInfo();
            ClearSelection();
        }

        // Nút Đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút Xem ví
        private void btnViewWallet_Click(object sender, EventArgs e)
        {
            frmWallet frm = new frmWallet(currentUser);
            frm.ShowDialog();
            UpdateWalletInfo();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmMembership : Form
    {
        private MembershipBLL membershipBLL = new MembershipBLL();
        private int userId;
        private MembershipDTO currentMembership;

        public frmMembership(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void frmMembership_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadMembershipInfo();
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionDate",
                HeaderText = "Ngày",
                DataPropertyName = "TransactionDate",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TransactionType",
                HeaderText = "Loại",
                DataPropertyName = "TransactionType",
                Width = 80
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Points",
                HeaderText = "Điểm",
                DataPropertyName = "Points",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Mô tả",
                DataPropertyName = "Description",
                Width = 290
            });
        }

        // Load thông tin hội viên
        private void LoadMembershipInfo()
        {
            try
            {
                currentMembership = membershipBLL.GetByUserId(userId);

                if (currentMembership == null)
                {
                    // Chưa có membership, tạo mới
                    int newId = membershipBLL.CreateMembership(userId);
                    if (newId > 0)
                    {
                        currentMembership = membershipBLL.GetByUserId(userId);
                    }
                }

                if (currentMembership != null)
                {
                    DisplayMembershipInfo();
                    LoadPointHistory();
                    CalculateProgress();
                }
                else
                {
                    MessageBox.Show("Không thể tải thông tin hội viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị thông tin hội viên
        private void DisplayMembershipInfo()
        {
            lblNameValue.Text = currentMembership.CustomerName;
            lblTypeValue.Text = currentMembership.TypeName;
            lblPointsValue.Text = currentMembership.Points.ToString("N0");
            lblJoinDateValue.Text = currentMembership.JoinDate.ToString("dd/MM/yyyy");

            // Ưu đãi
            if (currentMembership.DiscountPercent > 0)
            {
                lblDiscountValue.Text = $"Giảm {currentMembership.DiscountPercent}% giá vé";
            }
            else
            {
                lblDiscountValue.Text = "Chưa có ưu đãi";
            }

            // Quyền lợi
            lblBenefitsValue.Text = currentMembership.Benefits ?? "Tích điểm khi mua vé";

            // Màu sắc theo hạng
            SetTypeColor(currentMembership.TypeName);
        }

        // Đặt màu theo hạng hội viên
        private void SetTypeColor(string typeName)
        {
            switch (typeName)
            {
                case "Kim cương":
                    lblTypeValue.ForeColor = Color.DeepSkyBlue;
                    break;
                case "Vàng":
                    lblTypeValue.ForeColor = Color.Gold;
                    break;
                case "Bạc":
                    lblTypeValue.ForeColor = Color.Silver;
                    break;
                default:
                    lblTypeValue.ForeColor = Color.DarkOrange;
                    break;
            }
        }

        // Tính toán tiến độ nâng hạng
        private void CalculateProgress()
        {
            try
            {
                List<MembershipTypeDTO> types = membershipBLL.GetAllTypes();
                int currentPoints = currentMembership.Points;
                int currentTypeId = currentMembership.MembershipTypeID;

                // Tìm hạng tiếp theo
                MembershipTypeDTO nextType = null;
                MembershipTypeDTO currentType = null;

                foreach (var type in types)
                {
                    if (type.MembershipTypeID == currentTypeId)
                    {
                        currentType = type;
                    }
                    else if (currentType != null && nextType == null && type.PointsRequired > currentPoints)
                    {
                        nextType = type;
                        break;
                    }
                }

                if (nextType != null && currentType != null)
                {
                    // Tính % tiến độ
                    int pointsNeeded = nextType.PointsRequired - currentType.PointsRequired;
                    int pointsEarned = currentPoints - currentType.PointsRequired;
                    int percent = (int)((double)pointsEarned / pointsNeeded * 100);
                    percent = Math.Min(percent, 100);
                    percent = Math.Max(percent, 0);

                    progressBar.Value = percent;
                    lblProgressPercent.Text = $"{percent}%";
                    lblNextLevel.Text = $"Còn {nextType.PointsRequired - currentPoints:N0} điểm để lên hạng {nextType.TypeName}";
                }
                else
                {
                    // Đã đạt hạng cao nhất
                    progressBar.Value = 100;
                    lblProgressPercent.Text = "100%";
                    lblNextLevel.Text = "🎉 Bạn đã đạt hạng cao nhất!";
                    lblNextLevel.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblNextLevel.Text = "Không thể tính tiến độ: " + ex.Message;
            }
        }

        // Load lịch sử điểm
        private void LoadPointHistory()
        {
            try
            {
                List<PointTransactionDTO> history = membershipBLL.GetPointHistory(currentMembership.MembershipID);

                // Format loại giao dịch
                foreach (var item in history)
                {
                    switch (item.TransactionType)
                    {
                        case "Earn":
                            item.TransactionType = "Tích điểm";
                            break;
                        case "Redeem":
                            item.TransactionType = "Đổi điểm";
                            break;
                        case "Expire":
                            item.TransactionType = "Hết hạn";
                            break;
                        case "Adjust":
                            item.TransactionType = "Điều chỉnh";
                            break;
                    }
                }

                dgvHistory.DataSource = null;
                dgvHistory.DataSource = history;

                // Tô màu điểm
                foreach (DataGridViewRow row in dgvHistory.Rows)
                {
                    if (row.Cells["Points"].Value != null)
                    {
                        int points = Convert.ToInt32(row.Cells["Points"].Value);
                        if (points > 0)
                        {
                            row.Cells["Points"].Style.ForeColor = Color.Green;
                            row.Cells["Points"].Value = "+" + points;
                        }
                        else if (points < 0)
                        {
                            row.Cells["Points"].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử điểm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
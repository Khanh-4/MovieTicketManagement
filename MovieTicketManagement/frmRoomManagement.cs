using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;

namespace MovieTicketManagement
{
    public partial class frmRoomManagement : Form
    {
        private RoomBLL roomBLL = new RoomBLL();
        private int selectedRoomId = 0;
        private bool isAddMode = true;

        public frmRoomManagement()
        {
            InitializeComponent();
        }

        private void frmRoomManagement_Load(object sender, EventArgs e)
        {
            LoadRoomTypes();
            SetupDataGridView();
            LoadRooms();
            UpdateTotalSeats();
            SetAddMode();
        }

        // Load danh sách loại phòng
        private void LoadRoomTypes()
        {
            cboRoomType.Items.Clear();
            cboRoomType.Items.Add("Standard");
            cboRoomType.Items.Add("VIP");
            cboRoomType.Items.Add("IMAX");
            cboRoomType.Items.Add("4DX");
            cboRoomType.SelectedIndex = 0;
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dgvRooms.AutoGenerateColumns = false;
            dgvRooms.Columns.Clear();

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomID",
                HeaderText = "ID",
                DataPropertyName = "RoomID",
                Width = 50
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomName",
                HeaderText = "Tên phòng",
                DataPropertyName = "RoomName",
                Width = 150
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomType",
                HeaderText = "Loại phòng",
                DataPropertyName = "RoomType",
                Width = 100
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalSeats",
                HeaderText = "Số ghế",
                DataPropertyName = "TotalSeats",
                Width = 80
            });

            dgvRooms.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Hoạt động",
                DataPropertyName = "IsActive",
                Width = 80
            });
        }

        // Load danh sách phòng
        private void LoadRooms()
        {
            try
            {
                List<RoomDTO> rooms = roomBLL.GetAll();
                dgvRooms.DataSource = null;
                dgvRooms.DataSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi click vào dòng trong DataGridView
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvRooms.Rows.Count)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                if (row.DataBoundItem is RoomDTO room)
                {
                    selectedRoomId = room.RoomID;
                    DisplayRoomInfo(room);
                    SetEditMode();
                }
            }
        }

        // Hiển thị thông tin phòng lên form
        private void DisplayRoomInfo(RoomDTO room)
        {
            txtRoomName.Text = room.RoomName;
            cboRoomType.SelectedItem = room.RoomType;
            chkIsActive.Checked = room.IsActive;

            // Lấy thông tin ghế của phòng
            var seatInfo = roomBLL.GetRoomSeatInfo(room.RoomID);
            if (seatInfo.Rows > 0)
            {
                nudRows.Value = seatInfo.Rows;
                nudSeatsPerRow.Value = seatInfo.SeatsPerRow;
                nudVipRow.Value = seatInfo.VipRowStart;
            }
            else
            {
                nudRows.Value = 8;
                nudSeatsPerRow.Value = 10;
                nudVipRow.Value = 0;
            }

            UpdateTotalSeats();
            DrawSeatPreview();
        }

        // Cập nhật tổng số ghế
        private void UpdateTotalSeats()
        {
            int total = (int)(nudRows.Value * nudSeatsPerRow.Value);
            lblTotalSeatsValue.Text = total.ToString();
        }

        // Vẽ sơ đồ ghế xem trước
        private void DrawSeatPreview()
        {
            pnlSeats.Controls.Clear();

            int rows = (int)nudRows.Value;
            int seatsPerRow = (int)nudSeatsPerRow.Value;
            int vipRowStart = (int)nudVipRow.Value;

            int buttonSize = 35;
            int padding = 5;
            int startX = 50;
            int startY = 10;

            // Vẽ nhãn "MÀN HÌNH"
            Label lblScreen = new Label
            {
                Text = "MÀN HÌNH",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.DarkSlateGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(startX, startY),
                Size = new Size(seatsPerRow * (buttonSize + padding), 25)
            };
            pnlSeats.Controls.Add(lblScreen);

            startY += 35;

            for (int row = 0; row < rows; row++)
            {
                string rowLabel = ((char)('A' + row)).ToString();
                bool isVip = (vipRowStart > 0 && row >= vipRowStart - 1);

                // Label hàng
                Label lblRow = new Label
                {
                    Text = rowLabel,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(10, startY + row * (buttonSize + padding)),
                    Size = new Size(30, buttonSize)
                };
                pnlSeats.Controls.Add(lblRow);

                for (int seat = 1; seat <= seatsPerRow; seat++)
                {
                    Button btnSeat = new Button
                    {
                        Text = seat.ToString(),
                        Font = new Font("Segoe UI", 8),
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(startX + (seat - 1) * (buttonSize + padding), startY + row * (buttonSize + padding)),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = isVip ? Color.Gold : Color.LightGreen,
                        ForeColor = Color.Black,
                        Enabled = false
                    };
                    btnSeat.FlatAppearance.BorderColor = Color.Gray;
                    pnlSeats.Controls.Add(btnSeat);
                }
            }

            // Chú thích
            int legendY = startY + rows * (buttonSize + padding) + 10;

            Panel pnlNormal = new Panel { BackColor = Color.LightGreen, Size = new Size(20, 20), Location = new Point(startX, legendY) };
            Label lblNormal = new Label { Text = "Ghế thường", Location = new Point(startX + 25, legendY), AutoSize = true };

            Panel pnlVip = new Panel { BackColor = Color.Gold, Size = new Size(20, 20), Location = new Point(startX + 120, legendY) };
            Label lblVip = new Label { Text = "Ghế VIP", Location = new Point(startX + 145, legendY), AutoSize = true };

            pnlSeats.Controls.Add(pnlNormal);
            pnlSeats.Controls.Add(lblNormal);
            pnlSeats.Controls.Add(pnlVip);
            pnlSeats.Controls.Add(lblVip);
        }

        // Chế độ thêm mới
        private void SetAddMode()
        {
            isAddMode = true;
            selectedRoomId = 0;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            grpRoomInfo.Text = "Thông tin phòng (Thêm mới)";
        }

        // Chế độ chỉnh sửa
        private void SetEditMode()
        {
            isAddMode = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            grpRoomInfo.Text = "Thông tin phòng (Chỉnh sửa)";
        }

        // Xóa form
        private void ClearForm()
        {
            txtRoomName.Text = "";
            cboRoomType.SelectedIndex = 0;
            nudRows.Value = 8;
            nudSeatsPerRow.Value = 10;
            nudVipRow.Value = 0;
            chkIsActive.Checked = true;
            UpdateTotalSeats();
            pnlSeats.Controls.Clear();
            SetAddMode();
        }

        // Kiểm tra dữ liệu nhập
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomName.Focus();
                return false;
            }

            if (nudVipRow.Value > nudRows.Value)
            {
                MessageBox.Show("Hàng VIP không được lớn hơn tổng số hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudVipRow.Focus();
                return false;
            }

            return true;
        }

        // Lấy dữ liệu từ form
        private RoomDTO GetRoomFromForm()
        {
            return new RoomDTO
            {
                RoomID = selectedRoomId,
                RoomName = txtRoomName.Text.Trim(),
                RoomType = cboRoomType.SelectedItem?.ToString() ?? "Standard",
                TotalSeats = (int)(nudRows.Value * nudSeatsPerRow.Value),
                IsActive = chkIsActive.Checked
            };
        }

        // Thêm phòng mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                RoomDTO room = GetRoomFromForm();
                int newRoomId = roomBLL.Insert(room);

                if (newRoomId > 0)
                {
                    // Tạo ghế cho phòng mới
                    int rows = (int)nudRows.Value;
                    int seatsPerRow = (int)nudSeatsPerRow.Value;
                    int vipRowStart = (int)nudVipRow.Value;

                    bool seatsCreated = roomBLL.GenerateSeats(newRoomId, rows, seatsPerRow, vipRowStart);

                    if (seatsCreated)
                    {
                        MessageBox.Show("Thêm phòng và tạo ghế thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm phòng thành công nhưng tạo ghế thất bại!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    LoadRooms();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật phòng
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                RoomDTO room = GetRoomFromForm();
                bool success = roomBLL.Update(room);

                if (success)
                {
                    // Hỏi có muốn cập nhật lại ghế không
                    DialogResult result = MessageBox.Show(
                        "Cập nhật thông tin phòng thành công!\n\n" +
                        "Bạn có muốn tạo lại sơ đồ ghế không?\n" +
                        "(Lưu ý: Ghế cũ sẽ bị xóa)",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int rows = (int)nudRows.Value;
                        int seatsPerRow = (int)nudSeatsPerRow.Value;
                        int vipRowStart = (int)nudVipRow.Value;

                        roomBLL.GenerateSeats(selectedRoomId, rows, seatsPerRow, vipRowStart);
                    }

                    LoadRooms();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa phòng
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra phòng có lịch chiếu không
            if (roomBLL.HasShowtimes(selectedRoomId))
            {
                MessageBox.Show("Không thể xóa phòng đã có lịch chiếu!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa phòng '{txtRoomName.Text}'?\n\n" +
                "Lưu ý: Tất cả ghế trong phòng cũng sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = roomBLL.Delete(selectedRoomId);

                    if (success)
                    {
                        MessageBox.Show("Xóa phòng thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phòng thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Làm mới form
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            DrawSeatPreview();
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Khi thay đổi số hàng
        private void nudRows_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSeats();
            DrawSeatPreview();
        }

        // Khi thay đổi số ghế mỗi hàng
        private void nudSeatsPerRow_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalSeats();
            DrawSeatPreview();
        }
    }
}
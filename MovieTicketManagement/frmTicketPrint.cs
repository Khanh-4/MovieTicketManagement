using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MovieTicket.BLL;
using MovieTicket.DTO;
using QRCoder;

namespace MovieTicketManagement
{
    public partial class frmTicketPrint : Form
    {
        private BookingBLL bookingBLL = new BookingBLL();
        private int bookingId;
        private TicketDTO ticket;

        public frmTicketPrint(int bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;
        }

        private void frmTicketPrint_Load(object sender, EventArgs e)
        {
            LoadTicketInfo();
        }

        // Load thông tin vé
        private void LoadTicketInfo()
        {
            try
            {
                ticket = bookingBLL.GetTicketInfo(bookingId);

                if (ticket == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vé!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Hiển thị thông tin
                lblMovieValue.Text = ticket.MovieTitle;
                lblShowtimeValue.Text = $"{ticket.ShowDate:dd/MM/yyyy} - {ticket.ShowTime:hh\\:mm}";
                lblRoomValue.Text = ticket.RoomName;
                lblSeatsValue.Text = ticket.SeatInfo;
                lblCustomerValue.Text = ticket.CustomerName;
                lblTotalValue.Text = $"{ticket.TotalAmount:N0} VNĐ";
                lblBookingCodeValue.Text = ticket.BookingCode;

                // Tạo QR Code
                GenerateQRCode(ticket.BookingCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo QR Code từ mã booking
        private void GenerateQRCode(string bookingCode)
        {
            try
            {
                // Nội dung QR Code
                string qrContent = $"MOVIE TICKET\n" +
                                   $"Code: {ticket.BookingCode}\n" +
                                   $"Movie: {ticket.MovieTitle}\n" +
                                   $"Date: {ticket.ShowDate:dd/MM/yyyy}\n" +
                                   $"Time: {ticket.ShowTime:hh\\:mm}\n" +
                                   $"Room: {ticket.RoomName}\n" +
                                   $"Seats: {ticket.SeatInfo}";

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                picQRCode.Image = qrCodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo QR Code: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // In vé
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDoc;
                previewDialog.Width = 600;
                previewDialog.Height = 800;
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý in
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Fonts
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);
            Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font largeFont = new Font("Segoe UI", 14, FontStyle.Bold);

            // Brushes
            Brush blackBrush = Brushes.Black;
            Brush darkBlueBrush = Brushes.DarkBlue;
            Brush darkRedBrush = Brushes.DarkRed;
            Brush greenBrush = Brushes.Green;
            Brush blueBrush = Brushes.Blue;

            // Vị trí bắt đầu
            int x = 50;
            int y = 50;
            int width = 300;

            // Vẽ border
            g.DrawRectangle(Pens.Black, x - 10, y - 10, width + 20, 480);

            // Tiêu đề
            g.DrawString("🎬 MOVIE TICKET", titleFont, darkBlueBrush, x + 50, y);
            y += 40;

            // Đường kẻ
            g.DrawLine(Pens.Gray, x, y, x + width, y);
            y += 10;

            // QR Code
            if (picQRCode.Image != null)
            {
                g.DrawImage(picQRCode.Image, x + 75, y, 150, 150);
            }
            y += 160;

            // Đường kẻ
            g.DrawLine(Pens.Gray, x, y, x + width, y);
            y += 15;

            // Tên phim
            g.DrawString("Tên phim:", headerFont, blackBrush, x, y);
            y += 25;
            g.DrawString(ticket.MovieTitle, largeFont, darkRedBrush, x, y);
            y += 35;

            // Suất chiếu và Phòng
            g.DrawString("Suất chiếu:", normalFont, blackBrush, x, y);
            g.DrawString("Phòng:", normalFont, blackBrush, x + 150, y);
            y += 20;
            g.DrawString($"{ticket.ShowDate:dd/MM/yyyy} - {ticket.ShowTime:hh\\:mm}", boldFont, blackBrush, x, y);
            g.DrawString(ticket.RoomName, boldFont, blackBrush, x + 150, y);
            y += 30;

            // Ghế
            g.DrawString("Ghế:", normalFont, blackBrush, x, y);
            y += 20;
            g.DrawString(ticket.SeatInfo, largeFont, blueBrush, x, y);
            y += 35;

            // Đường kẻ
            g.DrawLine(Pens.Gray, x, y, x + width, y);
            y += 15;

            // Khách hàng và Tổng tiền
            g.DrawString("Khách hàng:", normalFont, blackBrush, x, y);
            g.DrawString("Tổng tiền:", normalFont, blackBrush, x + 150, y);
            y += 20;
            g.DrawString(ticket.CustomerName, boldFont, blackBrush, x, y);
            g.DrawString($"{ticket.TotalAmount:N0} VNĐ", largeFont, greenBrush, x + 150, y);
            y += 35;

            // Mã vé
            g.DrawString("Mã vé:", normalFont, blackBrush, x, y);
            y += 20;
            g.DrawString(ticket.BookingCode, boldFont, blackBrush, x, y);
        }

        // Đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
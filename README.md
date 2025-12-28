# 🎬 Hệ Thống Quản Lý Bán Vé Xem Phim

Đồ án môn học - Hệ thống quản lý rạp chiếu phim hoàn chỉnh được xây dựng bằng C# Windows Forms.

---

## 📋 Giới Thiệu

Ứng dụng quản lý bán vé xem phim với đầy đủ chức năng cho 3 vai trò: **Admin**, **Staff** và **Customer**.

### ✨ Tính năng chính:
- 🎥 Quản lý phim, suất chiếu, phòng chiếu
- 🎫 Đặt vé với giao diện chọn ghế trực quan (Thường, VIP, Couple)
- 🖨️ In vé với mã QR Code
- 📊 Thống kê doanh thu, xuất báo cáo CSV
- 🎁 Quản lý khuyến mãi, mã giảm giá
- 🍿 Quản lý đồ ăn, thức uống kèm vé
- 👥 Hệ thống hội viên tích điểm
- ✅ Kiểm tra vé vào rạp bằng QR Code
- 🔄 **Tính năng Pass Vé** - Chuyển nhượng vé với hoàn tiền
- 💰 **Ví điện tử** - Quản lý số dư, nạp tiền, thanh toán
- 📧 **Gửi email tự động** - Thông báo qua Gmail SMTP

---

## 🛠️ Công Nghệ Sử Dụng

| Công nghệ | Phiên bản | Mô tả |
|-----------|-----------|-------|
| C# | 12.0 | Ngôn ngữ lập trình |
| .NET | 8.0 | Framework |
| Windows Forms | - | Giao diện người dùng |
| SQL Server | 2019+ | Cơ sở dữ liệu |
| QRCoder | 1.4.3 | Tạo mã QR |
| Gmail SMTP | - | Gửi email thông báo |

---

## 📁 Cấu Trúc Project

```
MovieTicketManagement/
├── 📂 Database/
│   ├── Movieticketdb.sql               # Script tạo database chính
│   ├── BookingsAdd.sql                 # Thêm cột PaymentStatus, PaymentMethod
│   ├── 02_AddCoupleSeats_AllRooms.sql  # Thêm ghế đôi
│   └── MASTER_PassTicket_Database.sql  # Tính năng Pass Vé
├── 📂 MovieTicket.DTO/                 # Data Transfer Objects
├── 📂 MovieTicket.DAL/                 # Data Access Layer
├── 📂 MovieTicket.BLL/                 # Business Logic Layer
├── 📂 MovieTicket.Common/              # Utilities (PasswordHelper, OTPHelper...)
├── 📂 MovieTicketManagement/           # Windows Forms UI
│   ├── App.config                      # Cấu hình kết nối DB & SMTP
│   └── *.cs                            # Các form giao diện
└── 📄 MovieTicketManagement.slnx       # Solution file
```

### 🏗️ Kiến trúc 3 lớp (3-Layer Architecture):
```
┌─────────────────────────────────────┐
│         GUI (Windows Forms)         │  ← Giao diện người dùng
│   frmLogin, frmMain, frmBooking...  │
├─────────────────────────────────────┤
│         BLL (Business Logic)        │  ← Xử lý logic nghiệp vụ
│   UserBLL, BookingBLL, ResaleBLL... │
├─────────────────────────────────────┤
│         DAL (Data Access)           │  ← Truy xuất dữ liệu
│   UserDAL, BookingDAL, WalletDAL... │
├─────────────────────────────────────┤
│            SQL Server               │  ← Cơ sở dữ liệu
│         MovieTicketDB               │
└─────────────────────────────────────┘
```

---

## 🗄️ Cơ Sở Dữ Liệu

### Tổng quan:
- **19 bảng** dữ liệu
- **3 Stored Procedures** cho tính năng Pass Vé
- Quan hệ đầy đủ với khóa ngoại
- Dữ liệu mẫu sẵn có

### Danh sách các bảng:

| STT | Tên bảng | Mô tả |
|-----|----------|-------|
| 1 | USERS | Thông tin người dùng |
| 2 | ROLES | Vai trò (Admin, Staff, Customer) |
| 3 | MOVIES | Thông tin phim |
| 4 | ROOMS | Phòng chiếu |
| 5 | SEATS | Ghế ngồi |
| 6 | SHOWTIMES | Lịch chiếu |
| 7 | BOOKINGS | Đơn đặt vé |
| 8 | BOOKING_DETAILS | Chi tiết ghế đã đặt |
| 9 | BOOKING_FOODS | Đồ ăn kèm vé |
| 10 | FOODS | Danh mục đồ ăn |
| 11 | PROMOTIONS | Khuyến mãi |
| 12 | MEMBERSHIPS | Hội viên |
| 13 | MEMBERSHIP_LEVELS | Hạng hội viên |
| 14 | POINT_TRANSACTIONS | Lịch sử điểm |
| 15 | PASSWORD_RESET_TOKENS | Token đặt lại mật khẩu |
| 16 | USER_WALLET | Ví điện tử |
| 17 | WALLET_TRANSACTIONS | Lịch sử giao dịch ví |
| 18 | TICKET_RESALES | Vé pass |
| 19 | GENRES | Thể loại phim |

---

## ⚙️ Hướng Dẫn Cài Đặt

### 📋 Yêu cầu hệ thống:
- Windows 10/11
- Visual Studio 2022 (Community trở lên)
- SQL Server 2019+ (hoặc SQL Server Express)
- .NET 8.0 SDK

### Bước 1: Clone Repository

```bash
git clone https://github.com/Khanh-2910/MovieTicketManagement.git
cd MovieTicketManagement
```

### Bước 2: Tạo Database

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối đến SQL Server của bạn
3. Chạy các file SQL theo thứ tự:

```
1️⃣ Database/Movieticketdb.sql              # Tạo database chính
2️⃣ Database/BookingsAdd.sql                # Thêm cột bổ sung
3️⃣ Database/02_AddCoupleSeats_AllRooms.sql # Thêm ghế đôi
4️⃣ Database/MASTER_PassTicket_Database.sql # Tính năng Pass Vé
```

### Bước 3: Cấu hình Connection String

Mở file `MovieTicketManagement/App.config` và sửa tên Server:

```xml
<connectionStrings>
    <add name="MovieTicketDB" 
         connectionString="Data Source=TEN_SERVER_CUA_BAN;Initial Catalog=MovieTicketDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True" 
         providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

**Ví dụ tên Server:**
| Loại | Tên Server |
|------|------------|
| SQL Server Express | `.\SQLEXPRESS` hoặc `localhost\SQLEXPRESS` |
| SQL Server Local | `localhost` hoặc `.` |
| Named Instance | `TEN_MAY\TEN_INSTANCE` |

### Bước 4: Cấu hình Email SMTP (Tùy chọn)

Để sử dụng tính năng gửi email, cấu hình trong `App.config`:

```xml
<appSettings>
    <add key="SmtpHost" value="smtp.gmail.com"/>
    <add key="SmtpPort" value="587"/>
    <add key="SmtpEmail" value="your_email@gmail.com"/>
    <add key="SmtpPassword" value="your_app_password"/>
    <add key="SmtpDisplayName" value="Movie Ticket System"/>
</appSettings>
```

> ⚠️ **Lưu ý:** Sử dụng [App Password](https://support.google.com/accounts/answer/185833) của Google, không dùng mật khẩu thường.

### Bước 5: Build và Chạy

1. Mở file `MovieTicketManagement.slnx` bằng **Visual Studio 2022**
2. Nhấn **Ctrl + Shift + B** để Build Solution
3. Nhấn **F5** để chạy ứng dụng

---

## 👤 Tài Khoản Mặc Định

| Vai trò | Username | Password | Mô tả |
|---------|----------|----------|-------|
| Admin | `admin` | `123456` | Toàn quyền quản lý hệ thống |
| Staff | `staff1` | `123456` | Bán vé, kiểm tra vé |
| Customer | `customer1` | `123456` | Đặt vé, xem lịch sử |

> 💡 Sử dụng nút **"Reset PW"** trên form đăng nhập để reset tất cả mật khẩu về `123456`

---

## 📱 Chức Năng Theo Vai Trò

### 👨‍💼 Admin
| Chức năng | Mô tả |
|-----------|-------|
| Quản lý Staff | Thêm, sửa, xóa tài khoản nhân viên |
| Quản lý Phim | CRUD phim, upload poster |
| Quản lý Phòng chiếu | Cấu hình phòng, loại ghế |
| Quản lý Lịch chiếu | Tạo suất chiếu, kiểm tra trùng lịch |
| Quản lý Khuyến mãi | Tạo mã giảm giá, chương trình khuyến mãi |
| Quản lý Đồ ăn | CRUD đồ ăn, thức uống |
| Báo cáo Doanh thu | Xem thống kê, xuất CSV |
| Thống kê | Biểu đồ, top phim, tỷ lệ lấp đầy |

### 👨‍💻 Staff
| Chức năng | Mô tả |
|-----------|-------|
| Bán vé | Đặt vé cho khách tại quầy |
| Kiểm tra vé | Quét QR hoặc nhập mã vé |
| Quản lý Phim | Xem, thêm, sửa thông tin phim |
| Quản lý Lịch chiếu | Tạo và quản lý suất chiếu |
| Quản lý Đồ ăn | Quản lý menu đồ ăn |

### 👤 Customer
| Chức năng | Mô tả |
|-----------|-------|
| Đặt vé Online | Chọn phim, suất chiếu, ghế ngồi |
| Chọn Đồ ăn | Thêm combo, bắp nước |
| Lịch sử Đặt vé | Xem, in, hủy vé |
| Hội viên | Xem điểm tích lũy, hạng thành viên |
| 🆕 Pass Vé | Chuyển nhượng vé, nhận hoàn tiền |
| 🆕 Mua vé Pass | Mua vé giảm giá 15% |
| 🆕 Ví tiền | Quản lý số dư, nạp tiền |
| Đổi mật khẩu | Thay đổi mật khẩu tài khoản |

---

## 🔄 Tính Năng Nổi Bật: Pass Vé

### Mô tả:
Cho phép khách hàng **chuyển nhượng vé** đã mua khi không thể đi xem, nhận **hoàn tiền vào ví**. Rạp sẽ **bán lại vé** với giá **giảm 15%**.

### Quy trình:
```
┌─────────────┐         ┌─────────────┐         ┌─────────────┐
│   User A    │         │    Rạp      │         │   User B    │
│  (Người bán)│         │  (Trung gian)│         │ (Người mua) │
└──────┬──────┘         └──────┬──────┘         └──────┬──────┘
       │                       │                       │
       │  1. Pass vé           │                       │
       │  ──────────────────►  │                       │
       │                       │                       │
       │  2. Hoàn 70/50/30%    │                       │
       │  ◄──────────────────  │                       │
       │     (vào ví)          │                       │
       │                       │                       │
       │                       │  3. Xem vé pass       │
       │                       │  ◄────────────────────│
       │                       │                       │
       │                       │  4. Mua giảm 15%      │
       │                       │  ◄────────────────────│
       │                       │                       │
       │  5. Email thông báo   │  5. Email xác nhận    │
       │  ◄──────────────────  │  ────────────────────►│
       │                       │                       │
```

### Tỷ lệ hoàn tiền:
| Thời gian trước suất chiếu | Tỷ lệ hoàn |
|---------------------------|------------|
| ≥ 3 ngày | 70% |
| 2 ngày | 50% |
| 1 ngày | 30% |
| < 1 ngày | Không được pass |

### Email tự động:
- ✉️ Thông báo pass vé thành công (cho người bán)
- ✉️ Xác nhận mua vé pass (cho người mua)
- ✉️ Thông báo vé đã được bán (cho người bán)

---

## 🖼️ Giao Diện

### Màn hình Đăng nhập
- Đăng nhập với username/password
- Nút hiện/ẩn mật khẩu
- Đăng ký tài khoản mới
- Quên mật khẩu (gửi OTP qua email)
- Reset mật khẩu (cho testing)

### Màn hình Chọn ghế
Màu sắc phân biệt loại ghế:
| Màu | Loại ghế | Giá |
|-----|----------|-----|
| 🟦 Xanh dương | Ghế thường | Giá gốc |
| 🟨 Vàng | Ghế VIP | +20% |
| 🟪 Tím | Ghế Couple | x2 |
| 🟥 Đỏ | Đã đặt | - |
| 🟩 Xanh lá | Đang chọn | - |

### Màn hình Thống kê
- Biểu đồ doanh thu theo ngày/tháng
- Top phim doanh thu cao
- Tỷ lệ lấp đầy ghế
- Xuất báo cáo CSV

### Màn hình Ví tiền
- Hiển thị số dư
- Nạp tiền vào ví
- Lịch sử giao dịch
- Màu sắc phân biệt: Xanh (nạp), Đỏ (trừ)

---

## 🔧 Xử Lý Sự Cố

### ❌ Lỗi kết nối database
```
Cannot connect to SQL Server
```
**Giải pháp:**
1. Kiểm tra SQL Server đã khởi động
2. Kiểm tra tên server trong `App.config`
3. Đảm bảo đã chạy đủ các file SQL

### ❌ Lỗi thiếu thư viện
```
Could not load file or assembly 'QRCoder'
```
**Giải pháp:**
```bash
# Trong Package Manager Console
Install-Package QRCoder
Install-Package Microsoft.Data.SqlClient
```

### ❌ Lỗi gửi email
```
SMTP Authentication Error
```
**Giải pháp:**
1. Kiểm tra email và App Password trong `App.config`
2. Bật "Less secure app access" hoặc dùng App Password
3. Kiểm tra kết nối internet

### ❌ Lỗi Pass vé - CHECK constraint
```
The UPDATE statement conflicted with the CHECK constraint
```
**Giải pháp:**
```sql
-- Chạy trong SSMS
ALTER TABLE BOOKINGS DROP CONSTRAINT CK_BOOKINGS_BookingStatus
GO
ALTER TABLE BOOKINGS ADD CONSTRAINT CK_BOOKINGS_BookingStatus 
CHECK (BookingStatus IN ('Pending', 'Confirmed', 'Cancelled', 'Completed', 'Resold'))
GO
```

---

## 🚀 Định Hướng Phát Triển

### Giai đoạn 1: Hoàn thiện Desktop App
- [ ] Unit Testing
- [ ] Tính năng đánh giá phim
- [ ] Đề xuất phim theo sở thích
- [ ] Tối ưu hiệu năng

### Giai đoạn 2: Web Application
- [ ] ASP.NET Core MVC
- [ ] RESTful API
- [ ] Responsive Design
- [ ] Authentication JWT

### Giai đoạn 3: Mobile Application
- [ ] React Native / Flutter
- [ ] Tích hợp thanh toán (VNPay, Momo)
- [ ] Push Notification
- [ ] Đặt vé nhanh

### Giai đoạn 4: Cloud & DevOps
- [ ] Docker containerization
- [ ] Kubernetes orchestration
- [ ] CI/CD Pipeline
- [ ] Deploy Azure / AWS

---

## 👨‍💻 Tác Giả

| Thông tin | Chi tiết |
|-----------|----------|
| **Họ tên** | Cao Duy Quốc Khánh |
| **MSSV** | 2380601019 |
| **Lớp** | 23DTHC1 |
| **Trường** | Đại học Công nghệ TP.HCM (HUTECH) |
| **GitHub** | [Khanh-2910](https://github.com/Khanh-2910) |

---

## 📄 Giấy Phép

Project này được tạo cho mục đích **học tập và nghiên cứu**.

Mã nguồn được chia sẻ công khai để tham khảo. Vui lòng ghi nguồn nếu sử dụng.

---

## 🙏 Lời Cảm Ơn

Xin chân thành cảm ơn:
- Thầy/Cô giảng viên đã hướng dẫn trong quá trình thực hiện đồ án
- Các bạn sinh viên đã góp ý và test ứng dụng
- Cộng đồng lập trình viên đã chia sẻ kiến thức

---

<div align="center">

⭐ **Nếu project này hữu ích, hãy cho một Star nhé!** ⭐

Made with ❤️ by Khanh

</div>

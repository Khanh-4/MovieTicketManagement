# 🎬 Hệ Thống Quản Lý Bán Vé Xem Phim

Đồ án môn học - Hệ thống quản lý rạp chiếu phim hoàn chỉnh được xây dựng bằng C# Windows Forms.

---

## 📋 Giới Thiệu

Ứng dụng quản lý bán vé xem phim với đầy đủ chức năng cho 3 vai trò: **Admin**, **Staff** và **Customer**.

### Tính năng chính:
- 🎥 Quản lý phim, suất chiếu, phòng chiếu
- 🎫 Đặt vé với giao diện chọn ghế trực quan
- 🖨️ In vé với mã QR Code
- 📊 Thống kê doanh thu, biểu đồ
- 🎁 Quản lý khuyến mãi, mã giảm giá
- 🍿 Quản lý đồ ăn, thức uống
- 👥 Hệ thống hội viên tích điểm
- ✅ Kiểm tra vé vào rạp

---

## 🛠️ Công Nghệ Sử Dụng

| Công nghệ | Mô tả |
|-----------|-------|
| C# | Ngôn ngữ lập trình |
| .NET 8.0 | Framework |
| Windows Forms | Giao diện người dùng |
| SQL Server | Cơ sở dữ liệu |
| QRCoder | Tạo mã QR |

---

## 📁 Cấu Trúc Project

```
MovieTicketManagement/
├── 📂 Database/
│   └── MovieTicketDB.sql       # Script tạo database
├── 📂 MovieTicket.DTO/         # Data Transfer Objects
├── 📂 MovieTicket.DAL/         # Data Access Layer
├── 📂 MovieTicket.BLL/         # Business Logic Layer
├── 📂 MovieTicket.Common/      # Utilities (PasswordHelper...)
├── 📂 MovieTicketManagement/   # Windows Forms UI
└── 📄 MovieTicketManagement.slnx
```

### Kiến trúc 3 lớp:
```
┌─────────────────┐
│   GUI (Forms)   │  ← Giao diện người dùng
├─────────────────┤
│      BLL        │  ← Xử lý logic nghiệp vụ
├─────────────────┤
│      DAL        │  ← Truy xuất dữ liệu
├─────────────────┤
│   SQL Server    │  ← Cơ sở dữ liệu
└─────────────────┘
```

---

## ⚙️ Hướng Dẫn Cài Đặt

### Yêu cầu hệ thống:
- Windows 10/11
- Visual Studio 2022 (Community trở lên)
- SQL Server 2019+ (hoặc SQL Server Express)
- .NET 8.0 SDK

### Bước 1: Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/MovieTicketManagement.git
cd MovieTicketManagement
```

### Bước 2: Tạo Database

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối đến SQL Server của bạn
3. Mở file `Database/MovieTicketDB.sql`
4. Nhấn **F5** hoặc **Execute** để chạy script
5. Database `MovieTicketDB` sẽ được tạo với dữ liệu mẫu

### Bước 3: Cấu hình Connection String

1. Mở file `MovieTicketManagement/App.config`
2. Tìm dòng `connectionStrings` và sửa `Server=` thành tên SQL Server của bạn:

```xml
<connectionStrings>
    <add name="MovieTicketDB" 
         connectionString="Server=TEN_MAY_CUA_BAN;Database=MovieTicketDB;Trusted_Connection=True;TrustServerCertificate=True" 
         providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

**Ví dụ tên Server:**
| Loại | Tên Server |
|------|------------|
| SQL Server Express | `.\SQLEXPRESS` hoặc `localhost\SQLEXPRESS` |
| SQL Server Local | `localhost` hoặc `.` |
| Named Instance | `TEN_MAY\TEN_INSTANCE` |

### Bước 4: Build và Chạy

1. Mở file `MovieTicketManagement.slnx` bằng **Visual Studio 2022**
2. Nhấn **Ctrl + Shift + B** để Build Solution
3. Nhấn **F5** để chạy ứng dụng

---

## 👤 Tài Khoản Mặc Định

| Vai trò | Username | Password | Quyền hạn |
|---------|----------|----------|-----------|
| Admin | `admin` | `123456` | Toàn quyền quản lý hệ thống |
| Staff | `staff1` | `123456` | Bán vé, kiểm tra vé, báo cáo |
| Customer | *(Tự đăng ký)* | | Đặt vé, xem lịch sử |

---

## 📱 Chức Năng Theo Vai Trò

### 👨‍💼 Admin
- Quản lý phim (Thêm, Sửa, Xóa)
- Quản lý suất chiếu
- Quản lý phòng chiếu
- Quản lý người dùng
- Quản lý khuyến mãi
- Quản lý đồ ăn/thức uống
- Xem thống kê doanh thu
- Xuất báo cáo

### 👨‍💻 Staff
- Bán vé tại quầy
- Kiểm tra vé vào rạp
- Xem báo cáo doanh thu
- Quản lý đồ ăn

### 👤 Customer
- Xem phim đang chiếu
- Đặt vé online
- Chọn ghế ngồi
- Xem lịch sử đặt vé
- Hủy vé (trước 2 tiếng)
- In vé với QR Code
- Xem thông tin hội viên
- Đổi mật khẩu

---

## 🖼️ Giao Diện

### Màn hình đăng nhập
- Đăng nhập với username/password
- Nút hiện/ẩn mật khẩu
- Đăng ký tài khoản mới

### Màn hình chọn ghế
- Hiển thị sơ đồ ghế trực quan
- Màu sắc phân biệt loại ghế:
  - 🟦 Ghế thường
  - 🟨 Ghế VIP
  - 🟪 Ghế Couple
  - 🟥 Ghế đã đặt
  - 🟩 Ghế đang chọn

### Màn hình thống kê
- Biểu đồ doanh thu theo ngày
- Top phim doanh thu cao
- Xuất báo cáo CSV

---

## 🔧 Xử Lý Sự Cố

### Lỗi kết nối database
```
❌ Cannot connect to SQL Server
```
**Giải pháp:**
1. Kiểm tra SQL Server đã khởi động chưa
2. Kiểm tra tên server trong `App.config`
3. Đảm bảo đã chạy script tạo database

### Lỗi thiếu thư viện
```
❌ Could not load file or assembly 'QRCoder'
```
**Giải pháp:**
```bash
# Trong Package Manager Console
Install-Package QRCoder
```

### Lỗi đăng nhập sai mật khẩu
**Giải pháp:**
- Sử dụng nút **"Reset PW"** trên form đăng nhập để reset tất cả mật khẩu về `123456`

---

## 📝 Ghi Chú Phát Triển

### Thêm phim mới vào database:
```sql
INSERT INTO MOVIES (Title, Duration, Director, IsActive)
VALUES (N'Tên Phim', 120, N'Đạo diễn', 1)
```

### Thêm suất chiếu:
```sql
INSERT INTO SHOWTIMES (MovieID, RoomID, StartTime, EndTime, BasePrice, IsActive)
VALUES (1, 1, '2025-01-01 19:00', '2025-01-01 21:00', 80000, 1)
```

---

## 👨‍💻 Tác Giả

- **Họ tên:** [Tên của bạn]
- **MSSV:** [Mã số sinh viên]
- **Lớp:** [Tên lớp]
- **Trường:** [Tên trường]

---

## 📄 Giấy Phép

Project này được tạo cho mục đích học tập và nghiên cứu.

---

## 🙏 Lời Cảm Ơn

Cảm ơn thầy/cô đã hướng dẫn trong quá trình thực hiện đồ án.

---

⭐ Nếu project này hữu ích, hãy cho một **Star** nhé!

# 📚 TÀI LIỆU GIẢI THÍCH PROJECT
# HỆ THỐNG QUẢN LÝ BÁN VÉ XEM PHIM

> Tài liệu này giải thích chi tiết toàn bộ project để các thành viên trong nhóm hiểu và chuẩn bị cho buổi vấn đáp với giảng viên.

---

## 📑 MỤC LỤC

1. [Tổng quan kiến trúc](#1-tổng-quan-kiến-trúc)
2. [Cấu trúc Database](#2-cấu-trúc-database)
3. [Giải thích từng Layer](#3-giải-thích-từng-layer)
4. [Giải thích Logic nghiệp vụ quan trọng](#4-giải-thích-logic-nghiệp-vụ-quan-trọng)
5. [Luồng hoạt động chính](#5-luồng-hoạt-động-chính)
6. [Câu hỏi vấn đáp thường gặp](#6-câu-hỏi-vấn-đáp-thường-gặp)

---

# 1. TỔNG QUAN KIẾN TRÚC

## 1.1. Kiến trúc 3 lớp (3-Layer Architecture)

```
┌─────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                        │
│                   (MovieTicketManagement)                    │
│                                                              │
│   frmLogin, frmMain, frmBooking, frmStatistics, ...         │
│   → Giao diện người dùng, nhận input, hiển thị output       │
└─────────────────────────────────────────────────────────────┘
                              ↓ ↑
┌─────────────────────────────────────────────────────────────┐
│                   BUSINESS LOGIC LAYER                       │
│                      (MovieTicket.BLL)                       │
│                                                              │
│   UserBLL, MovieBLL, BookingBLL, ReportBLL, ...             │
│   → Xử lý logic nghiệp vụ, validate dữ liệu                 │
└─────────────────────────────────────────────────────────────┘
                              ↓ ↑
┌─────────────────────────────────────────────────────────────┐
│                    DATA ACCESS LAYER                         │
│                      (MovieTicket.DAL)                       │
│                                                              │
│   UserDAL, MovieDAL, BookingDAL, ReportDAL, ...             │
│   → Truy xuất database, thực hiện CRUD                      │
└─────────────────────────────────────────────────────────────┘
                              ↓ ↑
┌─────────────────────────────────────────────────────────────┐
│                        DATABASE                              │
│                   (SQL Server - MovieTicketDB)               │
│                                                              │
│   19 Tables: USERS, MOVIES, BOOKINGS, SEATS, ...            │
└─────────────────────────────────────────────────────────────┘
```

## 1.2. Tại sao dùng kiến trúc 3 lớp?

| Lợi ích | Giải thích |
|---------|------------|
| **Tách biệt trách nhiệm** | Mỗi layer chỉ làm một việc, dễ quản lý |
| **Dễ bảo trì** | Sửa code ở 1 layer không ảnh hưởng layer khác |
| **Tái sử dụng** | BLL có thể dùng cho cả WinForms, Web, Mobile |
| **Dễ test** | Có thể test từng layer riêng biệt |
| **Làm việc nhóm** | Mỗi người làm 1 layer khác nhau |

## 1.3. Các Project trong Solution

| Project | Loại | Mục đích |
|---------|------|----------|
| `MovieTicket.DTO` | Class Library | Chứa các class đối tượng dữ liệu |
| `MovieTicket.DAL` | Class Library | Truy xuất database |
| `MovieTicket.BLL` | Class Library | Xử lý logic nghiệp vụ |
| `MovieTicket.Common` | Class Library | Các tiện ích dùng chung |
| `MovieTicketManagement` | WinForms App | Giao diện người dùng |

---

# 2. CẤU TRÚC DATABASE

## 2.1. Sơ đồ quan hệ (ERD tóm tắt)

```
ROLES (1) ──────< USERS (N)
                    │
                    ├──────< BOOKINGS (N) >────── SHOWTIMES (1)
                    │            │                     │
                    │            │                     ├── MOVIES (1)
                    │            │                     └── ROOMS (1)
                    │            │                            │
                    │            └──< BOOKING_DETAILS (N)     │
                    │                       │                 │
                    │                       └───── SEATS (1) ─┘
                    │
                    └──────< MEMBERSHIPS (1) >── MEMBERSHIP_TYPES (1)
```

## 2.2. Các bảng chính và mục đích

### Nhóm User Management
| Bảng | Mục đích | Cột quan trọng |
|------|----------|----------------|
| `ROLES` | Lưu vai trò (Admin, Staff, Customer) | RoleID, RoleName |
| `USERS` | Lưu thông tin người dùng | UserID, Username, PasswordHash, Salt, RoleID |

### Nhóm Movie Management
| Bảng | Mục đích | Cột quan trọng |
|------|----------|----------------|
| `MOVIES` | Lưu thông tin phim | MovieID, Title, Duration, Director |
| `GENRES` | Lưu thể loại phim | GenreID, GenreName |
| `MOVIE_GENRES` | Liên kết phim - thể loại (N-N) | MovieID, GenreID |

### Nhóm Cinema Management
| Bảng | Mục đích | Cột quan trọng |
|------|----------|----------------|
| `ROOMS` | Lưu phòng chiếu | RoomID, RoomName, TotalSeats |
| `SEATS` | Lưu ghế ngồi | SeatID, RoomID, RowLabel, SeatNumber, SeatTypeID |
| `SEAT_TYPES` | Lưu loại ghế (Thường, VIP, Couple) | SeatTypeID, PriceMultiplier |
| `SHOWTIMES` | Lưu suất chiếu | ShowtimeID, MovieID, RoomID, StartTime, BasePrice |

### Nhóm Booking Management
| Bảng | Mục đích | Cột quan trọng |
|------|----------|----------------|
| `BOOKINGS` | Lưu đơn đặt vé | BookingID, BookingCode, UserID, ShowtimeID, TotalAmount, IsUsed |
| `BOOKING_DETAILS` | Lưu chi tiết ghế đã đặt | BookingDetailID, BookingID, SeatID, Price |

### Nhóm Membership
| Bảng | Mục đích | Cột quan trọng |
|------|----------|----------------|
| `MEMBERSHIP_TYPES` | Lưu hạng hội viên | MembershipTypeID, TypeName, DiscountPercent, PointsRequired |
| `MEMBERSHIPS` | Lưu thông tin hội viên | MembershipID, UserID, Points |
| `POINT_TRANSACTIONS` | Lưu lịch sử tích điểm | TransactionID, Points, TransactionType |

---

# 3. GIẢI THÍCH TỪNG LAYER

## 3.1. DTO Layer (Data Transfer Object)

### Mục đích:
- Định nghĩa các class chứa dữ liệu
- Truyền dữ liệu giữa các layer
- Không chứa logic xử lý

### Ví dụ - UserDTO.cs:
```csharp
public class UserDTO
{
    // Các property tương ứng với cột trong database
    public int UserID { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int RoleID { get; set; }
    
    // Property bổ sung (không có trong DB, dùng để hiển thị)
    public string RoleName { get; set; }
}
```

**Giải thích:**
- `UserDTO` là "bản sao" của bảng `USERS` trong database
- Mỗi property tương ứng với 1 cột
- `RoleName` là property bổ sung để hiển thị tên vai trò (JOIN từ bảng ROLES)

---

## 3.2. DAL Layer (Data Access Layer)

### Mục đích:
- Kết nối và truy xuất database
- Thực hiện các thao tác CRUD (Create, Read, Update, Delete)
- Chuyển đổi dữ liệu từ DB sang DTO

### 3.2.1. DatabaseConnection.cs - Kết nối Database

```csharp
public class DatabaseConnection
{
    // Đọc connection string từ App.config
    private static string connectionString = 
        ConfigurationManager.ConnectionStrings["MovieTicketDB"].ConnectionString;
    
    // Tạo và trả về connection mới
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
```

**Giải thích:**
- `ConfigurationManager.ConnectionStrings["MovieTicketDB"]` đọc chuỗi kết nối từ file `App.config`
- Mỗi khi cần kết nối DB, gọi `DatabaseConnection.GetConnection()`
- Dùng `using` để tự động đóng connection sau khi dùng xong

### 3.2.2. UserDAL.cs - Truy xuất User

```csharp
public class UserDAL
{
    // Lấy user theo username (dùng cho đăng nhập)
    public UserDTO GetByUsername(string username)
    {
        UserDTO user = null;
        
        // Câu query SQL với JOIN để lấy RoleName
        string query = @"SELECT u.*, r.RoleName 
                        FROM USERS u 
                        INNER JOIN ROLES r ON u.RoleID = r.RoleID 
                        WHERE u.Username = @Username AND u.IsActive = 1";
        
        // Mở connection
        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            
            // Dùng Parameter để tránh SQL Injection
            cmd.Parameters.AddWithValue("@Username", username);
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                // Chuyển dữ liệu từ reader sang DTO
                user = new UserDTO
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Username = reader["Username"].ToString(),
                    PasswordHash = reader["PasswordHash"].ToString(),
                    Salt = reader["Salt"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    RoleID = Convert.ToInt32(reader["RoleID"]),
                    RoleName = reader["RoleName"].ToString()
                };
            }
        }
        // Connection tự động đóng khi ra khỏi using
        
        return user;
    }
    
    // Thêm user mới (dùng cho đăng ký)
    public bool Insert(UserDTO user)
    {
        string query = @"INSERT INTO USERS 
                        (Username, PasswordHash, Salt, FullName, Email, Phone, RoleID) 
                        VALUES 
                        (@Username, @PasswordHash, @Salt, @FullName, @Email, @Phone, @RoleID)";
        
        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Salt", user.Salt);
            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RoleID", user.RoleID);
            
            conn.Open();
            // ExecuteNonQuery trả về số dòng bị ảnh hưởng
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
```

**Giải thích:**
- `@Username` là **parameter** để tránh **SQL Injection** (bảo mật)
- `using` đảm bảo connection được đóng dù có lỗi hay không
- `ExecuteReader()` dùng cho SELECT (đọc nhiều dòng)
- `ExecuteNonQuery()` dùng cho INSERT/UPDATE/DELETE
- `ExecuteScalar()` dùng khi cần lấy 1 giá trị (VD: COUNT, MAX)

### 3.2.3. BookingDAL.cs - Logic đặt vé

```csharp
// Sinh mã booking tự động
public string GenerateBookingCode()
{
    // Format: BK + yyyyMMddHHmmss + 3 số random
    // VD: BK20251221143052847
    return "BK" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(100, 999);
}

// Đánh dấu vé đã sử dụng (dùng cho kiểm tra vé)
public bool MarkAsUsed(int bookingId)
{
    string query = @"UPDATE BOOKINGS 
                    SET IsUsed = 1, UsedAt = @UsedAt 
                    WHERE BookingID = @BookingID";
    
    using (SqlConnection conn = DatabaseConnection.GetConnection())
    {
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@BookingID", bookingId);
        cmd.Parameters.AddWithValue("@UsedAt", DateTime.Now);
        
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }
}
```

---

## 3.3. BLL Layer (Business Logic Layer)

### Mục đích:
- Xử lý logic nghiệp vụ
- Validate dữ liệu trước khi lưu
- Gọi DAL để truy xuất database
- Là cầu nối giữa GUI và DAL

### 3.3.1. UserBLL.cs - Logic đăng nhập

```csharp
public class UserBLL
{
    private UserDAL userDAL = new UserDAL();
    
    // Đăng nhập
    public UserDTO Login(string username, string password)
    {
        // Bước 1: Lấy user từ database theo username
        UserDTO user = userDAL.GetByUsername(username);
        
        // Bước 2: Kiểm tra user có tồn tại không
        if (user == null)
            return null; // Username không tồn tại
        
        // Bước 3: Hash password người dùng nhập với Salt từ DB
        string hashedPassword = PasswordHelper.HashPassword(password, user.Salt);
        
        // Bước 4: So sánh hash
        if (hashedPassword == user.PasswordHash)
            return user; // Đăng nhập thành công
        
        return null; // Sai mật khẩu
    }
    
    // Đăng ký
    public (bool success, string message) Register(string username, string password, 
                                                    string fullName, string email, string phone)
    {
        // Validate dữ liệu
        if (string.IsNullOrEmpty(username) || username.Length < 3)
            return (false, "Username phải có ít nhất 3 ký tự");
        
        if (string.IsNullOrEmpty(password) || password.Length < 6)
            return (false, "Mật khẩu phải có ít nhất 6 ký tự");
        
        // Kiểm tra username đã tồn tại chưa
        if (userDAL.GetByUsername(username) != null)
            return (false, "Username đã tồn tại");
        
        // Tạo Salt và Hash password
        string salt = PasswordHelper.GenerateSalt();
        string passwordHash = PasswordHelper.HashPassword(password, salt);
        
        // Tạo DTO
        UserDTO newUser = new UserDTO
        {
            Username = username,
            PasswordHash = passwordHash,
            Salt = salt,
            FullName = fullName,
            Email = email,
            Phone = phone,
            RoleID = 3 // Customer
        };
        
        // Gọi DAL để lưu vào DB
        bool result = userDAL.Insert(newUser);
        
        if (result)
            return (true, "Đăng ký thành công");
        
        return (false, "Đăng ký thất bại");
    }
}
```

**Giải thích luồng đăng nhập:**
```
1. User nhập username + password
2. BLL lấy user từ DB theo username
3. BLL hash password với Salt từ DB
4. So sánh hash → khớp = đăng nhập thành công
```

### 3.3.2. BookingBLL.cs - Logic đặt vé

```csharp
public class BookingBLL
{
    private BookingDAL bookingDAL = new BookingDAL();
    private ShowtimeDAL showtimeDAL = new ShowtimeDAL();
    private SeatDAL seatDAL = new SeatDAL();
    
    // Đặt vé
    public (bool success, string message, int bookingId) CreateBooking(
        int userId, int showtimeId, List<int> seatIds, decimal totalAmount)
    {
        // Validate: Phải chọn ít nhất 1 ghế
        if (seatIds == null || seatIds.Count == 0)
            return (false, "Vui lòng chọn ít nhất một ghế!", 0);
        
        // Kiểm tra ghế còn trống không (tránh đặt trùng)
        List<int> bookedSeats = seatDAL.GetBookedSeatIds(showtimeId);
        foreach (int seatId in seatIds)
        {
            if (bookedSeats.Contains(seatId))
                return (false, "Một số ghế đã được đặt. Vui lòng chọn ghế khác!", 0);
        }
        
        // Tạo booking
        BookingDTO booking = new BookingDTO
        {
            BookingCode = bookingDAL.GenerateBookingCode(),
            UserID = userId,
            ShowtimeID = showtimeId,
            TotalAmount = totalAmount,
            BookingStatus = "Confirmed",
            BookingTime = DateTime.Now
        };
        
        // Lưu booking vào DB
        int bookingId = bookingDAL.Insert(booking);
        
        if (bookingId > 0)
        {
            // Lưu chi tiết (các ghế đã chọn)
            ShowtimeDTO showtime = showtimeDAL.GetById(showtimeId);
            
            foreach (int seatId in seatIds)
            {
                SeatDTO seat = seatDAL.GetById(seatId);
                // Giá = Giá cơ bản × Hệ số loại ghế
                decimal seatPrice = showtime.BasePrice * seat.PriceMultiplier;
                bookingDAL.InsertBookingDetail(bookingId, seatId, seatPrice);
            }
            
            return (true, $"Đặt vé thành công! Mã: {booking.BookingCode}", bookingId);
        }
        
        return (false, "Đặt vé thất bại!", 0);
    }
    
    // Kiểm tra có thể hủy vé không
    public bool CanCancelBooking(int bookingId)
    {
        return bookingDAL.CanCancelBooking(bookingId);
        // Logic: Chỉ hủy được nếu còn >= 2 tiếng trước giờ chiếu
    }
    
    // Tính tổng tiền
    public decimal CalculateTotalAmount(int showtimeId, List<int> seatIds)
    {
        ShowtimeDTO showtime = showtimeDAL.GetById(showtimeId);
        decimal total = 0;
        
        foreach (int seatId in seatIds)
        {
            SeatDTO seat = seatDAL.GetById(seatId);
            // Giá = Giá cơ bản × Hệ số (VIP = 1.5, Couple = 2.0)
            total += showtime.BasePrice * seat.PriceMultiplier;
        }
        
        return total;
    }
}
```

**Giải thích công thức tính giá:**
```
Giá vé = BasePrice × PriceMultiplier

Ví dụ:
- Suất chiếu có BasePrice = 80,000 VNĐ
- Ghế thường: PriceMultiplier = 1.0 → Giá = 80,000 × 1.0 = 80,000
- Ghế VIP: PriceMultiplier = 1.5 → Giá = 80,000 × 1.5 = 120,000
- Ghế Couple: PriceMultiplier = 2.0 → Giá = 80,000 × 2.0 = 160,000
```

---

## 3.4. Common Layer

### PasswordHelper.cs - Mã hóa mật khẩu

```csharp
public class PasswordHelper
{
    // Tạo Salt ngẫu nhiên
    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }
    
    // Hash password với Salt
    public static string HashPassword(string password, string salt)
    {
        // Kết hợp password + salt
        string combined = password + salt;
        
        // Hash bằng SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(combined);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
```

**Tại sao cần Salt?**
```
Không có Salt:
- "123456" → luôn hash thành "abc123xyz..."
- Hacker có thể dùng Rainbow Table để dò

Có Salt:
- User A: "123456" + "salt_A" → "xyz789..."
- User B: "123456" + "salt_B" → "def456..."
- Cùng password nhưng hash khác nhau → An toàn hơn
```

---

# 4. GIẢI THÍCH LOGIC NGHIỆP VỤ QUAN TRỌNG

## 4.1. Kiểm tra ghế đã đặt

```csharp
// SeatDAL.cs
public List<int> GetBookedSeatIds(int showtimeId)
{
    List<int> bookedSeats = new List<int>();
    
    string query = @"SELECT bd.SeatID 
                    FROM BOOKING_DETAILS bd
                    INNER JOIN BOOKINGS b ON bd.BookingID = b.BookingID
                    WHERE b.ShowtimeID = @ShowtimeID 
                    AND b.BookingStatus != 'Cancelled'";
    // ...
}
```

**Giải thích:**
- JOIN `BOOKING_DETAILS` với `BOOKINGS` để lấy ghế của suất chiếu cụ thể
- Loại trừ các booking đã hủy (`BookingStatus != 'Cancelled'`)
- Trả về danh sách SeatID đã được đặt

## 4.2. Kiểm tra vé vào rạp

```csharp
// Logic kiểm tra trạng thái vé
private void CheckTicketStatus(BookingDTO booking)
{
    DateTime showTime = booking.ShowTime;
    DateTime now = DateTime.Now;
    
    // Vé đã hủy
    if (booking.BookingStatus == "Cancelled")
    {
        status = "❌ VÉ ĐÃ HỦY";
        canEnter = false;
    }
    // Vé đã sử dụng
    else if (booking.IsUsed)
    {
        status = $"⚠️ VÉ ĐÃ SỬ DỤNG lúc {booking.UsedAt:HH:mm dd/MM}";
        canEnter = false;
    }
    // Vé hết hạn (quá 3 tiếng sau giờ chiếu)
    else if (now > showTime.AddHours(3))
    {
        status = "❌ VÉ ĐÃ HẾT HẠN";
        canEnter = false;
    }
    // Chưa đến giờ (còn > 30 phút)
    else if (now < showTime.AddMinutes(-30))
    {
        int minutes = (int)(showTime - now).TotalMinutes;
        status = $"⏳ CHƯA ĐẾN GIỜ (còn {minutes} phút)";
        canEnter = false;
    }
    // Vé hợp lệ
    else
    {
        status = "✅ VÉ HỢP LỆ - SẴN SÀNG VÀO RẠP";
        canEnter = true;
    }
}
```

## 4.3. Hệ thống hội viên - Tự động nâng hạng

```csharp
// MembershipDAL.cs
private void CheckAndUpgradeMembership(SqlConnection conn, int membershipId)
{
    // Lấy điểm hiện tại
    string getPointsQuery = "SELECT Points FROM MEMBERSHIPS WHERE MembershipID = @ID";
    // ... (lấy points)
    
    // Xác định hạng mới dựa trên điểm
    int newTypeId = 1; // Mặc định: Thành viên
    
    if (points >= 15000) newTypeId = 4;      // Kim cương
    else if (points >= 5000) newTypeId = 3;  // Vàng
    else if (points >= 1000) newTypeId = 2;  // Bạc
    
    // Cập nhật hạng nếu thay đổi
    string updateQuery = @"UPDATE MEMBERSHIPS 
                          SET MembershipTypeID = @TypeID 
                          WHERE MembershipID = @ID";
}
```

**Bảng điểm nâng hạng:**
| Hạng | Điểm yêu cầu | Ưu đãi |
|------|--------------|--------|
| Thành viên | 0 | Tích điểm |
| Bạc | 1,000 | Giảm 5% |
| Vàng | 5,000 | Giảm 10% |
| Kim cương | 15,000 | Giảm 15% |

## 4.4. Thống kê doanh thu

```csharp
// ReportDAL.cs
public List<DailyRevenueDTO> GetDailyRevenue(DateTime fromDate, DateTime toDate)
{
    string query = @"
        SELECT 
            CAST(b.BookingTime AS DATE) AS BookingDate,
            COUNT(DISTINCT b.BookingID) AS TotalBookings,
            COUNT(bd.BookingDetailID) AS TotalTickets,
            ISNULL(SUM(b.FinalAmount), 0) AS TotalRevenue
        FROM BOOKINGS b
        LEFT JOIN BOOKING_DETAILS bd ON b.BookingID = bd.BookingID
        WHERE b.BookingStatus != 'Cancelled'
        AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate
        GROUP BY CAST(b.BookingTime AS DATE)
        ORDER BY BookingDate";
    // ...
}
```

**Giải thích query:**
- `CAST(b.BookingTime AS DATE)` - Lấy phần ngày (bỏ giờ phút)
- `COUNT(DISTINCT b.BookingID)` - Đếm số đơn đặt vé (không trùng)
- `COUNT(bd.BookingDetailID)` - Đếm số vé (1 đơn có thể nhiều vé)
- `GROUP BY` - Nhóm theo ngày
- `WHERE BookingStatus != 'Cancelled'` - Không tính đơn đã hủy

---

# 5. LUỒNG HOẠT ĐỘNG CHÍNH

## 5.1. Luồng đăng nhập

```
┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐
│ frmLogin │───>│ UserBLL  │───>│ UserDAL  │───>│ Database │
└──────────┘    └──────────┘    └──────────┘    └──────────┘
     │               │               │               │
     │ 1. Nhập       │ 2. Gọi       │ 3. Query      │
     │ username,     │ Login()      │ SELECT        │
     │ password      │               │ FROM USERS   │
     │               │               │               │
     │               │ 4. Hash      │               │
     │               │ password     │               │
     │               │ với Salt     │               │
     │               │               │               │
     │ 6. Hiển thị   │ 5. So sánh  │               │
     │ kết quả       │ hash        │               │
     │               │               │               │
```

## 5.2. Luồng đặt vé

```
1. Customer chọn phim → frmMain
2. Chọn suất chiếu → frmShowtimeSelection
3. Chọn ghế → frmSeatSelection
   - Load sơ đồ ghế từ SEATS
   - Đánh dấu ghế đã đặt từ BOOKING_DETAILS
4. Xác nhận đặt vé → BookingBLL.CreateBooking()
   - Validate ghế còn trống
   - Tính tổng tiền
   - Insert BOOKINGS
   - Insert BOOKING_DETAILS (cho mỗi ghế)
5. Hiển thị kết quả + In vé
```

## 5.3. Luồng kiểm tra vé

```
1. Staff nhập mã vé (BookingCode)
2. BookingBLL.GetByBookingCode() → Lấy thông tin booking
3. Kiểm tra trạng thái:
   - Đã hủy? → Từ chối
   - Đã sử dụng? → Từ chối
   - Hết hạn? → Từ chối
   - Chưa đến giờ? → Từ chối
   - Hợp lệ? → Cho vào
4. Nếu hợp lệ: BookingBLL.MarkAsUsed() → Đánh dấu đã dùng
```

---

# 6. CÂU HỎI VẤN ĐÁP THƯỜNG GẶP

## 6.1. Câu hỏi về Kiến trúc

**Q: Tại sao dùng kiến trúc 3 lớp?**
> A: Để tách biệt trách nhiệm, dễ bảo trì, tái sử dụng code. VD: Nếu muốn đổi từ SQL Server sang MySQL, chỉ cần sửa DAL mà không ảnh hưởng BLL và GUI.

**Q: DTO là gì? Tại sao cần DTO?**
> A: DTO (Data Transfer Object) là class chứa dữ liệu, dùng để truyền dữ liệu giữa các layer. Giúp tách biệt cấu trúc DB với code xử lý.

**Q: BLL khác DAL như thế nào?**
> A: DAL chỉ làm việc với database (CRUD). BLL xử lý logic nghiệp vụ (validate, tính toán, quy tắc kinh doanh).

## 6.2. Câu hỏi về Bảo mật

**Q: Tại sao hash password thay vì lưu trực tiếp?**
> A: Nếu database bị hack, hacker không thể biết password thật. Hash là hàm một chiều, không thể giải mã ngược.

**Q: Salt dùng để làm gì?**
> A: Salt là chuỗi ngẫu nhiên thêm vào password trước khi hash. Giúp 2 user có cùng password nhưng hash khác nhau, chống Rainbow Table attack.

**Q: SQL Injection là gì? Cách phòng chống?**
> A: SQL Injection là kỹ thuật hacker chèn code SQL vào input. Phòng chống bằng cách dùng Parameter (`@Username`) thay vì nối chuỗi.

## 6.3. Câu hỏi về Nghiệp vụ

**Q: Làm sao biết ghế nào đã đặt?**
> A: Query bảng BOOKING_DETAILS JOIN với BOOKINGS, lọc theo ShowtimeID và BookingStatus != 'Cancelled'.

**Q: Công thức tính giá vé?**
> A: Giá = BasePrice (từ SHOWTIMES) × PriceMultiplier (từ SEAT_TYPES)

**Q: Tại sao cho hủy vé trước 2 tiếng?**
> A: Đây là quy định nghiệp vụ, để rạp có thời gian bán lại ghế cho khách khác.

**Q: Hệ thống hội viên hoạt động như thế nào?**
> A: Mỗi lần đặt vé được tích điểm. Điểm tích lũy đến ngưỡng sẽ tự động nâng hạng (Bạc → Vàng → Kim cương). Mỗi hạng có % giảm giá khác nhau.

## 6.4. Câu hỏi về Code

**Q: `using` dùng để làm gì?**
> A: Đảm bảo resource (connection, file) được giải phóng sau khi dùng xong, kể cả khi có exception.

**Q: `ExecuteReader` vs `ExecuteNonQuery` vs `ExecuteScalar`?**
> A: 
> - ExecuteReader: SELECT, trả về nhiều dòng
> - ExecuteNonQuery: INSERT/UPDATE/DELETE, trả về số dòng bị ảnh hưởng
> - ExecuteScalar: SELECT 1 giá trị (COUNT, MAX, SUM)

**Q: Tại sao dùng `(object)DBNull.Value`?**
> A: Khi giá trị có thể NULL, phải chuyển sang DBNull.Value để SQL Server hiểu là NULL.

---

## 📝 GHI CHÚ CUỐI

### Các điểm cần nhớ khi vấn đáp:

1. **Kiến trúc 3 lớp**: GUI → BLL → DAL → Database
2. **Bảo mật**: Hash password với Salt, dùng Parameter chống SQL Injection
3. **Nghiệp vụ đặt vé**: Kiểm tra ghế trống → Tính giá → Lưu booking + details
4. **Công thức giá**: BasePrice × PriceMultiplier
5. **Kiểm tra vé**: 5 trạng thái (Hủy, Đã dùng, Hết hạn, Chưa đến giờ, Hợp lệ)

### Nếu giảng viên hỏi câu không biết:

> "Dạ em chưa tìm hiểu sâu về phần này, em sẽ nghiên cứu thêm ạ."

---

**Chúc cả nhóm vấn đáp thành công! 🎉**

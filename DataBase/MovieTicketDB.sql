-- ============================================
-- MOVIE TICKET MANAGEMENT SYSTEM
-- Database Script for SQL Server
-- Version: 1.0
-- ============================================
-- 
-- HƯỚNG DẪN SỬ DỤNG:
-- 1. Mở SQL Server Management Studio (SSMS)
-- 2. Kết nối đến SQL Server
-- 3. Nhấn Ctrl + O để mở file này
-- 4. Nhấn F5 hoặc Execute để chạy script
-- 5. Database MovieTicketDB sẽ được tạo với dữ liệu mẫu
--
-- LƯU Ý: Script này sẽ XÓA database cũ nếu đã tồn tại!
-- ============================================

-- Tạo Database
USE master
GO

-- Xóa database cũ nếu tồn tại
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'MovieTicketDB')
BEGIN
    ALTER DATABASE MovieTicketDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE MovieTicketDB
END
GO

-- Tạo database mới
CREATE DATABASE MovieTicketDB
GO

USE MovieTicketDB
GO

-- ============================================
-- PHẦN 1: USER MANAGEMENT
-- ============================================

-- Bảng ROLES (Vai trò)
CREATE TABLE ROLES (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255)
)
GO

-- Bảng USERS (Người dùng)
CREATE TABLE USERS (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Salt NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20),
    DateOfBirth DATE,
    Gender NVARCHAR(10) CHECK (Gender IN (N'Nam', N'Nữ', N'Khác')),
    Address NVARCHAR(255),
    RoleID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID) REFERENCES ROLES(RoleID)
)
GO

-- ============================================
-- PHẦN 2: MOVIE MANAGEMENT
-- ============================================

-- Bảng GENRES (Thể loại phim)
CREATE TABLE GENRES (
    GenreID INT IDENTITY(1,1) PRIMARY KEY,
    GenreName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255)
)
GO

-- Bảng MOVIES (Phim)
CREATE TABLE MOVIES (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Duration INT NOT NULL,
    Director NVARCHAR(100),
    Actors NVARCHAR(500),
    ReleaseDate DATE,
    PosterURL NVARCHAR(500),
    TrailerURL NVARCHAR(500),
    Country NVARCHAR(100),
    AgeRating INT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    IsTrending BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
)
GO

-- Bảng MOVIE_GENRES (Liên kết Phim - Thể loại)
CREATE TABLE MOVIE_GENRES (
    MovieID INT NOT NULL,
    GenreID INT NOT NULL,
    PRIMARY KEY (MovieID, GenreID),
    CONSTRAINT FK_MovieGenres_Movies FOREIGN KEY (MovieID) REFERENCES MOVIES(MovieID) ON DELETE CASCADE,
    CONSTRAINT FK_MovieGenres_Genres FOREIGN KEY (GenreID) REFERENCES GENRES(GenreID) ON DELETE CASCADE
)
GO

-- ============================================
-- PHẦN 3: CINEMA MANAGEMENT
-- ============================================

-- Bảng ROOMS (Phòng chiếu)
CREATE TABLE ROOMS (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomName NVARCHAR(50) NOT NULL UNIQUE,
    TotalSeats INT NOT NULL,
    RoomType NVARCHAR(50) DEFAULT N'Standard',
    IsActive BIT DEFAULT 1
)
GO

-- Bảng SEAT_TYPES (Loại ghế)
CREATE TABLE SEAT_TYPES (
    SeatTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE,
    PriceMultiplier DECIMAL(3,2) DEFAULT 1.00,
    Description NVARCHAR(255)
)
GO

-- Bảng SEATS (Ghế ngồi)
CREATE TABLE SEATS (
    SeatID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT NOT NULL,
    RowLabel NVARCHAR(5) NOT NULL,
    SeatNumber INT NOT NULL,
    SeatTypeID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Seats_Rooms FOREIGN KEY (RoomID) REFERENCES ROOMS(RoomID) ON DELETE CASCADE,
    CONSTRAINT FK_Seats_SeatTypes FOREIGN KEY (SeatTypeID) REFERENCES SEAT_TYPES(SeatTypeID),
    CONSTRAINT UQ_Seats_Position UNIQUE (RoomID, RowLabel, SeatNumber)
)
GO

-- ============================================
-- PHẦN 4: SHOWTIME MANAGEMENT
-- ============================================

-- Bảng SHOWTIMES (Lịch chiếu)
CREATE TABLE SHOWTIMES (
    ShowtimeID INT IDENTITY(1,1) PRIMARY KEY,
    MovieID INT NOT NULL,
    RoomID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    BasePrice DECIMAL(10,2) NOT NULL,
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Showtimes_Movies FOREIGN KEY (MovieID) REFERENCES MOVIES(MovieID),
    CONSTRAINT FK_Showtimes_Rooms FOREIGN KEY (RoomID) REFERENCES ROOMS(RoomID),
    CONSTRAINT CK_Showtimes_Time CHECK (EndTime > StartTime)
)
GO

-- ============================================
-- PHẦN 5: PROMOTIONS
-- ============================================

-- Bảng PROMOTIONS (Khuyến mãi)
CREATE TABLE PROMOTIONS (
    PromotionID INT IDENTITY(1,1) PRIMARY KEY,
    PromotionCode NVARCHAR(50) NOT NULL UNIQUE,
    PromotionName NVARCHAR(100) NOT NULL,
    DiscountType NVARCHAR(20) NOT NULL CHECK (DiscountType IN ('Percent', 'Amount')),
    DiscountValue DECIMAL(10,2) NOT NULL,
    MinOrderAmount DECIMAL(10,2) DEFAULT 0,
    MaxDiscountAmount DECIMAL(10,2),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Quantity INT DEFAULT -1,
    UsedCount INT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT CK_Promotions_Date CHECK (EndDate > StartDate),
    CONSTRAINT CK_Promotions_Value CHECK (DiscountValue > 0)
)
GO

-- ============================================
-- PHẦN 6: BOOKING MANAGEMENT
-- ============================================

-- Bảng BOOKINGS (Đặt vé)
CREATE TABLE BOOKINGS (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    BookingCode NVARCHAR(20) NOT NULL UNIQUE,
    UserID INT NOT NULL,
    ShowtimeID INT NOT NULL,
    PromotionID INT,
    BookingTime DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(12,2) NOT NULL,
    Discount DECIMAL(12,2) DEFAULT 0,
    FinalAmount DECIMAL(12,2) NOT NULL,
    BookingStatus NVARCHAR(20) DEFAULT 'Pending' CHECK (BookingStatus IN ('Pending', 'Confirmed', 'Cancelled', 'Completed')),
    PaymentStatus NVARCHAR(50) DEFAULT N'Chưa thanh toán',
    PaymentMethod NVARCHAR(50) NULL,
    QRCode NVARCHAR(500),
    IsUsed BIT DEFAULT 0,
    UsedAt DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Bookings_Users FOREIGN KEY (UserID) REFERENCES USERS(UserID),
    CONSTRAINT FK_Bookings_Showtimes FOREIGN KEY (ShowtimeID) REFERENCES SHOWTIMES(ShowtimeID),
    CONSTRAINT FK_Bookings_Promotions FOREIGN KEY (PromotionID) REFERENCES PROMOTIONS(PromotionID)
)
GO

-- Bảng BOOKING_DETAILS (Chi tiết đặt vé - ghế)
CREATE TABLE BOOKING_DETAILS (
    BookingDetailID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    SeatID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_BookingDetails_Bookings FOREIGN KEY (BookingID) REFERENCES BOOKINGS(BookingID) ON DELETE CASCADE,
    CONSTRAINT FK_BookingDetails_Seats FOREIGN KEY (SeatID) REFERENCES SEATS(SeatID),
    CONSTRAINT UQ_BookingDetails UNIQUE (BookingID, SeatID)
)
GO

-- ============================================
-- PHẦN 7: FOOD & BEVERAGE
-- ============================================

-- Bảng FOOD_CATEGORIES (Loại đồ ăn/thức uống)
CREATE TABLE FOOD_CATEGORIES (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255)
)
GO

-- Bảng FOODS (Đồ ăn/thức uống)
CREATE TABLE FOODS (
    FoodID INT IDENTITY(1,1) PRIMARY KEY,
    FoodName NVARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    ImageURL NVARCHAR(500),
    Description NVARCHAR(255),
    StockQuantity INT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Foods_Categories FOREIGN KEY (CategoryID) REFERENCES FOOD_CATEGORIES(CategoryID)
)
GO

-- Bảng BOOKING_FOODS (Đồ ăn trong đơn đặt vé)
CREATE TABLE BOOKING_FOODS (
    BookingFoodID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    FoodID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_BookingFoods_Bookings FOREIGN KEY (BookingID) REFERENCES BOOKINGS(BookingID) ON DELETE CASCADE,
    CONSTRAINT FK_BookingFoods_Foods FOREIGN KEY (FoodID) REFERENCES FOODS(FoodID)
)
GO

-- ============================================
-- PHẦN 8: INVOICES
-- ============================================

-- Bảng INVOICES (Hóa đơn)
CREATE TABLE INVOICES (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceCode NVARCHAR(20) NOT NULL UNIQUE,
    BookingID INT NOT NULL UNIQUE,
    TicketAmount DECIMAL(12,2) NOT NULL,
    FoodAmount DECIMAL(12,2) DEFAULT 0,
    SubTotal DECIMAL(12,2) NOT NULL,
    DiscountAmount DECIMAL(12,2) DEFAULT 0,
    TaxAmount DECIMAL(12,2) DEFAULT 0,
    FinalAmount DECIMAL(12,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL CHECK (PaymentMethod IN (N'Tiền mặt', N'Thẻ ngân hàng', N'MoMo', N'ZaloPay', N'VNPay')),
    PaymentStatus NVARCHAR(20) DEFAULT 'Pending' CHECK (PaymentStatus IN ('Pending', 'Paid', 'Refunded', 'Cancelled')),
    StaffID INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(500),
    CONSTRAINT FK_Invoices_Bookings FOREIGN KEY (BookingID) REFERENCES BOOKINGS(BookingID),
    CONSTRAINT FK_Invoices_Staff FOREIGN KEY (StaffID) REFERENCES USERS(UserID)
)
GO

-- ============================================
-- PHẦN 9: MEMBERSHIP
-- ============================================

-- Bảng MEMBERSHIP_TYPES (Loại hội viên)
CREATE TABLE MEMBERSHIP_TYPES (
    MembershipTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE,
    DiscountPercent DECIMAL(5,2) DEFAULT 0,
    PointsRequired INT DEFAULT 0,
    Benefits NVARCHAR(500)
)
GO

-- Bảng MEMBERSHIPS (Hội viên)
CREATE TABLE MEMBERSHIPS (
    MembershipID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL UNIQUE,
    MembershipTypeID INT NOT NULL,
    Points INT DEFAULT 0,
    JoinDate DATETIME DEFAULT GETDATE(),
    ExpiryDate DATETIME,
    IsActive BIT DEFAULT 1,
    CONSTRAINT FK_Memberships_Users FOREIGN KEY (UserID) REFERENCES USERS(UserID),
    CONSTRAINT FK_Memberships_Types FOREIGN KEY (MembershipTypeID) REFERENCES MEMBERSHIP_TYPES(MembershipTypeID)
)
GO

-- Bảng POINT_TRANSACTIONS (Lịch sử tích/đổi điểm)
CREATE TABLE POINT_TRANSACTIONS (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    MembershipID INT NOT NULL,
    Points INT NOT NULL,
    TransactionType NVARCHAR(20) NOT NULL CHECK (TransactionType IN ('Earn', 'Redeem', 'Expire', 'Adjust')),
    Description NVARCHAR(255),
    TransactionDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_PointTransactions_Memberships FOREIGN KEY (MembershipID) REFERENCES MEMBERSHIPS(MembershipID)
)
GO

-- ============================================
-- PHẦN 10: INDEXES
-- ============================================

CREATE INDEX IX_Movies_Title ON MOVIES(Title)
CREATE INDEX IX_Movies_ReleaseDate ON MOVIES(ReleaseDate)
CREATE INDEX IX_Movies_IsTrending ON MOVIES(IsTrending) WHERE IsTrending = 1
CREATE INDEX IX_Showtimes_StartTime ON SHOWTIMES(StartTime)
CREATE INDEX IX_Showtimes_MovieID ON SHOWTIMES(MovieID)
CREATE INDEX IX_Bookings_UserID ON BOOKINGS(UserID)
CREATE INDEX IX_Bookings_ShowtimeID ON BOOKINGS(ShowtimeID)
CREATE INDEX IX_Bookings_BookingTime ON BOOKINGS(BookingTime)
CREATE INDEX IX_Invoices_CreatedAt ON INVOICES(CreatedAt)
CREATE INDEX IX_Invoices_PaymentStatus ON INVOICES(PaymentStatus)
GO

-- ============================================
-- PHẦN 11: DỮ LIỆU MẪU
-- ============================================

-- 11.1 Thêm Roles
INSERT INTO ROLES (RoleName, Description) VALUES
(N'Admin', N'Quản trị viên hệ thống'),
(N'Staff', N'Nhân viên bán vé'),
(N'Customer', N'Khách hàng')
GO

-- 11.2 Thêm Users mẫu (Password mặc định: 123456)
-- Salt và Hash được tạo từ password "123456"
INSERT INTO USERS (Username, PasswordHash, Salt, FullName, Email, Phone, RoleID, IsActive) VALUES
(N'admin', N'hkrLjBU1+mVUi5pSrUS1zEL4WgHczrVFbcDpGPRbK0U=', N'zB7mKcV7K9HqJxNpL2tD5w==', N'Quản trị viên', N'admin@cinema.com', N'0901234567', 1, 1),
(N'staff1', N'hkrLjBU1+mVUi5pSrUS1zEL4WgHczrVFbcDpGPRbK0U=', N'zB7mKcV7K9HqJxNpL2tD5w==', N'Nguyễn Văn A', N'staff1@cinema.com', N'0902345678', 2, 1),
(N'staff2', N'hkrLjBU1+mVUi5pSrUS1zEL4WgHczrVFbcDpGPRbK0U=', N'zB7mKcV7K9HqJxNpL2tD5w==', N'Trần Thị B', N'staff2@cinema.com', N'0903456789', 2, 1)
GO

-- 11.3 Thêm Genres
INSERT INTO GENRES (GenreName, Description) VALUES
(N'Hành động', N'Phim hành động, võ thuật'),
(N'Hài hước', N'Phim hài, giải trí'),
(N'Kinh dị', N'Phim kinh dị, ma quái'),
(N'Tình cảm', N'Phim tình cảm lãng mạn'),
(N'Hoạt hình', N'Phim hoạt hình'),
(N'Khoa học viễn tưởng', N'Phim khoa học viễn tưởng'),
(N'Phiêu lưu', N'Phim phiêu lưu mạo hiểm'),
(N'Tâm lý', N'Phim tâm lý xã hội')
GO

-- 11.4 Thêm Movies
INSERT INTO MOVIES (Title, Description, Duration, Director, Actors, ReleaseDate, Country, AgeRating, IsActive, IsTrending) VALUES
(N'Avengers: Endgame', N'Biệt đội siêu anh hùng đối đầu Thanos trong trận chiến cuối cùng', 181, N'Anthony Russo', N'Robert Downey Jr., Chris Evans, Scarlett Johansson', '2024-04-26', N'Mỹ', 13, 1, 1),
(N'Parasite', N'Câu chuyện về gia đình Kim và sự phân hóa giàu nghèo', 132, N'Bong Joon-ho', N'Song Kang-ho, Lee Sun-kyun, Cho Yeo-jeong', '2024-05-30', N'Hàn Quốc', 16, 1, 1),
(N'Spider-Man: No Way Home', N'Peter Parker đối mặt với đa vũ trụ', 148, N'Jon Watts', N'Tom Holland, Zendaya, Benedict Cumberbatch', '2024-12-17', N'Mỹ', 13, 1, 1),
(N'Joker', N'Câu chuyện về nguồn gốc của tên hề tội phạm', 122, N'Todd Phillips', N'Joaquin Phoenix, Robert De Niro', '2024-10-04', N'Mỹ', 18, 1, 0),
(N'Frozen II', N'Elsa và Anna tiếp tục hành trình phiêu lưu', 103, N'Chris Buck', N'Idina Menzel, Kristen Bell', '2024-11-22', N'Mỹ', 0, 1, 0),
(N'Làm Giàu Với Ma', N'Phim hài kinh dị Việt Nam', 120, N'Đức Thịnh', N'Hoài Linh, Ngọc Giàu', '2024-01-01', N'Việt Nam', 13, 1, 1)
GO

-- 11.5 Thêm Movie_Genres
INSERT INTO MOVIE_GENRES (MovieID, GenreID) VALUES
(1, 1), (1, 6), (1, 7),
(2, 8), (2, 4),
(3, 1), (3, 6), (3, 7),
(4, 8), (4, 3),
(5, 5), (5, 7),
(6, 2), (6, 3)
GO

-- 11.6 Thêm Seat Types
INSERT INTO SEAT_TYPES (TypeName, PriceMultiplier, Description) VALUES
(N'Thường', 1.00, N'Ghế ngồi thường'),
(N'VIP', 1.50, N'Ghế VIP có thêm không gian'),
(N'Couple', 2.00, N'Ghế đôi cho cặp đôi'),
(N'Sweetbox', 2.50, N'Ghế Sweetbox cao cấp')
GO

-- 11.7 Thêm Rooms
INSERT INTO ROOMS (RoomName, TotalSeats, RoomType, IsActive) VALUES
(N'Phòng 1', 80, N'Standard', 1),
(N'Phòng 2', 80, N'Standard', 1),
(N'Phòng 3', 60, N'VIP', 1),
(N'Phòng 4', 100, N'IMAX', 1)
GO

-- 11.8 Thêm Seats cho Phòng 1, 2 (8 hàng x 10 ghế)
DECLARE @RoomID INT = 1
WHILE @RoomID <= 2
BEGIN
    DECLARE @Row CHAR(1) = 'A'
    WHILE @Row <= 'H'
    BEGIN
        DECLARE @SeatNum INT = 1
        WHILE @SeatNum <= 10
        BEGIN
            DECLARE @SeatType INT = 1
            IF @Row IN ('G', 'H') SET @SeatType = 2
            
            INSERT INTO SEATS (RoomID, RowLabel, SeatNumber, SeatTypeID, IsActive)
            VALUES (@RoomID, @Row, @SeatNum, @SeatType, 1)
            
            SET @SeatNum = @SeatNum + 1
        END
        SET @Row = CHAR(ASCII(@Row) + 1)
    END
    SET @RoomID = @RoomID + 1
END
GO

-- 11.9 Thêm Seats cho Phòng 3 (VIP - 6 hàng x 10 ghế)
DECLARE @Row3 CHAR(1) = 'A'
WHILE @Row3 <= 'F'
BEGIN
    DECLARE @SeatNum3 INT = 1
    WHILE @SeatNum3 <= 10
    BEGIN
        DECLARE @SeatType3 INT = 2
        IF @Row3 IN ('E', 'F') SET @SeatType3 = 3
        
        INSERT INTO SEATS (RoomID, RowLabel, SeatNumber, SeatTypeID, IsActive)
        VALUES (3, @Row3, @SeatNum3, @SeatType3, 1)
        
        SET @SeatNum3 = @SeatNum3 + 1
    END
    SET @Row3 = CHAR(ASCII(@Row3) + 1)
END
GO

-- 11.10 Thêm Seats cho Phòng 4 (IMAX - 10 hàng x 10 ghế)
DECLARE @Row4 CHAR(1) = 'A'
WHILE @Row4 <= 'J'
BEGIN
    DECLARE @SeatNum4 INT = 1
    WHILE @SeatNum4 <= 10
    BEGIN
        DECLARE @SeatType4 INT = 1
        IF @Row4 IN ('H', 'I', 'J') SET @SeatType4 = 2
        
        INSERT INTO SEATS (RoomID, RowLabel, SeatNumber, SeatTypeID, IsActive)
        VALUES (4, @Row4, @SeatNum4, @SeatType4, 1)
        
        SET @SeatNum4 = @SeatNum4 + 1
    END
    SET @Row4 = CHAR(ASCII(@Row4) + 1)
END
GO

-- 11.11 Thêm Food Categories
INSERT INTO FOOD_CATEGORIES (CategoryName, Description) VALUES
(N'Nước uống', N'Các loại nước giải khát'),
(N'Bắp rang', N'Các loại bắp rang'),
(N'Snack', N'Đồ ăn nhẹ'),
(N'Combo', N'Combo tiết kiệm')
GO

-- 11.12 Thêm Foods
INSERT INTO FOODS (FoodName, CategoryID, Price, Description, StockQuantity, IsActive) VALUES
(N'Coca-Cola M', 1, 25000, N'Coca-Cola size M', 100, 1),
(N'Coca-Cola L', 1, 30000, N'Coca-Cola size L', 100, 1),
(N'Pepsi M', 1, 25000, N'Pepsi size M', 100, 1),
(N'Pepsi L', 1, 30000, N'Pepsi size L', 100, 1),
(N'Nước suối', 1, 15000, N'Nước suối đóng chai', 100, 1),
(N'Bắp rang Size S', 2, 35000, N'Bắp rang bơ size nhỏ', 50, 1),
(N'Bắp rang Size M', 2, 45000, N'Bắp rang bơ size vừa', 50, 1),
(N'Bắp rang Size L', 2, 55000, N'Bắp rang bơ size lớn', 50, 1),
(N'Bắp rang Caramel', 2, 50000, N'Bắp rang vị caramel', 30, 1),
(N'Bắp rang Phô mai', 2, 50000, N'Bắp rang vị phô mai', 30, 1),
(N'Hotdog', 3, 40000, N'Xúc xích nướng', 30, 1),
(N'Nachos', 3, 45000, N'Bánh Nachos với sốt phô mai', 30, 1),
(N'Combo Single', 4, 75000, N'1 Bắp M + 1 Nước L', 50, 1),
(N'Combo Couple', 4, 130000, N'1 Bắp L + 2 Nước L', 50, 1),
(N'Combo Family', 4, 180000, N'2 Bắp L + 4 Nước M', 30, 1)
GO

-- 11.13 Thêm Membership Types
INSERT INTO MEMBERSHIP_TYPES (TypeName, DiscountPercent, PointsRequired, Benefits) VALUES
(N'Thành viên', 0, 0, N'Tích điểm khi mua vé'),
(N'Bạc', 5, 1000, N'Giảm 5% giá vé, tích điểm x1.2'),
(N'Vàng', 10, 5000, N'Giảm 10% giá vé, tích điểm x1.5, ưu tiên đặt ghế'),
(N'Kim cương', 15, 15000, N'Giảm 15% giá vé, tích điểm x2, phòng chờ VIP, đổi vé miễn phí')
GO

-- 11.14 Thêm Promotions mẫu
INSERT INTO PROMOTIONS (PromotionCode, PromotionName, DiscountType, DiscountValue, MinOrderAmount, MaxDiscountAmount, StartDate, EndDate, Quantity, IsActive) VALUES
(N'WELCOME10', N'Chào mừng thành viên mới', 'Percent', 10, 100000, 50000, '2024-01-01', '2025-12-31', 1000, 1),
(N'SALE50K', N'Giảm 50K', 'Amount', 50000, 200000, NULL, '2024-01-01', '2025-12-31', 500, 1),
(N'NOEL2025', N'Khuyến mãi Noel', 'Percent', 20, 150000, 100000, '2025-12-20', '2025-12-26', 200, 1),
(N'TET2025', N'Khuyến mãi Tết 2025', 'Percent', 15, 100000, 80000, '2025-01-25', '2025-02-10', 500, 1)
GO

-- 11.15 Thêm Showtimes mẫu (cho ngày hôm nay và mai)
DECLARE @Today DATE = CAST(GETDATE() AS DATE)
DECLARE @Tomorrow DATE = DATEADD(DAY, 1, @Today)

INSERT INTO SHOWTIMES (MovieID, RoomID, StartTime, EndTime, BasePrice, IsActive) VALUES
-- Hôm nay - Phòng 1
(1, 1, CAST(@Today AS DATETIME) + '09:00:00', CAST(@Today AS DATETIME) + '12:01:00', 80000, 1),
(3, 1, CAST(@Today AS DATETIME) + '13:00:00', CAST(@Today AS DATETIME) + '14:43:00', 70000, 1),
(5, 1, CAST(@Today AS DATETIME) + '15:30:00', CAST(@Today AS DATETIME) + '17:10:00', 75000, 1),
(1, 1, CAST(@Today AS DATETIME) + '18:00:00', CAST(@Today AS DATETIME) + '21:01:00', 90000, 1),
(6, 1, CAST(@Today AS DATETIME) + '21:30:00', CAST(@Today AS DATETIME) + '23:30:00', 85000, 1),
-- Hôm nay - Phòng 2
(2, 2, CAST(@Today AS DATETIME) + '10:00:00', CAST(@Today AS DATETIME) + '12:02:00', 80000, 1),
(4, 2, CAST(@Today AS DATETIME) + '13:30:00', CAST(@Today AS DATETIME) + '15:42:00', 75000, 1),
(6, 2, CAST(@Today AS DATETIME) + '16:30:00', CAST(@Today AS DATETIME) + '18:30:00', 80000, 1),
(2, 2, CAST(@Today AS DATETIME) + '19:30:00', CAST(@Today AS DATETIME) + '21:32:00', 90000, 1),
-- Hôm nay - Phòng 3 (VIP)
(6, 3, CAST(@Today AS DATETIME) + '14:00:00', CAST(@Today AS DATETIME) + '16:00:00', 120000, 1),
(1, 3, CAST(@Today AS DATETIME) + '19:00:00', CAST(@Today AS DATETIME) + '22:01:00', 150000, 1),
-- Ngày mai - Phòng 1
(1, 1, CAST(@Tomorrow AS DATETIME) + '09:00:00', CAST(@Tomorrow AS DATETIME) + '12:01:00', 80000, 1),
(5, 1, CAST(@Tomorrow AS DATETIME) + '13:00:00', CAST(@Tomorrow AS DATETIME) + '14:40:00', 75000, 1),
(3, 1, CAST(@Tomorrow AS DATETIME) + '15:30:00', CAST(@Tomorrow AS DATETIME) + '17:13:00', 70000, 1),
(6, 1, CAST(@Tomorrow AS DATETIME) + '18:00:00', CAST(@Tomorrow AS DATETIME) + '20:00:00', 85000, 1)
GO

-- ============================================
-- PHẦN 12: STORED PROCEDURES
-- ============================================

-- SP: Kiểm tra ghế đã được đặt chưa
CREATE PROCEDURE sp_CheckSeatAvailability
    @ShowtimeID INT,
    @SeatID INT
AS
BEGIN
    SELECT COUNT(*) AS IsBooked
    FROM BOOKING_DETAILS bd
    INNER JOIN BOOKINGS b ON bd.BookingID = b.BookingID
    WHERE b.ShowtimeID = @ShowtimeID 
    AND bd.SeatID = @SeatID
    AND b.BookingStatus NOT IN ('Cancelled')
END
GO

-- SP: Lấy danh sách ghế đã đặt của một suất chiếu
CREATE PROCEDURE sp_GetBookedSeats
    @ShowtimeID INT
AS
BEGIN
    SELECT s.SeatID, s.RowLabel, s.SeatNumber, s.SeatTypeID
    FROM SEATS s
    INNER JOIN BOOKING_DETAILS bd ON s.SeatID = bd.SeatID
    INNER JOIN BOOKINGS b ON bd.BookingID = b.BookingID
    WHERE b.ShowtimeID = @ShowtimeID
    AND b.BookingStatus NOT IN ('Cancelled')
END
GO

-- SP: Lấy phim đang chiếu
CREATE PROCEDURE sp_GetNowShowingMovies
AS
BEGIN
    SELECT DISTINCT m.*
    FROM MOVIES m
    INNER JOIN SHOWTIMES s ON m.MovieID = s.MovieID
    WHERE s.StartTime >= GETDATE()
    AND s.IsActive = 1
    AND m.IsActive = 1
    ORDER BY m.IsTrending DESC, m.Title
END
GO

-- SP: Lấy lịch chiếu của một phim
CREATE PROCEDURE sp_GetShowtimesByMovie
    @MovieID INT,
    @Date DATE = NULL
AS
BEGIN
    IF @Date IS NULL
        SET @Date = CAST(GETDATE() AS DATE)
    
    SELECT 
        s.ShowtimeID,
        s.StartTime,
        s.EndTime,
        s.BasePrice,
        r.RoomID,
        r.RoomName,
        r.RoomType,
        m.Title AS MovieTitle,
        m.Duration
    FROM SHOWTIMES s
    INNER JOIN ROOMS r ON s.RoomID = r.RoomID
    INNER JOIN MOVIES m ON s.MovieID = m.MovieID
    WHERE s.MovieID = @MovieID
    AND CAST(s.StartTime AS DATE) = @Date
    AND s.IsActive = 1
    AND s.StartTime > GETDATE()
    ORDER BY s.StartTime
END
GO

-- ============================================
-- HOÀN TẤT
-- ============================================

PRINT N''
PRINT N'============================================'
PRINT N'  DATABASE CREATED SUCCESSFULLY!'
PRINT N'============================================'
PRINT N'Database: MovieTicketDB'
PRINT N'Tables: 19'
PRINT N''
PRINT N'Tài khoản mặc định:'
PRINT N'  - Admin: admin / 123456'
PRINT N'  - Staff: staff1 / 123456'
PRINT N'  - Staff: staff2 / 123456'
PRINT N''
PRINT N'Dữ liệu mẫu đã được thêm.'
PRINT N'============================================'
GO

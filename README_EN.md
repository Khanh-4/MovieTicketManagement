# 🎬 Movie Ticket Management System

A complete cinema management system built with C# Windows Forms.

---

## 📋 Introduction

A movie ticket booking application with full features for 3 roles: **Admin**, **Staff**, and **Customer**.

### Key Features:
- 🎥 Manage movies, showtimes, screening rooms
- 🎫 Book tickets with visual seat selection
- 🖨️ Print tickets with QR Code
- 📊 Revenue statistics and charts
- 🎁 Promotion and discount management
- 🍿 Food and beverage management
- 👥 Membership point system
- ✅ Ticket verification at entrance

---

## 🛠️ Technologies Used

| Technology | Description |
|------------|-------------|
| C# | Programming language |
| .NET 8.0 | Framework |
| Windows Forms | User interface |
| SQL Server | Database |
| QRCoder | QR code generation |

---

## 📁 Project Structure

```
MovieTicketManagement/
├── 📂 Database/
│   └── MovieTicketDB.sql       # Database creation script
├── 📂 MovieTicket.DTO/         # Data Transfer Objects
├── 📂 MovieTicket.DAL/         # Data Access Layer
├── 📂 MovieTicket.BLL/         # Business Logic Layer
├── 📂 MovieTicket.Common/      # Utilities (PasswordHelper...)
├── 📂 MovieTicketManagement/   # Windows Forms UI
└── 📄 MovieTicketManagement.slnx
```

### 3-Layer Architecture:
```
┌─────────────────┐
│   GUI (Forms)   │  ← User Interface
├─────────────────┤
│      BLL        │  ← Business Logic
├─────────────────┤
│      DAL        │  ← Data Access
├─────────────────┤
│   SQL Server    │  ← Database
└─────────────────┘
```

---

## ⚙️ Installation Guide

### System Requirements:
- Windows 10/11
- Visual Studio 2022 (Community or higher)
- SQL Server 2019+ (or SQL Server Express)
- .NET 8.0 SDK

### Step 1: Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/MovieTicketManagement.git
cd MovieTicketManagement
```

### Step 2: Create Database

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server
3. Open file `Database/MovieTicketDB.sql`
4. Press **F5** or **Execute** to run the script
5. Database `MovieTicketDB` will be created with sample data

### Step 3: Configure Connection String

1. Open file `MovieTicketManagement/App.config`
2. Find `connectionStrings` and change `Server=` to your SQL Server name:

```xml
<connectionStrings>
    <add name="MovieTicketDB" 
         connectionString="Server=YOUR_SERVER_NAME;Database=MovieTicketDB;Trusted_Connection=True;TrustServerCertificate=True" 
         providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

**Server Name Examples:**
| Type | Server Name |
|------|-------------|
| SQL Server Express | `.\SQLEXPRESS` or `localhost\SQLEXPRESS` |
| SQL Server Local | `localhost` or `.` |
| Named Instance | `COMPUTER_NAME\INSTANCE_NAME` |

### Step 4: Build and Run

1. Open `MovieTicketManagement.slnx` with **Visual Studio 2022**
2. Press **Ctrl + Shift + B** to Build Solution
3. Press **F5** to run the application

---

## 👤 Default Accounts

| Role | Username | Password | Permissions |
|------|----------|----------|-------------|
| Admin | `admin` | `123456` | Full system management |
| Staff | `staff1` | `123456` | Sell tickets, verify tickets, reports |
| Customer | *(Register)* | | Book tickets, view history |

---

## 📱 Features by Role

### 👨‍💼 Admin
- Manage movies (Add, Edit, Delete)
- Manage showtimes
- Manage screening rooms
- Manage users
- Manage promotions
- Manage food/beverages
- View revenue statistics
- Export reports

### 👨‍💻 Staff
- Sell tickets at counter
- Verify tickets at entrance
- View revenue reports
- Manage food items

### 👤 Customer
- View now showing movies
- Book tickets online
- Select seats
- View booking history
- Cancel tickets (2 hours before)
- Print tickets with QR Code
- View membership info
- Change password

---

## 🖼️ User Interface

### Login Screen
- Login with username/password
- Show/hide password toggle
- Register new account

### Seat Selection Screen
- Visual seat map display
- Color-coded seat types:
  - 🟦 Standard seats
  - 🟨 VIP seats
  - 🟪 Couple seats
  - 🟥 Booked seats
  - 🟩 Selected seats

### Statistics Screen
- Daily revenue chart
- Top revenue movies
- Export CSV reports

---

## 🔧 Troubleshooting

### Database Connection Error
```
❌ Cannot connect to SQL Server
```
**Solution:**
1. Check if SQL Server is running
2. Verify server name in `App.config`
3. Ensure database script has been executed

### Missing Library Error
```
❌ Could not load file or assembly 'QRCoder'
```
**Solution:**
```bash
# In Package Manager Console
Install-Package QRCoder
```

### Wrong Password Error
**Solution:**
- Use the **"Reset PW"** button on login form to reset all passwords to `123456`

---

## 📝 Development Notes

### Add new movie to database:
```sql
INSERT INTO MOVIES (Title, Duration, Director, IsActive)
VALUES (N'Movie Title', 120, N'Director Name', 1)
```

### Add new showtime:
```sql
INSERT INTO SHOWTIMES (MovieID, RoomID, StartTime, EndTime, BasePrice, IsActive)
VALUES (1, 1, '2025-01-01 19:00', '2025-01-01 21:00', 80000, 1)
```

---

## 👨‍💻 Author

- **Name:** [Cao Duy Quốc Khánh]
- **Student ID:** [2380601019]
- **Class:** [23DTHC1]
- **University:** [Trường Đại Học Công Nghệ Thành phố Hồ Chí Minh - HUTECH]

---

## 📄 License

This project is created for educational and research purposes.

---

## 🙏 Acknowledgments

Thanks to my professors for their guidance throughout this project.

---

⭐ If you find this project helpful, please give it a **Star**!

# 🎬 Movie Ticket Management System

A complete cinema management system built with C# Windows Forms.

---

## 📋 Introduction

A movie ticket booking application with full features for 3 roles: **Admin**, **Staff**, and **Customer**.

### ✨ Key Features:
- 🎥 Manage movies, showtimes, screening rooms
- 🎫 Book tickets with visual seat selection (Standard, VIP, Couple)
- 🖨️ Print tickets with QR Code
- 📊 Revenue statistics, export CSV reports
- 🎁 Promotion and discount management
- 🍿 Food and beverage management with tickets
- 👥 Membership point accumulation system
- ✅ Ticket verification with QR Code scanning
- 🔄 **Pass Ticket Feature** - Transfer tickets with refund
- 💰 **Digital Wallet** - Balance management, deposit, payment
- 📧 **Automatic Email** - Notifications via Gmail SMTP

---

## 🛠️ Technologies Used

| Technology | Version | Description |
|------------|---------|-------------|
| C# | 12.0 | Programming language |
| .NET | 8.0 | Framework |
| Windows Forms | - | User interface |
| SQL Server | 2019+ | Database |
| QRCoder | 1.4.3 | QR code generation |
| Gmail SMTP | - | Email notifications |

---

## 📁 Project Structure

```
MovieTicketManagement/
├── 📂 Database/
│   ├── Movieticketdb.sql               # Main database script
│   ├── BookingsAdd.sql                 # Add PaymentStatus, PaymentMethod columns
│   ├── 02_AddCoupleSeats_AllRooms.sql  # Add couple seats
│   └── MASTER_PassTicket_Database.sql  # Pass Ticket feature
├── 📂 MovieTicket.DTO/                 # Data Transfer Objects
├── 📂 MovieTicket.DAL/                 # Data Access Layer
├── 📂 MovieTicket.BLL/                 # Business Logic Layer
├── 📂 MovieTicket.Common/              # Utilities (PasswordHelper, OTPHelper...)
├── 📂 MovieTicketManagement/           # Windows Forms UI
│   ├── App.config                      # DB & SMTP configuration
│   └── *.cs                            # Form files
└── 📄 MovieTicketManagement.slnx       # Solution file
```

### 🏗️ 3-Layer Architecture:
```
┌─────────────────────────────────────┐
│         GUI (Windows Forms)         │  ← User Interface
│   frmLogin, frmMain, frmBooking...  │
├─────────────────────────────────────┤
│         BLL (Business Logic)        │  ← Business Logic Processing
│   UserBLL, BookingBLL, ResaleBLL... │
├─────────────────────────────────────┤
│         DAL (Data Access)           │  ← Data Access
│   UserDAL, BookingDAL, WalletDAL... │
├─────────────────────────────────────┤
│            SQL Server               │  ← Database
│         MovieTicketDB               │
└─────────────────────────────────────┘
```

---

## 🗄️ Database

### Overview:
- **19 tables**
- **3 Stored Procedures** for Pass Ticket feature
- Complete relationships with foreign keys
- Sample data included

### Table List:

| # | Table Name | Description |
|---|------------|-------------|
| 1 | USERS | User information |
| 2 | ROLES | Roles (Admin, Staff, Customer) |
| 3 | MOVIES | Movie information |
| 4 | ROOMS | Screening rooms |
| 5 | SEATS | Seats |
| 6 | SHOWTIMES | Showtimes |
| 7 | BOOKINGS | Booking orders |
| 8 | BOOKING_DETAILS | Booked seat details |
| 9 | BOOKING_FOODS | Food with tickets |
| 10 | FOODS | Food menu |
| 11 | PROMOTIONS | Promotions |
| 12 | MEMBERSHIPS | Membership |
| 13 | MEMBERSHIP_LEVELS | Membership levels |
| 14 | POINT_TRANSACTIONS | Point history |
| 15 | PASSWORD_RESET_TOKENS | Password reset tokens |
| 16 | USER_WALLET | Digital wallet |
| 17 | WALLET_TRANSACTIONS | Wallet transaction history |
| 18 | TICKET_RESALES | Pass tickets |
| 19 | GENRES | Movie genres |

---

## ⚙️ Installation Guide

### 📋 System Requirements:
- Windows 10/11
- Visual Studio 2022 (Community or higher)
- SQL Server 2019+ (or SQL Server Express)
- .NET 8.0 SDK

### Step 1: Clone Repository

```bash
git clone https://github.com/Khanh-2910/MovieTicketManagement.git
cd MovieTicketManagement
```

### Step 2: Create Database

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server
3. Run SQL files in order:

```
1️⃣ Database/Movieticketdb.sql              # Create main database
2️⃣ Database/BookingsAdd.sql                # Add additional columns
3️⃣ Database/02_AddCoupleSeats_AllRooms.sql # Add couple seats
4️⃣ Database/MASTER_PassTicket_Database.sql # Pass Ticket feature
```

### Step 3: Configure Connection String

Open `MovieTicketManagement/App.config` and change Server name:

```xml
<connectionStrings>
    <add name="MovieTicketDB" 
         connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=MovieTicketDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True" 
         providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

**Server Name Examples:**
| Type | Server Name |
|------|-------------|
| SQL Server Express | `.\SQLEXPRESS` or `localhost\SQLEXPRESS` |
| SQL Server Local | `localhost` or `.` |
| Named Instance | `COMPUTER_NAME\INSTANCE_NAME` |

### Step 4: Configure Email SMTP (Optional)

To use email features, configure in `App.config`:

```xml
<appSettings>
    <add key="SmtpHost" value="smtp.gmail.com"/>
    <add key="SmtpPort" value="587"/>
    <add key="SmtpEmail" value="your_email@gmail.com"/>
    <add key="SmtpPassword" value="your_app_password"/>
    <add key="SmtpDisplayName" value="Movie Ticket System"/>
</appSettings>
```

> ⚠️ **Note:** Use Google [App Password](https://support.google.com/accounts/answer/185833), not regular password.

### Step 5: Build and Run

1. Open `MovieTicketManagement.slnx` with **Visual Studio 2022**
2. Press **Ctrl + Shift + B** to Build Solution
3. Press **F5** to run the application

---

## 👤 Default Accounts

| Role | Username | Password | Description |
|------|----------|----------|-------------|
| Admin | `admin` | `123456` | Full system management |
| Staff | `staff1` | `123456` | Sell tickets, verify tickets |
| Customer | `customer1` | `123456` | Book tickets, view history |

> 💡 Use **"Reset PW"** button on login form to reset all passwords to `123456`

---

## 📱 Features by Role

### 👨‍💼 Admin
| Feature | Description |
|---------|-------------|
| Staff Management | Add, edit, delete staff accounts |
| Movie Management | CRUD movies, upload posters |
| Room Management | Configure rooms, seat types |
| Showtime Management | Create showtimes, check conflicts |
| Promotion Management | Create discount codes, promotions |
| Food Management | CRUD food, beverages |
| Revenue Reports | View statistics, export CSV |
| Statistics | Charts, top movies, occupancy rate |

### 👨‍💻 Staff
| Feature | Description |
|---------|-------------|
| Sell Tickets | Book tickets for customers at counter |
| Verify Tickets | Scan QR or enter booking code |
| Movie Management | View, add, edit movie information |
| Showtime Management | Create and manage showtimes |
| Food Management | Manage food menu |

### 👤 Customer
| Feature | Description |
|---------|-------------|
| Book Online | Select movie, showtime, seats |
| Select Food | Add combos, popcorn, drinks |
| Booking History | View, print, cancel tickets |
| Membership | View accumulated points, membership level |
| 🆕 Pass Ticket | Transfer tickets, receive refund |
| 🆕 Buy Pass Ticket | Buy tickets at 15% discount |
| 🆕 Wallet | Manage balance, deposit |
| Change Password | Change account password |

---

## 🔄 Highlight Feature: Pass Ticket

### Description:
Allows customers to **transfer purchased tickets** when unable to attend, receiving **refund to wallet**. Cinema will **resell tickets** at **15% discount**.

### Process:
```
┌─────────────┐         ┌─────────────┐         ┌─────────────┐
│   User A    │         │   Cinema    │         │   User B    │
│  (Seller)   │         │ (Middleman) │         │   (Buyer)   │
└──────┬──────┘         └──────┬──────┘         └──────┬──────┘
       │                       │                       │
       │  1. Pass ticket       │                       │
       │  ──────────────────►  │                       │
       │                       │                       │
       │  2. Refund 70/50/30%  │                       │
       │  ◄──────────────────  │                       │
       │     (to wallet)       │                       │
       │                       │                       │
       │                       │  3. View pass tickets │
       │                       │  ◄────────────────────│
       │                       │                       │
       │                       │  4. Buy at -15%       │
       │                       │  ◄────────────────────│
       │                       │                       │
       │  5. Email notification│  5. Email confirmation│
       │  ◄──────────────────  │  ────────────────────►│
       │                       │                       │
```

### Refund Rate:
| Time Before Showtime | Refund Rate |
|---------------------|-------------|
| ≥ 3 days | 70% |
| 2 days | 50% |
| 1 day | 30% |
| < 1 day | Not allowed |

### Automatic Emails:
- ✉️ Pass ticket success notification (to seller)
- ✉️ Purchase confirmation (to buyer)
- ✉️ Ticket sold notification (to seller)

---

## 🖼️ User Interface

### Login Screen
- Login with username/password
- Show/hide password toggle
- Register new account
- Forgot password (OTP via email)
- Reset password (for testing)

### Seat Selection Screen
Color-coded seat types:
| Color | Seat Type | Price |
|-------|-----------|-------|
| 🟦 Blue | Standard | Base price |
| 🟨 Yellow | VIP | +20% |
| 🟪 Purple | Couple | x2 |
| 🟥 Red | Booked | - |
| 🟩 Green | Selected | - |

### Statistics Screen
- Revenue chart by day/month
- Top revenue movies
- Seat occupancy rate
- Export CSV reports

### Wallet Screen
- Display balance
- Deposit to wallet
- Transaction history
- Color coded: Green (deposit), Red (deduct)

---

## 🔧 Troubleshooting

### ❌ Database Connection Error
```
Cannot connect to SQL Server
```
**Solution:**
1. Check if SQL Server is running
2. Verify server name in `App.config`
3. Ensure all SQL files have been executed

### ❌ Missing Library Error
```
Could not load file or assembly 'QRCoder'
```
**Solution:**
```bash
# In Package Manager Console
Install-Package QRCoder
Install-Package Microsoft.Data.SqlClient
```

### ❌ Email Sending Error
```
SMTP Authentication Error
```
**Solution:**
1. Check email and App Password in `App.config`
2. Enable "Less secure app access" or use App Password
3. Check internet connection

### ❌ Pass Ticket Error - CHECK constraint
```
The UPDATE statement conflicted with the CHECK constraint
```
**Solution:**
```sql
-- Run in SSMS
ALTER TABLE BOOKINGS DROP CONSTRAINT CK_BOOKINGS_BookingStatus
GO
ALTER TABLE BOOKINGS ADD CONSTRAINT CK_BOOKINGS_BookingStatus 
CHECK (BookingStatus IN ('Pending', 'Confirmed', 'Cancelled', 'Completed', 'Resold'))
GO
```

---

## 🚀 Future Development

### Phase 1: Complete Desktop App
- [ ] Unit Testing
- [ ] Movie rating feature
- [ ] Movie recommendations based on preferences
- [ ] Performance optimization

### Phase 2: Web Application
- [ ] ASP.NET Core MVC
- [ ] RESTful API
- [ ] Responsive Design
- [ ] JWT Authentication

### Phase 3: Mobile Application
- [ ] React Native / Flutter
- [ ] Payment integration (VNPay, Momo)
- [ ] Push Notification
- [ ] Quick booking

### Phase 4: Cloud & DevOps
- [ ] Docker containerization
- [ ] Kubernetes orchestration
- [ ] CI/CD Pipeline
- [ ] Deploy to Azure / AWS

---

## 👨‍💻 Author

| Information | Details |
|-------------|---------|
| **Name** | Cao Duy Quoc Khanh |
| **Student ID** | 2380601019 |
| **Class** | 23DTHC1 |
| **University** | Ho Chi Minh City University of Technology (HUTECH) |
| **GitHub** | [Khanh-4](https://github.com/Khanh-4) |

---

## 📄 License

This project is created for **educational and research purposes**.

Source code is shared publicly for reference. Please credit if used.

---

## 🙏 Acknowledgments

Sincere thanks to:
- Professors who guided throughout the project
- Fellow students who provided feedback and tested the application
- The programming community for sharing knowledge

---

<div align="center">

⭐ **If you find this project helpful, please give it a Star!** ⭐

Made with ❤️ by Khanh

</div>

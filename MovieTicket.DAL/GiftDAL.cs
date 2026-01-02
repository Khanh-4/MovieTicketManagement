using Microsoft.Data.SqlClient;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace MovieTicket.DAL
{
    /// <summary>
    /// Data Access Layer cho tính năng Quà tặng giới hạn
    /// </summary>
    public class GiftDAL
    {
        private readonly string connectionString;

        public GiftDAL()
        {
            connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["MovieTicketDB"].ConnectionString;
        }

        #region Gift Campaign Methods

        /// <summary>
        /// Lấy tất cả chiến dịch quà tặng
        /// </summary>
        public List<GiftCampaignDTO> GetAllCampaigns()
        {
            var list = new List<GiftCampaignDTO>();

            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        gc.*,
                        m.Title AS MovieTitle
                    FROM GIFT_CAMPAIGNS gc
                    LEFT JOIN MOVIES m ON gc.MovieID = m.MovieID
                    ORDER BY gc.IsActive DESC, gc.StartDate DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToGiftCampaignDTO(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy chiến dịch đang hoạt động (có thể lọc theo MovieID)
        /// </summary>
        public List<GiftCampaignDTO> GetActiveCampaigns(int? movieId = null)
        {
            var list = new List<GiftCampaignDTO>();

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_GetActiveCampaigns", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovieID", (object)movieId ?? DBNull.Value);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToGiftCampaignDTO(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy chiến dịch theo ID
        /// </summary>
        public GiftCampaignDTO GetCampaignById(int campaignId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        gc.*,
                        m.Title AS MovieTitle
                    FROM GIFT_CAMPAIGNS gc
                    LEFT JOIN MOVIES m ON gc.MovieID = m.MovieID
                    WHERE gc.CampaignID = @CampaignID";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CampaignID", campaignId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToGiftCampaignDTO(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Thêm chiến dịch mới
        /// </summary>
        public int AddCampaign(GiftCampaignDTO campaign)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO GIFT_CAMPAIGNS (
                        CampaignName, Description, GiftName, MovieID,
                        TotalGifts, RemainingGifts, MaxPerUser, HoldTimeoutMinutes,
                        StartDate, EndDate, IsActive, CreatedBy
                    )
                    VALUES (
                        @CampaignName, @Description, @GiftName, @MovieID,
                        @TotalGifts, @TotalGifts, @MaxPerUser, @HoldTimeoutMinutes,
                        @StartDate, @EndDate, @IsActive, @CreatedBy
                    );
                    SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CampaignName", campaign.CampaignName);
                    cmd.Parameters.AddWithValue("@Description", (object)campaign.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GiftName", campaign.GiftName);
                    cmd.Parameters.AddWithValue("@MovieID", (object)campaign.MovieID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalGifts", campaign.TotalGifts);
                    cmd.Parameters.AddWithValue("@MaxPerUser", campaign.MaxPerUser);
                    cmd.Parameters.AddWithValue("@HoldTimeoutMinutes", campaign.HoldTimeoutMinutes);
                    cmd.Parameters.AddWithValue("@StartDate", campaign.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", campaign.EndDate);
                    cmd.Parameters.AddWithValue("@IsActive", campaign.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", (object)campaign.CreatedBy ?? DBNull.Value);

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Cập nhật chiến dịch
        /// </summary>
        public bool UpdateCampaign(GiftCampaignDTO campaign)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE GIFT_CAMPAIGNS SET
                        CampaignName = @CampaignName,
                        Description = @Description,
                        GiftName = @GiftName,
                        MovieID = @MovieID,
                        TotalGifts = @TotalGifts,
                        MaxPerUser = @MaxPerUser,
                        HoldTimeoutMinutes = @HoldTimeoutMinutes,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        IsActive = @IsActive
                    WHERE CampaignID = @CampaignID";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CampaignID", campaign.CampaignID);
                    cmd.Parameters.AddWithValue("@CampaignName", campaign.CampaignName);
                    cmd.Parameters.AddWithValue("@Description", (object)campaign.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GiftName", campaign.GiftName);
                    cmd.Parameters.AddWithValue("@MovieID", (object)campaign.MovieID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalGifts", campaign.TotalGifts);
                    cmd.Parameters.AddWithValue("@MaxPerUser", campaign.MaxPerUser);
                    cmd.Parameters.AddWithValue("@HoldTimeoutMinutes", campaign.HoldTimeoutMinutes);
                    cmd.Parameters.AddWithValue("@StartDate", campaign.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", campaign.EndDate);
                    cmd.Parameters.AddWithValue("@IsActive", campaign.IsActive);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Kích hoạt/Tạm dừng chiến dịch
        /// </summary>
        public bool SetCampaignActive(int campaignId, bool isActive)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE GIFT_CAMPAIGNS SET IsActive = @IsActive WHERE CampaignID = @CampaignID";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CampaignID", campaignId);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        #endregion

        #region Gift Reservation Methods

        /// <summary>
        /// Giữ chỗ quà (xử lý Race Condition)
        /// </summary>
        public GiftReservationResult ReserveGift(int campaignId, int userId)
        {
            var result = new GiftReservationResult();

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_ReserveGift", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CampaignID", campaignId);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    // Output parameters
                    var successParam = new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                    var reservationIdParam = new SqlParameter("@ReservationID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(successParam);
                    cmd.Parameters.Add(messageParam);
                    cmd.Parameters.Add(reservationIdParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    result.Success = (bool)successParam.Value;
                    result.Message = messageParam.Value?.ToString() ?? "";
                    result.ReservationID = result.Success ? (int)reservationIdParam.Value : 0;

                    // Lấy HoldUntil nếu thành công
                    if (result.Success && result.ReservationID > 0)
                    {
                        var reservation = GetReservationById(result.ReservationID);
                        result.HoldUntil = reservation?.HoldUntil;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Xác nhận quà sau khi thanh toán
        /// </summary>
        public (bool success, string message) ConfirmGift(int reservationId, int bookingId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_ConfirmGift", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    var successParam = new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(successParam);
                    cmd.Parameters.Add(messageParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return ((bool)successParam.Value, messageParam.Value?.ToString() ?? "");
                }
            }
        }

        /// <summary>
        /// Hủy giữ chỗ quà
        /// </summary>
        public (bool success, string message) CancelGiftReservation(int reservationId, string cancelReason, bool returnToStock = true)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_CancelGiftReservation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    cmd.Parameters.AddWithValue("@CancelReason", cancelReason ?? "");
                    cmd.Parameters.AddWithValue("@ReturnToStock", returnToStock);

                    var successParam = new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(successParam);
                    cmd.Parameters.Add(messageParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return ((bool)successParam.Value, messageParam.Value?.ToString() ?? "");
                }
            }
        }

        /// <summary>
        /// Phát quà tại rạp (Staff scan vé)
        /// </summary>
        public (bool success, string message, string giftName) ReceiveGift(int bookingId, int staffId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_ReceiveGift", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.Parameters.AddWithValue("@StaffID", staffId);

                    var successParam = new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                    var giftNameParam = new SqlParameter("@GiftName", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(successParam);
                    cmd.Parameters.Add(messageParam);
                    cmd.Parameters.Add(giftNameParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (
                        (bool)successParam.Value,
                        messageParam.Value?.ToString() ?? "",
                        giftNameParam.Value?.ToString() ?? ""
                    );
                }
            }
        }

        /// <summary>
        /// Kiểm tra user đủ điều kiện nhận quà không
        /// </summary>
        public (bool isEligible, string message, int remainingGifts) CheckUserGiftEligibility(int campaignId, int userId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_CheckUserGiftEligibility", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CampaignID", campaignId);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    var isEligibleParam = new SqlParameter("@IsEligible", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                    var remainingParam = new SqlParameter("@RemainingGifts", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(isEligibleParam);
                    cmd.Parameters.Add(messageParam);
                    cmd.Parameters.Add(remainingParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (
                        (bool)isEligibleParam.Value,
                        messageParam.Value?.ToString() ?? "",
                        remainingParam.Value != DBNull.Value ? (int)remainingParam.Value : 0
                    );
                }
            }
        }

        /// <summary>
        /// Giải phóng các reservation hết hạn
        /// </summary>
        public int ReleaseExpiredReservations()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_ReleaseExpiredGiftReservations", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var releasedCountParam = new SqlParameter("@ReleasedCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(releasedCountParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)releasedCountParam.Value;
                }
            }
        }

        /// <summary>
        /// Lấy thông tin reservation theo ID
        /// </summary>
        public GiftReservationDTO GetReservationById(int reservationId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        gr.*,
                        gc.CampaignName,
                        gc.GiftName,
                        gc.Description AS GiftDescription,
                        u.FullName AS UserFullName,
                        u.Email AS UserEmail,
                        b.BookingCode,
                        s.FullName AS StaffName
                    FROM GIFT_RESERVATIONS gr
                    INNER JOIN GIFT_CAMPAIGNS gc ON gr.CampaignID = gc.CampaignID
                    INNER JOIN USERS u ON gr.UserID = u.UserID
                    LEFT JOIN BOOKINGS b ON gr.BookingID = b.BookingID
                    LEFT JOIN USERS s ON gr.ReceivedByStaffID = s.UserID
                    WHERE gr.ReservationID = @ReservationID";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToGiftReservationDTO(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Lấy thông tin quà của booking
        /// </summary>
        public BookingGiftInfoDTO GetBookingGiftInfo(int bookingId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("sp_GetBookingGiftInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BookingGiftInfoDTO
                            {
                                BookingID = reader.GetInt32(reader.GetOrdinal("BookingID")),
                                BookingCode = reader["BookingCode"]?.ToString(),
                                HasGift = reader["HasGift"] != DBNull.Value && (bool)reader["HasGift"],
                                ReservationID = reader["ReservationID"] != DBNull.Value ? (int?)reader["ReservationID"] : null,
                                GiftStatus = reader["GiftStatus"]?.ToString(),
                                ConfirmedAt = reader["ConfirmedAt"] != DBNull.Value ? (DateTime?)reader["ConfirmedAt"] : null,
                                ReceivedAt = reader["ReceivedAt"] != DBNull.Value ? (DateTime?)reader["ReceivedAt"] : null,
                                CampaignID = reader["CampaignID"] != DBNull.Value ? (int?)reader["CampaignID"] : null,
                                CampaignName = reader["CampaignName"]?.ToString(),
                                GiftName = reader["GiftName"]?.ToString(),
                                GiftDescription = reader["GiftDescription"]?.ToString(),
                                GiftStatusText = reader["GiftStatusText"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Lấy danh sách reservation của user
        /// </summary>
        public List<GiftReservationDTO> GetUserReservations(int userId)
        {
            var list = new List<GiftReservationDTO>();

            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        gr.*,
                        gc.CampaignName,
                        gc.GiftName,
                        gc.Description AS GiftDescription,
                        u.FullName AS UserFullName,
                        u.Email AS UserEmail,
                        b.BookingCode,
                        s.FullName AS StaffName
                    FROM GIFT_RESERVATIONS gr
                    INNER JOIN GIFT_CAMPAIGNS gc ON gr.CampaignID = gc.CampaignID
                    INNER JOIN USERS u ON gr.UserID = u.UserID
                    LEFT JOIN BOOKINGS b ON gr.BookingID = b.BookingID
                    LEFT JOIN USERS s ON gr.ReceivedByStaffID = s.UserID
                    WHERE gr.UserID = @UserID
                    ORDER BY gr.CreatedAt DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapToGiftReservationDTO(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy reservation đang Holding của user cho campaign
        /// </summary>
        public GiftReservationDTO GetUserHoldingReservation(int userId, int campaignId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP 1
                        gr.*,
                        gc.CampaignName,
                        gc.GiftName,
                        gc.Description AS GiftDescription,
                        u.FullName AS UserFullName,
                        u.Email AS UserEmail,
                        b.BookingCode,
                        s.FullName AS StaffName
                    FROM GIFT_RESERVATIONS gr
                    INNER JOIN GIFT_CAMPAIGNS gc ON gr.CampaignID = gc.CampaignID
                    INNER JOIN USERS u ON gr.UserID = u.UserID
                    LEFT JOIN BOOKINGS b ON gr.BookingID = b.BookingID
                    LEFT JOIN USERS s ON gr.ReceivedByStaffID = s.UserID
                    WHERE gr.UserID = @UserID 
                      AND gr.CampaignID = @CampaignID
                      AND gr.Status = 'Holding'
                      AND gr.HoldUntil > GETDATE()
                    ORDER BY gr.CreatedAt DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@CampaignID", campaignId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToGiftReservationDTO(reader);
                        }
                    }
                }
            }

            return null;
        }

        #endregion

        #region Statistics Methods

        /// <summary>
        /// Lấy thống kê chiến dịch
        /// </summary>
        public DataTable GetCampaignStatistics()
        {
            var dt = new DataTable();

            using (var conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vw_GiftCampaignStats ORDER BY CampaignID DESC";

                using (var cmd = new SqlCommand(query, conn))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        #endregion

        #region Mapping Methods

        private GiftCampaignDTO MapToGiftCampaignDTO(SqlDataReader reader)
        {
            return new GiftCampaignDTO
            {
                CampaignID = reader.GetInt32(reader.GetOrdinal("CampaignID")),
                CampaignName = reader["CampaignName"]?.ToString(),
                Description = reader["Description"]?.ToString(),
                GiftName = reader["GiftName"]?.ToString(),
                MovieID = reader["MovieID"] != DBNull.Value ? (int?)reader["MovieID"] : null,
                TotalGifts = reader.GetInt32(reader.GetOrdinal("TotalGifts")),
                RemainingGifts = reader.GetInt32(reader.GetOrdinal("RemainingGifts")),
                HoldingGifts = reader["HoldingGifts"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoldingGifts")) : 0,
                MaxPerUser = reader.GetInt32(reader.GetOrdinal("MaxPerUser")),
                HoldTimeoutMinutes = reader.GetInt32(reader.GetOrdinal("HoldTimeoutMinutes")),
                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime?)reader["CreatedAt"] : null,
                CreatedBy = reader["CreatedBy"] != DBNull.Value ? (int?)reader["CreatedBy"] : null,
                MovieTitle = reader["MovieTitle"]?.ToString()
            };
        }

        private GiftReservationDTO MapToGiftReservationDTO(SqlDataReader reader)
        {
            return new GiftReservationDTO
            {
                ReservationID = reader.GetInt32(reader.GetOrdinal("ReservationID")),
                CampaignID = reader.GetInt32(reader.GetOrdinal("CampaignID")),
                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                BookingID = reader["BookingID"] != DBNull.Value ? (int?)reader["BookingID"] : null,
                Status = reader["Status"]?.ToString(),
                HoldUntil = reader["HoldUntil"] != DBNull.Value ? (DateTime?)reader["HoldUntil"] : null,
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                ConfirmedAt = reader["ConfirmedAt"] != DBNull.Value ? (DateTime?)reader["ConfirmedAt"] : null,
                ReceivedAt = reader["ReceivedAt"] != DBNull.Value ? (DateTime?)reader["ReceivedAt"] : null,
                ReceivedByStaffID = reader["ReceivedByStaffID"] != DBNull.Value ? (int?)reader["ReceivedByStaffID"] : null,
                CancelledAt = reader["CancelledAt"] != DBNull.Value ? (DateTime?)reader["CancelledAt"] : null,
                CancelReason = reader["CancelReason"]?.ToString(),
                CampaignName = reader["CampaignName"]?.ToString(),
                GiftName = reader["GiftName"]?.ToString(),
                GiftDescription = reader["GiftDescription"]?.ToString(),
                UserFullName = reader["UserFullName"]?.ToString(),
                UserEmail = reader["UserEmail"]?.ToString(),
                BookingCode = reader["BookingCode"]?.ToString(),
                StaffName = reader["StaffName"]?.ToString()
            };
        }

        #endregion
    }
}
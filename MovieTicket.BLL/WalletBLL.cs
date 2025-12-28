using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class WalletBLL
    {
        private readonly WalletDAL walletDAL = new WalletDAL();

        // Lấy ví của user
        public WalletDTO GetWallet(int userId)
        {
            var wallet = walletDAL.GetByUserId(userId);
            if (wallet == null)
            {
                // Tự động tạo ví nếu chưa có
                walletDAL.CreateWallet(userId);
                wallet = walletDAL.GetByUserId(userId);
            }
            return wallet;
        }

        // Lấy số dư
        public decimal GetBalance(int userId)
        {
            var wallet = GetWallet(userId);
            return wallet?.Balance ?? 0;
        }

        // Nạp tiền
        public bool Deposit(int userId, decimal amount, string description = null)
        {
            if (amount <= 0)
                throw new Exception("Số tiền phải lớn hơn 0!");

            return walletDAL.Deposit(userId, amount, description ?? "Nạp tiền vào ví");
        }

        // Thanh toán
        public bool Payment(int userId, decimal amount, string description, int? referenceId = null)
        {
            if (amount <= 0)
                throw new Exception("Số tiền phải lớn hơn 0!");

            var wallet = GetWallet(userId);
            if (wallet.Balance < amount)
                throw new Exception($"Số dư không đủ! Hiện có: {wallet.Balance:N0}đ, Cần: {amount:N0}đ");

            return walletDAL.Payment(userId, amount, description, referenceId);
        }

        // Kiểm tra đủ tiền không
        public bool HasEnoughBalance(int userId, decimal amount)
        {
            var wallet = GetWallet(userId);
            return wallet != null && wallet.Balance >= amount;
        }

        // Lấy lịch sử giao dịch
        public List<WalletTransactionDTO> GetTransactionHistory(int userId, int top = 50)
        {
            var wallet = GetWallet(userId);
            if (wallet == null)
                return new List<WalletTransactionDTO>();

            return walletDAL.GetTransactionHistory(wallet.WalletID, top);
        }
    }
}
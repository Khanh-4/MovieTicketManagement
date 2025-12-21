using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class RoomBLL
    {
        private RoomDAL roomDAL = new RoomDAL();

        public List<RoomDTO> GetAll()
        {
            return roomDAL.GetAll();
        }

        public RoomDTO GetById(int roomId)
        {
            return roomDAL.GetById(roomId);
        }

        public int Insert(RoomDTO room)
        {
            // Kiểm tra tên phòng đã tồn tại chưa
            if (roomDAL.IsRoomNameExists(room.RoomName))
            {
                throw new Exception("Tên phòng đã tồn tại!");
            }
            return roomDAL.Insert(room);
        }

        public bool Update(RoomDTO room)
        {
            // Kiểm tra tên phòng đã tồn tại chưa (trừ phòng hiện tại)
            if (roomDAL.IsRoomNameExists(room.RoomName, room.RoomID))
            {
                throw new Exception("Tên phòng đã tồn tại!");
            }
            return roomDAL.Update(room);
        }

        public bool Delete(int roomId)
        {
            // Kiểm tra phòng có lịch chiếu không
            if (roomDAL.HasShowtimes(roomId))
            {
                throw new Exception("Không thể xóa phòng đã có lịch chiếu!");
            }
            return roomDAL.Delete(roomId);
        }

        public bool HasShowtimes(int roomId)
        {
            return roomDAL.HasShowtimes(roomId);
        }

        public bool GenerateSeats(int roomId, int rows, int seatsPerRow, int vipRowStart = 0)
        {
            return roomDAL.GenerateSeats(roomId, rows, seatsPerRow, vipRowStart);
        }

        public (int Rows, int SeatsPerRow, int VipRowStart) GetRoomSeatInfo(int roomId)
        {
            return roomDAL.GetRoomSeatInfo(roomId);
        }
    }
}
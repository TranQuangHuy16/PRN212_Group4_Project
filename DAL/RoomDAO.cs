using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomDAO : IRoomRepository
    {
        public List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                using var db = new MyDbContext();
                rooms = db.Rooms.Where(s => s.Status == 0).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return rooms;
        }

        public void CreateRoom(Room room)
        {
            try
            {
                isValidationRoom(room);
                using var db = new MyDbContext();
                if(db.Rooms.Any(r => r.RoomName == room.RoomName && r.Status == 0))
                {
                    throw new ArgumentException("Duplicate Room Name");
                }
                db.Rooms.Add(room);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateRoom(Room room)
        {
            try
            {
                isValidationRoom(room);
                using var db = new MyDbContext();
                if (db.Rooms.Any(r => r.RoomName == room.RoomName && r.Status == 0))
                {
                    throw new ArgumentException("Duplicate Room Name");
                }
                db.Entry<Room>(room).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRoom(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Room b = db.Rooms.SingleOrDefault(s => s.RoomId == id);
                if (b != null)
                {
                    b.Status = (byte)1;
                }
                else
                {
                    throw new Exception("Room not found");
                }
                db.Entry<Room>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Room GetRoomById(int id)
        {
            Room room = new Room();
            try
            {
                using var db = new MyDbContext();
                room = db.Rooms.Where(s => s.Status == 0).SingleOrDefault(s => s.RoomId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return room;
        }

        private void isValidationRoom(Room room)
        {
            if (string.IsNullOrWhiteSpace(room.RoomName)){
                throw new ArgumentException("Room Name is required");
            }
        }
    }
}

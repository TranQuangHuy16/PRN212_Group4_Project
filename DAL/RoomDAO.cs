﻿using BOs;
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
                rooms = db.Rooms.Where(s => s.Status == 1).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rooms;
        }

        public void CreateRoom(Room room)
        {
            try
            {
                using var db = new MyDbContext();
                db.Rooms.Add(room);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateRoom(Room room)
        {
            try
            {
                using var db = new MyDbContext();
                db.Entry<Room>(room).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    b.Status = (byte)0;
                }
                else
                {
                    throw new Exception("Room not found");
                }
                db.Entry<Room>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Room GetRoomById(int id)
        {
            Room room = new Room();
            try
            {
                using var db = new MyDbContext();
                room = db.Rooms.SingleOrDefault(s => s.RoomId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return room;
        }
    }
}

﻿using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        void CreateRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
        Room GetRoomById(int id);
    }
}

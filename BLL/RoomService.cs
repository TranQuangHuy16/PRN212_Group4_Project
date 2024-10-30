using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomService : IRoomService
    {

        IRoomRepository repo;
        public RoomService() {
            repo = new RoomDAO();
        }
        public void CreateRoom(Room room)
        {
            repo.CreateRoom(room);
        }

        public void DeleteRoom(int id)
        {
            repo.DeleteRoom(id);
        }

        public Room GetRoomById(int id)
        {
            return repo.GetRoomById(id);
        }

        public List<Room> GetRooms()
        {
            return repo.GetRooms();
        }

        public void UpdateRoom(Room room)
        {
            repo.UpdateRoom(room);
        }
    }
}

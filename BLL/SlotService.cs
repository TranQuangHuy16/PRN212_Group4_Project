using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SlotService : ISlotService
    {
        ISlotRepository repo;

        public SlotService()
        {
            repo = new SlotDAO();
        }

        public void CreateSlot(Slot slot)
        {
            repo.CreateSlot(slot);
        }

        public void DeleteSlot(int id)
        {
            repo.DeleteSlot(id);
        }

        public Slot GetSlotById(int id)
        {
            return repo.GetSlotById(id);
        }

        public List<Slot> GetSlots()
        {
            return repo.GetSlots();
        }

        public void UpdateSlot(Slot slot)
        {
            repo.UpdateSlot(slot);
        }
    }
}

using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISlotRepository
    {
        List<Slot> GetSlots();
        void CreateSlot(Slot slot);
        void UpdateSlot(Slot slot);
        void DeleteSlot(int id);
        Slot GetSlotById(int id);
    }
}

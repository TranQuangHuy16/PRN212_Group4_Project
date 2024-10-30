using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISlotService
    {
        List<Slot> GetSlots();
        void CreateSlot(Slot slot);
        void UpdateSlot(Slot slot);
        void DeleteSlot(int id);
        Slot GetSlotById(int id);
    }
}

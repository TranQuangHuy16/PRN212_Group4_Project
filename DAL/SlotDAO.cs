using BOs;

namespace DAL
{
    public class SlotDAO : ISlotRepository
    {

        public List<Slot> GetSlots()
        {
            List<Slot> slots = new List<Slot>();
            try
            {
                using var db = new MyDbContext();
                slots = db.Slots.Where(s => s.Status == 0).ToList();
                   
            }
            catch (Exception)
            {
                throw;
            }
            return slots;
        }

        public void CreateSlot (Slot slot)
        {
            try
            {
                ValidateSlot(slot);
                using var db = new MyDbContext();
                if (db.Slots.Any(s => s.SlotName == slot.SlotName && s.Status == 0))
                {
                    throw new ArgumentException("Duplicate Slot Name");
                }
                db.Slots.Add(slot);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSlot(Slot slot)
        {
            try
            {
                ValidateSlot(slot);
                using var db = new MyDbContext();
                if (db.Slots.Any(s => s.SlotName == slot.SlotName && s.Status == 0))
                {
                    throw new ArgumentException("Duplicate Slot Name");
                }
                db.Entry<Slot>(slot).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSlot(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Slot b = db.Slots.SingleOrDefault(s => s.SlotId == id);
                if (b != null)
                {
                    b.Status = (byte)1;
                }
                else
                {
                    throw new Exception("Slot not found");
                }
                db.Entry<Slot>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Slot GetSlotById(int id)
        {
            Slot slot = new Slot();
            try
            {
                using var db = new MyDbContext();
                slot = db.Slots.Where(s => s.Status == 0).SingleOrDefault(s => s.SlotId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return slot;
        }

        private void ValidateSlot(Slot slot)
        {
            if(slot.SlotName == null)
            {
                throw new ArgumentException("Slot Name is required");
            }

            if (slot.EndTime <= slot.StartTime)
            {
                throw new ArgumentException("The end time must be after the start time.");
            }
        }
    }
}

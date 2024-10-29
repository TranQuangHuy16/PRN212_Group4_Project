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
                slots = db.Slots.Where(s => s.Status == 1).ToList();
                   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return slots;
        }

        public void CreateSlot (Slot slot)
        {
            try
            {
                using var db = new MyDbContext();
                db.Slots.Add(slot);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSlot(Slot slot)
        {
            try
            {
                using var db = new MyDbContext();
                db.Entry<Slot>(slot).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteSlot(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Slot b = db.Slots.SingleOrDefault(s => s.SlotId == id);
                b.Status = (byte)0;
                db.Entry<Slot>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Slot GetSlotById(int id)
        {
            Slot slot = new Slot();
            try
            {
                using var db = new MyDbContext();
                slot = db.Slots.SingleOrDefault(s => s.SlotId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return slot;
        }
    }
}

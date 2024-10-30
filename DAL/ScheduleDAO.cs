using BOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ScheduleDAO : IScheduleRepository
    {

        public void CreateScheduled(Schedule schedule)
        {
            try
            {
                using var db = new MyDbContext();
                db.Schedules.Add(schedule);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateScheduled(Schedule schedule)
        {
            try
            {
                using var db = new MyDbContext();
                db.Entry<Schedule>(schedule).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void RegisterSchedule(int accountId, int scheduleId)
        {
            try
            {
                using var db = new MyDbContext();
                Schedule schedule = db.Schedules.SingleOrDefault(s => s.ScheduleId == scheduleId);
                if (schedule == null)
                {
                    throw new Exception("Not found Schedule");
                }
                schedule.AccountId = accountId;
                UpdateScheduled(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteScheduled(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Schedule schedule = db.Schedules.SingleOrDefault(s => s.ScheduleId == id);
                schedule.Status = (byte)0;
                UpdateScheduled(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Schedule> GetSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();
            try
            {
                using var db = new MyDbContext();
                schedules = db.Schedules
                    .Include(s => s.Room)
                    .Include(s => s.Account)
                    .Include(s => s.Slot)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return schedules;
        }

        public Schedule GetScheduleByScheduleId(int id)
        {
            Schedule schedule = new Schedule();
            try
            {
                using var db = new MyDbContext();
                schedule = db.Schedules
                    .Include(s => s.Room)
                    .Include(s => s.Account)
                    .Include(s => s.Slot)
                    .SingleOrDefault(s => s.ScheduleId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return schedule;
            
        }

        public List<Schedule> GetSchedulesByAccountId(int id)
        {
            List<Schedule> schedules = new List<Schedule> ();
            try
            {
                using var db = new MyDbContext();
                schedules = db.Schedules
                    .Where(s => s.AccountId == id && s.Status == 1)
                    .Include(s => s.Room)
                    .Include(s => s.Account)
                    .Include(s => s.Slot)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return schedules;
        }

    }
}

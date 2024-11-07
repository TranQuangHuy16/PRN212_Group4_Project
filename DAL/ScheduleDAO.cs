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
                isValidationSchedule(schedule);
                using var db = new MyDbContext();
                if (db.Schedules.Any(s => s.SemesterId == schedule.SemesterId &&
                                  s.RoomId == schedule.RoomId &&
                                  s.SlotId == schedule.SlotId &&
                                  s.ScheduleDate == schedule.ScheduleDate &&
                                  s.Status == 0))
                {
                    throw new ArgumentException("A schedule already exists for this room and this slot on the selected date.");
                }
                db.Schedules.Add(schedule);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateScheduled(Schedule schedule)
        {
            try
            {
                isValidationSchedule(schedule);
                using var db = new MyDbContext();
                if (db.Schedules.Any(s => s.SemesterId == schedule.SemesterId &&
                                  s.RoomId == schedule.RoomId &&
                                  s.SlotId == schedule.SlotId &&
                                  s.ScheduleDate == schedule.ScheduleDate &&
                                  s.Status == 0))
                {
                    throw new ArgumentException("A schedule already exists for this room and this slot on the selected date.");
                }
                db.Entry<Schedule>(schedule).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
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
                db.Entry<Schedule>(schedule).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteScheduled(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Schedule schedule = db.Schedules.SingleOrDefault(s => s.ScheduleId == id);
                schedule.Status = (byte)1;
                UpdateScheduled(schedule);
            }
            catch (Exception)
            {
                throw;
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
                    .Include(s => s.CourseSemester)
                    .ThenInclude(cs => cs.Course)
                    .Include(s => s.CourseSemester)
                    .ThenInclude(cs => cs.Semester)
                    .Where(s => s.Status == 0)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
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
                    .Where(s => s.Status == 0)
                    .Include(s => s.Room)
                    .Include(s => s.Account)
                    .Include(s => s.Slot)
                    .Include(s => s.CourseSemester)
                    .ThenInclude(cs => cs.Course)
                    .Include(s => s.CourseSemester)
                    .ThenInclude(cs => cs.Semester)
                    .SingleOrDefault(s => s.ScheduleId == id);

            }
            catch (Exception)
            {
                throw;
            }
            return schedule;
            
        }

        public List<Schedule> GetSchedulesByAccountId(int id)
        {
            List<Schedule> schedules = new List<Schedule>();
            try
            {
                using var db = new MyDbContext();
                schedules = db.Schedules
                    .Include(s => s.Room)
                    .Include(s => s.Account)
                    .Include(s => s.Slot)
                    .Include(s => s.CourseSemester)
                    .ThenInclude(cs => cs.Course)
                    .Include(s => s.CourseSemester)
                    .ThenInclude(cs => cs.Semester)
                    .Where(s => s.Status == 0 && s.AccountId == id)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return schedules;
        }

        private void isValidationSchedule(Schedule schedule)
        {
            if (schedule.CourseId == null){
                throw new ArgumentException("Course is required");
            }
            
            if (schedule.SemesterId == null){
                throw new ArgumentException("Semester is required");
            }
            
            if (schedule.RoomId == null){
                throw new ArgumentException("Room is required");
            }
            
            if (schedule.SlotId == null){
                throw new ArgumentException("Slot is required");
            }

            if (schedule.ScheduleDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("The Schedule date cannot be a date in the past.");
            }
        }

    }
}

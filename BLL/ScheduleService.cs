using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ScheduleService : IScheduleService
    {
        IScheduleRepository repo;

        public ScheduleService()
        {
            repo = new ScheduleDAO();
        }
        public void CreateScheduled(Schedule schedule)
        {
            repo.CreateScheduled(schedule);
        }

        public void UpdateScheduled(Schedule schedule)
        {
            repo.UpdateScheduled(schedule);
        }

        public void DeleteScheduled(int id)
        {
            repo.DeleteScheduled(id);
        }

        public List<Schedule> GetSchedules()
        {
            return repo.GetSchedules();
        }

        public Schedule GetScheduleByScheduleId(int id)
        {
            return repo.GetScheduleByScheduleId(id);
        }

        public List<Schedule> GetSchedulesByAccountId(int id)
        {
            return repo.GetSchedulesByAccountId(id);
        }

        public void RegisterSchedule(int accountId, int scheduleId)
        {
            repo.RegisterSchedule(accountId, scheduleId);
        }
    }
}

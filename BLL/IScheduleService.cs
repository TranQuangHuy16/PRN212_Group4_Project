using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IScheduleService
    {
        void CreateScheduled(Schedule schedule);
        void UpdateScheduled(Schedule schedule);
        void DeleteScheduled(int id);
        List<Schedule> GetSchedules();
        Schedule GetScheduleByScheduleId(int id);
        List<Schedule> GetSchedulesByAccountId(int id);
        void RegisterSchedule(int accountId, int scheduleId);
    }
}

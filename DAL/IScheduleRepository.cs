﻿using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IScheduleRepository
    {
        void CreateScheduled(Schedule schedule);
        void UpdateScheduled(Schedule schedule);
        void DeleteScheduled(int id);
        List<Schedule> GetSchedules();
        Schedule GetScheduleByScheduleId(int id);
        List<Schedule> GetSchedulesByAccountId(int id);
    }
}
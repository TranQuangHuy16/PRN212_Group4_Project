using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICourseSemesterRepository
    {
        List<CourseSemester> GetCourseSemesters();
        void CreateCourseSemester(CourseSemester courseSemester);
        void UpdateCourseSemester(CourseSemester courseSemester);
        void DeleteCourseSemester(int courseId, int semesterId);
    }
}

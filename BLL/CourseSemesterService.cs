using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseSemesterService : ICourseSemesterService
    {
        ICourseSemesterRepository repo;

        public CourseSemesterService()
        {
            repo = new CourseSemesterDAO();
        }

        public void CreateCourseSemester(CourseSemester courseSemester)
        {
            repo.CreateCourseSemester(courseSemester);
        }

        public void DeleteCourseSemester(int courseId, int semesterId)
        {
            repo.DeleteCourseSemester(courseId, semesterId);
        }

        public List<CourseSemester> GetCourseSemesters()
        {
            return repo.GetCourseSemesters();
        }

        public void UpdateCourseSemester(CourseSemester courseSemester)
        {
            repo.UpdateCourseSemester(courseSemester);
        }
    }
}

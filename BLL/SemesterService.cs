using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SemesterService : ISemesterService
    {
        ISemesterRepository repo;
        public SemesterService()
        {
            repo = new SemesterDAO();
        }
        public void CreateSemester(Semester semester)
        {
            repo.CreateSemester(semester);
        }

        public void DeleteSemester(int id)
        {
            repo.DeleteSemester(id);
        }

        public List<Semester> GetSemesterByCourseId(int courseId)
        {
            return repo.GetSemesterByCourseId(courseId);
        }

        public Semester GetSemesterById(int id)
        {
            return repo.GetSemesterById(id);
        }

        public List<Semester> GetSemesters()
        {
            return repo.GetSemesters();
        }

        public void UpdateSemester(Semester semester)
        {
            repo.UpdateSemester(semester);
        }
    }
}

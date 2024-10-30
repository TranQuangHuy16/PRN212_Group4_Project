using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISemesterRepository
    {
        List<Semester> GetSemesters();
        void CreateSemester(Semester semester);
        void UpdateSemester(Semester semester);
        void DeleteSemester(int id);
        Semester GetSemesterById(int id);
        List<Semester> GetSemesterByCourseId(int courseId);
    }
}

using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        Course GetCourseById(int id);
    }
}

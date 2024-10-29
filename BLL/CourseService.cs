using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseService : ICourseService
    {
        ICourseRepository repo;
        public CourseService() {
            repo = new CourseDAO();
        }
        public void CreateCourse(Course course)
        {
            repo.CreateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            repo.DeleteCourse(id);
        }

        public Course GetCourseById(int id)
        {
            return repo.GetCourseById(id);
        }

        public List<Course> GetCourses()
        {
            return repo.GetCourses();
        }

        public void UpdateCourse(Course course)
        {
            repo.UpdateCourse(course);
        }
    }
}

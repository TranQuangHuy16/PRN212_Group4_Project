using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseDAO : ICourseRepository
    {
        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using var db = new MyDbContext();
                courses = db.Courses.Where(s => s.Status == 1).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courses;
        }

        public void CreateCourse(Course course)
        {
            try
            {
                using var db = new MyDbContext();
                db.Courses.Add(course);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                using var db = new MyDbContext();
                db.Entry<Course>(course).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCourse(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Course b = db.Courses.SingleOrDefault(s => s.CourseId == id);
                if (b != null)
                {
                    b.Status = (byte)0;
                } else
                {
                    throw new Exception("Course not found");
                }
                
                db.Entry<Course>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Course GetCourseById(int id)
        {
            Course course = new Course();
            try
            {
                using var db = new MyDbContext();
                course = db.Courses.SingleOrDefault(s => s.CourseId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return course;
        }


    }
}

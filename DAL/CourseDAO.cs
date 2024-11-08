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
                courses = db.Courses.Where(s => s.Status == 0).ToList();

            }
            catch (Exception)
            {
                throw ;
            }
            return courses;
        }

        public void CreateCourse(Course course)
        {
            try
            {
                isValidationCourse(course);
                using var db = new MyDbContext();
                if(db.Courses.Any(c => c.CourseName == course.CourseName && c.Status == 0))
                {
                    throw new ArgumentException("Duplitcate Course Name");
                }
                db.Courses.Add(course);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                isValidationCourse(course);
                using var db = new MyDbContext();
                if (db.Courses.Any(c => c.CourseId != course.CourseId && c.CourseName == course.CourseName && c.Status == 0))
                {
                    throw new ArgumentException("Duplitcate Course Name");
                }
                db.Entry<Course>(course).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw ;
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
                    b.Status = (byte)1;
                } else
                {
                    throw new Exception("Course not found");
                }
                
                db.Entry<Course>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public Course GetCourseById(int id)
        {
            Course course = new Course();
            try
            {
                using var db = new MyDbContext();
                course = db.Courses.Where(s => s.Status == 0).SingleOrDefault(s => s.CourseId == id);
            }
            catch (Exception)
            {
                throw ;
            }
            return course;
        }

        private void isValidationCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName)){
                throw new ArgumentException("Course Name is required");
            }
        }


    }
}

using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseSemesterDAO : ICourseSemesterRepository
    {
        public List<CourseSemester> GetCourseSemesters()
        {
            List<CourseSemester> courseSemesters = new List<CourseSemester>();
            try
            {

                using var db = new MyDbContext();
                courseSemesters = db.CourseSemesters.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return courseSemesters;
        }

        public void CreateCourseSemester(CourseSemester courseSemester)
        {
            try
            {
                isValidationCourseSemester(courseSemester);
                using var db = new MyDbContext();
                if(db.CourseSemesters.Any(cs => cs.SemesterId ==  courseSemester.SemesterId && cs.CourseId == courseSemester.CourseId))
                {
                    throw new ArgumentException("Course have been registered for this semester");
                }
                db.CourseSemesters.Add(courseSemester);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCourseSemester(CourseSemester courseSemester)
        {
            try
            {
                isValidationCourseSemester(courseSemester);
                using var db = new MyDbContext();
                if (db.CourseSemesters.Any(cs => cs.SemesterId == courseSemester.SemesterId && cs.CourseId == courseSemester.CourseId))
                {
                    throw new ArgumentException("Course have been registered for this semester");
                }
                db.Entry<CourseSemester>(courseSemester).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCourseSemester(int courseId, int semesterId)
        {
            try
            {
                using var db = new MyDbContext();

                var courseSemester = db.CourseSemesters
                    .SingleOrDefault(cs => cs.CourseId == courseId && cs.SemesterId == semesterId);

                if (courseSemester != null)
                {
                    
                    db.CourseSemesters.Remove(courseSemester);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("CourseSemester Not Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void isValidationCourseSemester(CourseSemester courseSemester)
        {
            if (courseSemester.CourseId == null){
                throw new ArgumentException("Course is required");
            }

            if (courseSemester.SemesterId == null)
            {
                throw new ArgumentException("Semester is required");
            }
        }

    }
}

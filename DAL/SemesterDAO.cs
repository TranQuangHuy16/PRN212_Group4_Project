using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SemesterDAO : ISemesterRepository
    {
        public List<Semester> GetSemesters() 
        {
            List<Semester> semesters = new List<Semester>();
            try
            {
                using var db = new MyDbContext();
                semesters = db.Semesters.Where(s => s.Status == 0).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return semesters;
        }

        public void CreateSemester(Semester semester)
        {
            try
            {
                ValidateSemester(semester);
                using var db = new MyDbContext();
                if(db.Semesters.Any(s => s.SemesterName == semester.SemesterName && s.Status == 0))
                {
                    throw new ArgumentException("Duplicate Semeter Name");
                }
                db.Semesters.Add(semester);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSemester(Semester semester)
        {
            try
            {
                ValidateSemester(semester);
                using var db = new MyDbContext();
                if (db.Semesters.Any(s => s.SemesterId != semester.SemesterId && s.SemesterName == semester.SemesterName && s.Status == 0))
                {
                    throw new ArgumentException("Duplicate Semeter Name");
                }
                db.Entry<Semester>(semester).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSemester(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Semester b = db.Semesters.SingleOrDefault(s => s.SemesterId == id);
                if (b != null)
                {
                    b.Status = (byte)1;
                }
                else
                {
                    throw new Exception("Semester not found");
                }
                db.Entry<Semester>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Semester GetSemesterById(int id)
        {
            Semester semester = new Semester();
            try
            {
                using var db = new MyDbContext();
                semester = db.Semesters.Where(s => s.Status == 0).SingleOrDefault(s => s.SemesterId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return semester;
        }

        public List<Semester> GetSemesterByCourseId(int courseId)
        {
            List<Semester> semesters = new List<Semester>();
            
            try
            {
                using var db = new MyDbContext();
                var semesterIds = db.CourseSemesters
                    .Where(cs => cs.CourseId == courseId)
                    .Select(cs => cs.SemesterId)
                    .ToList();
                semesters = db.Semesters
                  .Where(s => semesterIds.Contains(s.SemesterId) && s.Status == 0)
                  .ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return semesters;
        }

        private void ValidateSemester(Semester semester)
        {
            if (string.IsNullOrWhiteSpace(semester.SemesterName))
            {
                throw new ArgumentException("Semester Name is required");
            }

            if (semester.StartDate < DateTime.Now.Date)
            {
                throw new ArgumentException("Start date not selected in the past.");
            }

            if (semester.EndDate <= semester.StartDate)
            {
                throw new ArgumentException("The end date must be after the start date.");
            }
        }

    }
}

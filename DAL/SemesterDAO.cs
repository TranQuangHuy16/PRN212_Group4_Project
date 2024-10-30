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
                semesters = db.Semesters.Where(s => s.Status == 1).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return semesters;
        }

        public void CreateSemester(Semester semester)
        {
            try
            {
                using var db = new MyDbContext();
                db.Semesters.Add(semester);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSemester(Semester semester)
        {
            try
            {
                using var db = new MyDbContext();
                db.Entry<Semester>(semester).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteSemester(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Semester b = db.Semesters.SingleOrDefault(s => s.SemesterId == id);
                b.Status = (byte)0;
                db.Entry<Semester>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Semester GetSemesterById(int id)
        {
            Semester semester = new Semester();
            try
            {
                using var db = new MyDbContext();
                semester = db.Semesters.SingleOrDefault(s => s.SemesterId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                  .Where(s => semesterIds.Contains(s.SemesterId))
                  .ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return semesters;
        }
    }
}

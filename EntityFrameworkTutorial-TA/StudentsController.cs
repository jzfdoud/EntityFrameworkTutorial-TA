using EntityFrameworkTutorial_TA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial_TA
{
    public class StudentsController
    {
        private readonly eddbContext _context;

        public Student Create(Student student)
        {
            if (student == null)
            {
                throw new Exception("Student cannot be null");
            }
            if (student.Id != 0)
            {
                throw new Exception("Student Id cannot equal zero");
            }
            _context.Students.Add(student);
            var rowsaffected = _context.SaveChanges();
            if (rowsaffected != 1)
            {
                throw new Exception("Create failed");
            }
            return student;
        }

        public void Change(Student student)
        {
            if (student == null)
            {
                throw new Exception("Student cannot be null");
            }
            if (student.Id <= 0)
            {
                throw new Exception("Student Id cannot equal zero");
            }
            //_context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsaffected = _context.SaveChanges();
            if (rowsaffected != 1)
            {
                throw new Exception("Change failed");
            }
            return;
        }

        public Student Remove(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return null;
            }
            _context.Students.Remove(student);
            var rowsaffected = _context.SaveChanges();
            if (rowsaffected != 1)
            {
                throw new Exception("Remove failed");
            }
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetByPk(int id)
        {
            return _context.Students.Find(id);
            //EF call 'find' only works with call primary key?
        }

        #region Read all students with SAT 1000-1200(inclusive), sort descending

        public IEnumerable<Student> GetBySATRange(int lowSAT, int highSAT)
        {
            return _context.Students.Where(s => s.Sat >= lowSAT && s.Sat <= highSAT).OrderByDescending(s => s.Sat).ToList();

            return (from s in _context.Students
                    where s.Sat >= lowSAT && s.Sat <= highSAT
                    orderby s.Sat descending
                    select s).ToList();
        }

        #endregion



        public StudentsController()
        {
            _context = new eddbContext();
        }

        //only place you can set the value of readonly is in constructor
    }
}

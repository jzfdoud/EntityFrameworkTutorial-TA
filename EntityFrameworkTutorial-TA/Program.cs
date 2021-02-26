using EntityFrameworkTutorial_TA.Models;
using System;
using System.Linq;

namespace EntityFrameworkTutorial_TA
{
    class Program
    {
        static void Main(string[] args)
        {

            var sctrl = new StudentsController();


            var students = sctrl.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Firstname} {s.Lastname}");
            }

            //var sGreg = new Student
            //{
            //    Id = 0,
            //    Firstname = "Greg",
            //    Lastname = "Doud",
            //    StateCode = "OH",
            //    Sat = 800
            //};
            //var sGregNew = sctrl.Create(sGreg);

            //var std = sctrl.GetByPk(76);
            //std.Firstname = "Gregory";
            //sctrl.Change(std);
            //Console.WriteLine($"{std.Id} | {std.Firstname} {std.Lastname}");

            //var studentDeleted = sctrl.Remove(std.Id);
            //Console.WriteLine($"{studentDeleted}");


            //var st = sctrl.GetByPk(76);
            //Console.WriteLine($"{st.Firstname} {st.Lastname}");
        }
        static void Run1() { 
            #region Day #13 C# - Entity Framework

            var _context = new eddbContext();


            #region List all students from EdDb
            //var students = _context.Students.ToList();
            foreach (var s in _context.Students.ToList())
            {
                Console.WriteLine($"{s.Firstname} {s.Lastname}");
            }
            #endregion

            #region Only show Majors with minSAT > 1000
            var majors = from m in _context.Majors
                         where m.MinSat > 1000
                         orderby m.Description
                         select m;
            foreach (var m in majors)
            {
                Console.WriteLine($"{ m.Description} | { m.MinSat}");
            }
            #endregion

            #region Join Students and Majors, print name and major

            var allStudents = (from s in _context.Students
                               join m in _context.Majors
                               on s.MajorId equals m.Id into grp
                               from mm in grp.DefaultIfEmpty()
                               select new
                               {
                                   Name = s.Firstname + " " + s.Lastname,
                                   Major = mm == null ? "Undeclared" : mm.Description
                               }).ToList();
            allStudents.ForEach(s => Console.WriteLine($"{s.Name} | {s.Major}"));
            #endregion

            #region

            #endregion

            #endregion
        }
    }
}

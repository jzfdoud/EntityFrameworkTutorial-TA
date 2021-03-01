using EntityFrameworkTutorial_TA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTutorial_TA
{
    public class MajorsController
    {
        private readonly eddbContext _context;

        public Major Create(Major major)
        {
            if (major == null)
            {
                throw new Exception("Major cannot be null");
            }
            if (major.Id != 0)
            {
                throw new Exception("Major Id cannot equal zero");
            }
            _context.Majors.Add(major);
            var rowsaffected = _context.SaveChanges();
            if (rowsaffected != 1)
            {
                throw new Exception("Create failed");
            }
            return major;
        }

        public void Change(Major major)
        {
            if (major == null)
            {
                throw new Exception("Major cannot be null");
            }
            if (major.Id <= 0)
            {
                throw new Exception("Major Id cannot equal zero");
            }
            var rowsaffected = _context.SaveChanges();
            if (rowsaffected != 1)
            {
                throw new Exception("Change failed");
            }
            return;
        }

        public async Task<Major> Remove(int id)
        {
            var major = _context.Majors.Find(id);
            if (major == null)
            {
                return null;
            }
            int count = await _context.Students.CountAsync(s => s.MajorId == major.Id);
            if(count > 0 )
            {
                throw new Exception("cannot remove major, it is a PK to a student");
            }
            _context.Majors.Remove(major);
            var rowsaffected = await _context.SaveChangesAsync();
            if (rowsaffected != 1)
            {
                throw new Exception("Remove failed");
            }
            return major;
        }

        public IEnumerable<Major> GetAll()
        {
            return _context.Majors.ToList();
        }

        public Major GetByPk(int id)
        {
            return _context.Majors.Find(id);
        }


        public MajorsController()
        {
            _context = new eddbContext();
        }
    }


}

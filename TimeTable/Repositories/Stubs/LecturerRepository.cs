using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable.Repositories.Stubs
{
    public class LecturerRepository : ILecturerRepository
    {
        public void Add(Lecturer lecturer) => throw new NotImplementedException();
        public Lecturer GetById(int lecturerId) => throw new NotImplementedException();
        public IEnumerable<Lecturer> GetAll() => new List<Lecturer>();
        public void Update(Lecturer lecturer) => throw new NotImplementedException();
        public void Delete(int lecturerId) => throw new NotImplementedException();
    }
}

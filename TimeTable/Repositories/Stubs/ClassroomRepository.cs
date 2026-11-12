using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        public void Add(Classroom classroom) => throw new NotImplementedException();
        public Classroom GetByRoomNumber(string roomNumber) => throw new NotImplementedException();
        public IEnumerable<Classroom> GetAll() => new List<Classroom>();
        public void Update(Classroom classroom) => throw new NotImplementedException();
        public void Delete(string roomNumber) => throw new NotImplementedException();
    }
}

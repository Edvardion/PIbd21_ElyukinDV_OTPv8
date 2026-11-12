using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable.Repositories.Stubs
{
    public class SyllabusRepository : ISyllabusRepository
    {
        public void Add(Syllabus syllabus) => throw new NotImplementedException();
        public Syllabus GetById(int disciplineId) => throw new NotImplementedException();
        public IEnumerable<Syllabus> GetAll() => new List<Syllabus>();
        public void Update(Syllabus syllabus) => throw new NotImplementedException();
        public void Delete(int disciplineId) => throw new NotImplementedException();
    }
}

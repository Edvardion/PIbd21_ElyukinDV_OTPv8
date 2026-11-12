using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable.Repositories.Stubs
{
    public class SyllabusGroupRepository : ISyllabusGroupRepository
    {
        public void Add(SyllabusGroup syllabusGroup) => throw new NotImplementedException();
        public IEnumerable<SyllabusGroup> GetByGroup(string groupName) => new List<SyllabusGroup>();
        public IEnumerable<SyllabusGroup> GetByDiscipline(int disciplineId) => new List<SyllabusGroup>();
        public void Delete(int disciplineId, string groupName) => throw new NotImplementedException();
    }
}

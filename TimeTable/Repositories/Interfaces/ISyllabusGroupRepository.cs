using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{
    public interface ISyllabusGroupRepository
    {
        void Add(SyllabusGroup syllabusGroup);
        IEnumerable<SyllabusGroup> GetByGroup(string groupName);
        IEnumerable<SyllabusGroup> GetByDiscipline(int disciplineId);
        void Delete(int disciplineId, string groupName);
    }
}

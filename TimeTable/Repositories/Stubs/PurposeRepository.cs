using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable.Repositories.Stubs
{
    public class PurposeRepository : IPurposeRepository
    {
        public void Add(Purpose purpose) => throw new NotImplementedException();
        public IEnumerable<Purpose> GetByLecturer(int lecturerId) => new List<Purpose>();
        public IEnumerable<Purpose> GetByDiscipline(int disciplineId) => new List<Purpose>();
        public void Delete(int disciplineId, int lecturerId) => throw new NotImplementedException();
    }
}

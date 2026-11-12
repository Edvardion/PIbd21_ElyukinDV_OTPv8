using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{
    public interface IPurposeRepository
    {
        void Add(Purpose purpose);
        IEnumerable<Purpose> GetByLecturer(int lecturerId);
        IEnumerable<Purpose> GetByDiscipline(int disciplineId);
        void Delete(int disciplineId, int lecturerId);
    }
}

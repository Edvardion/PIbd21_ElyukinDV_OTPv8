using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{
    public interface ISyllabusRepository
    {
        void Add(Syllabus syllabus);
        Syllabus GetById(int disciplineId);
        IEnumerable<Syllabus> GetAll();
        void Update(Syllabus syllabus);
        void Delete(int disciplineId);
    }
}

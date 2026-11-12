using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{
    public interface ILecturerRepository
    {
        void Add(Lecturer lecturer);
        Lecturer GetById(int lecturerId);
        IEnumerable<Lecturer> GetAll();
        void Update(Lecturer lecturer);
        void Delete(int lecturerId);
    }
}

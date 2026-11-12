using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{

    public interface IClassroomRepository
    {
        void Add(Classroom classroom);
        Classroom GetByRoomNumber(string roomNumber);
        IEnumerable<Classroom> GetAll();
        void Update(Classroom classroom);
        void Delete(string roomNumber);
    }
}

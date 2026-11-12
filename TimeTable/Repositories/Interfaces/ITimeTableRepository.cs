using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{
    public interface ITimeTableRepository
    {
        void Add(TimeTableItem item);
        IEnumerable<TimeTableItem> GetByGroup(string groupName);
        IEnumerable<TimeTableItem> GetByLecturer(int lecturerId);
        void Delete(int scheduleId);
    }
}

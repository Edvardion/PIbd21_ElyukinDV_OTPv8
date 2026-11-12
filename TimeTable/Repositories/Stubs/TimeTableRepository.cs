using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable.Repositories.Stubs
{
    public class TimeTableRepository : ITimeTableRepository
    {
        public void Add(TimeTableItem item) => throw new NotImplementedException();
        public IEnumerable<TimeTableItem> GetByGroup(string groupName) => new List<TimeTableItem>();
        public IEnumerable<TimeTableItem> GetByLecturer(int lecturerId) => new List<TimeTableItem>();
        public void Delete(int scheduleId) => throw new NotImplementedException();
    }
}

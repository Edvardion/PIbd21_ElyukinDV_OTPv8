using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class Purpose
    {
        public int DisciplineId { get; private set; }
        public int LecturerId { get; private set; }

        private Purpose(int disciplineId, int lecturerId)
        {
            DisciplineId = disciplineId;
            LecturerId = lecturerId;
        }

        public static Purpose Create(int disciplineId, int lecturerId)
        {
            if (disciplineId <= 0)
                throw new ArgumentOutOfRangeException(nameof(disciplineId), "ID дисциплины должен быть больше нуля.");

            if (lecturerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(lecturerId), "ID преподавателя должен быть больше нуля.");

            return new Purpose(disciplineId, lecturerId);
        }
    }

}

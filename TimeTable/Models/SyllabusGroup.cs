using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class SyllabusGroup
    {
        public int DisciplineId { get; private set; }
        public string GroupName { get; private set; }

        private SyllabusGroup(int disciplineId, string groupName)
        {
            DisciplineId = disciplineId;
            GroupName = groupName;
        }

        public static SyllabusGroup Create(int disciplineId, string groupName)
        {
            if (disciplineId <= 0)
                throw new ArgumentOutOfRangeException(nameof(disciplineId), "ID дисциплины должен быть больше нуля.");

            if (string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException("Название группы не может быть пустым или null.", nameof(groupName));

            if (groupName.Trim().Length > 12)
                throw new ArgumentException("Название группы не должно превышать 12 символов.", nameof(groupName));

            return new SyllabusGroup(disciplineId, groupName.Trim());
        }
    }

}

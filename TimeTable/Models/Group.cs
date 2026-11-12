using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class Group
    {
        public string GroupName { get; private set; }
        public int GroupSize { get; private set; }

        private Group(string groupName, int groupSize)
        {
            GroupName = groupName;
            GroupSize = groupSize;
        }

        public static Group Create(string groupName, int groupSize)
        {
            if (string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException("Название группы не может быть пустым или null.", nameof(groupName));

            if (groupName.Trim().Length > 12)
                throw new ArgumentException("Название группы не должно превышать 12 символов.", nameof(groupName));

            if (groupSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(groupSize), "Численность группы должна быть больше нуля.");

            return new Group(groupName.Trim(), groupSize);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class Lecturer
    {
        public int LecturerId { get; private set; }
        public string Name { get; private set; }
        public string Position { get; private set; }

        private Lecturer(int lecturerId, string name, string position)
        {
            LecturerId = lecturerId;
            Name = name;
            Position = position;
        }

        public static Lecturer Create(int lecturerId, string name, string position)
        {
            if (lecturerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(lecturerId), "ID преподавателя должен быть больше нуля.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("ФИО преподавателя не может быть пустым или null.", nameof(name));

            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException("Должность преподавателя не может быть пустой или null.", nameof(position));

            return new Lecturer(lecturerId, name.Trim(), position.Trim());
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class Classroom
    {
        public string RoomNumber { get; private set; }
        public int ClassCapacity { get; private set; }
        public RoomType Specification { get; private set; }

        private Classroom(string roomNumber, int classCapacity, RoomType specification)
        {
            RoomNumber = roomNumber;
            ClassCapacity = classCapacity;
            Specification = specification;
        }

        public static Classroom Create(string roomNumber, int classCapacity, RoomType specification)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
                throw new ArgumentException("Номер аудитории не может быть пустым или null.", nameof(roomNumber));

            if (classCapacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(classCapacity), "Вместимость аудитории должна быть больше нуля.");

            if (!Enum.IsDefined(typeof(RoomType), specification))
                throw new ArgumentOutOfRangeException(nameof(specification), "Указан некорректный тип аудитории.");

            return new Classroom(roomNumber.Trim(), classCapacity, specification);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class Syllabus
    {
        public int DisciplineId { get; private set; }
        public string DisciplineName { get; private set; }
        public int LectureNumber { get; private set; }
        public int LabNumber { get; private set; }
        public int Course { get; private set; }

        private Syllabus(int disciplineId, string disciplineName, int lectureNumber, int labNumber, int course)
        {
            DisciplineId = disciplineId;
            DisciplineName = disciplineName;
            LectureNumber = lectureNumber;
            LabNumber = labNumber;
            Course = course;
        }

        public static Syllabus Create(int disciplineId, string disciplineName, int lectureNumber, int labNumber, int course)
        {
            if (disciplineId <= 0)
                throw new ArgumentOutOfRangeException(nameof(disciplineId), "ID дисциплины должен быть больше нуля.");

            if (string.IsNullOrWhiteSpace(disciplineName))
                throw new ArgumentException("Название дисциплины не может быть пустым или null.", nameof(disciplineName));

            if (lectureNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(lectureNumber), "Количество лекций не может быть отрицательным.");

            if (labNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(labNumber), "Количество лабораторных работ не может быть отрицательным.");

            if (course <= 0 || course > 6)
                throw new ArgumentOutOfRangeException(nameof(course), "Курс должен быть в диапазоне от 1 до 6.");

            return new Syllabus(disciplineId, disciplineName.Trim(), lectureNumber, labNumber, course);
        }
    }

}

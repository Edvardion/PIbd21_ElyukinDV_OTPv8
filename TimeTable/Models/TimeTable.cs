using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class TimeTableItem
    {
        public int ScheduleId { get; private set; }
        public StudyDayOfWeek DayOfWeek { get; private set; }
        public int LessonNumber { get; private set; }
        public WeekType WeekType { get; private set; }
        public LessonType LessonType { get; private set; }
        public string GroupName { get; private set; }
        public string RoomNumber { get; private set; }
        public int DisciplineId { get; private set; }
        public int LecturerId { get; private set; }

        private TimeTableItem(
            int scheduleId,
            StudyDayOfWeek dayOfWeek,
            int lessonNumber,
            WeekType weekType,
            LessonType lessonType,
            string groupName,
            string roomNumber,
            int disciplineId,
            int lecturerId)
        {
            ScheduleId = scheduleId;
            DayOfWeek = dayOfWeek;
            LessonNumber = lessonNumber;
            WeekType = weekType;
            LessonType = lessonType;
            GroupName = groupName;
            RoomNumber = roomNumber;
            DisciplineId = disciplineId;
            LecturerId = lecturerId;
        }

        public static TimeTableItem Create(
            int scheduleId,
            StudyDayOfWeek dayOfWeek,
            int lessonNumber,
            WeekType weekType,
            LessonType lessonType,
            string groupName,
            string roomNumber,
            int disciplineId,
            int lecturerId)
        {
            if (scheduleId <= 0)
                throw new ArgumentOutOfRangeException(nameof(scheduleId), "ID записи расписания должен быть больше нуля.");

            if (!Enum.IsDefined(typeof(StudyDayOfWeek), dayOfWeek))
                throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Указан некорректный день недели.");

            if (lessonNumber <= 0 || lessonNumber > 8)
                throw new ArgumentOutOfRangeException(nameof(lessonNumber), "Номер пары должен быть от 1 до 8.");

            if (!Enum.IsDefined(typeof(WeekType), weekType))
                throw new ArgumentOutOfRangeException(nameof(weekType), "Указана некорректная четность недели.");

            if (!Enum.IsDefined(typeof(LessonType), lessonType))
                throw new ArgumentOutOfRangeException(nameof(lessonType), "Указан некорректный тип занятия.");

            if (string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException("Название группы не может быть пустым или null.", nameof(groupName));

            if (string.IsNullOrWhiteSpace(roomNumber))
                throw new ArgumentException("Номер аудитории не может быть пустым или null.", nameof(roomNumber));

            if (disciplineId <= 0)
                throw new ArgumentOutOfRangeException(nameof(disciplineId), "ID дисциплины должен быть больше нуля.");

            if (lecturerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(lecturerId), "ID преподавателя должен быть больше нуля.");

            return new TimeTableItem(
                scheduleId,
                dayOfWeek,
                lessonNumber,
                weekType,
                lessonType,
                groupName.Trim(),
                roomNumber.Trim(),
                disciplineId,
                lecturerId);
        }
    }

}

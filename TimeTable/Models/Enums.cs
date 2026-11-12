using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TimeTable.Models
{
    public enum RoomType
    {
        [Description("Лекционная аудитория")]
        LectureHall,

        [Description("Компьютерный класс")]
        ComputerLab
    }

    public enum LessonType
    {
        [Description("Лекция")]
        Lecture,

        [Description("Лабораторная работа")]
        Lab
    }

    [Flags]
    public enum WeekType
    {
        None = 0,
        Even = 1,            
        Odd = 2,             
        Both = Even | Odd     
    }

    public enum StudyDayOfWeek
    {
        [Description("Понедельник")]
        Monday = 1,

        [Description("Вторник")]
        Tuesday = 2,

        [Description("Среда")]
        Wednesday = 3,

        [Description("Четверг")]
        Thursday = 4,

        [Description("Пятница")]
        Friday = 5,

        [Description("Суббота")]
        Saturday = 6
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using TimeTable.Repositories;
using TimeTable.Repositories.Interfaces;
using TimeTable.Repositories.Stubs;

namespace TimeTable
{

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ClassroomRepository>().As<IClassroomRepository>();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<LecturerRepository>().As<ILecturerRepository>();
            builder.RegisterType<SyllabusRepository>().As<ISyllabusRepository>();
            builder.RegisterType<TimeTableRepository>().As<ITimeTableRepository>();
            builder.RegisterType<PurposeRepository>().As<IPurposeRepository>();
            builder.RegisterType<SyllabusGroupRepository>().As<ISyllabusGroupRepository>();

            builder.RegisterType<MainForm>();
            builder.RegisterType<ClassroomListForm>();
            builder.RegisterType<ClassroomEditForm>();
            builder.RegisterType<GroupListForm>();
            builder.RegisterType<GroupEditForm>();
            builder.RegisterType<LecturerListForm>();
            builder.RegisterType<LecturerEditForm>();
            builder.RegisterType<SyllabusListForm>();
            builder.RegisterType<SyllabusEditForm>();
            builder.RegisterType<TimeTableListForm>();
            builder.RegisterType<TimeTableAddForm>();

            builder.RegisterType<MainForm>();

            return builder.Build();
        }
    }
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainForm = scope.Resolve<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}

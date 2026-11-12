using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

public partial class MainForm : Form
{
    private readonly Func<ClassroomListForm> _classroomListFactory;
    private readonly Func<GroupListForm> _groupListFactory;
    private readonly Func<LecturerListForm> _lecturerListFactory;
    private readonly Func<TimeTableListForm> _timeTableListFactory;

    public MainForm(
        Func<ClassroomListForm> classroomListFactory,
        Func<GroupListForm> groupListFactory,
        Func<LecturerListForm> lecturerListFactory,
        Func<TimeTableListForm> timeTableListFactory)
    {
        InitializeComponent();

        _classroomListFactory = classroomListFactory;
        _groupListFactory = groupListFactory;
        _lecturerListFactory = lecturerListFactory;
        _timeTableListFactory = timeTableListFactory;

        Text = "Составление расписания";
        Width = 800;
        Height = 500;
        StartPosition = FormStartPosition.CenterScreen;

        BuildMenu();
    }

    private void BuildMenu()
    {
        var menuStrip = new MenuStrip();

        // 1. Меню "Справочники"
        var referencesMenu = new ToolStripMenuItem("Справочники");
        referencesMenu.DropDownItems.Add("Аудитории", null, (s, e) => _classroomListFactory().ShowDialog());
        referencesMenu.DropDownItems.Add("Группы", null, (s, e) => _groupListFactory().ShowDialog());
        referencesMenu.DropDownItems.Add("Преподаватели", null, (s, e) => _lecturerListFactory().ShowDialog());

        // 2. Меню "Операции"
        var operationsMenu = new ToolStripMenuItem("Операции");
        operationsMenu.DropDownItems.Add("Расписание занятий", null, (s, e) => _timeTableListFactory().ShowDialog());

        // 3. Меню "Отчеты" (пустое по заданию)
        var reportsMenu = new ToolStripMenuItem("Отчеты");

        menuStrip.Items.Add(referencesMenu);
        menuStrip.Items.Add(operationsMenu);
        menuStrip.Items.Add(reportsMenu);

        MainMenuStrip = menuStrip;
        Controls.Add(menuStrip);
    }
}


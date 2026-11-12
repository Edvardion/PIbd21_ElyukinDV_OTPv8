using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Models;
using TimeTable.Repositories.Interfaces;

namespace TimeTable
{

    public class ClassroomListForm : Form
    {
        private readonly IClassroomRepository _repository;
        private readonly Func<ClassroomEditForm> _editFormFactory;
        private DataGridView _grid;

        public ClassroomListForm(IClassroomRepository repository, Func<ClassroomEditForm> editFormFactory)
        {
            _repository = repository;
            _editFormFactory = editFormFactory;

            Text = "Справочник: Аудитории";
            Width = 600;
            Height = 400;
            StartPosition = FormStartPosition.CenterParent;

            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
            var btnAdd = new Button { Text = "Добавить", Width = 100 };
            var btnEdit = new Button { Text = "Редактировать", Width = 110 };
            var btnDelete = new Button { Text = "Удалить", Width = 100 };

            btnAdd.Click += (s, e) =>
            {
                var form = _editFormFactory();
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            };

            btnEdit.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Classroom selected)
                {
                    var form = _editFormFactory();
                    form.SetEditItem(selected);
                    if (form.ShowDialog() == DialogResult.OK) LoadData();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Classroom selected)
                {
                    _repository.Delete(selected.RoomNumber);
                    LoadData();
                }
            };

            panel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Controls.Add(_grid);
            Controls.Add(panel);
        }

        private void LoadData()
        {
            try { _grid.DataSource = _repository.GetAll().ToList(); }
            catch (NotImplementedException) { }
        }
    }

    public class ClassroomEditForm : Form
    {
        private readonly IClassroomRepository _repository;
        private bool _isEditMode;

        private TextBox _txtRoomNumber;
        private NumericUpDown _numCapacity;
        private ComboBox _cmbType;

        public ClassroomEditForm(IClassroomRepository repository)
        {
            _repository = repository;

            Text = "Аудитория";
            Width = 350;
            Height = 230;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            SetupUI();
        }

        public void SetEditItem(Classroom item)
        {
            _isEditMode = true;
            _txtRoomNumber.Text = item.RoomNumber;
            _txtRoomNumber.Enabled = false;
            _numCapacity.Value = item.ClassCapacity;
            _cmbType.SelectedItem = item.Specification;
        }

        private void SetupUI()
        {
            var lblRoom = new Label { Text = "Номер аудитории:", Left = 15, Top = 20, Width = 120 };
            _txtRoomNumber = new TextBox { Left = 145, Top = 18, Width = 160 };

            var lblCap = new Label { Text = "Вместимость:", Left = 15, Top = 60, Width = 120 };
            _numCapacity = new NumericUpDown { Left = 145, Top = 58, Width = 160, Minimum = 1, Maximum = 500, Value = 30 };

            var lblType = new Label { Text = "Тип аудитории:", Left = 15, Top = 100, Width = 120 };
            _cmbType = new ComboBox { Left = 145, Top = 98, Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };
            _cmbType.DataSource = Enum.GetValues(typeof(RoomType));

            var btnSave = new Button { Text = "Сохранить", Left = 145, Top = 140, Width = 160 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    var room = Classroom.Create(_txtRoomNumber.Text, (int)_numCapacity.Value, (RoomType)_cmbType.SelectedItem);
                    if (_isEditMode) _repository.Update(room);
                    else _repository.Add(room);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            };

            Controls.AddRange(new Control[] { lblRoom, _txtRoomNumber, lblCap, _numCapacity, lblType, _cmbType, btnSave });
        }
    }
    public class GroupListForm : Form
    {
        private readonly IGroupRepository _repository;
        private readonly Func<GroupEditForm> _editFormFactory;
        private DataGridView _grid;

        public GroupListForm(IGroupRepository repository, Func<GroupEditForm> editFormFactory)
        {
            _repository = repository;
            _editFormFactory = editFormFactory;

            Text = "Справочник: Группы";
            Width = 600;
            Height = 400;
            StartPosition = FormStartPosition.CenterParent;

            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
            var btnAdd = new Button { Text = "Добавить", Width = 100 };
            var btnEdit = new Button { Text = "Редактировать", Width = 110 };
            var btnDelete = new Button { Text = "Удалить", Width = 100 };

            btnAdd.Click += (s, e) =>
            {
                var form = _editFormFactory();
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            };

            btnEdit.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Group selected)
                {
                    var form = _editFormFactory();
                    form.SetEditItem(selected);
                    if (form.ShowDialog() == DialogResult.OK) LoadData();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Group selected)
                {
                    _repository.Delete(selected.GroupName);
                    LoadData();
                }
            };

            panel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Controls.Add(_grid);
            Controls.Add(panel);
        }

        private void LoadData()
        {
            try { _grid.DataSource = _repository.GetAll().ToList(); }
            catch (NotImplementedException) { }
        }
    }

    public class GroupEditForm : Form
    {
        private readonly IGroupRepository _repository;
        private bool _isEditMode;

        private TextBox _txtName;
        private NumericUpDown _numSize;

        public GroupEditForm(IGroupRepository repository)
        {
            _repository = repository;

            Text = "Группа";
            Width = 350;
            Height = 190;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            SetupUI();
        }

        public void SetEditItem(Group item)
        {
            _isEditMode = true;
            _txtName.Text = item.GroupName;
            _txtName.Enabled = false;
            _numSize.Value = item.GroupSize;
        }

        private void SetupUI()
        {
            var lblName = new Label { Text = "Название группы:", Left = 15, Top = 20, Width = 120 };
            _txtName = new TextBox { Left = 145, Top = 18, Width = 160 };

            var lblSize = new Label { Text = "Количество человек:", Left = 15, Top = 60, Width = 120 };
            _numSize = new NumericUpDown { Left = 145, Top = 58, Width = 160, Minimum = 1, Maximum = 100, Value = 25 };

            var btnSave = new Button { Text = "Сохранить", Left = 145, Top = 100, Width = 160 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    var group = Group.Create(_txtName.Text, (int)_numSize.Value);
                    if (_isEditMode) _repository.Update(group);
                    else _repository.Add(group);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            };

            Controls.AddRange(new Control[] { lblName, _txtName, lblSize, _numSize, btnSave });
        }
    }
    public class LecturerListForm : Form
    {
        private readonly ILecturerRepository _repository;
        private readonly Func<LecturerEditForm> _editFormFactory;
        private DataGridView _grid;

        public LecturerListForm(ILecturerRepository repository, Func<LecturerEditForm> editFormFactory)
        {
            _repository = repository;
            _editFormFactory = editFormFactory;

            Text = "Справочник: Преподаватели";
            Width = 600;
            Height = 400;
            StartPosition = FormStartPosition.CenterParent;

            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
            var btnAdd = new Button { Text = "Добавить", Width = 100 };
            var btnEdit = new Button { Text = "Редактировать", Width = 110 };
            var btnDelete = new Button { Text = "Удалить", Width = 100 };

            btnAdd.Click += (s, e) =>
            {
                var form = _editFormFactory();
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            };

            btnEdit.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Lecturer selected)
                {
                    var form = _editFormFactory();
                    form.SetEditItem(selected);
                    if (form.ShowDialog() == DialogResult.OK) LoadData();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Lecturer selected)
                {
                    _repository.Delete(selected.LecturerId);
                    LoadData();
                }
            };

            panel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Controls.Add(_grid);
            Controls.Add(panel);
        }

        private void LoadData()
        {
            try { _grid.DataSource = _repository.GetAll().ToList(); }
            catch (NotImplementedException) { }
        }
    }

    public class LecturerEditForm : Form
    {
        private readonly ILecturerRepository _repository;
        private bool _isEditMode;

        private NumericUpDown _numId;
        private TextBox _txtName;
        private TextBox _txtPosition;

        public LecturerEditForm(ILecturerRepository repository)
        {
            _repository = repository;

            Text = "Преподаватель";
            Width = 350;
            Height = 230;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            SetupUI();
        }

        public void SetEditItem(Lecturer item)
        {
            _isEditMode = true;
            _numId.Value = item.LecturerId;
            _numId.Enabled = false;
            _txtName.Text = item.Name;
            _txtPosition.Text = item.Position;
        }

        private void SetupUI()
        {
            var lblId = new Label { Text = "ID преподавателя:", Left = 15, Top = 20, Width = 120 };
            _numId = new NumericUpDown { Left = 145, Top = 18, Width = 160, Minimum = 1, Maximum = 10000 };

            var lblName = new Label { Text = "ФИО:", Left = 15, Top = 60, Width = 120 };
            _txtName = new TextBox { Left = 145, Top = 58, Width = 160 };

            var lblPos = new Label { Text = "Должность:", Left = 15, Top = 100, Width = 120 };
            _txtPosition = new TextBox { Left = 145, Top = 98, Width = 160 };

            var btnSave = new Button { Text = "Сохранить", Left = 145, Top = 140, Width = 160 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    var lecturer = Lecturer.Create((int)_numId.Value, _txtName.Text, _txtPosition.Text);
                    if (_isEditMode) _repository.Update(lecturer);
                    else _repository.Add(lecturer);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            };

            Controls.AddRange(new Control[] { lblId, _numId, lblName, _txtName, lblPos, _txtPosition, btnSave });
        }
    }

public class TimeTableListForm : Form
    {
        private readonly ITimeTableRepository _repository;
        private readonly Func<TimeTableAddForm> _addFormFactory;
        private DataGridView _grid;
        private TextBox _txtFilterGroup;

        public TimeTableListForm(ITimeTableRepository repository, Func<TimeTableAddForm> addFormFactory)
        {
            _repository = repository;
            _addFormFactory = addFormFactory;

            Text = "Операции: Расписание занятий";
            Width = 750;
            Height = 450;
            StartPosition = FormStartPosition.CenterParent;

            SetupUI();
        }

        private void SetupUI()
        {
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 45 };

            var btnAdd = new Button { Text = "Добавить пару", Width = 120 };
            var lblGroup = new Label { Text = "Группа:", AutoSize = true, Margin = new Padding(10, 8, 0, 0) };
            _txtFilterGroup = new TextBox { Width = 100 };
            var btnSearch = new Button { Text = "Показать", Width = 90 };

            btnAdd.Click += (s, e) =>
            {
                var form = _addFormFactory();
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            };

            btnSearch.Click += (s, e) => LoadData();

            panel.Controls.AddRange(new Control[] { btnAdd, lblGroup, _txtFilterGroup, btnSearch });

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Controls.Add(_grid);
            Controls.Add(panel);
        }

        private void LoadData()
        {
            try { _grid.DataSource = _repository.GetByGroup(_txtFilterGroup.Text).ToList(); }
            catch (NotImplementedException) { }
        }
    }

    public class TimeTableAddForm : Form
    {
        private static int _nextId = 1;

        private readonly ITimeTableRepository _repository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ISyllabusRepository _syllabusRepository;
        private readonly IClassroomRepository _classroomRepository;

        private ComboBox _cmbDay;
        private NumericUpDown _numLesson;
        private CheckBox _chkEven;
        private CheckBox _chkOdd;
        private ComboBox _cmbLessonType;
        private ComboBox _cmbGroup;
        private ComboBox _cmbRoom;
        private ComboBox _cmbDiscipline;
        private ComboBox _cmbLecturer;

        public TimeTableAddForm(
            ITimeTableRepository repository,
            ILecturerRepository lecturerRepository,
            IGroupRepository groupRepository,
            ISyllabusRepository syllabusRepository,
            IClassroomRepository classroomRepository)
        {
            _repository = repository;
            _lecturerRepository = lecturerRepository;
            _groupRepository = groupRepository;
            _syllabusRepository = syllabusRepository;
            _classroomRepository = classroomRepository;

            Text = "Добавление занятия в расписание";
            Width = 420;
            Height = 430;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            SetupUI();
            LoadReferenceData();
        }

        private void LoadReferenceData()
        {
            try
            {
                _cmbLecturer.DataSource = _lecturerRepository.GetAll().ToList();
                _cmbLecturer.DisplayMember = "Name";
                _cmbLecturer.ValueMember = "LecturerId";
            }
            catch (NotImplementedException) { }

            try
            {
                _cmbGroup.DataSource = _groupRepository.GetAll().ToList();
                _cmbGroup.DisplayMember = "GroupName";
                _cmbGroup.ValueMember = "GroupName";
            }
            catch (NotImplementedException) { }

            try
            {
                _cmbDiscipline.DataSource = _syllabusRepository.GetAll().ToList();
                _cmbDiscipline.DisplayMember = "DisciplineName";
                _cmbDiscipline.ValueMember = "DisciplineId";
            }
            catch (NotImplementedException) { }

            try
            {
                _cmbRoom.DataSource = _classroomRepository.GetAll().ToList();
                _cmbRoom.DisplayMember = "RoomNumber";
                _cmbRoom.ValueMember = "RoomNumber";
            }
            catch (NotImplementedException) { }
        }

        private void SetupUI()
        {
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 9,
                Padding = new Padding(15)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));

            _cmbDay = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, DataSource = Enum.GetValues(typeof(StudyDayOfWeek)) };
            _numLesson = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 8 };

            var weekPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, Margin = new Padding(0) };
            _chkEven = new CheckBox { Text = "Чётная", AutoSize = true, Checked = true };
            _chkOdd = new CheckBox { Text = "Нечётная", AutoSize = true, Checked = true };

            _chkEven.CheckedChanged += (s, e) =>
            {
                if (!_chkEven.Checked && !_chkOdd.Checked)
                    _chkOdd.Checked = true;
            };
            _chkOdd.CheckedChanged += (s, e) =>
            {
                if (!_chkOdd.Checked && !_chkEven.Checked)
                    _chkEven.Checked = true;
            };

            weekPanel.Controls.Add(_chkEven);
            weekPanel.Controls.Add(_chkOdd);

            _cmbLessonType = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, DataSource = Enum.GetValues(typeof(LessonType)) };
            _cmbGroup = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cmbRoom = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cmbDiscipline = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cmbLecturer = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            AddRow(table, 0, "День недели:", _cmbDay);
            AddRow(table, 1, "Номер пары (1-8):", _numLesson);
            AddRow(table, 2, "Неделя:", weekPanel);
            AddRow(table, 3, "Тип занятия:", _cmbLessonType);
            AddRow(table, 4, "Группа:", _cmbGroup);
            AddRow(table, 5, "Аудитория:", _cmbRoom);
            AddRow(table, 6, "Дисциплина:", _cmbDiscipline);
            AddRow(table, 7, "Преподаватель:", _cmbLecturer);

            var btnSave = new Button { Text = "Добавить в расписание", Dock = DockStyle.Fill, Height = 32 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    if (_cmbGroup.SelectedValue == null)
                        throw new InvalidOperationException("Выберите группу из списка.");

                    if (_cmbRoom.SelectedValue == null)
                        throw new InvalidOperationException("Выберите аудиторию из списка.");

                    if (_cmbDiscipline.SelectedValue == null)
                        throw new InvalidOperationException("Выберите дисциплину из списка.");

                    if (_cmbLecturer.SelectedValue == null)
                        throw new InvalidOperationException("Выберите преподавателя из списка.");

                    WeekType week = WeekType.None;
                    if (_chkEven.Checked) week |= WeekType.Even;
                    if (_chkOdd.Checked) week |= WeekType.Odd;

                    var item = TimeTableItem.Create(
                        _nextId,
                        (StudyDayOfWeek)_cmbDay.SelectedItem,
                        (int)_numLesson.Value,
                        week,
                        (LessonType)_cmbLessonType.SelectedItem,
                        _cmbGroup.SelectedValue.ToString(),
                        _cmbRoom.SelectedValue.ToString(),
                        (int)_cmbDiscipline.SelectedValue,
                        (int)_cmbLecturer.SelectedValue);

                    _repository.Add(item);
                    _nextId++;

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            };

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            table.Controls.Add(btnSave, 1, 8);

            Controls.Add(table);
        }

        private void AddRow(TableLayoutPanel table, int row, string labelText, Control control)
        {
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            var lbl = new Label { Text = labelText, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            table.Controls.Add(lbl, 0, row);
            table.Controls.Add(control, 1, row);
        }
    }


    public class SyllabusListForm : Form
    {
        private readonly ISyllabusRepository _repository;
        private readonly Func<SyllabusEditForm> _editFormFactory;
        private DataGridView _grid;

        public SyllabusListForm(ISyllabusRepository repository, Func<SyllabusEditForm> editFormFactory)
        {
            _repository = repository;
            _editFormFactory = editFormFactory;

            Text = "Справочник: Учебный план (Дисциплины)";
            Width = 650;
            Height = 400;
            StartPosition = FormStartPosition.CenterParent;

            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
            var btnAdd = new Button { Text = "Добавить", Width = 100 };
            var btnEdit = new Button { Text = "Редактировать", Width = 110 };
            var btnDelete = new Button { Text = "Удалить", Width = 100 };

            btnAdd.Click += (s, e) =>
            {
                var form = _editFormFactory();
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            };

            btnEdit.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Syllabus selected)
                {
                    var form = _editFormFactory();
                    form.SetEditItem(selected);
                    if (form.ShowDialog() == DialogResult.OK) LoadData();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (_grid.CurrentRow?.DataBoundItem is Syllabus selected)
                {
                    _repository.Delete(selected.DisciplineId);
                    LoadData();
                }
            };

            panel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });

            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Controls.Add(_grid);
            Controls.Add(panel);
        }

        private void LoadData()
        {
            try { _grid.DataSource = _repository.GetAll().ToList(); }
            catch (NotImplementedException) { }
        }
    }

    public class SyllabusEditForm : Form
    {
        private readonly ISyllabusRepository _repository;
        private bool _isEditMode;

        private NumericUpDown _numId;
        private TextBox _txtName;
        private NumericUpDown _numLectures;
        private NumericUpDown _numLabs;
        private NumericUpDown _numCourse;

        public SyllabusEditForm(ISyllabusRepository repository)
        {
            _repository = repository;

            Text = "Дисциплина учебного плана";
            Width = 360;
            Height = 300;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            SetupUI();
        }

        public void SetEditItem(Syllabus item)
        {
            _isEditMode = true;
            _numId.Value = item.DisciplineId;
            _numId.Enabled = false;
            _txtName.Text = item.DisciplineName;
            _numLectures.Value = item.LectureNumber;
            _numLabs.Value = item.LabNumber;
            _numCourse.Value = item.Course;
        }

        private void SetupUI()
        {
            int top = 20;
            int step = 38;

            Controls.Add(new Label { Text = "ID дисциплины:", Left = 15, Top = top, Width = 130 });
            _numId = new NumericUpDown { Left = 155, Top = top - 2, Width = 170, Minimum = 1, Maximum = 10000 };
            top += step;

            Controls.Add(new Label { Text = "Название:", Left = 15, Top = top, Width = 130 });
            _txtName = new TextBox { Left = 155, Top = top - 2, Width = 170 };
            top += step;

            Controls.Add(new Label { Text = "Часов лекций:", Left = 15, Top = top, Width = 130 });
            _numLectures = new NumericUpDown { Left = 155, Top = top - 2, Width = 170, Minimum = 0, Maximum = 500 };
            top += step;

            Controls.Add(new Label { Text = "Часов лабораторных:", Left = 15, Top = top, Width = 130 });
            _numLabs = new NumericUpDown { Left = 155, Top = top - 2, Width = 170, Minimum = 0, Maximum = 500 };
            top += step;

            Controls.Add(new Label { Text = "Курс (1-6):", Left = 15, Top = top, Width = 130 });
            _numCourse = new NumericUpDown { Left = 155, Top = top - 2, Width = 170, Minimum = 1, Maximum = 6, Value = 1 };
            top += step + 5;

            var btnSave = new Button { Text = "Сохранить", Left = 155, Top = top, Width = 170 };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    var syllabus = Syllabus.Create(
                        (int)_numId.Value,
                        _txtName.Text,
                        (int)_numLectures.Value,
                        (int)_numLabs.Value,
                        (int)_numCourse.Value);

                    if (_isEditMode) _repository.Update(syllabus);
                    else _repository.Add(syllabus);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            };

            Controls.Add(btnSave);
        }
    }

}

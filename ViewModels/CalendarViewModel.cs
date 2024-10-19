using DiaryApp.Interfaces;
using DiaryApp.Models;
using DiaryApp.Views.Popup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiaryApp.ViewModels;

public class CalendarViewModel : INotifyPropertyChanged
{
    private readonly IDatabase<Diary?> _database;

    private DateTime _currentDate;
    public DateTime CurrentDate
    {
        get => _currentDate;
        set
        {
            if (_currentDate != value)
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
                SelectDate = _currentDate.ToString("MMMM yyyy");
                UpdateCalendar();
            }
        }
    }

    private string selectDate;
    public string SelectDate
    {
        get { return selectDate; }
        set
        {
            if (selectDate != value)
            {
                selectDate = value;
                OnPropertyChanged(nameof(SelectDate));
            }
        }
    }

    public ObservableCollection<CustomDayButton> DayButtons { get; set; }
    public ICommand PreviousMonthCommand { get; set; }
    public ICommand NextMonthCommand { get; set; }

    public CalendarViewModel(IDatabase<Diary?> database)
    {
        _database = database;
        DayButtons = new ObservableCollection<CustomDayButton>();

        CurrentDate = DateTime.Today;
        this.PreviousMonthCommand = new RelayCommand(action => PreviousMonth());
        this.NextMonthCommand = new RelayCommand(action => NextMonth());

        UpdateCalendar();
    }

    private void PreviousMonth()
    {
        CurrentDate = _currentDate.AddMonths(-1);
    }

    private void NextMonth()
    {
        CurrentDate = _currentDate.AddMonths(1);
    }

    private void UpdateCalendar()
    {
        DayButtons.Clear();

        DateTime firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);

        int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

        for (int i = 0; i < startDayOfWeek; i++)
        {
            CustomDayButton emptyButton = new CustomDayButton();
            emptyButton.Hide();
            DayButtons.Add(emptyButton);
        }

        List<Diary?> currentMonthDiaries = _database.Get().Where(d => d != null
                                                   && d.Date.Year == CurrentDate.Year
                                                   && d.Date.Month == CurrentDate.Month)
                                       .ToList();

        for (int day = 1; day <= daysInMonth; day++)
        {
            CustomDayButton dayButton = new CustomDayButton();
            dayButton.SetDay(day);

            var diaryForDay = currentMonthDiaries.FirstOrDefault(d => d.Date.Day == day);

            if (diaryForDay != null)
                dayButton.SetEmotion(diaryForDay.Emotion);

            DayButtons.Add(dayButton);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

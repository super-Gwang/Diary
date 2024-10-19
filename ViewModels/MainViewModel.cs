using DiaryApp.Interfaces;
using DiaryApp.Models;
using DiaryApp.Service;
using DiaryApp.Services;
using DiaryApp.Views.Popup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiaryApp.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    private readonly IDatabase<Diary?>? _database;
    private readonly IDialogService _dialogService;

    private int selectYear;
    public int SelectYear
    {
        get { return selectYear; }
        set
        {
            if (selectYear != value)
            {
                selectYear = value;
                OnPropertyChanged(nameof(SelectYear));
            }
        }
    }
    private int selectMonth;
    public int SelectMonth
    {
        get { return selectMonth; }
        set
        {
            if (selectMonth != value)
            {
                selectMonth = value;
                OnPropertyChanged(nameof(SelectMonth));
            }
        }
    }
    private int selectDay;
    public int SelectDay
    {
        get { return selectDay; }
        set
        {
            if (selectDay != value)
            {
                selectDay = value;
                OnPropertyChanged(nameof(SelectDay));
            }
        }
    }
    private string weather;
    public string Weather
    {
        get { return weather; }
        set
        {
            if (weather != value)
            {
                weather = value;
                OnPropertyChanged(nameof(Weather));
            }
        }
    }
    private string emotion;
    public string Emotion
    {
        get { return emotion; }
        set
        {
            if (emotion != value)
            {
                emotion = value;
                OnPropertyChanged(nameof(Emotion));
            }
        }
    }
    private string title;
    public string Title
    {
        get { return title; }
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
    private string content;
    public string Content
    {
        get { return content; }
        set
        {
            if (content != value)
            {
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
    }

    public ICommand SaveCommand { get; set; } 
    public ICommand WeatherCommand { get; set; }
    public ICommand EmotionCommand { get; set; }
    public ICommand PopupCommand { get; set; }

    public MainViewModel(IDatabase<Diary> database, IDialogService dialogService)
    {
        _database = database;
        _dialogService = dialogService;

        SelectYear = DateTime.Now.Year;
        SelectMonth = DateTime.Now.Month;
        SelectDay = DateTime.Now.Day;

        Title = "톨톨 일기장";
        Emotion = "기쁨";

        this.SaveCommand = new RelayCommand(action => SaveDiary());
        this.WeatherCommand = new RelayCommand(param => OnSelectWeather(param));
        this.EmotionCommand = new RelayCommand(param => OnSelectEmotion(param));
        this.PopupCommand = new RelayCommand(action => ShowCalendarPopup());
    }

    public void OnSelectDiary(int id)
    {
        Diary selectDiary = _database.GetDetail(id);

        SelectYear = selectDiary.Date.Year;
        SelectMonth = selectDiary.Date.Month;
        SelectDay = selectDiary.Date.Day;
        Weather = selectDiary.Weather;
        Title = selectDiary.Title;
        Content = selectDiary.Content;
        Emotion = selectDiary.Emotion;
    }

    public void SaveDiary()
    {
        Diary newDiary = new Diary();
        newDiary.Weather = Weather;
        newDiary.Title = Title;
        newDiary.Content = Content;
        newDiary.Date = DateTime.Now;
        newDiary.Emotion = Emotion;

        _database.Create(newDiary);
    }

    public void OnSelectWeather(object? parameter)
    {
        this.Weather = parameter.ToString();
    }
    public void OnSelectEmotion(object? parameter)
    {
        this.Emotion = parameter.ToString();
    }

    public void ShowCalendarPopup()
    {
        var calendarViewModel = App.ServiceProvider.GetService<CalendarViewModel>();
        var calendarPopup = new CalendarPopup(calendarViewModel);
        _dialogService.Show(calendarPopup);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

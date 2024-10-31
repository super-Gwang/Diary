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
using System.Windows;
using System.Windows.Input;

namespace DiaryApp.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    private readonly IDatabase<Diary?>? _database;
    private readonly IDialogService _dialogService;

    public event Action<DateTime> DateSelected;

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
    private DateTime date;
    public DateTime Date
    {
        get { return date; }
        set
        {
            if (date != value)
            {
                date = value;
                SelectYear = date.Year;
                SelectMonth = date.Month;
                SelectDay = date.Day;

                UpdateSaveButtonState();
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
                OnPropertyChanged(nameof(EmotionImageSource));
            }
        }
    }
    public string EmotionImageSource
    {
        get
        {
            return Emotion switch
            {
                "기쁨" => "/images/happy.png",
                "슬픔" => "/images/sad.png",
                "분노" => "/images/angry.png",
                "사랑" => "/images/love.png",
                _ => "/images/happy.png",
            };
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

    private bool saveButtonEnabled;
    public bool SaveButtonEnabled
    {
        get { return saveButtonEnabled; }
        set
        {
            saveButtonEnabled = value;
            OnPropertyChanged(nameof(SaveButtonEnabled));
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

        Date = DateTime.Now;
        SetDiary(Date);

        this.SaveCommand = new RelayCommand(action => SaveDiary());
        this.WeatherCommand = new RelayCommand(param => OnSelectWeather(param));
        this.EmotionCommand = new RelayCommand(param => OnSelectEmotion(param));
        this.PopupCommand = new RelayCommand(action => ShowCalendarPopup());
    }

    public void OnSelectDiary(int id)
    {
        Diary selectDiary = _database.GetDetail(id);

        if (selectDiary is null) return;

        Date = selectDiary.Date;
        Weather = selectDiary.Weather;
        Title = selectDiary.Title;
        Content = selectDiary.Content;
        Emotion = selectDiary.Emotion;
    }

    public void SetDiary(DateTime _date)
    {
        Diary selectDiary = _database.GetDetail(_date);

        Date = _date;

        if (selectDiary is null)
        {
            Title = string.Empty;
            Content = string.Empty;
        }
        else
        {
            Weather = selectDiary.Weather;
            Title = selectDiary.Title;
            Content = selectDiary.Content;
            Emotion = selectDiary.Emotion;
        }
        
    }

    public void SaveDiary()
    {
        Diary? diary = _database?.GetDetail(new DateTime(SelectYear, SelectMonth, SelectDay));

        int affectedRows = 0;

        if (diary is null)
        {
            diary = new Diary();
            
            diary.Weather = Weather;
            diary.Title = Title;
            diary.Content = Content;
            diary.Date = Date;
            diary.Emotion = Emotion;

            affectedRows = _database.Create(diary);
        }
        else
        {
            diary.Weather = Weather;
            diary.Title = Title;
            diary.Content = Content;
            diary.Date = Date;
            diary.Emotion = Emotion;

            affectedRows = _database.Update(diary);
        }

        if (affectedRows == 1)
            MessageBox.Show("일기가 성공적으로 저장되었습니다.");
        else
            MessageBox.Show("일기 저장에 실패했습니다.");
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
        calendarViewModel.DaySelected -= SetDiary;
        calendarViewModel.DaySelected += SetDiary;

        var calendarPopup = new CalendarPopup(calendarViewModel);

        _dialogService.Show(calendarPopup);
    }

    private void UpdateSaveButtonState()
    {
        SaveButtonEnabled = Date.Date == DateTime.Now.Date;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

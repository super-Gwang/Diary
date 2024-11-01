﻿using DiaryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiaryApp.Views.Popup;
public partial class CustomDayButton : UserControl
{
    private DateTime day;
    public DateTime Day
    {
        get { return day; }
        set
        {
            if (day != value)
            {
                day = value;
                DayText.Text = day.Day.ToString();
            }
        }
    }
    public event Action<DateTime> DaySelected;
    public CustomDayButton()
    {
        InitializeComponent();
    }

    public void SetDay(DateTime day)
    {
        Day = day;
        //Visibility = Visibility.Visible;
    }
    public void Hide()
    {
        Visibility = Visibility.Hidden;
    }

    public void SetEmotion(string emotion)
    {
        string imagePath = string.Empty;

        switch (emotion)
        {
            case "기쁨":
                imagePath = "/images/happy.png";
                break;
            case "슬픔":
                imagePath = "/images/sad.png";
                break;
            case "화남":
                imagePath = "/images/angry.png";
                break;
            case "사랑":
                imagePath = "/images/love.png";
                break;
            default:
                break;
        }

        // 이미지 경로를 BitmapImage로 변환하여 Source에 설정
        DayImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
    }

    private void DayButton_Click(object sender, RoutedEventArgs e)
    {
        DaySelected?.Invoke(Day);
    }
}

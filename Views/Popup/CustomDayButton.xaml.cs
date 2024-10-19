using DiaryApp.ViewModels;
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

namespace DiaryApp.Views.Popup;
public partial class CustomDayButton : UserControl
{
    public string Day;
    public CustomDayButton()
    {
        InitializeComponent();
    }

    public void SetDay(int day)
    {
        DayText.Text = day.ToString();
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
}

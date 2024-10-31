using DiaryApp.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Media.Animation;
using System.Windows.Controls.Primitives;

namespace DiaryApp;
public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        this.DataContext = viewModel;
    }
    private void UpdateSaveButtonState()
    {
        btn_Save.IsEnabled = _viewModel.Date == DateTime.Now.Date;
    }
    private void EmotionButton_Click(object sender, RoutedEventArgs e)
    {
        EmotionPopup.IsOpen = true; 
    }
    private void EmotionSelected_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        string selectedEmotion = clickedButton.CommandParameter.ToString();

        switch (selectedEmotion)
        {
            case "기쁨":
                EmotionImg.Source = new BitmapImage(new Uri("/images/happy.png", UriKind.Relative));
                break;
            case "슬픔":
                EmotionImg.Source = new BitmapImage(new Uri("/images/sad.png", UriKind.Relative));
                break;
            case "화남":
                EmotionImg.Source = new BitmapImage(new Uri("/images/angry.png", UriKind.Relative));
                break;
            case "사랑":
                EmotionImg.Source = new BitmapImage(new Uri("/images/love.png", UriKind.Relative));
                break;
        }

        EmotionPopup.IsOpen = false;
    }

    private void ToggleBtn_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is ToggleButton checkedButton)
        {
            var btn = sender as ToggleButton;
            AnimateButtonSize(btn, 40, 40);
            foreach (var button in new[] { SunnyBtn, littleCloudyBtn, CloudyBtn, RainBtn, SnowBtn })
            {
                if (button != checkedButton)
                {
                    button.IsChecked = false;
                    AnimateButtonSize(button, 30, 30);
                }
            }
        }
    }
    private void AnimateButtonSize(ToggleButton button, double toWidth, double toHeight)
    {
        DoubleAnimation widthAnimation = new DoubleAnimation
        {
            To = toWidth,
            Duration = TimeSpan.FromMilliseconds(200),
            EasingFunction = new QuadraticEase()
        };

        DoubleAnimation heightAnimation = new DoubleAnimation
        {
            To = toHeight,
            Duration = TimeSpan.FromMilliseconds(200),
            EasingFunction = new QuadraticEase()
        };

        button.BeginAnimation(WidthProperty, widthAnimation);
        button.BeginAnimation(HeightProperty, heightAnimation);
    }
    private void CloseApplication(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
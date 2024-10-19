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

namespace DiaryApp;
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
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
}
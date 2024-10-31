using System.Configuration;
using System.Data;
using System.Windows;
using DiaryApp.Interfaces;
using DiaryApp.Models;
using DiaryApp.Service;
using DiaryApp.Services;
using DiaryApp.ViewModels;
using DiaryApp.Views.Popup;
using Microsoft.Extensions.DependencyInjection;

namespace DiaryApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        var mainViewModel = ServiceProvider.GetService<MainViewModel>();
        var mainWindow = new MainWindow(mainViewModel);
        mainWindow.Show();

        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDatabase<Diary>, DiaryService>();
        services.AddSingleton<IDialogService, DialogService>();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<CalendarPopup>();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainViewModel>();
        //services.AddSingleton<CalendarPopup>();
        services.AddSingleton<CalendarViewModel>();
        services.AddSingleton<CustomDayButton>();
    }
}

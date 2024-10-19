using DiaryApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DiaryApp.Services;

public class DialogService : IDialogService
{
    private Window _dialogWindow;

    public void Show(Window dialogWindow)
    {
        dialogWindow.ShowDialog(); // ShowDialog로 띄워 모달로 처리
    }

    public void Close()
    {
        _dialogWindow?.Close();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiaryApp.Interfaces;

public interface IDialogService
{
    void Show(Window dialogWindow);
    void Close();
}

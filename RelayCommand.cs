using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiaryApp;

public class RelayCommand : ICommand
{
    public Action<object?>? ExecuteHandler { get; set; }
    public Predicate<object?>? CanExecuteHandler { get; set; }

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action<object?> executeHandler)
    {
        ExecuteHandler = executeHandler;
    }

    public bool CanExecute(object? parameter)
    {
        return CanExecuteHandler == null ? true :
            CanExecuteHandler(parameter);
    }

    public void Execute(object? parameter)
    {
        if (ExecuteHandler != null)
        {
            ExecuteHandler(parameter);
        }
    }
}

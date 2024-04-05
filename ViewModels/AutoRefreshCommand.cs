using System.ComponentModel;
using System.Windows.Input;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public class AutoRefreshCommand : ICommand
{
    private readonly Func<Task> _execute;
    private readonly Func<bool> _canExecute;
    private readonly INotifyPropertyChanged _viewModel;

    public event EventHandler CanExecuteChanged;

    public AutoRefreshCommand(Func<Task> execute, Func<bool> canExecute, INotifyPropertyChanged viewModel)
    {
        _execute = execute;
        _canExecute = canExecute;
        _viewModel = viewModel;

        _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

    public async void Execute(object parameter)
    {
        if (CanExecute(parameter))
        {
            await _execute();
        }
    }
}

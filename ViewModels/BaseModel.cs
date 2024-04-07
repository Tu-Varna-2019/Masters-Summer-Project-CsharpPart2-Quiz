using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;


namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    protected INavigationService _navigationService;
    public bool _isLoading = false;
    public bool IsLoading
    {
        get => _isLoading;
        set { if (_isLoading != value) _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected ICommand InitCommand(Func<Task> execute)
    {
        return new Command(async () => await execute());
    }

    protected abstract bool CanExecuteCommand();
    protected abstract Task ExecuteCommand();
}

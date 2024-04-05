using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected ICommand InitCommand(Func<Task> execute)
    {
        return new Command(async () => await execute());
    }

}

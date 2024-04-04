using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public interface IPropertyChangedViewModel : IQueryAttributable, INotifyPropertyChanged
{

    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null);
}

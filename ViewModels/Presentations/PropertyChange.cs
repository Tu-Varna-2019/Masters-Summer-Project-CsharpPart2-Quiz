using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;

public class PropertyChange : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}

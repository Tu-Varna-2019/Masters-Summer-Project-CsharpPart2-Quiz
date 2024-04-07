namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;
public class UXAnimation : PropertyChange, IUXAnimation
{
    private bool _isLoading = false;
    public bool IsLoading
    {
        get => _isLoading;
        set { if (_isLoading != value) _isLoading = value; OnPropertyChanged(); }
    }
};

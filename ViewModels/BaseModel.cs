using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;


namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public abstract class BaseViewModel : PropertyChange
{
    protected INavigationService _navigationService;
    private readonly IUXAnimation _uxAnimation = new UXAnimation();
    public IUXAnimation UXAnimation => (UXAnimation)_uxAnimation;

    protected abstract bool CanExecuteCommand();
    protected abstract Task ExecuteCommand();
}

using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.Services;
using Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;


namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;

public abstract class BaseViewModel : PropertyChange
{
    protected INavigationService _navigationService;
    protected readonly UserService _userService;
    protected User _user;
    private readonly IUXAnimation _uxAnimation = new UXAnimation();
    public IUXAnimation UXAnimation => (UXAnimation)_uxAnimation;

    protected abstract bool CanExecuteCommand();
    protected abstract Task ExecuteCommand();

    protected BaseViewModel() { }
    protected BaseViewModel(UserRepository userRepository, INavigationService navigation, User user)
    {
        _user = user;
        _navigationService = navigation;
        _userService = new UserService(userRepository);
    }
}

namespace Masters_Summer_Project_CsharpPart2_Quiz.Services;

public interface INavigationService
{
    Task NavigateToAsync<TPage>() where TPage : Page;
    Task GoBackAsync();
}

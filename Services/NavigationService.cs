namespace Masters_Summer_Project_CsharpPart2_Quiz.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task NavigateToAsync<TPage>() where TPage : Page
    {
        var page = _serviceProvider.GetService(typeof(TPage)) as Page;
        if (page == null) throw new InvalidOperationException($"The page of type {typeof(TPage).Name} could not be instantiated. Make sure it's registered with the DI container.");

        await Application.Current.MainPage.Navigation.PushAsync(page);
    }

    public async Task GoBackAsync()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

}


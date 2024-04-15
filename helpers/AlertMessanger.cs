using CommunityToolkit.Mvvm.Messaging;
namespace Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
public static class AlertMessenger
{
    private const string SUCCESS = "Success";
    private const string ERROR = "Error";

    public static string SendMessage(string message, bool isSuccess)
    {
        var token = isSuccess ? SUCCESS : ERROR;
        return WeakReferenceMessenger.Default.Send(message, token);
    }

    public static void RegisterForAlerts(Page page)
    {
        WeakReferenceMessenger.Default.Register<string, string>(page, SUCCESS, (recipient, message) =>
        {

            ShowAlert(page, "Success", message);
        });

        WeakReferenceMessenger.Default.Register<string, string>(page, ERROR, (recipient, message) =>
        {
            ShowAlert(page, "Error occured", message);
        });
    }

    private static void ShowAlert(Page page, string title, string message)
    {
        Dispatcher.GetForCurrentThread().Dispatch(async () =>
        {
            await page.DisplayAlert(title, message, "OK");
        });
    }

    public async static Task<string> ShowPrompt(Page page, string title, string message, string defaultEntry)
    {
        var response = "";
        Dispatcher.GetForCurrentThread().Dispatch(async () =>
        {
            response = await page.DisplayPromptAsync(title, message, initialValue: defaultEntry, maxLength: 1, keyboard: Keyboard.Numeric, accept: $"Confirm {title}", cancel: "Quit");
        });

        return response;
    }

    public static void UnregisterAlerts(Page page)
    {
        WeakReferenceMessenger.Default.UnregisterAll(page);
    }
}

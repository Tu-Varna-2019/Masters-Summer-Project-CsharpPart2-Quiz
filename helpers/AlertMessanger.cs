using CommunityToolkit.Mvvm.Messaging;
namespace Masters_Summer_Project_CsharpPart2_Quiz.Helpers;
public static class AlertMessenger
{
    private const string SuccessToken = "Success";
    private const string ErrorToken = "Error";

    public static void SendMessage(string message, bool isSuccess)
    {
        var token = isSuccess ? SuccessToken : ErrorToken;
        WeakReferenceMessenger.Default.Send(message, token);
    }

    public static void RegisterForAlerts(Page page)
    {
        WeakReferenceMessenger.Default.Register<string, string>(page, SuccessToken, (recipient, message) =>
        {
            ShowAlert(page, true, message);
        });

        WeakReferenceMessenger.Default.Register<string, string>(page, ErrorToken, (recipient, message) =>
        {
            ShowAlert(page, false, message);
        });
    }

    private static void ShowAlert(Page page, bool isSuccess, string message)
    {
        var title = isSuccess ? "Success" : "Error";
        Dispatcher.GetForCurrentThread().Dispatch(async () =>
        {
            await page.DisplayAlert(title, message, "OK");
        });
    }

    public static void UnregisterAlerts(Page page)
    {
        WeakReferenceMessenger.Default.UnregisterAll(page);
    }
}

using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Masters_Summer_Project_CsharpPart2_Quiz;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // // Set our view from the "main" layout resource
        // SetContentView(Resource.Layout.Main);

        // // Set the App's theme
        // SetAppTheme(MainLauncher = true, Resource.Style.MainTheme);

    }

}

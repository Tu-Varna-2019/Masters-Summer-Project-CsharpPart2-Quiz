using Masters_Summer_Project_CsharpPart2_Quiz.Models;
using System.Windows.Input;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels;
internal class LoginViewModel : IQueryAttributable

{
    private User _user;

    public string Email
    {
        get => _user.Email;
        set
        {
            _user.Email = value;
            //  OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _user.Password;
        set
        {
            _user.Password = value;
            // OnPropertyChanged();
        }
    }


    public ICommand SaveCommand { get; set; }
    public ICommand RegisterCommand { get; set; }

    public LoginViewModel()
    {
        _user = new User();

        RegisterCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.RegisterPage)}");
        });
    }

    public LoginViewModel(User user)
    {
        _user = user;
    }

    private async Task Save()
    {
        // _user.Save();
        await App.Current.MainPage.DisplayAlert("Success", "User saved", "OK");
        //await Shell.Current.GoToAsync($"//{nameof(Views.LoginPage)}");
    }

    private async Task Delete()
    {
        // _user.Delete();
        await App.Current.MainPage.DisplayAlert("Success", "User deleted", "OK");
        //await Shell.Current.GoToAsync($"//{nameof(Views.LoginPage)}");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            //_user = User.Load(query["load"].ToString());
            RefreshProperties();
        }
    }

    public void Reload()
    {
        //_note = Models.Note.Load(_note.Filename);
        RefreshProperties();
    }

    private void RefreshProperties()
    {
        // OnPropertyChanged(nameof(Text));
        // OnPropertyChanged(nameof(Date));
    }
}

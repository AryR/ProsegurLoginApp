using ProsegurLoginApp.Models;
using ProsegurLoginApp.Services.API;
using ProsegurLoginApp.Services.Navigation;
using ProsegurLoginApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProsegurLoginApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IApiService _apiService;
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand ExecuteLogin => new Command(Login);

        public LoginViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
        }

        private async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                User user = await _apiService.Login(Email, Password);
                await _navigationService.NavigateTo<HomeViewModel>(user);
            }
            else
            {
                await _navigationService.DisplayAlert("Error", "All fields are requiered", "Ok");
            }
        }
    }
}

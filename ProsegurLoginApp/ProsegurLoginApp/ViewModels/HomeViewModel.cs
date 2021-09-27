using ProsegurLoginApp.Models;
using ProsegurLoginApp.Services.Navigation;
using ProsegurLoginApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProsegurLoginApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private User _user;
        public User User { 
            get { return _user; } 
            set { _user = value; RaisePropertyChanged(() => User); } 
        }
        public ICommand ExecuteLogout => new Command(Logout);

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override Task InitializeAsync(object navigationData = null)
        {
            if (navigationData != null)
                User = (User)navigationData;

            return Task.FromResult(true);
        }

        private async void Logout()
        {
            await _navigationService.NavigateTo<LoginViewModel>();
        }
    }
}

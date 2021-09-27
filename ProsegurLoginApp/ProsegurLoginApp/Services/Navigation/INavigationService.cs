using ProsegurLoginApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurLoginApp.Services.Navigation
{
    public interface INavigationService
    {
        Task GoBack();
        Task NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateTo<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task DisplayAlert(string title, string message, string cancel);
    }
}

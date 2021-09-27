using ProsegurLoginApp.ViewModels.Base;
using ProsegurLoginApp.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProsegurLoginApp.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public Task NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateTo(typeof(TViewModel));
        }

        public Task NavigateTo<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateTo(typeof(TViewModel), parameter);
        }

        public Task GoBack()
        {
            return Application.Current.MainPage.Navigation.PopAsync();
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return App.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        private async Task InternalNavigateTo(Type viewModelType, object parameter = null)
        {
            Page page = CreatePage(viewModelType, parameter);

            if (page is LoginView)
            {
                Application.Current.MainPage = page;
            }
            else
            {
                var navigationPage = Application.Current.MainPage as NavigationPage;
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(
                        CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}

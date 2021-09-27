using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProsegurLoginApp.Services.Navigation;

namespace ProsegurLoginApp.ViewModels.Base
{

    public class BaseViewModel : ExtendedBindableObject
    {

        internal INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual Task InitializeAsync(object navigationData = null)
        {
            return Task.FromResult(false);
        }
    }
}

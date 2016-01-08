using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace QuickTwitter.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly WinRTContainer _container;
        private INavigationService _navigationService;

        public ShellViewModel(WinRTContainer container)
        {
            _container = container;
        }

        #region Navigation

        public void SetupNavigationService(Frame frame)
        {
            _navigationService = _container.RegisterNavigationService(frame);

            var navigationManager = SystemNavigationManager.GetForCurrentView();
            navigationManager.BackRequested += (a, b) => { if (_navigationService.CanGoBack) _navigationService.GoBack(); };
            _navigationService.Navigated += _navigationService_Navigated;

            _navigationService.For<MainViewModel>().Navigate();
        }

        private void _navigationService_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var navigationManager = SystemNavigationManager.GetForCurrentView();
            navigationManager.AppViewBackButtonVisibility = _navigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        #endregion
    }

}

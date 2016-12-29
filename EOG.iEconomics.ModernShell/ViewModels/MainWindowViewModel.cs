using System;
using EOG.iEconomics.ModernShell.ViewModels.Base;
using EOG.iEconomics.ModernShell.ViewModels.LoginAs;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.Prism.Commands;

namespace EOG.iEconomics.ModernShell.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Variables

        private bool _isHamburgerMenuOpen;
        private bool _isLoginAsEnabled;
        private string _loggedInAs;

        #endregion

        #region Properties

        public bool IsHamburgerMenuOpen
        {
            get { return _isHamburgerMenuOpen; }
            set { _isHamburgerMenuOpen = value; OnPropertyChanged(); }
        }

        public bool IsLoginAsEnabled
        {
            get { return _isLoginAsEnabled; }
            set { _isLoginAsEnabled = value; OnPropertyChanged(); }
        }


        public string LoggedInAs
        {
            get { return _loggedInAs; }
            set { _loggedInAs = value; OnPropertyChanged();}
        }
        public DelegateCommand LoginAsCommand { get; private set; }
        #endregion

        public MainWindowViewModel()
        {
            this.LoggedInAs = "ngodugu";
            this.IsLoginAsEnabled = true;
            LoginAsCommand = new DelegateCommand(LoginAs);
            var dialogHost = new DialogHost();
            
        }

        private async void LoginAs()
        {
            
            var viewModel = new LoginAsViewModel();
            viewModel.IsDialogOpen = true;
            viewModel.LdapId = "test";
            var view = new Controls.LoginAs() { DataContext =viewModel };
            var result = await DialogHost.Show(view, "RootDialog");

        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (Convert.ToBoolean(eventArgs.Parameter))
            {
                //Clicked Login AS
                //Validate
            }
        }

        #region Methods

        #region Private Methods


        #endregion

        #region Public Methods



        #endregion

        #endregion
    }
}

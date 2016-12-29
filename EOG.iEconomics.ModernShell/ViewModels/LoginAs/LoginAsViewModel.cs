using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EOG.iEconomics.ModernShell.ViewModels.Base;
using Microsoft.Practices.Prism.Commands;

namespace EOG.iEconomics.ModernShell.ViewModels.LoginAs
{
    public class LoginAsViewModel:BaseViewModel
    {
        public bool IsDialogOpen
        {
            get { return _isDialogOpen; }
            set { _isDialogOpen = value; OnPropertyChanged();}
        }

        private string _ldapId;
        private bool _isDialogOpen;

        public string LdapId
        {
            get { return _ldapId; }
            set { _ldapId = value; OnPropertyChanged();}
        }

        public DelegateCommand LoginAsCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }


        public LoginAsViewModel()
        {
            LoginAsCommand = new DelegateCommand(() =>
            {
                
            });
            CancelCommand = new DelegateCommand(() =>
            {
                this.IsDialogOpen = false;
            });
        }

        
    }
}

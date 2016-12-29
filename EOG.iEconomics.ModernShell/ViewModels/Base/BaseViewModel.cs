using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EOG.iEconomics.ModernShell.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }

        protected BaseViewModel()
        {
          
        }

        #region Methods

        public virtual void DoPrerequisites()
        {
            
        }

        public virtual void InitializeEventSubscriptions()
        {
            
        }

        #endregion


        #region NotifyChanged

        public new event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void NotifyPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var handler = PropertyChanged;
            if (handler == null)
                return;
            var propertyName = PropertyOf(expression).Name;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private static PropertyInfo PropertyOf<T>(Expression<Func<T>> expression)
        {
            var memberExpr = expression.Body as MemberExpression;
            // If the method gets a lambda expression that is not a member access,
            // for example, () => x + y, an exception is thrown
            if (memberExpr == null)
                throw new ArgumentException("Expression \"" + expression +
                                            "\" is not a valid member expression.");
            var property = memberExpr.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("Expression \"" + expression +
                                            "\" does not reference a property.");
            return property;
        }

        /// <summary>
        /// Triggers property change notification on the caller. 
        /// Without passing the property Namew
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Input;

namespace debtManager
{
    public class AddDebtViewModel : BindableBase
    {
        public AddDebtViewModel(Debt newDebt)
        {
            CurrentDebt = newDebt;
        }

        Debt currentDebt;

        public Debt CurrentDebt
        {
            get { return currentDebt; }
            set
            {
                SetProperty(ref currentDebt, value);
            }
        }

        #region Methods

        public bool checkEntry()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(CurrentDebt.Debtor))
            {
                isValid = false;
            }
            return isValid;
        }
        #endregion


        #region Commands

        ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new DelegateCommand(
                    ExecuteSaveCommand, CanExecuteSaveCommand)
                    .ObservesProperty(() => CurrentDebt.Debtor)
                    .ObservesProperty(() => CurrentDebt.Amount));
            }
        }
       
        void ExecuteSaveCommand()
        {

        }
        bool CanExecuteSaveCommand()
        {
            return checkEntry();
        }
        #endregion
    }
}

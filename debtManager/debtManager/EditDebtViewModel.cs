using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace debtManager
{
    public class EditDebtViewModel : BindableBase
    {
        private Debt _currentDebt;
        private Debit _newDebitPayment;

        public Debt CurrentDebt
        {
            get
            {
                return _currentDebt;
            }
            set
            {
                SetProperty(ref _currentDebt, value);
            }
        }

        public Debit NewDebitPayment
        {
            get { return _newDebitPayment; }
            set { SetProperty(ref _newDebitPayment, value); }
        }

        public EditDebtViewModel(Debt currentDebt, Debit newDebitPayment)
        {
            _currentDebt = currentDebt;
            _newDebitPayment = newDebitPayment;
        }

        #region Methods
        public bool Checkout()
        {
            if (NewDebitPayment.Payment != 0)
            {
                return true;
            }

            return false;
        }

        #endregion
        
        #region Commands

        private ICommand _addValueCommand;
        public ICommand AddValueCommand
        {
            get
            {
                return _addValueCommand ?? (_addValueCommand = new DelegateCommand(
                    ExecuteAddValueCommand)
                    .ObservesProperty(() => NewDebitPayment.Payment));
            }
        }
       
        void ExecuteAddValueCommand()
        {
            CurrentDebt.Amount -= NewDebitPayment.Payment;
        }


        #endregion
    }
}

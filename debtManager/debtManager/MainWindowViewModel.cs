using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Net.Mime;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace debtManager
{
    public class MainWindowViewModel : BindableBase
    {
        ObservableCollection<Debt> debts;

        public MainWindowViewModel()
        {
            debts = new ObservableCollection<Debt>();
            debts.Add(new Debt(-1000, "Alice"));
            debts.Add(new Debt(5000, "Bob"));
            CurrentDebt = debts[0];

        }

        #region Properties

        Debt currentDebt = new Debt();

        private Debt _currentDebt;
        public Debt CurrentDebt
        {
            get { return _currentDebt; }
            set { SetProperty(ref _currentDebt, value); }

        }

        private int _currentIndex;

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { SetProperty(ref _currentIndex, value); }
        }

        public ObservableCollection<Debt> Debts
        {
            get
            {
                return debts;
            }
        }
        #endregion
        
        #region Methods

        public void AddNewDebt()
        {
            debts.Add(new Debt());
        }

        public bool isValueNegative
        {
            get { return (CurrentDebt.Amount < 0);  }
        }

        #endregion

        #region Commands

        private DelegateCommand? _previousCommand;
        public DelegateCommand PreviousCommand =>
        _previousCommand ?? (_previousCommand = new DelegateCommand(ExecutePreviousCommand, CanExecutePreviousCommand)
        .ObservesProperty(() => CurrentIndex));
        void ExecutePreviousCommand()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }
        bool CanExecutePreviousCommand()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        private DelegateCommand? _nextCommand;
        public DelegateCommand NextCommand =>
        _nextCommand ?? (_nextCommand = new DelegateCommand(ExecuteNextCommand, CanExecuteNextCommand)
        .ObservesProperty(() => CurrentIndex));
        void ExecuteNextCommand()
        {
            if (CurrentIndex < Debts.Count-1)
                ++CurrentIndex;
        }
        bool CanExecuteNextCommand()
        {
            if (CurrentIndex < Debts.Count-1)
                return true;
            else
                return false;
        }

        private DelegateCommand? _addDebtCommand;
        public DelegateCommand AddDebtCommand => 
            _addDebtCommand ?? (_addDebtCommand = new DelegateCommand(ExecuteAddDebtCommand));
  
        void ExecuteAddDebtCommand()
        {
            var newDebt = new Debt();
            var VM = new AddDebtViewModel(newDebt);
            var win2 = new AddDebt
            {
                DataContext = VM
            };
            if (win2.ShowDialog() == true) 
            {
                Debts.Add(newDebt);
                CurrentIndex = Debts.Count-1;
            }
        }

        private DelegateCommand? _deleteDebtCommand;
        public DelegateCommand DeleteDebtCommand =>
            _deleteDebtCommand ?? (_deleteDebtCommand = new DelegateCommand(ExecuteDeleteDebtCommand, CanExecuteDeleteDebtCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteDeleteDebtCommand()
        {
            if (CurrentDebt != null) 
            {
                Debts.Remove(CurrentDebt);
            }
        }
        bool CanExecuteDeleteDebtCommand()
        {
            if (CurrentDebt != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DelegateCommand? _exitCommand;
        public DelegateCommand ExitCommand =>
            _exitCommand ?? (_exitCommand = new DelegateCommand(ExecuteExitCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteExitCommand()
        {
            App.Current.MainWindow.Close();
        }

        private DelegateCommand? _editCommand;

        public DelegateCommand EditCommand =>
            _editCommand ?? (_editCommand = new DelegateCommand(ExecuteEditCommand));
        
        void ExecuteEditCommand()
        {
            var DebitPayment = new Debit(DateTime.Today.ToString("d"), 0);
            var VM = new EditDebtViewModel(CurrentDebt, DebitPayment);
            var win2 = new EditDebt 
            {
                DataContext = VM
            };
            
            if (win2.ShowDialog() == true)
            {
                CurrentDebt.AddDebit(DebitPayment);
            }
        }
        bool CanExecuteEditCommand()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }


        #endregion

     
    }
}
        
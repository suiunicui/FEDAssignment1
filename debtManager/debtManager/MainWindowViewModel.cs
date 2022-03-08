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
using System.IO;
using Microsoft.Win32;

namespace debtManager
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            debts = new ObservableCollection<Debt>();
            debts.Add(new Debt(-1000, "Alice"));
            debts.Add(new Debt(5000, "Bob"));
            CurrentDebt = debts[0];

        }

        #region Properties

       // Debt currentDebt ;

        private Debt currentDebt= new Debt();
        public Debt CurrentDebt
        {
            get { return currentDebt; }
            set { SetProperty(ref currentDebt, value); }

        }

        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set { SetProperty(ref currentIndex, value); }
        }

        private string filename = "";
        public string Filename
        {
            get { return filename; }
            set
            {
                SetProperty(ref filename, value);
            }
        }

        ObservableCollection<Debt> debts;
        public ObservableCollection<Debt> Debts
        {
            get
            {
                return debts;
            }
            set
            {
                SetProperty(ref debts, value);
            }
        }
        #endregion

        #region Commands

        private DelegateCommand? addDebtCommand;
        public DelegateCommand AddDebtCommand => 
            addDebtCommand ?? (addDebtCommand = new DelegateCommand(ExecuteAddDebtCommand));
  
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
                newDebt.AddDebit(new Debit(DateTime.Today.ToString("d"), newDebt.Amount));
                Debts.Add(newDebt);

                CurrentIndex = Debts.Count-1;
            }
        }

        private DelegateCommand? deleteDebtCommand;
        public DelegateCommand DeleteDebtCommand =>
            deleteDebtCommand ?? (deleteDebtCommand = new DelegateCommand(ExecuteDeleteDebtCommand, CanExecuteDeleteDebtCommand)
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

        private DelegateCommand? exitCommand;
        public DelegateCommand ExitCommand =>
            exitCommand ?? (exitCommand = new DelegateCommand(ExecuteExitCommand)
            .ObservesProperty(() => CurrentIndex));

        void ExecuteExitCommand()
        {
            App.Current.MainWindow.Close();
        }

        private DelegateCommand? editCommand;

        public DelegateCommand EditCommand =>
            editCommand ?? (editCommand = new DelegateCommand(ExecuteEditCommand));
        
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


        private DelegateCommand? saveFileCommand;

        public DelegateCommand SaveFileCommand =>
            saveFileCommand ?? (saveFileCommand = new DelegateCommand(ExecuteSaveFileCommand));

        void ExecuteSaveFileCommand()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Debt documents|*.gd|All Files|*.*",
                DefaultExt = "gd"
            };
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                string filePath = dialog.FileName;
                
                FileManager.SaveFile(filePath, Debts);
            }
        }

        private DelegateCommand? loadFileCommand;

        public DelegateCommand LoadFileCommand =>
            loadFileCommand ?? (loadFileCommand = new DelegateCommand(ExecuteLoadFileCommand));

        void ExecuteLoadFileCommand()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Debt documents|*.gd|All Files|*.*",
                DefaultExt = "gd"
            };
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                string filePath = dialog.FileName;

                Debts = FileManager.LoadFile(filePath);
            }
        }
        #endregion


    }
}
        
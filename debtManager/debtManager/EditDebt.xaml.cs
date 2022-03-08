using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace debtManager
{
    /// <summary>
    /// Interaction logic for EditDebt.xaml
    /// </summary>
    public partial class EditDebt : Window
    {
        public EditDebt()
        {
            InitializeComponent();
        }

        private void btn_addValue(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as EditDebtViewModel;
            if (vm.Checkout())
                DialogResult = true;
            else
                MessageBox.Show("Enter debit amount", "Missing data");

        }
    }
}

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
    /// Interaction logic for AddDebt.xaml
    /// </summary>
    public partial class AddDebt : Window
    {
        public AddDebt()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AddDebtViewModel;
            if (vm.checkEntry())
                DialogResult = true;
            else
                MessageBox.Show("Enter debtor name and debt amount", "Missing data");
        }

    }
}

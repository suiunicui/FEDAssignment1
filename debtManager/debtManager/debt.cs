using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace debtManager
{
    public class debt : BindableBase
    {
        int amount;
        string debtor;
        List<debit> debitList;

        public debt()
        {
        }

        public debt(int damount, string ddebtor)
        {
            amount = damount;
            debtor = ddebtor;
            debitList = new List<debit>();
            debitList.Add(new debit("Today", Amount));
        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public string Debtor
        {
            get
            {
                return debtor;
            }
            set
            {
                debtor = value;
            }
        }

    }

    public class debit : BindableBase
    {
        string date;
        int payment;

        public debit(string ddate, int dpayment)
        {
            Date = ddate;
            Payment = dpayment;
        }
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public int Payment
        {
            get
            {
                return payment;
            }
            set
            {
                payment = value;
            }
        }

    }
}

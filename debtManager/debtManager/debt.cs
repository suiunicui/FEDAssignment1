using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace debtManager
{
    public class Debt : BindableBase
    {
        int amount;
        string debtor;
        List<Debit> debitList;

        public Debt()
        {
        }

        public Debt(int damount, string ddebtor)
        {
            amount = damount;
            debtor = ddebtor;
            debitList = new List<Debit>();
            debitList.Add(new Debit("Today", Amount));
        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                SetProperty(ref amount, value);
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
                SetProperty(ref debtor, value); 
            }
        }

    }

    public class Debit : BindableBase
    {
        
      

        public Debit(string ddate, int dpayment)
        {
            Date = ddate;
            Payment = dpayment;
        }
        
        string date;
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
        
        int payment;
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

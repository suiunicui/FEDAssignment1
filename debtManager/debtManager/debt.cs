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
        Int32 amount;
        string debtor;
        List<Debit> debitList;

        public Debt()
        {
            debitList = new List<Debit>();
        }

        public Debt(int damount, string ddebtor)
        {
            amount = damount;
            debtor = ddebtor;
            debitList = new List<Debit>();
            debitList.Add(new Debit(DateTime.Today.ToString("d"), Amount));
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

        public List<Debit> DebitList
        {
            get { return debitList; }
            set { SetProperty(ref debitList, value); }
        }

        public void AddDebit(Debit newDebit)
        {
            debitList.Add(newDebit);
        }

        public override string ToString()
        {
            string theString = amount + "," + debtor;

            foreach(Debit debit in debitList)
            {
                theString += debit.ToString();
            }
            theString += ";";
            return theString;
        }

    }

    public class Debit : BindableBase
    {
        public Debit()
        {
        }
        public Debit(string ddate, int dpayment)
        {
            date = ddate;
            payment = -dpayment;
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
                SetProperty(ref date, value);
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
                SetProperty(ref payment, value);
            }
        }
        public override string ToString()
        {
            string dstring = "," + date + "," + payment.ToString();
            return dstring;
        }
    }
}

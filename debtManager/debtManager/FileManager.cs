using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;

namespace debtManager
{
    public class FileManager
    {
        internal static ObservableCollection<Debt> LoadFile(string filePath)
        {
            ObservableCollection < Debt > debts = new ObservableCollection < Debt >();
            string allData = System.IO.File.ReadAllText(filePath);
            string[] dataList = allData.Split(';');
            foreach(string data in dataList)
            {
                if(data != "") {
                string[] debtData = data.Split(',');
                Debt debt = new Debt();

                debt.Amount = Convert.ToInt32(debtData[0]);
                debt.Debtor = debtData[1];

                for (int i = 2; i < debtData.Length; i +=2)
                {
                    Debit debit = new Debit(debtData[i], Int32.Parse(debtData[i + 1]));
                    debt.AddDebit(debit);
                }
                debts.Add(debt);
                }
            }
            return debts;
        }

        internal static void SaveFile(string filePath, ObservableCollection<Debt> debts)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Debt debt in debts)
            {
                sb.Append(debt.ToString());
            }
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }
        
    }
}

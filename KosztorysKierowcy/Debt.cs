using System;
using System.ComponentModel;

namespace KosztorysKierowcy
{
    public class Debt
    {
        private int debtid;
        private Person creditor;
        private Person debtor;
        private double amount;
        private DateTime date;

        public Debt(int debtid, Person creditor, Person debtor, double amount, DateTime date)
        {
            this.debtid = debtid;
            this.creditor = creditor;
            this.debtor = debtor;
            this.amount = amount;
            this.date = date;
        }

        [DisplayName("LP.")]
        public string Debtid => debtid.ToString();
        [DisplayName("Wierzyciel")]
        public string Creditor => creditor.FullName;
        [DisplayName("Dłużnik")]
        public string Debtor => debtor.FullName;
        [DisplayName("Kwota")]
        public string TransitCost => amount.ToString("F") + " zł";
        [DisplayName("Data")]
        public string Date => date.ToString();
    }
}

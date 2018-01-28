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

        [DisplayName("ID")]
        public string Debtid { get { return debtid.ToString(); } }
        [DisplayName("Wierzyciel")]
        public string Creditor { get { return creditor.FullName; } }
        [DisplayName("Dłużnik")]
        public string Debtor { get { return debtor.FullName; } }
        [DisplayName("Kwota")]
        public string TransitCost { get { return amount.ToString("F") + " zł"; } }
        [DisplayName("Data")]
        public string Date { get { return date.ToString(); } }
    }
}

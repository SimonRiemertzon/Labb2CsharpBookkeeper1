using System;
using SQLite;
namespace Labb2CSharp
{
    public class Entry
    {
        BooksKeeperManager bk = BooksKeeperManager.Instance;

        [PrimaryKey, AutoIncrement]
        public string EntryID { get; set; }
        public bool ExpenseEntry { get; set; }
        public string DateOfEntry { get; set; }
        public string Description { get; set; }
        public double TotalAmount { get; set; }
        public Account TypeOfEntry { get; set; }
        public Account ToOrFromAccount { get; set; }
        public TaxRate EntryTaxRate { get; set; }







        /*
        public Entry(string id,
                     string date,
                     Account typeAccount,
                     Account toFromAccount,
                     TaxRate tr)
        {
            EntryID = id;
            DateOfEntry = date;
            // TypeOfEntry = typeEntry;
            TypeOfAccount = typeAccount;
            ToOrFromAccount = toFromAccount;
            EntryTaxRate = tr;

        }
        */

    }
}

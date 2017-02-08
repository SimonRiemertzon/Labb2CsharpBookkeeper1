using System;
namespace Labb2CSharp
{
    public class Entry
    {
        BooksKeeperManager bk = BooksKeeperManager.Instance;


        public string EntryID { get; set; }
        public string DateOfEntry { get; set; }
        public string TypeOfEntry { get; set; }
        public TaxRate EntryTaxRate { get; set; }
        public Account TypeOfAccount { get; set; }
        public Account ToOrFromAccount { get; set; }






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


    }
}

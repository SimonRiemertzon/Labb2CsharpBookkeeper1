using System;
namespace Labb2CSharp
{
    public class Entry
    {
        BooksKeeperManager bk = BooksKeeperManager.Instance;


        public string EntryID { get; set; }
        public double DateOfEntry { get; set; }
        public string TypeOfEntry { get; set; }
        public Account TypeOfAccount { get; set; }
        public Account ToOrFromAccount { get; set; }






        public Entry(string id, double date, string typeEntry, Account typeAccount, Account toFromAccount)
        {
            EntryID = id;
            DateOfEntry = date;
            TypeOfEntry = typeEntry;
            TypeOfAccount = typeAccount;
            ToOrFromAccount = toFromAccount;
        }


    }
}

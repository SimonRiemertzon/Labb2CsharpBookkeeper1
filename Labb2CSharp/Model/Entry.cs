using System;
namespace Labb2CSharp
{
    public class Entry
    {
        BooksKeeperManager bk = BooksKeeperManager.Instance;


        public string entryID { get; set; }
        public double dateOfEntry { get; set; }
        public string typeOfEntry { get; set; }
        public Account typeOfAccount { get; set; }
        public Account toOrFromAccount { get; set; }






        public Entry(string id, double date, string typeEntry, Account typeAccount, Account toFromAccount)
        {
            entryID = id;
            dateOfEntry = date;
            typeOfEntry = typeEntry;
            typeOfAccount = typeAccount;
            toOrFromAccount = toFromAccount;
        }


    }
}

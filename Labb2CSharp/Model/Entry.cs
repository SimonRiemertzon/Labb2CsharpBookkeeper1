using System;
using SQLite;
namespace Labb2CSharp
{
    public class Entry
    {
        [PrimaryKey, AutoIncrement]
        public int EntryID { get; private set; }
        public string DateOfEntry { get; set; }
        public string Description { get; set; }
        public double TotalAmount { get; set; }
        public int TypeOfEntryID { get; set; }
        public string TypeOfEntryName { get; set; }
        public int ToOrFromAccountID { get; set; }
        public int EntryTaxRateID { get; set; }




    }


}

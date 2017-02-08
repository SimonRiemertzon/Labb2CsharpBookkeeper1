using System;
using System.Collections.Generic;
using Java.Util;
using SQLite;

namespace Labb2CSharp
{


    public class BooksKeeperManager
    {

        private static BooksKeeperManager instance;
        private double numberOfEntries = 0;



        public List<Entry> allEntries { get; private set; }
        public List<Account> incomeAccounts { get; private set; }
        public List<Account> expenseAccounts { get; private set; }
        public List<Account> moneyAccounts { get; private set; }
        public List<TaxRate> taxRates { get; private set; }

        private BooksKeeperManager()
        {

            //Income Accounts
            Account a3000 = new Account(3000, "Försäljning");
            Account a3040 = new Account(3040, "Försäljning av tjänster");

            //Expense Accounts
            Account a4010 = new Account(4010, "Varuinköp");
            Account a5010 = new Account(5010, "Lokalhyra");

            //Asset Accounts
            Account a1930 = new Account(1930, "Företagskonto/Checkräkningskonto");
            Account a1250 = new Account(1250, "Datorer");

            //Taxrates
            TaxRate tr25 = new TaxRate(1, 0.25);
            TaxRate tr12 = new TaxRate(2, 0.12);
            TaxRate tr6 = new TaxRate(3, 0.06);

            //Implementing lists

            allEntries = new List<Entry> { };
            incomeAccounts = new List<Account> { a3000, a3040 };
            expenseAccounts = new List<Account> { a4010, a5010 };
            moneyAccounts = new List<Account> { a1930, a1250 };
            taxRates = new List<TaxRate> { tr25, tr12, tr6 };

            //Implementing Database
            string pathToDB = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            SQLiteConnection db = new SQLiteConnection(pathToDB + @"\database.db");

        }


        public static BooksKeeperManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BooksKeeperManager();
                }
                return instance;
            }
        }



        //Entries (All entries made)
        //IncomeAccounts
        //ExpenseAccounts
        //Taxrates (List made of diffrent taxrate doubles)
        //AssetsAccount 1930



        public void addEntry(bool expenseEntry,
                             Account typeEntry,
                             String date,
                             Account toFromAccount,
                             TaxRate tr)
        {
            numberOfEntries++;
            Entry e = new Entry(numberOfEntries.ToString(),
                                date,
                                typeEntry,
                                toFromAccount,
                                tr);
            allEntries.Add(e);
            //Entry e = new Entry(string.Format("e{0}", numberOfEntries), );

            //När jag skapar en händelse måste den läggas till listan av entrys! Detta måste skrivas innan min "Allentrys kommer funka"

        }



    }
}

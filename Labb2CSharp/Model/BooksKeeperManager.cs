using System;
using System.Collections.Generic;
using Java.Util;

namespace Labb2CSharp
{


    public class BooksKeeperManager
    {

        private static BooksKeeperManager instance;




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
            TaxRate tr25 = new TaxRate(0.25);
            TaxRate tr12 = new TaxRate(0.12);
            TaxRate tr6 = new TaxRate(0.06);

            //Implementing lists
            //Lists
            // List<Entry> allEntries = new List<Entry>();

            incomeAccounts = new List<Account> { a3000, a3040 };
            expenseAccounts = new List<Account> { a4010, a5010 };
            moneyAccounts = new List<Account> { a1930, a1250 };
            taxRates = new List<TaxRate> { tr25, tr12, tr6 };

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







        //Addentry()
        //
    }
}

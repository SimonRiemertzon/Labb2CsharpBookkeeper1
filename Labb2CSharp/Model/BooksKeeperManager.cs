using System;
using System.Collections.Generic;
using System.Linq;
using Java.Util;
using SQLite;

namespace Labb2CSharp
{


    public class BooksKeeperManager
    {
        private static BooksKeeperManager instance;
        private static string pathToDB = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static string fullPath = pathToDB + @"\database.db";

        private BooksKeeperManager() {
            createTables();
        }


        public static BooksKeeperManager Instance {
            get
            {
                if(instance == null) {
                    instance = new BooksKeeperManager();
                }
                return instance;
            }
        }

        public void createTables() {
            SQLiteConnection db = new SQLiteConnection(pathToDB + @"\database.db");
            //Implementing Databas
            db.CreateTable<Account>();
            db.CreateTable<TaxRate>();
            db.CreateTable<Entry>();


            int tableCountSum = db.Table<Account>().Count() + db.Table<TaxRate>().Count();
            db.Close();

            if(tableCountSum == 0) {
                addDataToDb();
            }


        }

        private void addDataToDb() {
            SQLiteConnection db = new SQLiteConnection(pathToDB + @"\database.db");

            //Income Accounts
            Account a3000 = new Account() { ID = 3000, Name = "Försäljning", TypeOfAccount = "Income" };
            Account a3040 = new Account() { ID = 3040, Name = "Försäljning av tjänster", TypeOfAccount = "Income" };
            db.Insert(a3000);
            db.Insert(a3040);

            //Expense Accounts
            Account a4010 = new Account { ID = 4010, Name = "Varuinköp", TypeOfAccount = "Expense" };
            Account a5010 = new Account { ID = 5010, Name = "Lokalhyra", TypeOfAccount = "Expense" };
            db.Insert(a4010);
            db.Insert(a5010);

            //Asset Accounts
            Account a1930 = new Account { ID = 1930, Name = "Företagskonto/Checkräkningskonto", TypeOfAccount = "Assets" };
            Account a1250 = new Account { ID = 1250, Name = "Datorer", TypeOfAccount = "Assets" };
            db.Insert(a1930);
            db.Insert(a1250);

            //Taxrates
            TaxRate tr25 = new TaxRate() { Percent = 0.25 };
            TaxRate tr12 = new TaxRate() { Percent = 0.12 };
            TaxRate tr6 = new TaxRate() { Percent = 0.06 };
            db.Insert(tr25);
            db.Insert(tr12);
            db.Insert(tr6);


            //Closing the database
            db.Close();
        }



        public void addEntry(
                             String date,
                             String description,
                             double totalAmount,
                             int typeOfEntryID,
                             string typeOfEntryName,
                             int toFromAccountID,
                             int taxRateID) {

            Entry entry = new Entry {
                DateOfEntry = date,
                Description = description,
                TotalAmount = totalAmount,
                TypeOfEntryID = typeOfEntryID,
                TypeOfEntryName = typeOfEntryName,
                ToOrFromAccountID = toFromAccountID,
                EntryTaxRateID = taxRateID

            };

            SQLiteConnection db = new SQLiteConnection(pathToDB + @"\database.db");
            db.Insert(entry);
            db.Close();

        }

        public List<Entry> getAllEntrys() {
            SQLiteConnection db = new SQLiteConnection(pathToDB + @"\database.db");
            List<Entry> entrys = db.Table<Entry>().ToList();
            db.Close();

            return entrys;
        }


        public List<Account> getListOfAccounts(int atleast, int max) {
            SQLiteConnection db = new SQLiteConnection(fullPath);
            var accounts = db.Table<Account>().Where(a => a.ID >= atleast & a.ID < max);

            return accounts.ToList();

        }

        public List<TaxRate> getTaxRate(int i, bool getAllTaxrates) {
            SQLiteConnection db = new SQLiteConnection(fullPath);

            var taxRates = getAllTaxrates ? db.Table<TaxRate>().Take(3) : db.Table<TaxRate>().Take(i);

            return taxRates.ToList();
        }

        public string GetTaxReport() {
            string consumptionTaxTable = "";
            double sumTax = 0;

            foreach(var entry in getAllEntrys()) {
                if(new string[] { "Expense", "Income" }.Contains(entry.TypeOfEntryName)) {
                    double thisTax = entry.TotalAmount * getTaxRate(entry.EntryTaxRateID, false)[0].Percent;
                    consumptionTaxTable += string.Format(
                        "{0} {1}: {2}\n",
                        entry.Description,
                        entry.TypeOfEntryName == "Expense" ? "Ingående" : "Utgående",
                        thisTax);
                    sumTax += entry.TypeOfEntryName == "Expense" ? thisTax : -thisTax;
                }
            }
            consumptionTaxTable += string.Format("SUMMA: {0}", sumTax);
            return consumptionTaxTable;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using Java.Util;
using SQLite;

namespace Labb2CSharp
{


    public class BooksKeeperManager
    {

        private static BooksKeeperManager instance;
        private double numberOfEntries = 0;


        private static string pathToDB = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);



        public List<Entry> allEntries { get; private set; }
        public List<Account> incomeAccounts { get; private set; }
        public List<Account> expenseAccounts { get; private set; }
        public List<Account> moneyAccounts { get; private set; }
        public List<TaxRate> taxRates { get; private set; }

        private BooksKeeperManager() {
            SQLiteConnection db = new SQLiteConnection(pathToDB + @"\database.db");
            //Implementing Database

            db.CreateTable<TaxRate>();
            db.CreateTable<Account>();
            db.CreateTable<Entry>();


            //Income Accounts
            Account a3000 = new Account() { ID = 3000, Name = "Försäljning" };
            Account a3040 = new Account { ID = 3040, Name = "Försäljning av tjänster" };
            db.Insert(a3000);
            db.Insert(a3040);

            //Expense Accounts
            Account a4010 = new Account { ID = 4010, Name = "Varuinköp" };
            Account a5010 = new Account { ID = 5010, Name = "Lokalhyra" };
            db.Insert(a4010);
            db.Insert(a5010);

            //Asset Accounts
            Account a1930 = new Account { ID = 1930, Name = "Företagskonto/Checkräkningskonto" };
            Account a1250 = new Account { ID = 1250, Name = "DatorerID" };
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


        public static BooksKeeperManager Instance
        {
            get
            {
                if(instance == null) {
                    instance = new BooksKeeperManager();
                }
                return instance;
            }
        }





        public void addEntry(bool expenseEntry, String date, String description, double totalAmount, Account typeOfEntry, Account toFromAccount, TaxRate tr) {

            Entry entry = new Entry {
                ExpenseEntry = expenseEntry,
                DateOfEntry = date,
                Description = description,
                TotalAmount = totalAmount,
                TypeOfEntry = typeOfEntry,
                ToOrFromAccount = toFromAccount,
                EntryTaxRate = tr
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





    }
}

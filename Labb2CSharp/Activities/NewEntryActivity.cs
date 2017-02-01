
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Labb2CSharp
{
    [Activity(Label = "Ny Händelse")]

    public class NewEntryActivity : Activity
    {
        BooksKeeperManager bk = BooksKeeperManager.Instance;
        Spinner spinnerType;
        Spinner spinnerAccount;
        Spinner spinnerTaxRate;
        RadioButton radioSetExpense;
        RadioButton radioSetIncome;
        Button addEntryBtn;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewEntryLo);


            //Setting values for local variables
            radioSetExpense = FindViewById<RadioButton>(Resource.Id.expense_radioButton);
            radioSetIncome = FindViewById<RadioButton>(Resource.Id.income_radioButton);
            spinnerType = FindViewById<Spinner>(Resource.Id.type_spinner);
            spinnerAccount = FindViewById<Spinner>(Resource.Id.account_spinner);
            spinnerTaxRate = FindViewById<Spinner>(Resource.Id.tax_spinner);
            addEntryBtn = FindViewById<Button>(Resource.Id.add_new_entry_btn);


            //Setting up default spinners
            SetEntryModeToExpense();
            SetAccountSpinner();
            SetTaxSpinner();


            //Clickmethods
            radioSetExpense.Click += delegate
            {
                SetEntryModeToExpense();
            };

            radioSetIncome.Click += delegate
            {
                SetEntryModeToIncome();
            };

            addEntryBtn.Click += delegate
            {

                bk.addEntry((Account)spinnerType.SelectedItem,
                            (Account)spinnerAccount.SelectedItem,
                            (Account)spinnerTaxRate.SelectedItem);

            };


        }

        private void SetEntryModeToExpense()
        {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.expenseAccounts);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerType.Adapter = adapter;
        }

        private void SetEntryModeToIncome()
        {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.incomeAccounts);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerType.Adapter = adapter;
        }

        private void SetAccountSpinner()
        {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.moneyAccounts);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerAccount.Adapter = adapter;
        }

        private void SetTaxSpinner()
        {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.taxRates);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerTaxRate.Adapter = adapter;
        }


    }
}
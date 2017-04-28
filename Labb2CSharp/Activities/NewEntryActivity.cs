
using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.OS;
using Android.Widget;


namespace Labb2CSharp
{
    [Activity(Label = "Ny Händelse")]

    public class NewEntryActivity : Activity
    {

        BooksKeeperManager bk = BooksKeeperManager.Instance;
        Spinner spinnerType;
        Spinner spinnerToFromAccount;
        Spinner spinnerTaxRate;
        RadioButton radioSetExpense;
        RadioButton radioSetIncome;
        Button addEntryBtn;
        EditText totalAmount;
        TextView exTaxTv;
        EditText dateEt;
        EditText descriptionEt;






        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewEntryLo);


            //Setting values for local variables
            radioSetExpense = FindViewById<RadioButton>(Resource.Id.expense_radioButton);
            radioSetIncome = FindViewById<RadioButton>(Resource.Id.income_radioButton);
            spinnerType = FindViewById<Spinner>(Resource.Id.type_spinner);
            spinnerToFromAccount = FindViewById<Spinner>(Resource.Id.account_spinner);
            spinnerTaxRate = FindViewById<Spinner>(Resource.Id.tax_spinner);
            addEntryBtn = FindViewById<Button>(Resource.Id.add_new_entry_btn);
            totalAmount = FindViewById<EditText>(Resource.Id.total_amount_edittext);
            exTaxTv = FindViewById<TextView>(Resource.Id.ex_tax_tv);
            dateEt = FindViewById<EditText>(Resource.Id.date_edittext);
            descriptionEt = FindViewById<EditText>(Resource.Id.description_edittext);



            //Setting up default spinners
            SetEntryModeToExpense();
            SetMoneyAccountSpinner();
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
                int typeOfEntryID = ((Account)spinnerType.SelectedItem).ID;
                string typeOfEntryName = ((Account)spinnerType.SelectedItem).Name;
                int toFromAccount = ((Account)spinnerToFromAccount.SelectedItem).ID;
                int taxRateID = ((TaxRate)spinnerTaxRate.SelectedItem).ID;

                bk.addEntry(
                            dateEt.Text,
                            descriptionEt.Text,
                            Double.Parse(totalAmount.Text),
                            typeOfEntryID,
                            typeOfEntryName,
                            toFromAccount,
                            taxRateID);



            };


            spinnerTaxRate.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(TaxSelected);


        }

        private void SetEntryModeToExpense() {

            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.getListOfAccounts(4000, 8999));
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerType.Adapter = adapter;
        }

        private void SetEntryModeToIncome() {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.getListOfAccounts(3000, 3999));
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerType.Adapter = adapter;
        }

        private void SetMoneyAccountSpinner() {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.getListOfAccounts(1000, 1999));
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerToFromAccount.Adapter = adapter;
        }

        private void SetTaxSpinner() {
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, bk.getTaxRate(0, true));
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerTaxRate.Adapter = adapter;
        }

        private void TaxSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
            Spinner s = (Spinner)sender;
            if(!totalAmount.Text.Equals("")) {


                string currentTaxRate = Regex.Match(s.SelectedItem.ToString(), @"\d+").Value;
                double currentTaxRateDouble = Double.Parse(currentTaxRate) / 100;
                int intTotalAmountInclusiveTax = Int32.Parse(totalAmount.Text);
                double doubleTotalAmountExclusiveTax = intTotalAmountInclusiveTax - (intTotalAmountInclusiveTax * currentTaxRateDouble);

                exTaxTv.Text = doubleTotalAmountExclusiveTax.ToString();

            } else {
                exTaxTv.Text = "-";
            }



        }


    }
}
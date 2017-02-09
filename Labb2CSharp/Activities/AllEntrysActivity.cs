
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
    [Activity(Label = "AllEntrysActivity")]



    public class AllEntrysActivity : Activity
    {
        BooksKeeperManager bk = BooksKeeperManager.Instance;
        private ListView entryList;


        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AllEntrysLo);

            entryList = FindViewById<ListView>(Resource.Id.all_entrys_list_lv);
            entryList.Adapter = new EntryAdapter(this, BooksKeeperManager.Instance.getAllEntrys());
        }
    }
}

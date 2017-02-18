using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;



namespace Labb2CSharp
{
    public class EntryAdapter : BaseAdapter
    {

        private Activity context;
        private List<Entry> entrys;

        public EntryAdapter(Activity activity, List<Entry> entrys) {
            this.context = activity;
            this.entrys = entrys;
        }



        public override int Count {
            get { return entrys.Count; }
        }

        public override Java.Lang.Object GetItem(int position) {
            return null;
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            View view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.Entry_List_Item, parent, false);

            view.FindViewById<TextView>(Resource.Id.entryID_tv).Text = "Händelse ID: " + entrys[position].EntryID;
            view.FindViewById<TextView>(Resource.Id.date_tv).Text = "Datum : " + entrys[position].DateOfEntry + "";
            view.FindViewById<TextView>(Resource.Id.typeAccounts_tv).Text = "Typ av händelse: " + entrys[position].TypeOfEntryID + " - " + entrys[position].TypeOfEntryName;

            return view;

        }
    }
}

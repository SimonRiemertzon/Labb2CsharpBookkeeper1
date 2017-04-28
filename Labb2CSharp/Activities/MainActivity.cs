using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Labb2CSharp
{
    [Activity(Label = "Huvudmeny", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Button newEntryButton = FindViewById<Button>(Resource.Id.new_entry_btn);
            Button allEntrysButton = FindViewById<Button>(Resource.Id.show_all_entrys_btn);

            newEntryButton.Click += delegate
            {
                Intent i = new Intent(this, typeof(NewEntryActivity));
                StartActivity(i);
            };

            allEntrysButton.Click += delegate
            {
                Intent i = new Intent(this, typeof(AllEntrysActivity));
                StartActivity(i);
            };

        }

    }
}


using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Labb2CSharp
{
    [Activity(Label = "Huvudmeny", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Button newEntryButton = FindViewById<Button>(Resource.Id.new_entry_btn);

            newEntryButton.Click += delegate
            {
                Intent i = new Intent(this, typeof(NewEntryActivity));
                StartActivity(i);
            };


        }
    }
}


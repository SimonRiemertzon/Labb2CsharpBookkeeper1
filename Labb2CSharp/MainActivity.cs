using Android.App;
using Android.Widget;
using Android.OS;

namespace Labb2CSharp
{
    [Activity(Label = "Labb2C#", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.Main);


        }
    }
}


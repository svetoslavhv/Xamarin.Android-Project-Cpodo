using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Cpodo.Activities;

namespace Cpodo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
		Button informationBtn;
		ImageButton congressImageBtn;
		ImageButton exhibitionAreaImageBtn;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			
            SetContentView(Resource.Layout.MainActivity);

			informationBtn = FindViewById<Button>(Resource.Id.informationBtn);
			informationBtn.Click += delegate
			{
				StartActivity(typeof(ContactInformationActivity));
				Finish();
			};

			congressImageBtn = FindViewById<ImageButton>(Resource.Id.congressImageBtn);
			congressImageBtn.Click += delegate
			{
				StartActivity(typeof(CongressActivity));
				Finish();
			};

			exhibitionAreaImageBtn = FindViewById<ImageButton>(Resource.Id.exhibitionAreaImageBtn);
			exhibitionAreaImageBtn.Click += delegate
			{
				StartActivity(typeof(ExhibitionAreaActivity));
				Finish();
			};

		}
		
	}
}
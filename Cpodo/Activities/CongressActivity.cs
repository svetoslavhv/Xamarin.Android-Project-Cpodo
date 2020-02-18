using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cpodo.Activities
{
	[Activity(Label = "CongressActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class CongressActivity : BaseActivity
	{
		ImageButton locationImageBtn;
		ImageButton congressMapImageBtn;
		ImageButton scheduleImageBtn;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CongressActivity);

			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};


			locationImageBtn = FindViewById<ImageButton>(Resource.Id.locationImageBtn);
			locationImageBtn.Click += delegate
			{
				StartActivity(typeof(LocationActivity));
				Finish();
			};

			scheduleImageBtn = FindViewById<ImageButton>(Resource.Id.scheduleImageBtn);
			scheduleImageBtn.Click += delegate
			{
				StartActivity(typeof(ScheduleActivity));
				Finish();
			};

			congressMapImageBtn = FindViewById<ImageButton>(Resource.Id.congressMapImageBtn);
			congressMapImageBtn.Click += delegate
			{
				//this prevents user to click the button several times while CongressMapActivity is loading
				congressMapImageBtn.Enabled = false;

				StartActivity(typeof(CongressMapActivity));
				Finish();
			};
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(MainActivity));
			Finish();
		}

	}
}
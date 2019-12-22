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
	[Activity(Label = "ContactInformationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ContactInformationActivity : Activity
	{
		ImageButton cityImageBtn;
		ImageButton palaceImageBtn;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.ContactInformationActivity);
			
			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				StartActivity(typeof(MainActivity));
				Finish();
			};

			cityImageBtn = FindViewById<ImageButton>(Resource.Id.cityImageBtn);
			cityImageBtn.Click += delegate
			{
				//TODO: open a website
			};

			palaceImageBtn = FindViewById<ImageButton>(Resource.Id.palaceImageBtn);
			palaceImageBtn.Click += delegate
			{
				var uri = Android.Net.Uri.Parse("https://www.palcongres-vlc.com/");
				var intent = new Intent(Intent.ActionView, uri);
				StartActivity(intent);
			};
		}
	}
}
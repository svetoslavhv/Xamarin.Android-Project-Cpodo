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
	public class CongressActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CongressActivity);

			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				StartActivity(typeof(MainActivity));
				Finish();
			};
		}
	
	}
}
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
	[Activity(Label = "CongressMapActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class CongressMapActivity : BaseActivity
	{
		Toolbar toolbar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CongressMapActivity);

			toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				StartActivity(typeof(CongressActivity));
				Finish();
			};
		}
	}
}
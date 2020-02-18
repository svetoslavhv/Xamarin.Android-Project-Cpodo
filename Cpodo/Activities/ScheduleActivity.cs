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

namespace Cpodo.Activities
{
	[Activity(Label = "ScheduleActivity")]
	public class ScheduleActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.ScheduleActivity);

			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(CongressActivity));
			Finish();
		}
	}
}
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
		TextView scheduleFridayTextView;
		TextView scheduleSaturdayTextView;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.ScheduleActivity);

			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};

			scheduleFridayTextView = FindViewById<TextView>(Resource.Id.scheduleFridayTextView);
			scheduleFridayTextView.Click += delegate
			{
				//change TextViews color
				scheduleSaturdayTextView.SetBackgroundResource(Resource.Drawable.schedule_textView_unselected);
				scheduleFridayTextView.SetBackgroundResource(Resource.Drawable.schedule_textView_selected);

				//TODO: Change recyclerview here
			};

			scheduleSaturdayTextView = FindViewById<TextView>(Resource.Id.scheduleSaturdayTextView);
			scheduleSaturdayTextView.Click += delegate
			{
				//change TextViews color
				scheduleFridayTextView.SetBackgroundResource(Resource.Drawable.schedule_textView_unselected);
				scheduleSaturdayTextView.SetBackgroundResource(Resource.Drawable.schedule_textView_selected);

				//TODO: Change recyclerview here
			};

		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(CongressActivity));
			Finish();
		}
	}
}
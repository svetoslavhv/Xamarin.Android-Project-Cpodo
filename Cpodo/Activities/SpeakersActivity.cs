using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Cpodo.Adapters;
using Cpodo.HelperClasses;
using Cpodo.Models;

namespace Cpodo.Activities
{
	[Activity(Label = "SpeakersActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class SpeakersActivity : BaseActivity
	{
		RecyclerView speakersRecyclerView;

		// Layout manager that lays out each card in the RecyclerView:
		RecyclerView.LayoutManager speakersLayoutManager;

		// Adapter that accesses the data set (speakers):
		SpeakersAdapter speakersAdapter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SpeakersActivity);

			Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};

			//get all speakers from the db
			List<Speaker> speakers = DatabaseHelper.GetAllFromTable<Speaker>("speakers.db");
			
			//fills RecyclerView with data
			speakersRecyclerView = FindViewById<RecyclerView>(Resource.Id.speakersRecyclerView);
			speakersLayoutManager = new LinearLayoutManager(this);
			speakersRecyclerView.SetLayoutManager(speakersLayoutManager);
			speakersAdapter = new SpeakersAdapter(speakers);
			speakersRecyclerView.SetAdapter(speakersAdapter);
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(CongressActivity));
			Finish();
		}
	}
}
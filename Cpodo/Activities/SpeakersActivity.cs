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

			List<Speaker> speakers = new List<Speaker>
			{
				new Speaker { Photo = "https://i.imgur.com/DDH2Ckk.png", Name = "Speaker 1", Resume = "Resume1, Resume1, Resume1, Resume1, Resume1, Resume1" },
				new Speaker { Photo = "https://i.imgur.com/DDH2Ckk.png", Name = "Speaker 2", Resume = "Resume2, Resume2, Resume2, Resume2, Resume2, Resume2" },
				new Speaker { Photo = "https://i.imgur.com/DDH2Ckk.png", Name = "Speaker 3", Resume = "Resume3, Resume3, Resume3, Resume3, Resume3, Resume3" },
			};

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
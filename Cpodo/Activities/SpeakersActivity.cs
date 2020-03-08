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
		TextView internationalSpeakersTextView;

		TextView nationalSpeakersTextView;

		RecyclerView speakersRecyclerView;

		// Layout manager that lays out each card in the RecyclerView:
		RecyclerView.LayoutManager speakersLayoutManager;

		// Adapter that accesses the data set (speakers):
		SpeakersAdapter speakersAdapter;
		
		List<Speaker> speakers;
			
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SpeakersActivity);

			Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				this.OnBackPressed();
			};
			
			speakersRecyclerView = FindViewById<RecyclerView>(Resource.Id.speakersRecyclerView);
			speakersLayoutManager = new LinearLayoutManager(this);
			speakersRecyclerView.SetLayoutManager(speakersLayoutManager);
			LoadSpeakers("international");

			internationalSpeakersTextView = FindViewById<TextView>(Resource.Id.internationalSpeakersTextView);
			internationalSpeakersTextView.Click += delegate
			{
				//change TextViews's style when selected/not-selected
				internationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				nationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);

				LoadSpeakers("international");
			};

			nationalSpeakersTextView = FindViewById<TextView>(Resource.Id.nationalSpeakersTextView);
			nationalSpeakersTextView.Click += delegate
			{
				//change TextViews's style when selected/not-selected
				nationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				internationalSpeakersTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);

				LoadSpeakers("national");
			};
		}

		/// <summary>
		/// Load speakers inside activity
		/// </summary>
		/// <param name="speakerType">type of speaker</param>
		private void LoadSpeakers(string speakerType)
		{
			//get all speakers from the db 
			//TODO: get only spekaers of given speakerType
			speakers = DatabaseHelper.GetAllFromTable<Speaker>("speakers.db");

			speakersAdapter = new SpeakersAdapter(speakers);
			speakersAdapter.ItemClick += OnItemClick;
			speakersRecyclerView.SetAdapter(speakersAdapter);
		}

		private void OnItemClick(object sender, string speakerResumeUrl)
		{
			var speakerDetailsActivity = new Intent(this, typeof(SpeakerDetailsActivity));
			speakerDetailsActivity.PutExtra("speakerResumeUrl", speakerResumeUrl);
			StartActivity(speakerDetailsActivity);
			Finish();
		}

		public override void OnBackPressed()
		{
			StartActivity(typeof(CongressActivity));
			Finish();
		}
	}
}
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
using Cpodo.Fragments;

namespace Cpodo.Activities
{
	[Activity(Label = "CongressMapActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class CongressMapActivity : BaseActivity
	{
		Toolbar toolbar;

		TextView exhibitionAreaTextView;
		TextView multipurposeRoomTextView;

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

			exhibitionAreaTextView = FindViewById<TextView>(Resource.Id.exhibitionAreaTextView);
			multipurposeRoomTextView = FindViewById<TextView>(Resource.Id.multipurposeRoomTextView);

			ExhibitionAreaFragment exhibitionAreaFragment = new ExhibitionAreaFragment();
			MultipurposeRoomFragment multipurposeRoomFragment = new MultipurposeRoomFragment();

			SupportFragmentManager.BeginTransaction().Add(Resource.Id.imageZoneLinearLayout, exhibitionAreaFragment).Commit();

			exhibitionAreaTextView.Click += delegate
			{
				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.imageZoneLinearLayout, exhibitionAreaFragment).Commit();
			};

			multipurposeRoomTextView.Click += delegate
			{
				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.imageZoneLinearLayout, multipurposeRoomFragment).Commit();
			};
		}
	}
}
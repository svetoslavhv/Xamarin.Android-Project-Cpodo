using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
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
				//change one fragment for another
				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.imageZoneLinearLayout, exhibitionAreaFragment).Commit();

				ChangeTextViewsColor("exhibitionAreaTextView");
			};

			multipurposeRoomTextView.Click += delegate
			{
				//change one fragment for another
				SupportFragmentManager.BeginTransaction().Replace(Resource.Id.imageZoneLinearLayout, multipurposeRoomFragment).Commit();

				ChangeTextViewsColor("multipurposeRoomTextView");
			};
		}

		/// <summary>
		/// Method which changes the color of the TextViews
		/// </summary>
		/// <param name="textViewClicked">the TextView which was clicked</param>
		private void ChangeTextViewsColor(string textViewClicked)
		{
			if(textViewClicked.Equals("exhibitionAreaTextView"))
			{
				exhibitionAreaTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				exhibitionAreaTextView.SetTextColor(Color.White);

				multipurposeRoomTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);
				multipurposeRoomTextView.SetTextColor(ContextCompat.GetColorStateList(Application.Context, Resource.Color.appColor));
			}

			if (textViewClicked.Equals("multipurposeRoomTextView"))
			{
				multipurposeRoomTextView.SetBackgroundResource(Resource.Drawable.textView_selected);
				multipurposeRoomTextView.SetTextColor(Color.White);

				exhibitionAreaTextView.SetBackgroundResource(Resource.Drawable.textView_unselected);
				exhibitionAreaTextView.SetTextColor(ContextCompat.GetColorStateList(Application.Context, Resource.Color.appColor));
			}
		}
	}
}
﻿using System;
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
	[Activity(Label = "LocationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class LocationActivity : Activity
	{
		ImageButton informationImageBtn;
		ImageButton locationImageBtn;
		ImageButton mapImageBtn;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			
			SetContentView(Resource.Layout.LocationActivity);

			//TODO: try placing that in BaseActivity
			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.NavigationOnClick += delegate
			{
				StartActivity(typeof(CongressActivity));
				Finish();
			};

			informationImageBtn = FindViewById<ImageButton>(Resource.Id.informationImageBtn);
			informationImageBtn.Click += delegate
			{
				var uri = Android.Net.Uri.Parse("https://www.palcongres-vlc.com/");
				var intent = new Intent(Intent.ActionView, uri);
				StartActivity(intent);
			};

			locationImageBtn = FindViewById<ImageButton>(Resource.Id.locationImageBtn);
			locationImageBtn.Click += delegate
			{
				var geoUri = Android.Net.Uri.Parse("geo:0,0?q=Avinguda+de+les+Corts+Valencianes,+60,+46015+València");
				var mapIntent = new Intent(Intent.ActionView, geoUri);
				StartActivity(mapIntent);
			};

			mapImageBtn = FindViewById<ImageButton>(Resource.Id.mapImageBtn);
			mapImageBtn.Click += delegate
			{
				StartActivity(typeof(MapActivity));
				Finish();
			};
		}
	}
}
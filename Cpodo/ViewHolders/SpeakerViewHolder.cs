using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Cpodo.ViewHolders
{
	public class SpeakerViewHolder : RecyclerView.ViewHolder
	{
		public ImageView speakerPhotoImageView { get; private set; }
		public TextView speakerNameTextView { get; private set; }
		public TextView speakerResumeTextView { get; private set; }

		// Get references to the views defined in the CardView layout.
		public SpeakerViewHolder(View itemView)
			: base(itemView)
		{
			// Locate and cache view references:
			speakerPhotoImageView = itemView.FindViewById<ImageView>(Resource.Id.speakerPhotoImageView);
			speakerNameTextView = itemView.FindViewById<TextView>(Resource.Id.speakerNameTextView);
			speakerResumeTextView = itemView.FindViewById<TextView>(Resource.Id.speakerResumeTextView);
		}
	}
}
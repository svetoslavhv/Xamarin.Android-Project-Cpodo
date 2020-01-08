using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Cpodo.Activities
{
	[Activity(Label = "BaseActivity")]
	public class BaseActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		//TODO: Put comment here
		protected override void AttachBaseContext(Context context)
		{
			base.AttachBaseContext(Calligraphy.CalligraphyContextWrapper.Wrap(context));
		}
	}
}
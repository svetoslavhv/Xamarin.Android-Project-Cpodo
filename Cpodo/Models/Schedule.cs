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

namespace Cpodo.Models
{
	public class Schedule
	{
		public int Id { get; set; }

		public string Day { get; set; }

		public string Hour { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

	}
}
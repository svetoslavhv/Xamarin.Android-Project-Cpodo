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

namespace Cpodo.HelperClasses
{
	public static class DatabaseHelper
	{
		public static List<T> GetAllFromTable<T>() where T: new()
		{
			using (var connection = new SQLiteConnection(System.IO.Path.Combine(GlobalVariables.databasePath, "MobileSell.db")))
			{
				try
				{
					var all = connection.Table<T>().ToList();
					return all;
				}
				catch (Exception ex)
				{
					return null;

				}
			}
		}
	}
}
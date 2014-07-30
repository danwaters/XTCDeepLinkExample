
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

namespace DeepLinks.Android
{
	[Activity(Label = "Deeply Linked App Activity")]
	[IntentFilter(new String[] {Intent.ActionView, Intent.ActionDefault },
		Categories = new string[] {Intent.CategoryDefault, Intent.CategoryBrowsable},
		DataScheme="example",
		DataHost="deeplink")]
	public class DeeplyLinkedActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.DeeplyLinkedLayout);
		}
	}


}


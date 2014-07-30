using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Webkit;

namespace DeepLinks.Android
{
	[Activity (Label = "DeepLinks.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				var webView = new WebView(this);
				webView.Settings.JavaScriptEnabled = true;
				webView.SetWebViewClient(new TestWebViewClient());
				webView.LoadUrl("http://singlecoilstudios.com/deeplink.html");

				SetContentView(webView);
			};
		}
	}

	public class TestWebViewClient : WebViewClient
	{
		public override bool ShouldOverrideUrlLoading (WebView view, string url)
		{
			try {
				var intent = new Intent(Intent.ActionView);
				intent.SetData(global::Android.Net.Uri.Parse(url));
				//WebViewActivity.this.startActivity(intent);
				view.Context.StartActivity(intent);

			}   catch(ActivityNotFoundException e) {

			}

			return base.ShouldOverrideUrlLoading(view, url);  
		}
	}
}



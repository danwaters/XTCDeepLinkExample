using NUnit.Framework;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Shouldly;
using System.Linq;

namespace DeepLinkTests
{
	[TestFixture]
	public class DeepLinkingTests
	{
		private AndroidApp app;
		private const string APKPATH = "../../../DeepLinks.Android/DeepLinks.Android.apk";

		[SetUp]
		public void Setup()
		{
			app = ConfigureApp.Android.ApkFile (APKPATH).StartApp ();
		}

		[Test]
		public void NavigatingToDeepLinkShouldOpenPage ()
		{	
			var expectedText = "This screen was deeply linked!";

			app.WaitForElement (c => c.Id ("myButton"));
			app.Screenshot ("Given I am on the main page");

			app.Tap (c => c.Id ("myButton"));
			app.Screenshot ("And I tap the button");

			app.WaitForElement (c => c.Class ("WebView"));
			app.WaitForElement (c => c.Css (".deeplink"));
			app.Screenshot ("Then I see the deep link in a web page");
			app.Tap (c => c.Css (".deeplink"));

			app.WaitForElement (c => c.Id ("deeplyLinkedText"));
			app.Screenshot ("Then I see the screen I linked to");

			app.Query (c => c.Id ("deeplyLinkedText")).Single ().Text.ShouldBe (expectedText);
			app.Screenshot (string.Format("And the text should be '{0}'", expectedText));
		}
	}
}


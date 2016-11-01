using System;
using Foundation;

using UIKit;

namespace phoneword.iOS
{
	public partial class ViewController : UIViewController
	{
		FirstView v;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			v = FirstView.Create();
			v.Frame = View.Frame;
			View.AddSubview(v);

			string translatedNumber = "";

			v.TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				// Convert the phone number with text to a number
				// using PhoneTranslator.cs
				translatedNumber = PhoneTranslator.ToNumber(
					v.PhonewordText.Text);

				// Dismiss the keyboard if text field was tapped
				v.PhonewordText.ResignFirstResponder();

				if (translatedNumber == "")
				{
					v.CallButton.SetTitle("Call ", UIControlState.Normal);
					v.CallButton.Enabled = false;
				}
				else {
					v.CallButton.SetTitle("Call " + translatedNumber,
						UIControlState.Normal);
					v.CallButton.Enabled = true;
				}
			};

			v.CallButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				// Use URL handler with tel: prefix to invoke Apple's Phone app...
				var url = new NSUrl("tel:" + translatedNumber);

				// ...otherwise show an alert dialog
				if (!UIApplication.SharedApplication.OpenUrl(url))
				{
					var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
					PresentViewController(alert, true, null);
				}
			};
		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}

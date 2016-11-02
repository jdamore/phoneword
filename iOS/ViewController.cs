using System;
using Foundation;

using UIKit;

namespace phoneword.iOS
{
	public partial class ViewController : UIViewController
	{
		FirstView firstView;

		private void translateEventHandler(object sender, EventArgs e)
		{
			string translatedNumber = "";
			translatedNumber = PhoneTranslator.ToNumber(firstView.GetPhonewordText().Text);
			firstView.GetPhonewordText().ResignFirstResponder();
			if (translatedNumber == "")
			{
				firstView.GetCallButton().SetTitle("Call ", UIControlState.Normal);
				firstView.GetCallButton().Enabled = false;
			}
			else {
				firstView.GetCallButton().SetTitle("Call " + translatedNumber, UIControlState.Normal);
				firstView.GetCallButton().Enabled = true;
			}
		}

		private void callEventHandler(object sender, EventArgs e)
		{
			string translatedNumber = "";
			translatedNumber = PhoneTranslator.ToNumber(firstView.GetPhonewordText().Text);
			var url = new NSUrl("tel:" + translatedNumber);

			if (!UIApplication.SharedApplication.OpenUrl(url))
			{
				var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(alert, true, null);
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			firstView = FirstView.Create();
			firstView.Frame = View.Frame;
			firstView.GetTranslateButton().TouchUpInside += this.translateEventHandler;
			firstView.GetCallButton().TouchUpInside += this.callEventHandler;
			View.AddSubview(firstView);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}

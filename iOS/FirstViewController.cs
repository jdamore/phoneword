using System;
using Foundation;

using UIKit;

namespace phoneword.iOS
{
	public partial class FirstViewController : UIViewController
	{
		FirstView view;

		private void translateEventHandler(object sender, EventArgs e)
		{
			string translatedNumber = "";
			translatedNumber = PhoneTranslator.ToNumber(view.GetPhonewordText().Text);
			view.GetPhonewordText().ResignFirstResponder();
			if (translatedNumber == "")
			{
				view.GetCallButton().SetTitle("Call ", UIControlState.Normal);
				view.GetCallButton().Enabled = false;
			}
			else {
				view.GetCallButton().SetTitle("Call " + translatedNumber, UIControlState.Normal);
				view.GetCallButton().Enabled = true;
			}
		}

		private void callEventHandler(object sender, EventArgs e)
		{
			string translatedNumber = "";
			translatedNumber = PhoneTranslator.ToNumber(view.GetPhonewordText().Text);
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
			view = FirstView.Create();
			view.Frame = View.Frame;
			view.GetTranslateButton().TouchUpInside += this.translateEventHandler;
			view.GetCallButton().TouchUpInside += this.callEventHandler;
			View.AddSubview(view);

		}
	}
}

using System;
using Foundation;

using UIKit;

namespace phoneword.iOS
{
	public partial class ViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			FirstViewController firstViewController = new FirstViewController();
			//PresentViewController(firstViewController, true, null);
			View.AddSubview(firstViewController.View);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}

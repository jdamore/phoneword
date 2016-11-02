using System;
using Foundation;

using UIKit;

namespace phoneword.iOS
{
	public partial class RootViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			FirstViewController firstViewController = new FirstViewController();
			View.AddSubview(firstViewController.View);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}

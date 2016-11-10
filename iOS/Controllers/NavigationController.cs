using System;
using Foundation;

using UIKit;

namespace phoneword.iOS
{
	public class NavigationController : UINavigationController
	{
		PhonewordViewController phonewordViewController;
		FlipitViewController flipitViewController;

		public NavigationController() 
		{
			phonewordViewController = new PhonewordViewController();
			flipitViewController = new FlipitViewController();
			PushViewController(phonewordViewController, true);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if (Toggle.Value("ViewFlipit"))
			{
				phonewordViewController.NavigationItem.SetRightBarButtonItem(
					new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, args) =>
					{
						PushViewController(flipitViewController, true);
					}
				), true);
			}

		}
	}
}

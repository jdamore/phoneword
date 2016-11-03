using System;

using UIKit;

namespace phoneword.iOS
{
	public partial class FlipitViewController : UIViewController
	{
		FlipitView view;

		public FlipitViewController()
		{
			this.Title = "Flipit!";
			view = FlipitView.Create();
			view.Frame = View.Frame;
			View = view;
		}
	}
}


using Foundation;
using System;
using UIKit;
using ObjCRuntime;

namespace phoneword.iOS
{
    public partial class FlipitView : UIWebView
    {
		private static string url = "http://flipit.corsamore.com";

        public FlipitView (IntPtr handle) : base (handle)
        {
        }

		public static FlipitView Create()
		{
			var arr = NSBundle.MainBundle.LoadNib("FlipitView", null, null);
			var v = Runtime.GetNSObject<FlipitView>(arr.ValueAt(0));
			v.LoadRequest(new NSUrlRequest(new NSUrl(url)));
			v.ScalesPageToFit = true;
			return v;
		}
    }
}
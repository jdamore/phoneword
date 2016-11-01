using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ObjCRuntime;

namespace phoneword.iOS
{
    public partial class FirstView : UIView
    {
        public FirstView (IntPtr handle) : base (handle)
        {
        }

		public static FirstView Create()
		{

			var arr = NSBundle.MainBundle.LoadNib("FirstView", null, null);
			var v = Runtime.GetNSObject<FirstView>(arr.ValueAt(0));

			return v;
		}

		public override void AwakeFromNib()
		{
			//PhonewordLabel.Text = "hello from the View class";
		}
    }
}
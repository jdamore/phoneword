using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ObjCRuntime;

namespace phoneword.iOS
{
    public partial class PhonewordView : UIView
    {
        public PhonewordView (IntPtr handle) : base (handle)
        {
        }

		public static PhonewordView Create()
		{
			var arr = NSBundle.MainBundle.LoadNib("PhonewordView", null, null);
			var v = Runtime.GetNSObject<PhonewordView>(arr.ValueAt(0));
			return v;
		}

		public override void AwakeFromNib()
		{
			//PhonewordLabel.Text = "hello from the View class";
		}

		public UIKit.UIButton GetCallButton()
		{
			return CallButton;
		}

		public UIKit.UIButton GetTranslateButton()
		{
			return TranslateButton;
		}

		public UIKit.UITextField GetPhonewordText()
		{
			return PhonewordText;
		}
    }
}
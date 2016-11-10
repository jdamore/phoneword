using System;
using Foundation;

namespace phoneword.iOS
{
	public static class Toggle
	{
		public static Boolean Value(String toggle)
		{
			#if DEBUG
				return NSUserDefaults.StandardUserDefaults.BoolForKey(toggle);
			#else
				return false;
			#endif
		}
	}
}

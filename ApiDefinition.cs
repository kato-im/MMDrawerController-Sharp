using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MMDrawerControllerSharp
{
	[BaseType (typeof(UIViewController))]
	public interface MMDrawerController
	{
		[Export("initWithCenterViewController:leftDrawerViewController:rightDrawerViewController:")]
		IntPtr Constructor(UIViewController centerViewController,
			[NullAllowed] UIViewController leftDrawerViewController,
			[NullAllowed] UIViewController rightDrawerViewController);

		[Export("leftDrawerViewController")]
		UIViewController LeftDrawerViewController { get; set; }

		[Export("rightDrawerViewController")]
		UIViewController RightDrawerViewController { get; set; }

		[Export("toggleDrawerSide:animated:completion:")]
		void ToggleDrawerSide(MMDrawerSide drawerSide, bool animated, IntPtr completion);
	}
}


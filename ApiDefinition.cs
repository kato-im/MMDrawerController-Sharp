using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MMDrawerControllerSharp
{
	[BaseType (typeof(UIViewController))]
	interface MMDrawerController
	{
		[Export("initWithCenterViewController:")]
		IntPtr Constructor(UIViewController centerViewController);

		[Export("initWithCenterViewController:leftDrawerViewController:")]
		IntPtr Constructor(UIViewController centerViewController, UIViewController leftDrawerViewController);

		[Export("toggleDrawerSide:animated:completion:")]
		void ToggleDrawerSide(MMDrawerSide drawerSide, bool animated, IntPtr completion);
	}
}


using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MMDrawerController
{
	[BaseType (typeof(UIViewController), Name = "MMDrawerController")]
	public interface DrawerController
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


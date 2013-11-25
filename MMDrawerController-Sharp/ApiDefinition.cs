using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MMDrawerControllerSharp
{
	[BaseType (typeof(UIViewController))]
	interface MMDrawerController
	{
		[Export("initWithCenterViewController:leftDrawerViewController")]
		IntPtr Constructor(UIViewController centerViewController, UIViewController leftDrawerViewController);
	}
}


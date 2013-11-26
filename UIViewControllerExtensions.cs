using System;
using MonoTouch.UIKit;

namespace MMDrawerController
{
	public static class UIViewControllerExtensions
	{
		public static DrawerController GetDrawerController(this UIViewController controller)
		{
			var parent = controller.ParentViewController;
			while (parent != null && !(parent is DrawerController))
			{
				parent = parent.ParentViewController;
			}

			return parent as DrawerController;
		}
	}
}


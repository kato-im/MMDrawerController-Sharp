using System;
using MonoTouch.UIKit;

namespace MMDrawerControllerSharp
{
	public static class UIViewControllerExtensions
	{
		public static MMDrawerController GetDrawerController(this UIViewController controller)
		{
			var parent = controller.ParentViewController;
			while (parent != null && !(parent is MMDrawerController))
			{
				parent = parent.ParentViewController;
			}

			return parent as MMDrawerController;
		}
	}
}


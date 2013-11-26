using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace MMDrawerController
{
	public delegate void Finished(bool finished);
	public delegate void VisualState(DrawerController drawerController, MMDrawerSide drawerSide, Single percentVisible);

	[BaseType (typeof(UIViewController), Name = "MMDrawerController")]
	public interface DrawerController
	{
		[Export ("initWithCenterViewController:leftDrawerViewController:rightDrawerViewController:")]
		IntPtr Constructor (UIViewController centerViewController,
			[NullAllowed] UIViewController leftDrawerViewController,
			[NullAllowed] UIViewController rightDrawerViewController);

		[Export ("centerViewController", ArgumentSemantic.Retain)]
		UIViewController CenterViewController { get; set; }

		[Export ("leftDrawerViewController", ArgumentSemantic.Retain)]
		UIViewController LeftDrawerViewController { get; set; }

		[Export ("rightDrawerViewController", ArgumentSemantic.Retain)]
		UIViewController RightDrawerViewController { get; set; }

		[Export ("maximumLeftDrawerWidth")]
		float MaximumLeftDrawerWidth { get; set; }

		[Export ("maximumRightDrawerWidth")]
		float MaximumRightDrawerWidth { get; set; }

		[Export ("visibleLeftDrawerWidth")]
		float VisibleLeftDrawerWidth { get; }

		[Export ("visibleRightDrawerWidth")]
		float VisibleRightDrawerWidth { get; }

		[Export ("animationVelocity")]
		float AnimationVelocity { get; set; }

		[Export ("shouldStretchDrawer")]
		bool ShouldStretchDrawer { get; set; }

		[Export ("openSide")]
		MMDrawerSide OpenSide { get; }

		[Export ("openDrawerGestureModeMask")]
		MMOpenDrawerGestureMode OpenDrawerGestureModeMask { get; set; }

		[Export ("closeDrawerGestureModeMask")]
		MMCloseDrawerGestureMode CloseDrawerGestureModeMask { get; set; }

		[Export ("centerHiddenInteractionMode")]
		MMDrawerOpenCenterInteractionMode CenterHiddenInteractionMode { get; set; }

		[Export ("showsShadow")]
		bool ShowsShadow { get; set; }

		[Export ("showsStatusBarBackgroundView")]
		bool ShowsStatusBarBackgroundView { get; set; }

		[Export ("statusBarViewBackgroundColor", ArgumentSemantic.Retain)]
		UIColor StatusBarViewBackgroundColor { get; set; }

		[Export ("toggleDrawerSide:animated:completion:")]
		void ToggleDrawerSide (MMDrawerSide drawerSide, bool animated, [BlockCallback] Finished completion);

		[Export ("closeDrawerAnimated:completion:")]
		void CloseDrawerAnimated (bool animated, [BlockCallback] Finished completion);

		[Export ("openDrawerSide:animated:completion:")]
		void OpenDrawerSide (MMDrawerSide drawerSide, bool animated, [BlockCallback] Finished completion);

		[Export ("setCenterViewController:withCloseAnimation:completion:")]
		void SetCenterViewController (UIViewController centerViewController, bool closeAnimated, [BlockCallback] Finished completion);

		[Export ("setCenterViewController:withFullCloseAnimation:completion:")]
		void SetCenterViewControllerFull (UIViewController newCenterViewController, bool fullCloseAnimated, [BlockCallback] Finished completion);

		[Export ("setMaximumLeftDrawerWidth:animated:completion:")]
		void SetMaximumLeftDrawerWidth (float width, bool animated, [BlockCallback] Finished completion);

		[Export ("setMaximumRightDrawerWidth:animated:completion:")]
		void SetMaximumRightDrawerWidth (float width, bool animated, [BlockCallback] Finished completion);

		[Export ("bouncePreviewForDrawerSide:completion:")]
		void BouncePreviewForDrawerSide (MMDrawerSide drawerSide, [BlockCallback] Finished completion);

		[Export ("bouncePreviewForDrawerSide:distance:completion:")]
		void BouncePreviewForDrawerSide (MMDrawerSide drawerSide, float distance, [BlockCallback] Finished completion);

		[Export ("drawerVisualStateBlock")]
		VisualState DrawerVisualStateBlock { set; }

		[Export ("gestureCompletionBlock")]
		VisualState GestureCompletionBlock { set; }

		[Export ("gestureShouldRecognizeTouchBlock")]
		VisualState GestureShouldRecognizeTouchBlock { set; }
	}

	[Category, BaseType (typeof (DrawerController))]
	public partial interface Subclass_MMDrawerController {

		[Export ("tapGestureCallback:")]
		void TapGestureCallback (UITapGestureRecognizer tapGesture);

		[Export ("panGestureCallback:")]
		void PanGestureCallback (UIPanGestureRecognizer panGesture);

		[Export ("gestureRecognizer:shouldReceiveTouch:")]
		bool GestureRecognizer (UIGestureRecognizer gestureRecognizer, UITouch touch);

		[Export ("prepareToPresentDrawer:animated:")]
		void PrepareToPresentDrawer (MMDrawerSide drawer, bool animated);

		[Export ("closeDrawerAnimated:velocity:animationOptions:completion:")]
		void CloseDrawerAnimated (bool animated, float velocity, UIViewAnimationOptions options, [BlockCallback] Finished completion);

		[Export ("openDrawerSide:animated:velocity:animationOptions:completion:")]
		void OpenDrawerSide (MMDrawerSide drawerSide, bool animated, float velocity, UIViewAnimationOptions options, [BlockCallback] Finished completion);

		[Export ("willRotateToInterfaceOrientation:duration:")]
		void WillRotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation, double duration);

		[Export ("willAnimateRotationToInterfaceOrientation:duration:")]
		void WillAnimateRotationToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation, double duration);
	}

	[BaseType (typeof(UIBarButtonItem), Name = "MMDrawerBarButtonItem")]
	public interface DrawerBarButtonItem
	{
		[Export ("initWithTarget:action:")]
		IntPtr Constructor (NSObject target, Selector action);

		[Export ("menuButtonColorForState:")]
		UIColor MenuButtonColorForState (UIControlState state);

		[Export ("setMenuButtonColor:forState:")]
		void SetMenuButtonColor (UIColor color, UIControlState state);

		[Export ("shadowColorForState:")]
		UIColor ShadowColorForState (UIControlState state);

		[Export ("setShadowColor:forState:")]
		void SetShadowColor (UIColor color, UIControlState state);
	}
}


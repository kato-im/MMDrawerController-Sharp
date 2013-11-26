using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMMDrawerController.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]

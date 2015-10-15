using System;
using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Glossaries.IOS
{
	public abstract class BaseViewController : MvxViewController{
		protected Glossaries.Core.Interfaces.IVisible VisibleViewModel {
			get { return base.ViewModel as Glossaries.Core.Interfaces.IVisible; }
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			VisibleViewModel.IsVisible (true);
		}
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			VisibleViewModel.IsVisible (false);
		}
	}
}

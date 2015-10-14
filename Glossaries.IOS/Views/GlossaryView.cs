using System;
using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Glossaries.IOS
{
	[Register("GlossaryView")]
	public class GlossaryView : MvxViewController
		{
			public override void ViewDidLoad()
		{
			View = new UIView { BackgroundColor = UIColor.White };
			base.ViewDidLoad ();

			// ios7 layout
			if (RespondsToSelector (new Selector ("edgesForExtendedLayout"))) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}

			var screenBounds = UIScreen.MainScreen.Bounds;

			var lblGlossary = new UILabel (new CGRect (10, 10, screenBounds.Width-20, 40));
			lblGlossary.Text = "Glossary:";
			Add (lblGlossary);

			var txtGlossary = new UITextField (new CGRect (10, 60, screenBounds.Width-20, 40));
			Add (txtGlossary);

			var lblDescription = new UILabel (new CGRect (10, 110, screenBounds.Width-20, 40));
			lblDescription.Text = "Description:";
			Add (lblDescription);

			var txtDescription = new UITextView (new CGRect (10, 160, screenBounds.Width-20, screenBounds.Height - 350));
			Add (txtDescription);

			var txtMaxCount = new UITextField (new CGRect (10, screenBounds.Height - 180, screenBounds.Width-20, 40));
			txtMaxCount.TextAlignment = UITextAlignment.Right;
			Add (txtMaxCount);

			var btnAdd = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			this.NavigationItem.SetRightBarButtonItem(btnAdd, true);

			var set = this.CreateBindingSet<GlossaryView, Core.ViewModels.GlossaryViewModel> ();
			set.Bind (txtGlossary).To (vm => vm.Name);
			set.Bind (txtDescription).To (vm => vm.Description);
			set.Bind (txtMaxCount).To (vm => vm.Description).WithConversion("StringLength");
			set.Bind (btnAdd).To (vm => vm.AddGlossaryCommand);
			set.Apply ();
		}
	}
}

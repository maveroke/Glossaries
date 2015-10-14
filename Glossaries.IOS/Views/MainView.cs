using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Glossaries.IOS.Views
{
    [Register("MainView")]
	public class MainView : MvxViewController
    {
        public override void ViewDidLoad()
        {
			View = new UIView { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
               EdgesForExtendedLayout = UIRectEdge.None;
            }

			var screenBounds = UIScreen.MainScreen.Bounds;
			var table = new UITableView(new CGRect(0, 0, screenBounds.Width, screenBounds.Height-40));
			Add(table);

			var source = new MvxStandardTableViewSource (table, "TitleText Name; ItemClick AddGlossaryCommand");
			table.Source = source;

			var btnAdd = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			this.SetToolbarItems( new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),btnAdd}
				, false);
			
			this.NavigationController.ToolbarHidden = false;

			var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(table).To(vm => vm.Glossaries);
			set.Bind (btnAdd).To (vm => vm.AddGlossaryCommand);
            set.Apply();
			table.ReloadData ();
        }
    }
}
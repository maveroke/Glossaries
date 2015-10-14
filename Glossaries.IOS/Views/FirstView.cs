using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Glossaries.IOS.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
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
			   
            var label = new UILabel(new CGRect(10, 10, 300, 40));
			Add(label);
			var textField = new UITextField(new CGRect(10, 50, 300, 40));
			Add(textField);

			var button = new UIButton(new CGRect(10, 90, 300, 40));
			button.SetTitle ("Parse!",UIControlState.Normal);
			button.SetTitleColor (UIColor.Black,UIControlState.Normal);
			Add(button);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(label).To(vm => vm.Hello);
            set.Bind(textField).To(vm => vm.Hello);
			set.Bind (button).To (vm => vm.ParseCommand);
            set.Apply();
        }
    }
}
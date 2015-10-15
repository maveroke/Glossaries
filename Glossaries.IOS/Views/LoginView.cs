using System;
using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Glossaries.IOS
{
	[Register("LoginView")]
	public class LoginView : BaseViewController
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
			var halfScreenHeight = screenBounds.Height / 2;

			var loginBox = new UIView(new CGRect (20, halfScreenHeight - 80, screenBounds.Width-40, 160));
			loginBox.BackgroundColor = UIColor.LightGray;
			Add (loginBox);

			var txtEmail = new UITextField (new CGRect (10, 10, loginBox.Bounds.Width-20, 40));
			txtEmail.Placeholder = "Email Address";
			txtEmail.TextAlignment = UITextAlignment.Center;
			txtEmail.BackgroundColor = UIColor.White;
			txtEmail.KeyboardType = UIKeyboardType.EmailAddress;
			loginBox.Add (txtEmail);

			var txtPassword = new UITextField (new CGRect (10, 60, loginBox.Bounds.Width-20, 40));
			txtPassword.Placeholder = "Password";
			txtPassword.TextAlignment = UITextAlignment.Center;
			txtPassword.BackgroundColor = UIColor.White;
			txtPassword.SecureTextEntry = true;
			loginBox.Add (txtPassword);

			var btnLogin = new UIButton (new CGRect (10, 110, loginBox.Bounds.Width/2-20, 40));
			btnLogin.SetTitle ("Log In", UIControlState.Normal);
			btnLogin.SetTitleColor (UIColor.White, UIControlState.Normal);
			btnLogin.BackgroundColor = UIColor.Blue;
			loginBox.Add (btnLogin);

			var btnSignUp = new UIButton (new CGRect (loginBox.Bounds.Width/2 + 10, 110, loginBox.Bounds.Width/2-20, 40));
			btnSignUp.SetTitle ("Sign Up", UIControlState.Normal);
			btnSignUp.SetTitleColor (UIColor.Blue, UIControlState.Normal);
			loginBox.Add (btnSignUp);

			this.NavigationItem.SetHidesBackButton (true, true);

			var set = this.CreateBindingSet<LoginView, Core.ViewModels.LoginViewModel> ();
			set.Bind (txtEmail).To (vm => vm.EmailAddress);
			set.Bind (txtPassword).To (vm => vm.Password);
			set.Bind (btnLogin).To (vm => vm.LoginCommand);
			set.Bind (btnSignUp).To (vm => vm.SignUpCommand);
			set.Apply ();
		}
	}
}

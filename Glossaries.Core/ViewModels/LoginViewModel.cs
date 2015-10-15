using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;
using System.Collections.ObjectModel;
using Racing.Core.Services;
using Xamarin.Forms;
using Glossaries.Model;
using System;
using Glossaries.Core.Interfaces;
using Cirrious.CrossCore;
using Chance.MvvmCross.Plugins.UserInteraction;

namespace Glossaries.Core.ViewModels
{
	public class LoginViewModel : MvxViewModel,IVisible
	{
		private IUserService userService;
		private bool waitForResponse;
		public LoginViewModel(IUserService userService){
			this.userService = userService;
			MessagingCenter.Subscribe<UserMessenger> (this, "Login", (sender) => {
				if (sender.UserModel != null) {
					ShowViewModel<MainViewModel> (new { userId = sender.UserModel.Id});
				} else {
					//Unsuccessful
					Mvx.Resolve<IUserInteraction>().Alert("Incorrect Username or Password");
				}
				waitForResponse = false;
			});
		}

		private string emailAddress;
		public string EmailAddress
		{ 
			get { return this.emailAddress; }
			set { this.emailAddress = value; RaisePropertyChanged(() => EmailAddress); }
		}

		private string password;
		public string Password
		{ 
			get { return this.password; }
			set { this.password = value; RaisePropertyChanged(() => Password); }
		}

		private ICommand loginCommand;

		public ICommand LoginCommand {
			get {
				if (this.loginCommand == null) {
					this.loginCommand = new MvxCommand (() => {
						Login();
					});
				}
				return this.loginCommand;
			}
		}

		private ICommand signUpCommand;

		public ICommand SignUpCommand {
			get {
				if (this.signUpCommand == null) {
					this.signUpCommand = new MvxCommand (() => {
						SignUp();
					});
				}
				return this.signUpCommand;
			}
		}

		public bool SignUp ()
		{
			var isSuccess = false;
			var errorMessage = String.Empty;
			if (!waitForResponse) {
				this.waitForResponse = true;
				if (String.IsNullOrEmpty (this.EmailAddress) || String.IsNullOrWhiteSpace (this.EmailAddress) ||
				   String.IsNullOrEmpty (this.Password)) {
					Mvx.Resolve<IUserInteraction> ().Alert ("You must supply an Email Address and Password to sign up.");
					return isSuccess;
				} else {
					isSuccess = true;
					this.userService.SaveUser (this.EmailAddress, this.Password);
				}
			}
			return isSuccess;
		}

		public bool Login(){
			var isSuccess = false;
			if (!waitForResponse) {
				this.waitForResponse = true;
				var errorMessage = String.Empty;
				if (String.IsNullOrEmpty (this.EmailAddress) || String.IsNullOrWhiteSpace (this.EmailAddress) ||
				   String.IsNullOrEmpty (this.Password)) {
					Mvx.Resolve<IUserInteraction> ().Alert ("You must supply an Email Address and Password to Login.");
					return isSuccess;
				} else {
					isSuccess = true;
					this.userService.GetUser (this.EmailAddress, this.Password);
				}
			}
			return isSuccess;
		}

		public void IsVisible (bool isVisible)
		{
			if (!isVisible) {
				MessagingCenter.Unsubscribe<UserMessenger> (this, "Login");
			}
		}
    }
}

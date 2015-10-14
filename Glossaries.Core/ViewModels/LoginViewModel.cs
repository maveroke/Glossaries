using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;
using System.Collections.ObjectModel;
using Racing.Core.Services;
using Xamarin.Forms;
using Glossaries.Model;
using System;

namespace Glossaries.Core.ViewModels
{
	public class LoginViewModel 
		: MvxViewModel
	{
		private IUserService userService;

		public LoginViewModel(IUserService userService){
			this.userService = userService;
			MessagingCenter.Subscribe<UserMessenger>(this,"Login",(sender) => {
				if(sender.UserModel != null){
					ShowViewModel<MainViewModel>(new { userId = sender.UserModel.Id});
				}else{
					//Unsuccessful
				}
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

						this.userService.GetUser(this.EmailAddress,this.Password);
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

		public ErrorModel SignUp ()
		{
			var isError = false;
			var errorMessage = String.Empty;
			if (String.IsNullOrEmpty (this.EmailAddress) || String.IsNullOrWhiteSpace (this.EmailAddress) ||
				String.IsNullOrEmpty (this.Password)) {
				isError = true;
				errorMessage = "You must supply an Email Address and Password to sign up.";
			} else {
				this.userService.SaveUser(this.EmailAddress,this.Password);
			}
			return new ErrorModel (isError, errorMessage);
		}
    }
}

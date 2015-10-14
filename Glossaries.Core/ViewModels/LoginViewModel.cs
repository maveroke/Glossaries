using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;
using Racing.Core.Services;
using System;

namespace Glossaries.Core.ViewModels
{
    public class LoginViewModel 
		: MvxViewModel
    {
		private IParseService parseService;

		public LoginViewModel(IParseService parseService){
			this.parseService = parseService;
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
						this.parseService.ParseNewObject();
					});
				}
				return this.LoginCommand;
			}
		}

		private ICommand signUpCommand;

		public ICommand SignUpCommand {
			get {
				if (this.signUpCommand == null) {
					this.signUpCommand = new MvxCommand (() => {
						throw new Exception();
					});
				}
				return this.signUpCommand;
			}
		}
    }
}

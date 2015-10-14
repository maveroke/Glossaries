using NUnit.Framework;
using System;
using Glossaries.Core.ViewModels;
using Moq;
using Racing.Core.Services;
using Cirrious.MvvmCross.Test.Core;
using Glossaries.Model;
using System.Threading.Tasks;

namespace Glossaries.Test
{
	[TestFixture]
	public class LoginTest : MvxIoCSupportingTest
	{
		[Test]
		public void TestLoginEmptyFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			mockUserService.Setup (t => t.GetUser (It.IsAny<string> (), It.IsAny<string> ()))
				.ReturnsAsync (null);
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			var loggedIn = loginViewModel.Login ();
			Assert.IsFalse (loggedIn);
		}

		[Test]
		public void TestLoginFailCredentials ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			mockUserService.Setup (t => t.GetUser (It.IsAny<string> (), It.IsAny<string> ()))
				.ReturnsAsync (null);
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test@test.com";
			loginViewModel.Password = "wrongPassword";
			var loggedIn = loginViewModel.Login ();
			Assert.IsFalse (loggedIn);
		}

		[Test]
		public void TestLoginSuccessfulCredentials ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var user = new UserModel ();
			user.EmailAddress = "test@test.com";
			user.Password = "correctPassword";
			mockUserService.Setup (t => t.GetUser (It.IsAny<string> (), It.IsAny<string> ()))
				.ReturnsAsync (user);
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test@test.com";
			loginViewModel.Password = "correctPassword";
			var loggedIn = loginViewModel.Login ();
			Assert.IsTrue (loggedIn);
		}

		[Test]
		public void TestSignUpNoCredentials ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			mockUserService.Setup (t => t.GetUser (It.IsAny<string> (), It.IsAny<string> ()))
				.ReturnsAsync (null);
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			var signedUp = loginViewModel.SignUp ();
			Assert.IsTrue (signedUp.IsError);
			Assert.AreEqual ("You must supply an Email Address and Password to sign up.",signedUp.Message);
		}

		[Test]
		public void TestSignUpEmailAddressIsAlreadyBeingUsed ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var error = new ErrorModel (true,"Email Address is already being used.");
			mockUserService.Setup (t => t.SaveUser (It.IsAny<string> (), It.IsAny<string> ()))
				.ReturnsAsync (error);
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test@test.com";
			loginViewModel.Password = "correctPassword";
			var signedUp = loginViewModel.SignUp ();
			Assert.IsTrue (signedUp.IsError);
			Assert.AreEqual ("Email Address is already being used.",signedUp.Message);
		}

		[Test]
		public void TestSignUpSuccessfulCredentials ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var error = new ErrorModel (false,String.Empty);
			mockUserService.Setup (t => t.SaveUser (It.IsAny<string> (), It.IsAny<string> ()))
				.ReturnsAsync (error);
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test@test.com";
			loginViewModel.Password = "correctPassword";
			var signedUp = loginViewModel.SignUp ();
			Assert.IsFalse (signedUp.IsError);
			Assert.AreEqual ("",signedUp.Message);
		}
	}
}


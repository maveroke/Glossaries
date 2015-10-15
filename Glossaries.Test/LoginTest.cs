using NUnit.Framework;
using Cirrious.MvvmCross.Test.Core;
using Moq;
using Glossaries.Core.Interfaces;
using Glossaries.Core.ViewModels;


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
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			var loggedIn = loginViewModel.Login ();
			Assert.IsFalse (loggedIn);
		}		

		[Test]
		public void TestLoginFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test";
			loginViewModel.Password = "test";
			var loggedIn = loginViewModel.Login ();
			Assert.IsTrue (loggedIn);
		}


		[Test]
		public void TestLoginJustEmailFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test";
			var loggedIn = loginViewModel.Login ();
			Assert.IsFalse (loggedIn);
		}



		[Test]
		public void TestLoginJustPasswordFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.Password = "test";
			var loggedIn = loginViewModel.Login ();
			Assert.IsFalse (loggedIn);
		}

		[Test]
		public void TestSignUpEmptyFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			var loggedIn = loginViewModel.SignUp ();
			Assert.IsFalse (loggedIn);
		}		

		[Test]
		public void TestSignUpFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test";
			loginViewModel.Password = "test";
			var loggedIn = loginViewModel.SignUp ();
			Assert.IsTrue (loggedIn);
		}


		[Test]
		public void TestSignUpJustEmailFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.EmailAddress = "test";
			var loggedIn = loginViewModel.SignUp ();
			Assert.IsFalse (loggedIn);
		}



		[Test]
		public void TestSignUpJustPasswordFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IUserService> ();
			var loginViewModel = new LoginViewModel (mockUserService.Object);
			loginViewModel.Password = "test";
			var loggedIn = loginViewModel.SignUp ();
			Assert.IsFalse (loggedIn);
		}
	}
}


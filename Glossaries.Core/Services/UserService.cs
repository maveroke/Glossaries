using System.Threading.Tasks;
using Parse;
using Glossaries.Model;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Racing.Core.Services
{
	public class UserService : IUserService
	{
		public void GetUser (string emailAddress, string password)
		{
			GetUserTask (emailAddress, password);
		}

		public void SaveUser (string emailAddress, string password)
		{
			SaveUserTask(emailAddress,password);
		}

		private const string UserTable = "User";

		private async void GetUserTask (string emailAddress, string password)
		{
			var query = ParseObject.GetQuery (UserTable)
				.WhereEqualTo ("EmailAddress", emailAddress)
				.WhereEqualTo ("Password", password);
			IEnumerable<ParseObject> results = await query.FindAsync();

			if (results.FirstOrDefault () != null) {
				MessagingCenter.Send<UserMessenger> (new UserMessenger (new UserModel (results.FirstOrDefault ())), "Login");
			} else {
				MessagingCenter.Send<UserMessenger> (new UserMessenger (null), "Login");
			}
		}

		private async void SaveUserTask (string emailAddress, string password)
		{
			var user = new ParseObject (UserTable);
			user["EmailAddress"] = emailAddress;
			user["Password"] = password;
			await user.SaveAsync ();
			GetUserTask (emailAddress, password);
		}
	}
}
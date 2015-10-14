using System.Threading.Tasks;
using Parse;
using Glossaries.Model;
using System.Linq;
using System.Collections.Generic;

namespace Racing.Core.Services
{
	public class UserService : IUserService
	{
		private const string UserTable = "User";

		public async Task<UserModel> GetUser (string emailAddress, string password)
		{
			var query = ParseObject.GetQuery (UserTable)
				.WhereEqualTo ("EmailAddress", emailAddress)
				.WhereEqualTo ("Password", password);
			IEnumerable<ParseObject> results = await query.FindAsync();
			if(results.FirstOrDefault() != null){
				return new UserModel (results.FirstOrDefault());
			}
			return null;
		}

		public async Task<ErrorModel> SaveUser (string emailAddress, string password)
		{
			var user = new ParseObject (UserTable);
			user["EmailAddress"] = emailAddress;
			user["Password"] = password;
			await user.SaveAsync ();
			return null;
		}
	}
}
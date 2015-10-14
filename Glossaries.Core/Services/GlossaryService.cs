using System.Threading.Tasks;
using Parse;
using Glossaries.Model;
using System.Linq;
using System.Collections.Generic;

namespace Racing.Core.Services
{
	public class GlossaryService : IGlossaryService
	{
		private const string GlossaryTable = "User";

//		public async Task<UserModel> GetUser (UserModel userModel)
//		{
//			var query = ParseObject.GetQuery (UserTable)
//				.WhereEqualTo ("EmailAddress", userModel.EmailAddress)
//				.WhereEqualTo ("Password", userModel.Password);
//			IEnumerable<ParseObject> results = await query.FindAsync();
//			if(results.FirstOrDefault() != null){
//				return new UserModel (results.FirstOrDefault());
//			}
//			return null;
//		}
//
//		public async void SaveUser (UserModel userModel)
//		{
//			var user = new ParseObject (UserTable);
//			user["EmailAddress"] = userModel.EmailAddress;
//			user["Password"] = userModel.Password;
//			await user.SaveAsync ();
//		}

		public Task<UserModel> GetUserGlossaries (UserModel userModel)
		{
			throw new System.NotImplementedException ();
		}

		public void SaveGlossaries (UserModel userModel)
		{
			throw new System.NotImplementedException ();
		}

		public void DeleteGlossary (GlossaryModel glossaryModel)
		{
			throw new System.NotImplementedException ();
		}
	}
}
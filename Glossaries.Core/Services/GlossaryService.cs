using System.Threading.Tasks;
using Parse;
using Glossaries.Model;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Racing.Core.Services
{
	public class GlossaryService : IGlossaryService
	{
		private const string GlossaryTable = "Glossary";

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

		public void GetUserGlossaries (string userId)
		{
			GetGlossaries (userId);
		}

		public void DeleteGlossary (string id)
		{
			throw new System.NotImplementedException ();
		}

		public void SaveGlossary (string name, string description,string userId)
		{
			var glossary = new ParseObject (GlossaryTable);
			glossary["Name"] = name;
			glossary["Description"] = description;
			glossary ["UserId"] = userId;
			SaveGlossary (glossary);
		}

		public void DeleteGlossary (string name, string description,string userId)
		{
			var glossary = new ParseObject (GlossaryTable);
			glossary["Name"] = name;
			glossary["Description"] = description;
			glossary ["UserId"] = userId;
			DeleteGlossary (glossary);
		}

		private async void GetGlossaries(string userId){
			var query = ParseObject.GetQuery (GlossaryTable)
				.WhereEqualTo ("UserId", userId);
				IEnumerable<ParseObject> results = await query.FindAsync();
			if(results.Any()){
				var list = new List<GlossaryModel> ();
				foreach(var result in results){
					list.Add (new GlossaryModel (result));
				}
				MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (list), "Glossaries");
			} else {
				MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (null), "Glossaries");
			}
		}

		private async void SaveGlossary(ParseObject glossary){
			await glossary.SaveAsync ();
			MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (), "SaveGlossary");
		}

		private async void DeleteGlossary(ParseObject glossary){
			await glossary.DeleteAsync ();
			MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (), "DeleteGlossary");
		}
	}
}
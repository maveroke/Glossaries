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

		public void GetUserGlossaries (string userId)
		{
			GetGlossaries (userId);
		}

		public void GetUserGlossary (string id)
		{
			GetGlossary (id);
		}

		public void SaveUserGlossary (string id, string name, string description,string userId)
		{
//			var glossary = new ParseObject (GlossaryTable);
//			glossary["Name"] = name;
//			glossary["Description"] = description;
//			glossary ["UserId"] = userId;
			SaveGlossary (id,name,description,userId);
		}

		public void DeleteUserGlossary (string Id){
			DeleteGlossary (Id);
		}
//		public void DeleteGlossary (string name, string description,string userId)
//		{
//			var glossary = new ParseObject (GlossaryTable);
//			glossary["Name"] = name;
//			glossary["Description"] = description;
//			glossary ["UserId"] = userId;
//			DeleteGlossary (glossary);
//		}

		private async void GetGlossary(string id){
			var query = ParseObject.GetQuery (GlossaryTable)
				.WhereEqualTo ("objectId", id);
			IEnumerable<ParseObject> results = await query.FindAsync();
			if(results.Any()){
				MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (new GlossaryModel (results.FirstOrDefault())), "EditGlossary");
			} else {
				MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (), "EditGlossary");
			}
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
				MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (), "Glossaries");
			}
		}

		private async void SaveGlossary(string id, string name, string description,string userId){
			ParseObject glossaryParseObject = null;
			if (!string.IsNullOrEmpty (id)) {
				var query = ParseObject.GetQuery (GlossaryTable)
				.WhereEqualTo ("objectId", id);
				IEnumerable<ParseObject> results = await query.FindAsync ();
				if (results.Any ()) {
					if (results.FirstOrDefault () != null) {
						glossaryParseObject = results.FirstOrDefault ();
					}
				}
			}
			if (glossaryParseObject == null) {
				glossaryParseObject = new ParseObject (GlossaryTable);
			}

			glossaryParseObject ["Name"] = name;
			glossaryParseObject ["Description"] = description;
			glossaryParseObject ["UserId"] = userId;

			await glossaryParseObject.SaveAsync ();
			MessagingCenter.Send<GlossaryMessenger> (new GlossaryMessenger (), "SaveGlossary");
		}

		private async void DeleteGlossary(string Id){
			var query = ParseObject.GetQuery (GlossaryTable)
				.WhereEqualTo ("objectId", Id);
			IEnumerable<ParseObject> results = await query.FindAsync ();
			if (results.Any ()) {
				if (results.FirstOrDefault() != null) {
					var glossary = (ParseObject)results.FirstOrDefault();
					await (glossary).DeleteAsync ();
					GetGlossaries (glossary ["UserId"].ToString());
				}
			}
		}
	}
}
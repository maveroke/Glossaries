using System.Threading.Tasks;
using Parse;
using Glossaries.Model;
using System.Collections.Generic;

namespace Racing.Core.Services
{
	public interface IGlossaryService
	{
		Task<UserModel> GetUserGlossaries(UserModel userModel);

		void SaveGlossaries(UserModel userModel);

		void DeleteGlossary(GlossaryModel glossaryModel);
	}
}
using System.Threading.Tasks;
using Parse;
using Glossaries.Model;
using System.Collections.Generic;

namespace Glossaries.Core.Interfaces
{
	public interface IGlossaryService
	{
		void GetUserGlossary (string id);

		void GetUserGlossaries(string userId);

		void SaveUserGlossary(string Id, string name, string description,string userId);

		void DeleteUserGlossary(string userId);
	}
}
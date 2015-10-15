using System.Threading.Tasks;
using Parse;
using Glossaries.Model;

namespace Racing.Core.Services
{
	public interface IUserService
	{
		 void GetUser(string emailAddress, string password);

		 void SaveUser (string emailAddress, string password);
	}
}
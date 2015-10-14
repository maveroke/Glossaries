using System.Threading.Tasks;
using Parse;
using Glossaries.Model;

namespace Racing.Core.Services
{
	public interface IUserService
	{
		Task<UserModel> GetUser(string emailAddress, string password);

		Task<ErrorModel> SaveUser(string emailAddress, string password);
	}
}
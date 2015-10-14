using System.Threading.Tasks;
using Parse;

namespace Racing.Core.Services
{
	public class UserService : IUserService
	{

		public async void ParseNewObject ()
		{
			var testObject = new ParseObject ("TestObject");
			testObject ["foo"] = "bar";
			await testObject.SaveAsync ();
		}
	}
}
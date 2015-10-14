using System;
using System.Collections.Generic;
using Parse;

namespace Glossaries.Model
{
	public class UserModel
	{
		public string Id{ get; set; }
		public string EmailAddress{ get; set; }
		public string Password{ get; set; }
		public List<GlossaryModel> Glossaries{ get; set; }

		public UserModel(){}

		public UserModel(ParseObject user){
			this.Id = user.ObjectId;
			this.EmailAddress = user ["EmailAddress"].ToString();
			this.Password = user ["Password"].ToString();
		}
	}
}


using System;
using Parse;

namespace Glossaries.Model
{
	public class GlossaryModel
	{
		public string UserId{ get; private set; }
		public string Name{ get; set; }
		public string Description{ get; set; }


		public GlossaryModel(ParseObject user){
			this.UserId = user ["UserId"].ToString();
			this.Name = user ["Name"].ToString();
			this.Description = user ["Description"].ToString();
		}
	}
}


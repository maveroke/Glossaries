using System;

namespace Glossaries.Model
{
	public class GlossaryModel
	{
		public string UserId{ get; private set; }
		public string Name{ get; set; }
		public string Description{ get; set; }

		public GlossaryModel(string userId){
			this.UserId = userId;
		}
	}
}


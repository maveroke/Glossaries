using System;
using Parse;

namespace Glossaries.Model
{
	public class GlossaryModel
	{
		public string Id{ get; private set;}
		public string UserId{ get; private set; }
		public string Name{ get; set; }
		public string Description{ get; set; }


		public GlossaryModel(ParseObject glossary){
			this.Id = glossary.ObjectId;
			this.UserId = glossary ["UserId"].ToString();
			this.Name = glossary ["Name"].ToString();
			this.Description = glossary ["Description"].ToString();
		}
	}
}


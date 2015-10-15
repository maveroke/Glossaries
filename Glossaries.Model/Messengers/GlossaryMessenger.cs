using System;
using System.Collections.Generic;

namespace Glossaries.Model
{
	public class GlossaryMessenger
	{
		public List<GlossaryModel> GlossariesModel;
		public GlossaryModel EditGlossaryModel;

		public GlossaryMessenger(){

		}

		public GlossaryMessenger(List<GlossaryModel> glossariesModel){
			this.GlossariesModel = glossariesModel;
		}
		public GlossaryMessenger(GlossaryModel glossaryModel){
			this.EditGlossaryModel = glossaryModel;
		}
	}
}


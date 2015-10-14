using System;
using System.Collections.Generic;

namespace Glossaries.Model
{
	public class GlossaryMessenger
	{
		public List<GlossaryModel> GlossaryModel;

		public GlossaryMessenger(){

		}

		public GlossaryMessenger(List<GlossaryModel> glossaryModel){
			this.GlossaryModel = glossaryModel;
		}
	}
}


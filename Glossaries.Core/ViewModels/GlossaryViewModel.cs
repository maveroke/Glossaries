using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Racing.Core.Services;

namespace Glossaries.Core
{
	public class GlossaryViewModel : MvxViewModel
	{
		private IGlossaryService glossaryService;

		public GlossaryViewModel(IGlossaryService glossaryService){
			this.glossaryService = glossaryService;
		}

		private ICommand editGlossaryCommand;

		public ICommand EditGlossaryCommand {
			get {
				if (this.editGlossaryCommand == null) {
					this.editGlossaryCommand = new MvxCommand (() => {

					});
				}
				return this.editGlossaryCommand;
			}
		}
	}
}


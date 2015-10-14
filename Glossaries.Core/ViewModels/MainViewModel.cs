using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;
using System.Collections.ObjectModel;
using Racing.Core.Services;

namespace Glossaries.Core.ViewModels
{
	public class MainViewModel 
		: MvxViewModel
	{
		private IGlossaryService glossaryService;

		public MainViewModel(IGlossaryService glossaryService){
			this.glossaryService = glossaryService;
		}

		private ObservableCollection<GlossaryViewModel> glossaries;
		public ObservableCollection<GlossaryViewModel> Glossaries {
			get {
				if (glossaries == null) {
					glossaries = new ObservableCollection<GlossaryViewModel> ();
				}
				return glossaries;
			}
		}

		private ICommand addGlossaryCommand;

		public ICommand AddGlossaryCommand {
			get {
				if (this.addGlossaryCommand == null) {
					this.addGlossaryCommand = new MvxCommand (() => {
						ShowViewModel<GlossaryViewModel>();
					});
				}
				return this.addGlossaryCommand;
			}
		}

		private ICommand deleteGlossaryCommand;

		public ICommand DeleteGlossaryCommand {
			get {
				if (this.deleteGlossaryCommand == null) {
					this.deleteGlossaryCommand = new MvxCommand (() => {

					});
				}
				return this.deleteGlossaryCommand;
			}
		}
    }
}

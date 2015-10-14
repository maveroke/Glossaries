using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;
using System.Collections.ObjectModel;
using Racing.Core.Services;
using Xamarin.Forms;
using Glossaries.Model;
using Cirrious.CrossCore;

namespace Glossaries.Core.ViewModels
{
	public class MainViewModel 
		: MvxViewModel
	{
		private string userId;

		private IGlossaryService glossaryService;

		public MainViewModel(IGlossaryService glossaryService){
			this.glossaryService = glossaryService;
			MessagingCenter.Subscribe<GlossaryMessenger>(this,"Glossaries",(sender) => {
				if(sender.GlossaryModel != null){
					this.Glossaries.Clear();
					foreach(var glossary in sender.GlossaryModel){
						var glossaryViewModel = new GlossaryViewModel(glossary);
						this.Glossaries.Add(glossaryViewModel);
					}
				}
			});
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

		private ICommand addGlossaryCommand;

		public ICommand AddGlossaryCommand {
			get {
				if (this.addGlossaryCommand == null) {
					this.addGlossaryCommand = new MvxCommand (() => {
						ShowViewModel<GlossaryViewModel>(new { userId = this.userId});
					});
				}
				return this.addGlossaryCommand;
			}
		}
		public void Init (string userId)
		{
			if (!string.IsNullOrEmpty (userId)) {
				this.userId = userId;
				this.glossaryService.GetUserGlossaries (userId);
			}
		}
    }
}

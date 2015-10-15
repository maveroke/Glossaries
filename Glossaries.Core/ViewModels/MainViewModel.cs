using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;
using System.Collections.ObjectModel;
using Racing.Core.Services;
using Xamarin.Forms;
using Glossaries.Model;
using Cirrious.CrossCore;
using System.Collections.Generic;

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
				if(sender.GlossariesModel != null){
					this.Glossaries.Clear();
					foreach(var glossary in sender.GlossariesModel){
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

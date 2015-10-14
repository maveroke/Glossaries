using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Racing.Core.Services;
using Xamarin.Forms;
using Glossaries.Model;

namespace Glossaries.Core.ViewModels
{
	public class GlossaryViewModel : MvxViewModel
	{
		private IGlossaryService glossaryService;

		public GlossaryViewModel(IGlossaryService glossaryService){
			this.glossaryService = glossaryService;
			MessagingCenter.Subscribe<GlossaryMessenger>(this,"SaveGlossary",(sender) => {
				ShowViewModel<MainViewModel>(new { userId = this.userId});
			});
		}

		public GlossaryViewModel (GlossaryModel glossary)
		{
			UpdateViewModel (glossary);
		}

		private ICommand addGlossaryCommand;

		public ICommand AddGlossaryCommand {
			get {
				if (this.addGlossaryCommand == null) {
					this.addGlossaryCommand = new MvxCommand (() => {
						if(!SaveGlossary()){
							//Description over Max Size
						}
					});
				}
				return this.addGlossaryCommand;
			}
		}
		private string userId;

		private string name;
		public string Name
		{ 
			get { return this.name; }
			set { this.name = value; RaisePropertyChanged(() => Name); }
		}

		private string description;
		public string Description
		{ 
			get { return this.description; }
			set { this.description = value; RaisePropertyChanged(() => Description); }
		}

		public bool SaveGlossary ()
		{
			if(this.Description.Length <= 500){
				this.glossaryService.SaveGlossary(this.Name,this.Description,this.userId);
				return true;
			}
			return false;
		}

		public void Init (string userId)
		{
			if (!string.IsNullOrEmpty (userId)) {
				this.userId = userId;
			}
		}

		public void UpdateViewModel (GlossaryModel glossary)
		{
			this.userId = glossary.UserId;
			this.Name = glossary.Name;
			this.Description = glossary.Description;
		}
	}
}


using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Racing.Core.Services;
using Xamarin.Forms;
using Glossaries.Model;
using Glossaries.Core.Interfaces;
using Cirrious.CrossCore;
using Chance.MvvmCross.Plugins.UserInteraction;

namespace Glossaries.Core.ViewModels
{
	public class GlossaryViewModel : MvxViewModel,IVisible
	{
		private IGlossaryService glossaryService;
		private bool waitForResponse;
		public GlossaryViewModel(IGlossaryService glossaryService){
			this.glossaryService = glossaryService;
			MessagingCenter.Subscribe<GlossaryMessenger>(this,"SaveGlossary",(sender) => {
				ShowViewModel<MainViewModel>(new { userId = this.userId});
				waitForResponse = false;
			});
			MessagingCenter.Subscribe<GlossaryMessenger>(this,"EditGlossary",(sender) => {
				if(sender.EditGlossaryModel != null){
					UpdateViewModel(sender.EditGlossaryModel);
					waitForResponse = false;
				}
			});
		}

		public GlossaryViewModel (GlossaryModel glossary)
		{
			this.glossaryService = new GlossaryService ();
			UpdateViewModel (glossary);
		}

		private ICommand addGlossaryCommand;

		public ICommand AddGlossaryCommand {
			get {
				if (this.addGlossaryCommand == null) {
					this.addGlossaryCommand = new MvxCommand (() => {
						if(this.Name == null || this.Description == null){
							Mvx.Resolve<IUserInteraction>().Alert("You need a Glossary and Description to save");
						}else if(!SaveGlossary()){
							Mvx.Resolve<IUserInteraction>().Alert("Description must not exceed 500 characters");
						}
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
					if(!waitForResponse){
							waitForResponse = true;
							this.glossaryService.DeleteUserGlossary(this.Id);
						}
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
						ShowViewModel<GlossaryViewModel>(new { Id = this.Id});
					});
				}
				return this.editGlossaryCommand;
			}
		}

		private string userId;

		private string Id;

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
			if (this.Name != null && this.Description != null && this.Description.Length <= 500) {
				this.glossaryService.SaveUserGlossary (this.Id, this.Name, this.Description, this.userId);
				return true;
			}
			return false;
		}

		public void Init (string Id, string userId)
		{
			if (!string.IsNullOrEmpty (Id)) {
				this.glossaryService.GetUserGlossary (Id);
			}
			if (!string.IsNullOrEmpty (userId)) {
				this.userId = userId;
			}
		}

		public void UpdateViewModel (GlossaryModel glossary)
		{
			this.Id = glossary.Id;
			this.userId = glossary.UserId;
			this.Name = glossary.Name;
			this.Description = glossary.Description;
		}

		public void IsVisible (bool isVisible)
		{
			if (!isVisible) {
				MessagingCenter.Unsubscribe<GlossaryMessenger> (this, "SaveGlossary");
				MessagingCenter.Unsubscribe<GlossaryMessenger> (this, "EditGlossary");
			}
		}
	}
}


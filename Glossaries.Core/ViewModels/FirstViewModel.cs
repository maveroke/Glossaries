using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using Parse;

namespace Glossaries.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

		private ICommand parseCommand;

		public ICommand ParseCommand {
			get {
				if (this.parseCommand == null) {
					this.parseCommand = new MvxCommand (() => {
						ParseObject();
					});
				}
				return this.parseCommand;
			}
		}
		public async void ParseObject(){

			var testObject = new ParseObject ("TestObject");
			testObject ["foo"] = "bar";
			await testObject.SaveAsync ();
		}
    }
}

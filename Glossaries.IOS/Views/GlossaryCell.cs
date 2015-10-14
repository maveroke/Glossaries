
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Glossaries.Core.ViewModels;

namespace Glossaries.IOS
{
	public partial class GlossaryCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("GlossaryCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("GlossaryCell");

		public GlossaryCell (IntPtr handle) : base (handle)
		{
			this.DelayBind(() => {
				var set = this.CreateBindingSet<GlossaryCell,GlossaryViewModel>();
				set.Bind(NameLabel).To(glossary => glossary.Name);
				set.Bind(DeleteButton).To(glossary=>glossary.DeleteGlossaryCommand);
				set.Apply();
			});
		}

		public static GlossaryCell Create ()
		{
			return (GlossaryCell)Nib.Instantiate (null, null) [0];
		}
	}
}


using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using UIKit;

namespace Glossaries.IOS
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
		protected override void AddPluginsLoaders (Cirrious.CrossCore.Plugins.MvxLoaderPluginRegistry loaders)
		{
			loaders.AddConventionalPlugin<Chance.MvvmCross.Plugins.UserInteraction.Touch.Plugin>();

			base.AddPluginsLoaders (loaders);
		}
	}
}
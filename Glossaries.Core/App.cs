using Cirrious.CrossCore.IoC;
using Parse;

namespace Glossaries.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
		{
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
			
			ParseClient.Initialize("5EOhYzjPF95M3i37VCS4k2GLPy012pvSRB7C8uof",
				"kUHCPj4tYITMqUEiOsYu8KiGkItNuNm16rctlyWr");
			
			RegisterAppStart<ViewModels.LoginViewModel>();
        }
    }
}
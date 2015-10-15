using NUnit.Framework;
using Cirrious.MvvmCross.Test.Core;
using Moq;
using Glossaries.Core.Interfaces;
using Glossaries.Core.ViewModels;


namespace Glossaries.Test
{
	[TestFixture]
	public class GlossaryTest : MvxIoCSupportingTest
	{
		[Test]
		public void TestSaveGlossaryEmptyFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IGlossaryService> ();
			var glossaryViewModel = new  GlossaryViewModel(mockUserService.Object);
			var saveGlossary = glossaryViewModel.SaveGlossary ();
			Assert.IsFalse (saveGlossary);
		}

		[Test]
		public void TestSaveGlossaryNameWithNoDescriptionFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IGlossaryService> ();
			var glossaryViewModel = new  GlossaryViewModel(mockUserService.Object);
			glossaryViewModel.Name = "test";
			var saveGlossary = glossaryViewModel.SaveGlossary ();
			Assert.IsFalse (saveGlossary);
		}

		[Test]
		public void TestSaveGlossaryDescriptionWithNoNameFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IGlossaryService> ();
			var glossaryViewModel = new  GlossaryViewModel(mockUserService.Object);
			glossaryViewModel.Description = "test";
			var saveGlossary = glossaryViewModel.SaveGlossary ();
			Assert.IsFalse (saveGlossary);
		}
		[Test]
		public void TestSaveGlossaryFilledFields ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IGlossaryService> ();
			var glossaryViewModel = new  GlossaryViewModel(mockUserService.Object);
			glossaryViewModel.Name = "test";
			glossaryViewModel.Description = "test";
			var saveGlossary = glossaryViewModel.SaveGlossary ();
			Assert.IsTrue (saveGlossary);
		}

		[Test]
		public void TestGlossaryFilledFieldsDescriptionOver500 ()
		{
			base.ClearAll ();
			var mockUserService = new Mock<IGlossaryService> ();
			var glossaryViewModel = new  GlossaryViewModel(mockUserService.Object);
			glossaryViewModel.Name = "test";
			var str = string.Empty;
			for (int i = 0; i < 501; i++) {
				str += "V";
			}
			glossaryViewModel.Description = str;
			var saveGlossary = glossaryViewModel.SaveGlossary ();
			Assert.IsFalse (saveGlossary);
		}
	}
}


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Regions;
using Prism.Services.Dialogs;
using SPRAK_App.ViewModels;

namespace SPRAKTest.Tests.Tests
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockIDialogService = new Mock<IDialogService>();
            var mockIRegionManager = new Mock<IRegionManager>();
            var viewModel = new MainWindowViewModel(mockIRegionManager.Object, mockIDialogService.Object);

            mockIDialogService.Setup(x => x.ShowDialog(
                It.IsAny<string>(),
                It.IsAny<IDialogParameters>(),
                It.IsAny<Action<IDialogResult>>()
                )).Callback<
                    string,
                    IDialogParameters,
                    Action<IDialogResult>>
                    ((viewName, p, result) =>
                    {
                        Assert.AreEqual("ListSaveView", viewName);
                    });
            viewModel.ListSaveButton.Execute();
        }
    }

}

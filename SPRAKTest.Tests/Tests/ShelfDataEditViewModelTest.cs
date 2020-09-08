using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Services.Dialogs;
using SPRAK.Domain.Repositories;
using SPRAK.Domain.Services;
using SPRAK_App.ViewModels;

namespace SPRAKTest.Tests.Tests
{
    [TestClass]
    public class ShelfDataEditViewModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var shelfBoxRepository = new Mock<IShelfBoxRepository>();
            var messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.Question("更新しますか？")).Returns(System.Windows.MessageBoxResult.OK);
            var viewModel = new ShelfDataEditViewModel(messageService.Object, shelfBoxRepository.Object);

            messageService.Setup(x => x.ShowDialog(
                It.IsAny<string>()
                )).Callback<string>
                (message =>
                {
                    Assert.AreEqual("更新しました。", message);
                });

            viewModel.UpdateButton.Execute();
            messageService.VerifyAll();

        }
    }
}

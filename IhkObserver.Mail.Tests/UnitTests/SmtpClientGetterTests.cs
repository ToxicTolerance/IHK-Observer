using IhkObserver.Mail.Classes;
using IhkObserver.Mail.Exceptions;
using IhkObserver.Text.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IhkObserver.Mail.Tests.UnitTests
{
    [TestClass]
    public class SmtpClientGetterTests
    {
        [TestMethod]
        public async Task InitializeSmtpClientAsync_ConnectFailed()
        {
            MockStorage storage = new MockStorage();

            Exception originalEx = new Exception();
            storage.SmtpClientMock.Setup(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(originalEx);

            SmtpNotConnectedException ex =
                await Assert.ThrowsExceptionAsync<SmtpNotConnectedException>(async () =>
                    await storage.Create().InitializeSmtpClientAsync(storage.SmtpConfigMock.Object));
            Assert.AreSame(originalEx, ex.InnerException);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task InitializeSmtpClientAsync_AuthenticateFailed()
        {
            MockStorage storage = new MockStorage();

            Exception originalEx = new Exception();
            storage.SmtpClientMock.Setup(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(originalEx);

            SmtpNotAuthenticatedException ex =
                await Assert.ThrowsExceptionAsync<SmtpNotAuthenticatedException>(async () =>
                    await storage.Create().InitializeSmtpClientAsync(storage.SmtpConfigMock.Object));
            Assert.AreSame(originalEx, ex.InnerException);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.Verify(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task InitializeSmtpClientAsync_Successful()
        {
            MockStorage storage = new MockStorage();

            SmtpClientGetter getter = storage.Create();
            await getter.InitializeSmtpClientAsync(storage.SmtpConfigMock.Object);

            Assert.AreSame(getter.Smtp, storage.SmtpClientMock.Object);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.Verify(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Dispose_NotConnected()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(false);

            SmtpClientGetter smtpGetter = storage.Create();
            Assert.IsNotNull(smtpGetter.Smtp);

            smtpGetter.Dispose();
            Assert.IsNull(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Dispose_Connected_ConnectionDisposed()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

            storage.SmtpClientMock.Setup(a => a.Disconnect(true, It.IsAny<CancellationToken>()))
                .Throws(new ObjectDisposedException(nameof(storage.SmtpClientMock.Object)));

            SmtpClientGetter smtpGetter = storage.Create();
            Assert.IsNotNull(smtpGetter.Smtp);

            smtpGetter.Dispose();
            Assert.IsNull(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.Verify(a => a.Disconnect(true, It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Dispose_Connected_Successful()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

            SmtpClientGetter smtpGetter = storage.Create();
            Assert.IsNotNull(smtpGetter.Smtp);

            smtpGetter.Dispose();
            Assert.IsNull(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.Verify(a => a.Disconnect(true, It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        private class MockStorage
        {
            public MockStorage()
            {
                SmtpClientMock = new Mock<ISmtpClient>();
                SmtpConfigMock = new Mock<ISmtpConfig>();
            }

            public SmtpClientGetter Create()
            {
                return new SmtpClientGetter(SmtpClientMock.Object);
            }

            public void SetupConfigMock()
            {
                SmtpConfigMock.SetupGet(a => a.Host).Returns("smtp.host.com");
                SmtpConfigMock.SetupGet(a => a.Port).Returns(-1337);
                SmtpConfigMock.SetupGet(a => a.Mail).Returns("user@example.com");
                SmtpConfigMock.SetupGet(a => a.SenderPassword).Returns("My super secret mega password!");
            }

            public Mock<ISmtpClient> SmtpClientMock { get; set; }
            public Mock<ISmtpConfig> SmtpConfigMock { get; set; }
        }
    }
}
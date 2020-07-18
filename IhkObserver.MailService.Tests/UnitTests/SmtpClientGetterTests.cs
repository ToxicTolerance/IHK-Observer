using IhkObserver.MailService.Classes;
using IhkObserver.MailService.Exceptions;
using IhkObserver.MailService.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IhkObserver.MailService.Tests.UnitTests
{
    public class SmtpClientGetterTests
    {
        [Fact]
        public async Task InitializeSmtpClientAsync_ConnectFailed()
        {
            MockStorage storage = new MockStorage();

            Exception originalEx = new Exception();
            storage.SmtpClientMock.Setup(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(originalEx);

            SmtpNotConnectedException ex =
                await Assert.ThrowsAsync<SmtpNotConnectedException>(async () =>
                    await storage.Create().InitializeSmtpClientAsync(storage.MailConfigMock.Object));
            Assert.Same(originalEx, ex.InnerException);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task InitializeSmtpClientAsync_AuthenticateFailed()
        {
            MockStorage storage = new MockStorage();

            Exception originalEx = new Exception();
            storage.SmtpClientMock.Setup(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(originalEx);

            SmtpNotAuthenticatedException ex =
                await Assert.ThrowsAsync<SmtpNotAuthenticatedException>(async () =>
                    await storage.Create().InitializeSmtpClientAsync(storage.MailConfigMock.Object));
            Assert.Same(originalEx, ex.InnerException);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.Verify(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task InitializeSmtpClientAsync_Successful() 
        {
            MockStorage storage = new MockStorage();

            SmtpClientGetter getter = storage.Create();
            await getter.InitializeSmtpClientAsync(storage.MailConfigMock.Object);

            Assert.Same(getter.Smtp, storage.SmtpClientMock.Object);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.Verify(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisposeAsync_NotConnected()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(false);

            SmtpClientGetter smtpGetter = storage.Create();
            Assert.NotNull(smtpGetter.Smtp);

            await smtpGetter.DisposeAsync();
            Assert.Null(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisposeAsync_Connected_ConnectionDisposed()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

            storage.SmtpClientMock.Setup(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ObjectDisposedException(nameof(storage.SmtpClientMock.Object)));

            SmtpClientGetter smtpGetter = storage.Create();
            Assert.NotNull(smtpGetter.Smtp);

            await smtpGetter.DisposeAsync();
            Assert.Null(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.Verify(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisposeAsync_Connected_Successful()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

            SmtpClientGetter smtpGetter = storage.Create();
            Assert.NotNull(smtpGetter.Smtp);

            await smtpGetter.DisposeAsync();
            Assert.Null(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.Verify(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        private class MockStorage
        {
            public MockStorage()
            {
                SmtpClientMock = new Mock<ISmtpClient>();
                
                MailConfigMock = new Mock<IMailConfig>();
                SmtpConfigMock = new Mock<ISmtpConfig>();
             
                MailConfigMock.SetupGet(a => a.SmtpSetting).Returns(SmtpConfigMock.Object);
            }

            public SmtpClientGetter Create()
            {
                return new SmtpClientGetter(SmtpClientMock.Object);
            }

            public void SetupConfigMock()
            {
                MailConfigMock.SetupGet(a => a.SendFrom).Returns("user@example.com");

                SmtpConfigMock.SetupGet(a => a.Host).Returns("smtp.host.com");
                SmtpConfigMock.SetupGet(a => a.Port).Returns(-1337);
                SmtpConfigMock.SetupGet(a => a.SenderPassword).Returns("My super secret mega password!");
            }

            public Mock<ISmtpClient> SmtpClientMock { get; set; }
            public Mock<IMailConfig> MailConfigMock { get; set; }
            public Mock<ISmtpConfig> SmtpConfigMock { get; set; }
        }
    }
}